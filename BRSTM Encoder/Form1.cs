using System;
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

namespace BRSTM_Encoder
{
    public partial class Form1 : Form
    {
        VGAudio.Containers.AudioWithConfig Audio;
        VGAudio.Containers.NintendoWare.NwTarget OutType = VGAudio.Containers.NintendoWare.NwTarget.Revolution;

        string Filter = "BRSTM Files (*.brstm)|*.brstm|All files (*.*)|*.*";

        public Form1()
        {
            InitializeComponent();
            Label_Status.Text = "Waiting for file...";
            ComboOutType.SelectedIndex = 0;
        }

        private void Button_Open_Click(object sender, EventArgs e)
        {
            OpenFileDialog Dialog = new OpenFileDialog();
            Dialog.Filter = "WAV Files (*.wav)|*.wav|All files (*.*)|*.*";
            Dialog.ShowDialog();

            if (Dialog.FileName == "")
                return;
            else
            {
                try
                {
                    LoadFile(Dialog.FileName);

                    Label_Bitrate.Text = "Bitrate: " + Audio.AudioFormat.SampleRate.ToString();
                    Label_Channels.Text = "Channels detected: " + Audio.AudioFormat.ChannelCount.ToString();
                    Label_NumSamples.Text = "Number of samples: " + Audio.AudioFormat.SampleCount.ToString();

                    NumUpDown_LoopStart.Value = 0;
                    NumUpDown_LoopEnd.Value = 0;
                    NumUpDown_LoopStart.Maximum = Audio.AudioFormat.SampleCount;
                    NumUpDown_LoopEnd.Maximum = Audio.AudioFormat.SampleCount;

                    Label_Status.Text = "Ready...";
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        public void LoadFile(string FileName)
        {
            byte[] OpenedWAVFile = File.ReadAllBytes(FileName);

            VGAudio.Containers.Wave.WaveReader Reader = new VGAudio.Containers.Wave.WaveReader();
            Audio = Reader.ReadWithConfig(OpenedWAVFile);
        }

        public void Convert(int LoopSt, int LoopEn, bool Loop, string Out)
        {
            if (File.Exists(Out))
                File.Delete(Out);

            FileStream Stream = new FileStream(Out, FileMode.CreateNew);
            VGAudio.Containers.NintendoWare.BCFstmWriter Writer = new VGAudio.Containers.NintendoWare.BCFstmWriter(OutType);

            Writer.WriteToStream(Audio.AudioFormat.WithLoop(Loop, LoopSt, LoopEn == 0 ? Audio.AudioFormat.SampleCount : LoopEn), Stream, Audio.Configuration);
            Stream.Close();
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

                Convert((int)NumUpDown_LoopStart.Value, (int)NumUpDown_LoopEnd.Value, CheckBox_IsLooped.Checked, Dialog.FileName);

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
            }

            return;
        }
    }
}
