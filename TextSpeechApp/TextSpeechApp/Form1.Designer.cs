namespace TextSpeechApp
{
    partial class Form_Speech
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
            this.TextBox = new System.Windows.Forms.RichTextBox();
            this.Speech_btn = new System.Windows.Forms.Button();
            this.Save_btn = new System.Windows.Forms.Button();
            this.SpeecherList = new System.Windows.Forms.ComboBox();
            this.LivePlay = new System.Windows.Forms.CheckBox();
            this.LangList = new System.Windows.Forms.ComboBox();
            this.Info_btn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // TextBox
            // 
            this.TextBox.Location = new System.Drawing.Point(0, 0);
            this.TextBox.Name = "TextBox";
            this.TextBox.Size = new System.Drawing.Size(480, 470);
            this.TextBox.TabIndex = 0;
            this.TextBox.Text = "";
            // 
            // Speech_btn
            // 
            this.Speech_btn.Location = new System.Drawing.Point(393, 476);
            this.Speech_btn.Name = "Speech_btn";
            this.Speech_btn.Size = new System.Drawing.Size(75, 23);
            this.Speech_btn.TabIndex = 1;
            this.Speech_btn.Text = "Seslendir";
            this.Speech_btn.UseVisualStyleBackColor = true;
            this.Speech_btn.Click += new System.EventHandler(this.Speech_Btn_Click);
            // 
            // Save_btn
            // 
            this.Save_btn.Location = new System.Drawing.Point(312, 476);
            this.Save_btn.Name = "Save_btn";
            this.Save_btn.Size = new System.Drawing.Size(75, 23);
            this.Save_btn.TabIndex = 2;
            this.Save_btn.Text = "Kaydet";
            this.Save_btn.UseVisualStyleBackColor = true;
            this.Save_btn.Click += new System.EventHandler(this.Save_btn_Click);
            // 
            // SpeecherList
            // 
            this.SpeecherList.FormattingEnabled = true;
            this.SpeecherList.Location = new System.Drawing.Point(102, 478);
            this.SpeecherList.Name = "SpeecherList";
            this.SpeecherList.Size = new System.Drawing.Size(91, 21);
            this.SpeecherList.TabIndex = 4;
            this.SpeecherList.Text = "Seslendirmen";
            // 
            // LivePlay
            // 
            this.LivePlay.AutoSize = true;
            this.LivePlay.Checked = true;
            this.LivePlay.CheckState = System.Windows.Forms.CheckState.Checked;
            this.LivePlay.Location = new System.Drawing.Point(209, 482);
            this.LivePlay.Name = "LivePlay";
            this.LivePlay.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.LivePlay.Size = new System.Drawing.Size(67, 17);
            this.LivePlay.TabIndex = 5;
            this.LivePlay.Text = "Canlı Çal";
            this.LivePlay.UseVisualStyleBackColor = true;
            // 
            // LangList
            // 
            this.LangList.FormattingEnabled = true;
            this.LangList.Location = new System.Drawing.Point(15, 478);
            this.LangList.Name = "LangList";
            this.LangList.Size = new System.Drawing.Size(72, 21);
            this.LangList.TabIndex = 6;
            this.LangList.Text = "Diller";
            // 
            // Info_btn
            // 
            this.Info_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Info_btn.Location = new System.Drawing.Point(282, 476);
            this.Info_btn.Name = "Info_btn";
            this.Info_btn.Size = new System.Drawing.Size(24, 23);
            this.Info_btn.TabIndex = 7;
            this.Info_btn.Text = "?";
            this.Info_btn.UseVisualStyleBackColor = true;
            this.Info_btn.Click += new System.EventHandler(this.Info_btn_Click);
            // 
            // Form_Speech
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(480, 508);
            this.Controls.Add(this.Info_btn);
            this.Controls.Add(this.LangList);
            this.Controls.Add(this.LivePlay);
            this.Controls.Add(this.SpeecherList);
            this.Controls.Add(this.Save_btn);
            this.Controls.Add(this.Speech_btn);
            this.Controls.Add(this.TextBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Form_Speech";
            this.Text = "Seslendirici";
            this.Load += new System.EventHandler(this.FormSpeech_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox TextBox;
        private System.Windows.Forms.Button Speech_btn;
        private System.Windows.Forms.Button Save_btn;
        private System.Windows.Forms.ComboBox SpeecherList;
        private System.Windows.Forms.CheckBox LivePlay;
        private System.Windows.Forms.ComboBox LangList;
        private System.Windows.Forms.Button Info_btn;
    }
}

