using System.ComponentModel;
using System.Windows.Forms;

namespace Winter.YandexMultiStepAuth
{
    partial class QrCodeUserControl
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

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.labelQrCode = new System.Windows.Forms.Label();
            this.pictureBoxQrCode = new System.Windows.Forms.PictureBox();
            this.buttonAccept = new System.Windows.Forms.Button();
            this.timerLoading = new System.Windows.Forms.Timer(this.components);
            this.labelLoading = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxQrCode)).BeginInit();
            this.SuspendLayout();
            // 
            // labelQrCode
            // 
            this.labelQrCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelQrCode.Location = new System.Drawing.Point(0, 0);
            this.labelQrCode.Margin = new System.Windows.Forms.Padding(0);
            this.labelQrCode.Name = "labelQrCode";
            this.labelQrCode.Size = new System.Drawing.Size(370, 48);
            this.labelQrCode.TabIndex = 9;
            this.labelQrCode.Text = "Отсканируйте QR-код в приложении Яндекс Ключ:";
            this.labelQrCode.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // pictureBoxQrCode
            // 
            this.pictureBoxQrCode.Location = new System.Drawing.Point(0, 67);
            this.pictureBoxQrCode.Margin = new System.Windows.Forms.Padding(0);
            this.pictureBoxQrCode.Name = "pictureBoxQrCode";
            this.pictureBoxQrCode.Size = new System.Drawing.Size(370, 272);
            this.pictureBoxQrCode.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBoxQrCode.TabIndex = 10;
            this.pictureBoxQrCode.TabStop = false;
            // 
            // buttonAccept
            // 
            this.buttonAccept.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttonAccept.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonAccept.Location = new System.Drawing.Point(-1, 357);
            this.buttonAccept.Name = "buttonAccept";
            this.buttonAccept.Size = new System.Drawing.Size(372, 34);
            this.buttonAccept.TabIndex = 11;
            this.buttonAccept.Text = "Подтвердить";
            this.buttonAccept.UseVisualStyleBackColor = true;
            this.buttonAccept.Click += new System.EventHandler(this.buttonAccept_Click);
            // 
            // timerLoading
            // 
            this.timerLoading.Enabled = true;
            this.timerLoading.Interval = 150;
            this.timerLoading.Tick += new System.EventHandler(this.timerLoading_Tick);
            // 
            // labelLoading
            // 
            this.labelLoading.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelLoading.Location = new System.Drawing.Point(0, 67);
            this.labelLoading.Name = "labelLoading";
            this.labelLoading.Size = new System.Drawing.Size(370, 272);
            this.labelLoading.TabIndex = 14;
            this.labelLoading.Text = "Загрузка";
            this.labelLoading.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // QrCodeUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.labelLoading);
            this.Controls.Add(this.buttonAccept);
            this.Controls.Add(this.pictureBoxQrCode);
            this.Controls.Add(this.labelQrCode);
            this.Location = new System.Drawing.Point(15, 15);
            this.Name = "QrCodeUserControl";
            this.Size = new System.Drawing.Size(370, 391);
            this.Load += new System.EventHandler(this.QrCodeUserControl_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxQrCode)).EndInit();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Timer timerLoading;
        private System.Windows.Forms.Label labelLoading;

        private System.Windows.Forms.Button buttonAccept;

        private System.Windows.Forms.PictureBox pictureBoxQrCode;

        private System.Windows.Forms.Label labelQrCode;

        #endregion
    }
}
