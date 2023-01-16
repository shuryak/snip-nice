using System.ComponentModel;

namespace Winter
{
    partial class QrCodeAuthUserControl
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
            this.pictureBoxAuthQrCode = new System.Windows.Forms.PictureBox();
            this.labelQrCodeLoading = new System.Windows.Forms.Label();
            this.buttonQrAuthorize = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.timerQrCodeLoading = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxAuthQrCode)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBoxAuthQrCode
            // 
            this.pictureBoxAuthQrCode.Location = new System.Drawing.Point(0, 66);
            this.pictureBoxAuthQrCode.Margin = new System.Windows.Forms.Padding(0);
            this.pictureBoxAuthQrCode.Name = "pictureBoxAuthQrCode";
            this.pictureBoxAuthQrCode.Size = new System.Drawing.Size(484, 294);
            this.pictureBoxAuthQrCode.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBoxAuthQrCode.TabIndex = 1;
            this.pictureBoxAuthQrCode.TabStop = false;
            // 
            // labelQrCodeLoading
            // 
            this.labelQrCodeLoading.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelQrCodeLoading.Location = new System.Drawing.Point(0, 66);
            this.labelQrCodeLoading.Margin = new System.Windows.Forms.Padding(0);
            this.labelQrCodeLoading.Name = "labelQrCodeLoading";
            this.labelQrCodeLoading.Size = new System.Drawing.Size(484, 294);
            this.labelQrCodeLoading.TabIndex = 3;
            this.labelQrCodeLoading.Text = "Загрузка";
            this.labelQrCodeLoading.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // buttonQrAuthorize
            // 
            this.buttonQrAuthorize.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttonQrAuthorize.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonQrAuthorize.Location = new System.Drawing.Point(12, 363);
            this.buttonQrAuthorize.Name = "buttonQrAuthorize";
            this.buttonQrAuthorize.Size = new System.Drawing.Size(460, 50);
            this.buttonQrAuthorize.TabIndex = 4;
            this.buttonQrAuthorize.Text = "Авторизоваться";
            this.buttonQrAuthorize.UseVisualStyleBackColor = true;
            this.buttonQrAuthorize.Click += new System.EventHandler(this.buttonQrAuthorize_Click);
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Margin = new System.Windows.Forms.Padding(0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(484, 66);
            this.label1.TabIndex = 5;
            this.label1.Text = "Просканируйте QR-код любым удобным способом, например, в приложении Яндекс.Ключ:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // timerQrCodeLoading
            // 
            this.timerQrCodeLoading.Enabled = true;
            this.timerQrCodeLoading.Interval = 300;
            this.timerQrCodeLoading.Tick += new System.EventHandler(this.timerQrCodeLoading_Tick);
            // 
            // QrCodeAuthUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonQrAuthorize);
            this.Controls.Add(this.labelQrCodeLoading);
            this.Controls.Add(this.pictureBoxAuthQrCode);
            this.Name = "QrCodeAuthUserControl";
            this.Size = new System.Drawing.Size(484, 416);
            this.Load += new System.EventHandler(this.QrCodeAuthUserControl_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxAuthQrCode)).EndInit();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Timer timerQrCodeLoading;

        private System.Windows.Forms.Label label1;

        private System.Windows.Forms.Button buttonQrAuthorize;

        private System.Windows.Forms.Label labelQrCodeLoading;

        private System.Windows.Forms.PictureBox pictureBoxAuthQrCode;

        #endregion
    }
}
