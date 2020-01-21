namespace BRSTM_Encoder
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.Button_Open = new System.Windows.Forms.Button();
            this.Button_Save = new System.Windows.Forms.Button();
            this.NumUpDown_LoopStart = new System.Windows.Forms.NumericUpDown();
            this.NumUpDown_LoopEnd = new System.Windows.Forms.NumericUpDown();
            this.Label_LoopStart = new System.Windows.Forms.Label();
            this.Label_LoopEnd = new System.Windows.Forms.Label();
            this.Label_Channels = new System.Windows.Forms.Label();
            this.Label_Bitrate = new System.Windows.Forms.Label();
            this.Label_NumSamples = new System.Windows.Forms.Label();
            this.Label_Status = new System.Windows.Forms.Label();
            this.CheckBox_IsLooped = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.NumUpDown_LoopStart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumUpDown_LoopEnd)).BeginInit();
            this.SuspendLayout();
            // 
            // Button_Open
            // 
            this.Button_Open.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.Button_Open.Location = new System.Drawing.Point(12, 12);
            this.Button_Open.Name = "Button_Open";
            this.Button_Open.Size = new System.Drawing.Size(120, 47);
            this.Button_Open.TabIndex = 0;
            this.Button_Open.Text = "Open WAV...";
            this.Button_Open.UseVisualStyleBackColor = true;
            this.Button_Open.Click += new System.EventHandler(this.Button_Open_Click);
            // 
            // Button_Save
            // 
            this.Button_Save.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Button_Save.Location = new System.Drawing.Point(167, 211);
            this.Button_Save.Name = "Button_Save";
            this.Button_Save.Size = new System.Drawing.Size(130, 49);
            this.Button_Save.TabIndex = 1;
            this.Button_Save.Text = "Convert...";
            this.Button_Save.UseVisualStyleBackColor = true;
            this.Button_Save.Click += new System.EventHandler(this.Button_Save_Click);
            // 
            // NumUpDown_LoopStart
            // 
            this.NumUpDown_LoopStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.NumUpDown_LoopStart.Location = new System.Drawing.Point(75, 78);
            this.NumUpDown_LoopStart.Name = "NumUpDown_LoopStart";
            this.NumUpDown_LoopStart.Size = new System.Drawing.Size(223, 20);
            this.NumUpDown_LoopStart.TabIndex = 2;
            // 
            // NumUpDown_LoopEnd
            // 
            this.NumUpDown_LoopEnd.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.NumUpDown_LoopEnd.Location = new System.Drawing.Point(75, 103);
            this.NumUpDown_LoopEnd.Name = "NumUpDown_LoopEnd";
            this.NumUpDown_LoopEnd.Size = new System.Drawing.Size(223, 20);
            this.NumUpDown_LoopEnd.TabIndex = 3;
            // 
            // Label_LoopStart
            // 
            this.Label_LoopStart.AutoSize = true;
            this.Label_LoopStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.Label_LoopStart.Location = new System.Drawing.Point(12, 80);
            this.Label_LoopStart.Name = "Label_LoopStart";
            this.Label_LoopStart.Size = new System.Drawing.Size(57, 13);
            this.Label_LoopStart.TabIndex = 4;
            this.Label_LoopStart.Text = "Loop start:";
            // 
            // Label_LoopEnd
            // 
            this.Label_LoopEnd.AutoSize = true;
            this.Label_LoopEnd.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.Label_LoopEnd.Location = new System.Drawing.Point(12, 110);
            this.Label_LoopEnd.Name = "Label_LoopEnd";
            this.Label_LoopEnd.Size = new System.Drawing.Size(55, 13);
            this.Label_LoopEnd.TabIndex = 5;
            this.Label_LoopEnd.Text = "Loop end:";
            // 
            // Label_Channels
            // 
            this.Label_Channels.AutoSize = true;
            this.Label_Channels.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.Label_Channels.Location = new System.Drawing.Point(12, 145);
            this.Label_Channels.Name = "Label_Channels";
            this.Label_Channels.Size = new System.Drawing.Size(99, 13);
            this.Label_Channels.TabIndex = 6;
            this.Label_Channels.Text = "Channels detected:";
            // 
            // Label_Bitrate
            // 
            this.Label_Bitrate.AutoSize = true;
            this.Label_Bitrate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.Label_Bitrate.Location = new System.Drawing.Point(12, 188);
            this.Label_Bitrate.Name = "Label_Bitrate";
            this.Label_Bitrate.Size = new System.Drawing.Size(40, 13);
            this.Label_Bitrate.TabIndex = 7;
            this.Label_Bitrate.Text = "Bitrate:";
            // 
            // Label_NumSamples
            // 
            this.Label_NumSamples.AutoSize = true;
            this.Label_NumSamples.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.Label_NumSamples.Location = new System.Drawing.Point(12, 167);
            this.Label_NumSamples.Name = "Label_NumSamples";
            this.Label_NumSamples.Size = new System.Drawing.Size(102, 13);
            this.Label_NumSamples.TabIndex = 9;
            this.Label_NumSamples.Text = "Number of Samples:";
            // 
            // Label_Status
            // 
            this.Label_Status.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.Label_Status.Location = new System.Drawing.Point(13, 263);
            this.Label_Status.Name = "Label_Status";
            this.Label_Status.Size = new System.Drawing.Size(285, 13);
            this.Label_Status.TabIndex = 10;
            this.Label_Status.Text = "<Status>";
            // 
            // CheckBox_IsLooped
            // 
            this.CheckBox_IsLooped.AutoSize = true;
            this.CheckBox_IsLooped.Checked = true;
            this.CheckBox_IsLooped.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CheckBox_IsLooped.Location = new System.Drawing.Point(229, 42);
            this.CheckBox_IsLooped.Name = "CheckBox_IsLooped";
            this.CheckBox_IsLooped.Size = new System.Drawing.Size(68, 17);
            this.CheckBox_IsLooped.TabIndex = 11;
            this.CheckBox_IsLooped.Text = "Looped?";
            this.CheckBox_IsLooped.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(309, 285);
            this.Controls.Add(this.CheckBox_IsLooped);
            this.Controls.Add(this.Label_Status);
            this.Controls.Add(this.Label_NumSamples);
            this.Controls.Add(this.Label_Bitrate);
            this.Controls.Add(this.Label_Channels);
            this.Controls.Add(this.Label_LoopEnd);
            this.Controls.Add(this.Label_LoopStart);
            this.Controls.Add(this.NumUpDown_LoopEnd);
            this.Controls.Add(this.NumUpDown_LoopStart);
            this.Controls.Add(this.Button_Save);
            this.Controls.Add(this.Button_Open);
            this.Name = "Form1";
            this.Text = "BRSTM Encoder";
            ((System.ComponentModel.ISupportInitialize)(this.NumUpDown_LoopStart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumUpDown_LoopEnd)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Button_Open;
        private System.Windows.Forms.Button Button_Save;
        private System.Windows.Forms.NumericUpDown NumUpDown_LoopStart;
        private System.Windows.Forms.NumericUpDown NumUpDown_LoopEnd;
        private System.Windows.Forms.Label Label_LoopStart;
        private System.Windows.Forms.Label Label_LoopEnd;
        private System.Windows.Forms.Label Label_Channels;
        private System.Windows.Forms.Label Label_Bitrate;
        private System.Windows.Forms.Label Label_NumSamples;
        private System.Windows.Forms.Label Label_Status;
        private System.Windows.Forms.CheckBox CheckBox_IsLooped;
    }
}

