using System.ComponentModel;
using System.Drawing;

namespace Winter
{
    partial class YandexMusicAuthorization
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

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
            this.buttonCodeAuthorize = new System.Windows.Forms.Button();
            this.qrCodeAuthUserControl = new Winter.QrCodeAuthUserControl(_ymClient);
            this.SuspendLayout();
            // 
            // buttonCodeAuthorize
            // 
            this.buttonCodeAuthorize.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttonCodeAuthorize.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonCodeAuthorize.Location = new System.Drawing.Point(12, 422);
            this.buttonCodeAuthorize.Name = "buttonCodeAuthorize";
            this.buttonCodeAuthorize.Size = new System.Drawing.Size(460, 27);
            this.buttonCodeAuthorize.TabIndex = 4;
            this.buttonCodeAuthorize.Text = "Авторизация по пин-коду";
            this.buttonCodeAuthorize.UseVisualStyleBackColor = true;
            this.buttonCodeAuthorize.Click += new System.EventHandler(this.buttonCodeAuthorize_Click);
            // 
            // qrCodeAuthUserControl
            // 
            this.qrCodeAuthUserControl.Location = new System.Drawing.Point(0, 0);
            this.qrCodeAuthUserControl.Name = "qrCodeAuthUserControl";
            this.qrCodeAuthUserControl.Size = new System.Drawing.Size(484, 416);
            this.qrCodeAuthUserControl.TabIndex = 5;
            // 
            // YandexMusicAuthorization
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 461);
            this.Controls.Add(this.qrCodeAuthUserControl);
            this.Controls.Add(this.buttonCodeAuthorize);
            this.Name = "YandexMusicAuthorization";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Авторизация в Яндекс Музыке";
            this.ResumeLayout(false);
        }

        private Winter.QrCodeAuthUserControl qrCodeAuthUserControl;
        private Winter.PinCodeAuthUserControl pinCodeAuthUserControl;

        private System.Windows.Forms.Button buttonCodeAuthorize;

        #endregion
    }
}
