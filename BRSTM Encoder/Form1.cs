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

        public Form1()
        {
            InitializeComponent();
            Label_Status.Text = "Waiting for file...";
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
                    byte[] OpenedWAVFile = File.ReadAllBytes(Dialog.FileName);

                    VGAudio.Containers.Wave.WaveReader Reader = new VGAudio.Containers.Wave.WaveReader();
                    Audio = Reader.ReadWithConfig(OpenedWAVFile);

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
                Dialog.Filter = "BRSTM Files (*.brstm)|*.brstm|All files (*.*)|*.*";
                Dialog.ShowDialog();

                if (Dialog.FileName == "")
                    return;

                Label_Status.Text = "Saving BRSTM...";
                Label_Status.Update();

                Audio.AudioFormat.LoopStart = (int)NumUpDown_LoopStart.Value;
                Audio.AudioFormat.LoopEnd = (int)NumUpDown_LoopEnd.Value == 0 ? Audio.AudioFormat.SampleCount : (int)NumUpDown_LoopEnd.Value;
                Audio.AudioFormat.Looping = CheckBox_IsLooped.Checked;

                VGAudio.Containers.NintendoWare.BrstmWriter Writer = new VGAudio.Containers.NintendoWare.BrstmWriter();

                if (File.Exists(Dialog.FileName))
                    File.Delete(Dialog.FileName);

                FileStream Stream = new FileStream(Dialog.FileName, FileMode.CreateNew);
                Writer.WriteToStream(Audio.Audio, Stream, Audio.Configuration);
                Stream.Close();

                Label_Status.Text = "Done!";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
