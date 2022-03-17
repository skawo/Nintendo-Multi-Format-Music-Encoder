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
            this.ComboOutType = new System.Windows.Forms.ComboBox();
            this.Label_OutType = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.NumUpDown_LoopStart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumUpDown_LoopEnd)).BeginInit();
            this.SuspendLayout();
            // 
            // Button_Open
            // 
            this.Button_Open.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.Button_Open.Location = new System.Drawing.Point(16, 15);
            this.Button_Open.Margin = new System.Windows.Forms.Padding(4);
            this.Button_Open.Name = "Button_Open";
            this.Button_Open.Size = new System.Drawing.Size(160, 58);
            this.Button_Open.TabIndex = 0;
            this.Button_Open.Text = "Open WAV...";
            this.Button_Open.UseVisualStyleBackColor = true;
            this.Button_Open.Click += new System.EventHandler(this.Button_Open_Click);
            // 
            // Button_Save
            // 
            this.Button_Save.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Button_Save.Location = new System.Drawing.Point(223, 260);
            this.Button_Save.Margin = new System.Windows.Forms.Padding(4);
            this.Button_Save.Name = "Button_Save";
            this.Button_Save.Size = new System.Drawing.Size(173, 60);
            this.Button_Save.TabIndex = 1;
            this.Button_Save.Text = "Convert...";
            this.Button_Save.UseVisualStyleBackColor = true;
            this.Button_Save.Click += new System.EventHandler(this.Button_Save_Click);
            // 
            // NumUpDown_LoopStart
            // 
            this.NumUpDown_LoopStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.NumUpDown_LoopStart.Location = new System.Drawing.Point(100, 96);
            this.NumUpDown_LoopStart.Margin = new System.Windows.Forms.Padding(4);
            this.NumUpDown_LoopStart.Name = "NumUpDown_LoopStart";
            this.NumUpDown_LoopStart.Size = new System.Drawing.Size(297, 20);
            this.NumUpDown_LoopStart.TabIndex = 2;
            // 
            // NumUpDown_LoopEnd
            // 
            this.NumUpDown_LoopEnd.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.NumUpDown_LoopEnd.Location = new System.Drawing.Point(100, 127);
            this.NumUpDown_LoopEnd.Margin = new System.Windows.Forms.Padding(4);
            this.NumUpDown_LoopEnd.Name = "NumUpDown_LoopEnd";
            this.NumUpDown_LoopEnd.Size = new System.Drawing.Size(297, 20);
            this.NumUpDown_LoopEnd.TabIndex = 3;
            // 
            // Label_LoopStart
            // 
            this.Label_LoopStart.AutoSize = true;
            this.Label_LoopStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.Label_LoopStart.Location = new System.Drawing.Point(16, 98);
            this.Label_LoopStart.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label_LoopStart.Name = "Label_LoopStart";
            this.Label_LoopStart.Size = new System.Drawing.Size(57, 13);
            this.Label_LoopStart.TabIndex = 4;
            this.Label_LoopStart.Text = "Loop start:";
            // 
            // Label_LoopEnd
            // 
            this.Label_LoopEnd.AutoSize = true;
            this.Label_LoopEnd.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.Label_LoopEnd.Location = new System.Drawing.Point(16, 135);
            this.Label_LoopEnd.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label_LoopEnd.Name = "Label_LoopEnd";
            this.Label_LoopEnd.Size = new System.Drawing.Size(55, 13);
            this.Label_LoopEnd.TabIndex = 5;
            this.Label_LoopEnd.Text = "Loop end:";
            // 
            // Label_Channels
            // 
            this.Label_Channels.AutoSize = true;
            this.Label_Channels.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.Label_Channels.Location = new System.Drawing.Point(16, 178);
            this.Label_Channels.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label_Channels.Name = "Label_Channels";
            this.Label_Channels.Size = new System.Drawing.Size(99, 13);
            this.Label_Channels.TabIndex = 6;
            this.Label_Channels.Text = "Channels detected:";
            // 
            // Label_Bitrate
            // 
            this.Label_Bitrate.AutoSize = true;
            this.Label_Bitrate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.Label_Bitrate.Location = new System.Drawing.Point(16, 231);
            this.Label_Bitrate.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label_Bitrate.Name = "Label_Bitrate";
            this.Label_Bitrate.Size = new System.Drawing.Size(40, 13);
            this.Label_Bitrate.TabIndex = 7;
            this.Label_Bitrate.Text = "Bitrate:";
            // 
            // Label_NumSamples
            // 
            this.Label_NumSamples.AutoSize = true;
            this.Label_NumSamples.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.Label_NumSamples.Location = new System.Drawing.Point(16, 206);
            this.Label_NumSamples.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label_NumSamples.Name = "Label_NumSamples";
            this.Label_NumSamples.Size = new System.Drawing.Size(102, 13);
            this.Label_NumSamples.TabIndex = 9;
            this.Label_NumSamples.Text = "Number of Samples:";
            // 
            // Label_Status
            // 
            this.Label_Status.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.Label_Status.Location = new System.Drawing.Point(17, 324);
            this.Label_Status.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label_Status.Name = "Label_Status";
            this.Label_Status.Size = new System.Drawing.Size(380, 16);
            this.Label_Status.TabIndex = 10;
            this.Label_Status.Text = "<Status>";
            // 
            // CheckBox_IsLooped
            // 
            this.CheckBox_IsLooped.AutoSize = true;
            this.CheckBox_IsLooped.Checked = true;
            this.CheckBox_IsLooped.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CheckBox_IsLooped.Location = new System.Drawing.Point(184, 53);
            this.CheckBox_IsLooped.Margin = new System.Windows.Forms.Padding(4);
            this.CheckBox_IsLooped.Name = "CheckBox_IsLooped";
            this.CheckBox_IsLooped.Size = new System.Drawing.Size(81, 20);
            this.CheckBox_IsLooped.TabIndex = 11;
            this.CheckBox_IsLooped.Text = "Looped?";
            this.CheckBox_IsLooped.UseVisualStyleBackColor = true;
            // 
            // ComboOutType
            // 
            this.ComboOutType.FormattingEnabled = true;
            this.ComboOutType.Items.AddRange(new object[] {
            "BRSTM",
            "BCSTM",
            "BFSTM"});
            this.ComboOutType.Location = new System.Drawing.Point(275, 15);
            this.ComboOutType.Name = "ComboOutType";
            this.ComboOutType.Size = new System.Drawing.Size(121, 24);
            this.ComboOutType.TabIndex = 12;
            this.ComboOutType.Text = "BRSTM";
            this.ComboOutType.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // Label_OutType
            // 
            this.Label_OutType.AutoSize = true;
            this.Label_OutType.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.Label_OutType.Location = new System.Drawing.Point(208, 20);
            this.Label_OutType.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label_OutType.Name = "Label_OutType";
            this.Label_OutType.Size = new System.Drawing.Size(61, 13);
            this.Label_OutType.TabIndex = 13;
            this.Label_OutType.Text = "Encode as:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(412, 351);
            this.Controls.Add(this.Label_OutType);
            this.Controls.Add(this.ComboOutType);
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
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Text = "BxSTM Encoder";
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
        private System.Windows.Forms.ComboBox ComboOutType;
        private System.Windows.Forms.Label Label_OutType;
    }
}

