namespace Winter
{
    partial class OutputFormat
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
            this.Text = LocalizedMessages.SetOutputFormatForm;
            
            this.labelTrackFormat = new System.Windows.Forms.Label();
            this.textBoxTrackFormat = new System.Windows.Forms.TextBox();
            this.labelSeparatorFormat = new System.Windows.Forms.Label();
            this.textBoxSeparatorFormat = new System.Windows.Forms.TextBox();
            this.labelArtistFormat = new System.Windows.Forms.Label();
            this.textBoxArtistFormat = new System.Windows.Forms.TextBox();
            this.buttonDefaults = new System.Windows.Forms.Button();
            this.buttonSave = new System.Windows.Forms.Button();
            this.labelAlbumFormat = new System.Windows.Forms.Label();
            this.textBoxAlbumFormat = new System.Windows.Forms.TextBox();
            this.textBoxRightSeparatorFormat = new System.Windows.Forms.TextBox();
            this.labelRightSeparatorFormat = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // labelTrackFormat
            // 
            this.labelTrackFormat.Location = new System.Drawing.Point(12, 9);
            this.labelTrackFormat.Name = "labelTrackFormat";
            this.labelTrackFormat.Size = new System.Drawing.Size(254, 13);
            this.labelTrackFormat.TabIndex = 0;
            this.labelTrackFormat.Text = LocalizedMessages.SetTrackFormat;
            // 
            // textBoxTrackFormat
            // 
            this.textBoxTrackFormat.Location = new System.Drawing.Point(12, 25);
            this.textBoxTrackFormat.Name = "textBoxTrackFormat";
            this.textBoxTrackFormat.Size = new System.Drawing.Size(254, 20);
            this.textBoxTrackFormat.TabIndex = 1;
            // 
            // labelSeparatorFormat
            // 
            this.labelSeparatorFormat.Location = new System.Drawing.Point(12, 58);
            this.labelSeparatorFormat.Name = "labelSeparatorFormat";
            this.labelSeparatorFormat.Size = new System.Drawing.Size(254, 13);
            this.labelSeparatorFormat.TabIndex = 2;
            this.labelSeparatorFormat.Text = LocalizedMessages.SetSeparatorFormat;
            // 
            // textBoxSeparatorFormat
            // 
            this.textBoxSeparatorFormat.Location = new System.Drawing.Point(12, 74);
            this.textBoxSeparatorFormat.Name = "textBoxSeparatorFormat";
            this.textBoxSeparatorFormat.Size = new System.Drawing.Size(254, 20);
            this.textBoxSeparatorFormat.TabIndex = 3;
            // 
            // labelArtistFormat
            // 
            this.labelArtistFormat.Location = new System.Drawing.Point(12, 107);
            this.labelArtistFormat.Name = "labelArtistFormat";
            this.labelArtistFormat.Size = new System.Drawing.Size(254, 13);
            this.labelArtistFormat.TabIndex = 4;
            this.labelArtistFormat.Text = LocalizedMessages.SetArtistFormat;
            // 
            // textBoxArtistFormat
            // 
            this.textBoxArtistFormat.Location = new System.Drawing.Point(12, 123);
            this.textBoxArtistFormat.Name = "textBoxArtistFormat";
            this.textBoxArtistFormat.Size = new System.Drawing.Size(254, 20);
            this.textBoxArtistFormat.TabIndex = 5;
            // 
            // labelAlbumFormat
            // 
            this.labelAlbumFormat.Location = new System.Drawing.Point(12, 156);
            this.labelAlbumFormat.Name = "labelAlbumFormat";
            this.labelAlbumFormat.Size = new System.Drawing.Size(254, 13);
            this.labelAlbumFormat.TabIndex = 6;
            this.labelAlbumFormat.Text = LocalizedMessages.SetAlbumFormat;
            // 
            // textBoxAlbumFormat
            // 
            this.textBoxAlbumFormat.Location = new System.Drawing.Point(12, 172);
            this.textBoxAlbumFormat.Name = "textBoxAlbumFormat";
            this.textBoxAlbumFormat.Size = new System.Drawing.Size(254, 20);
            this.textBoxAlbumFormat.TabIndex = 7;
            // 
            // textBoxRightSeparatorFormat
            // 
            this.textBoxRightSeparatorFormat.Location = new System.Drawing.Point(12, 221);
            this.textBoxRightSeparatorFormat.Name = "textBoxRightSeparatorFormat";
            this.textBoxRightSeparatorFormat.Size = new System.Drawing.Size(254, 20);
            this.textBoxRightSeparatorFormat.TabIndex = 11;
            // 
            // labelRightSeparatorFormat
            // 
            this.labelRightSeparatorFormat.Location = new System.Drawing.Point(10, 205);
            this.labelRightSeparatorFormat.Name = "labelRightSeparatorFormat";
            this.labelRightSeparatorFormat.Size = new System.Drawing.Size(254, 13);
            this.labelRightSeparatorFormat.TabIndex = 10;
            this.labelRightSeparatorFormat.Text = LocalizedMessages.SetRightSeparatorFormat;
            // 
            // buttonDefaults
            // 
            this.buttonDefaults.Location = new System.Drawing.Point(12, 258);
            this.buttonDefaults.Name = "buttonDefaults";
            this.buttonDefaults.Size = new System.Drawing.Size(122, 23);
            this.buttonDefaults.TabIndex = 8;
            this.buttonDefaults.UseVisualStyleBackColor = true;
            this.buttonDefaults.Click += new System.EventHandler(this.ButtonDefaults_Click);
            this.buttonDefaults.Text = LocalizedMessages.ButtonDefaults;
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(144, 258);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(122, 23);
            this.buttonSave.TabIndex = 9;
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.ButtonSave_Click);
            this.buttonSave.Text = LocalizedMessages.ButtonSave;
            // 
            // OutputFormat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(278, 291);
            this.Controls.Add(this.textBoxRightSeparatorFormat);
            this.Controls.Add(this.labelRightSeparatorFormat);
            this.Controls.Add(this.textBoxAlbumFormat);
            this.Controls.Add(this.labelAlbumFormat);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.buttonDefaults);
            this.Controls.Add(this.textBoxArtistFormat);
            this.Controls.Add(this.labelArtistFormat);
            this.Controls.Add(this.textBoxSeparatorFormat);
            this.Controls.Add(this.labelSeparatorFormat);
            this.Controls.Add(this.textBoxTrackFormat);
            this.Controls.Add(this.labelTrackFormat);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "OutputFormat";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.TextBox textBoxRightSeparatorFormat;
        private System.Windows.Forms.Label labelRightSeparatorFormat;

        #endregion

        private System.Windows.Forms.Label labelTrackFormat;
        private System.Windows.Forms.TextBox textBoxTrackFormat;
        private System.Windows.Forms.Label labelSeparatorFormat;
        private System.Windows.Forms.TextBox textBoxSeparatorFormat;
        private System.Windows.Forms.Label labelArtistFormat;
        private System.Windows.Forms.TextBox textBoxArtistFormat;
        private System.Windows.Forms.Button buttonDefaults;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Label labelAlbumFormat;
        private System.Windows.Forms.TextBox textBoxAlbumFormat;
    }
}
