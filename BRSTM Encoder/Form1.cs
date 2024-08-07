﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading;
using NAudio.Wave;

namespace NMFME
{
    public partial class Form1 : Form
    {
        public VGAudio.Containers.AudioWithConfig Audio;
        public object OutType = VGAudio.Containers.NintendoWare.NwTarget.Revolution;

        string Filter = "BRSTM Files (*.brstm)|*.brstm|All files (*.*)|*.*";
        string FileName = "";
        string TempFileName = Path.Combine(Program.ExecPath, "temp.wav");
        string TempVolFileName = Path.Combine(Program.ExecPath, "tempVol.wav");

        public Form1()
        {
            InitializeComponent();
            Label_Status.Text = "Waiting for file...";
            ComboOutType.SelectedIndex = 0;
        }

        private void Button_Open_Click(object sender, EventArgs e)
        {
            OpenFileDialog Dialog = new OpenFileDialog();
            Dialog.Filter = "All Supported (*.wav, *.brstm,*.bcstm,*.bfstm, *.bwav)|*.wav;*.brstm;*.bcstm;*.bfstm;*.bwav|WAV Files (*.wav)|*.wav|Nintendo Ware Sound Files (*.brstm,*.bcstm,*.bfstm)|*.brstm;*.bcstm;*.bfstm|BWAV (*.bwav)|*.bwav|All files (*.*)|*.*";
            Dialog.ShowDialog();

            if (Dialog.FileName == "")
                return;
            else
            {
                try
                {
                    FileName = Dialog.FileName;
                    LoadFile(Dialog.FileName);

                    Label_SampleRate.Text = "Sample rate: " + Audio.AudioFormat.SampleRate.ToString();
                    Label_Channels.Text = "Channels detected: " + Audio.AudioFormat.ChannelCount.ToString();
                    Label_NumSamples.Text = "Number of samples: " + Audio.AudioFormat.SampleCount.ToString();


                    Label_Status.Text = "Ready...";
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        public void LoadFile(string fln, bool setLoops = true)
        {
            byte[] OpenedWAVFile = File.ReadAllBytes(fln);
            FileName = fln;

            switch (Path.GetExtension(fln))
            {
                case ".brstm":
                    {
                        VGAudio.Containers.NintendoWare.BrstmReader reader = new VGAudio.Containers.NintendoWare.BrstmReader();
                        Audio = reader.ReadWithConfig(OpenedWAVFile);

                        if (setLoops)
                        {
                            NumUpDown_LoopStart.Maximum = Audio.AudioFormat.SampleCount;
                            NumUpDown_LoopEnd.Maximum = Audio.AudioFormat.SampleCount;
                            NumUpDown_LoopStart.Value = Audio.AudioFormat.LoopStart;
                            NumUpDown_LoopEnd.Value = Audio.AudioFormat.LoopEnd;
                        }

                        break;
                    }
                case ".bfstm":
                    {
                        VGAudio.Containers.NintendoWare.BCFstmReader reader = new VGAudio.Containers.NintendoWare.BCFstmReader();
                        Audio = reader.ReadWithConfig(OpenedWAVFile);

                        if (setLoops)
                        {
                            NumUpDown_LoopStart.Maximum = Audio.AudioFormat.SampleCount;
                            NumUpDown_LoopEnd.Maximum = Audio.AudioFormat.SampleCount;
                            NumUpDown_LoopStart.Value = Audio.AudioFormat.LoopStart;
                            NumUpDown_LoopEnd.Value = Audio.AudioFormat.LoopEnd;
                        }

                        break;
                    }
                case ".bwav":
                    {
                        bool Loop = false;
                        int LoopSt = 0;
                        int LoopEn = 0;

                        OpenRevolution.BWAV2WAV(fln, TempFileName, out Loop, out LoopSt, out LoopEn);
                        fln = TempFileName;
                        OpenedWAVFile = File.ReadAllBytes(TempFileName);
                        VGAudio.Containers.Wave.WaveReader Reader = new VGAudio.Containers.Wave.WaveReader();
                        Audio = Reader.ReadWithConfig(OpenedWAVFile);

                        if (setLoops)
                        {
                            NumUpDown_LoopStart.Maximum = Audio.AudioFormat.SampleCount;
                            NumUpDown_LoopEnd.Maximum = Audio.AudioFormat.SampleCount;
                            NumUpDown_LoopStart.Value = LoopSt;
                            NumUpDown_LoopEnd.Value = LoopEn;
                        }

                        return;
                    }
                default:
                    {
                        VGAudio.Containers.Wave.WaveReader Reader = new VGAudio.Containers.Wave.WaveReader();
                        Audio = Reader.ReadWithConfig(OpenedWAVFile);

                        if (setLoops)
                        {
                            NumUpDown_LoopStart.Maximum = Audio.AudioFormat.SampleCount;
                            NumUpDown_LoopEnd.Maximum = Audio.AudioFormat.SampleCount;
                            NumUpDown_LoopStart.Value = Audio.AudioFormat.LoopStart;
                            NumUpDown_LoopEnd.Value = Audio.AudioFormat.SampleCount;
                        }

                        break;
                    }
            }
        }

        public void ChangeVolume(string wavFilePath, float Volume)
        {
            var wave = new NAudio.Wave.WaveFileReader(wavFilePath);

            float[] samples = new float[wave.SampleCount * Audio.AudioFormat.ChannelCount];
            var a = wave.ReadNextSampleFrame();
            int i = 0;
            while (a != null)
            {
                for (int j = 0; j < Audio.AudioFormat.ChannelCount; j++)
                {
                    samples[i] = a[j] * Volume;
                    i++;
                }
                a = wave.ReadNextSampleFrame();
            }


            //create the new .wav with the samples modified
            WaveFormat waveFormat = new WaveFormat(Audio.AudioFormat.SampleRate, 16, Audio.AudioFormat.ChannelCount);
   
            wave.Dispose();

            if (File.Exists(wavFilePath))
                File.Delete(wavFilePath);

            WaveFileWriter writer = new WaveFileWriter(wavFilePath, waveFormat);
            for (int u = 0; u < i; u++)
            {
                writer.WriteSample(samples[u]);
            }
            writer.Dispose();
            
            // Stop BWAV converter from having an aneurysm (fmt must be 16 for it to accept the wav)
            if ((OutType as string) == "BWAV")
            {
                byte[] sigh = File.ReadAllBytes(wavFilePath);
                sigh[0x10] = 16;
                File.WriteAllBytes(wavFilePath, sigh);
            }
        }

        public void Convert(float Volume, int LoopSt, int LoopEn, bool Loop, string Out)
        {
            if (File.Exists(Out))
                File.Delete(Out);


            if (Volume != 1.0f)
            {
                if (File.Exists(TempVolFileName))
                    File.Delete(TempVolFileName);

                FileStream Stream = new FileStream(TempVolFileName, FileMode.CreateNew);

                VGAudio.Containers.Wave.WaveWriter wv = new VGAudio.Containers.Wave.WaveWriter();
                wv.WriteToStream(Audio.Audio, Stream, Audio.Configuration);

                Stream.Close();

                ChangeVolume(TempVolFileName, Volume);

                if ((OutType as string) != "BWAV")
                    LoadFile(TempVolFileName, false);

                FileName = TempVolFileName;
            }

            if (OutType is VGAudio.Containers.NintendoWare.NwTarget)
            {
                FileStream Stream = new FileStream(Out, FileMode.CreateNew);

                VGAudio.Containers.NintendoWare.NwTarget NwTargetOutType = (VGAudio.Containers.NintendoWare.NwTarget)OutType;

                if (NwTargetOutType == VGAudio.Containers.NintendoWare.NwTarget.Revolution)
                {
                    VGAudio.Containers.NintendoWare.BrstmWriter brWriter = new VGAudio.Containers.NintendoWare.BrstmWriter();
                    brWriter.Configuration.Version = new VGAudio.Containers.NintendoWare.NwVersion((byte)VerA.Value, (byte)VerB.Value, (byte)VerC.Value, (byte)VerD.Value);
                    brWriter.WriteToStream(Audio.AudioFormat.WithLoop(Loop, LoopSt, LoopEn == 0 ? Audio.AudioFormat.SampleCount : LoopEn), Stream, Audio.Configuration);
                }
                else
                {
                    VGAudio.Containers.NintendoWare.BCFstmWriter fcWriter = new VGAudio.Containers.NintendoWare.BCFstmWriter(NwTargetOutType);
                    fcWriter.Configuration.Version = new VGAudio.Containers.NintendoWare.NwVersion((byte)VerA.Value, (byte)VerB.Value, (byte)VerC.Value, (byte)VerD.Value);
                    fcWriter.WriteToStream(Audio.AudioFormat.WithLoop(Loop, LoopSt, LoopEn == 0 ? Audio.AudioFormat.SampleCount : LoopEn), Stream, Audio.Configuration);
                }

                Stream.Close();
            }
            else if ((OutType as string) == "BWAV") 
            {
                OpenRevolution.WAV2BWAV(FileName, Out, Loop, LoopSt, LoopEn);
            }
            else
            {
                FileStream Stream = new FileStream(Out, FileMode.CreateNew);

                VGAudio.Containers.Wave.WaveWriter wv = new VGAudio.Containers.Wave.WaveWriter();
                wv.WriteToStream(Audio.Audio, Stream, Audio.Configuration);

                Stream.Close();
            }


            if (File.Exists(TempVolFileName))
                File.Delete(TempVolFileName);
        }

        private void Button_Save_Click(object sender, EventArgs e)
        {
            try
            {
                if (NumUpDown_LoopStart.Value >= NumUpDown_LoopEnd.Value && NumUpDown_LoopEnd.Value != 0)
                {
                    MessageBox.Show("Loop end must be bigger than loop start.");
                    return;
                }

                SaveFileDialog Dialog = new SaveFileDialog();
                Dialog.Filter = Filter;
                Dialog.ShowDialog();

                if (Dialog.FileName == "")
                    return;

                Label_Status.Text = "Saving...";
                Label_Status.Update();

                if (CheckBox_IsLooped.Checked && (int)NumUpDown_LoopStart.Value > (int)NumUpDown_LoopEnd.Value)
                {
                    MessageBox.Show("Loop start cannot be smaller than the loop end");
                    return;
                }

                Convert((float)NumUp_Volume.Value, (int)NumUpDown_LoopStart.Value, (int)NumUpDown_LoopEnd.Value, CheckBox_IsLooped.Checked, Dialog.FileName);

                Label_Status.Text = "Done!";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (ComboOutType.SelectedIndex)
            {
                case 0:
                    {
                        Filter = "BRSTM Files (*.brstm)|*.brstm|All files (*.*)|*.*";
                        OutType = VGAudio.Containers.NintendoWare.NwTarget.Revolution;
                        break;
                    }
                case 1:
                    {
                        Filter = "BCSTM Files (*.bcstm)|*.bcstm|All files (*.*)|*.*";
                        OutType = VGAudio.Containers.NintendoWare.NwTarget.Ctr; 
                        break;
                    }
                case 2:
                    {
                        Filter = "BFSTM Files (*.bfstm)|*.bfstm|All files (*.*)|*.*";
                        OutType = VGAudio.Containers.NintendoWare.NwTarget.Cafe;
                        break;
                    }
                case 3:
                    {
                        Filter = "BWAV Files (*.bwav)|*.bwav|All files (*.*)|*.*";
                        OutType = "BWAV";
                        break;
                    }
                case 4:
                    {
                        Filter = "WAV Files (*.wav)|*.wav|All files (*.*)|*.*";
                        OutType = "WAV";
                        break;
                    }
            }

            return;
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
