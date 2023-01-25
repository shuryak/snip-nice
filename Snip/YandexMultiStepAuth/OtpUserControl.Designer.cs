using System.ComponentModel;

namespace Winter.YandexMultiStepAuth
{
    partial class OtpUserControl
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
            this.showHideCheckBox = new System.Windows.Forms.CheckBox();
            this.loginButton = new System.Windows.Forms.Button();
            this.otpTextBox = new System.Windows.Forms.TextBox();
            this.passwordLabel = new System.Windows.Forms.Label();
            this.captchaPictureBox = new System.Windows.Forms.PictureBox();
            this.captchaTextBox = new System.Windows.Forms.TextBox();
            this.captchaLabel = new System.Windows.Forms.Label();
            this.loadingLabel = new System.Windows.Forms.Label();
            this.loadingTimer = new System.Windows.Forms.Timer(this.components);
            this.listenCheckBox = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.captchaPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // showHideCheckBox
            // 
            this.showHideCheckBox.Appearance = System.Windows.Forms.Appearance.Button;
            this.showHideCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.showHideCheckBox.ImageIndex = 0;
            this.showHideCheckBox.Location = new System.Drawing.Point(340, 57);
            this.showHideCheckBox.Name = "showHideCheckBox";
            this.showHideCheckBox.Size = new System.Drawing.Size(31, 31);
            this.showHideCheckBox.TabIndex = 24;
            this.showHideCheckBox.UseVisualStyleBackColor = true;
            this.showHideCheckBox.Click += new System.EventHandler(this.showHideCheckBox_CheckedChanged);
            // 
            // loginButton
            // 
            this.loginButton.AutoSize = true;
            this.loginButton.Enabled = false;
            this.loginButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.loginButton.Location = new System.Drawing.Point(-1, 93);
            this.loginButton.Name = "loginButton";
            this.loginButton.Size = new System.Drawing.Size(372, 34);
            this.loginButton.TabIndex = 23;
            this.loginButton.Text = "Войти";
            this.loginButton.UseVisualStyleBackColor = true;
            this.loginButton.Click += new System.EventHandler(this.loginButton_Click);
            // 
            // otpTextBox
            // 
            this.otpTextBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.otpTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.otpTextBox.Location = new System.Drawing.Point(0, 58);
            this.otpTextBox.Margin = new System.Windows.Forms.Padding(0, 0, 0, 3);
            this.otpTextBox.MaxLength = 255;
            this.otpTextBox.Name = "otpTextBox";
            this.otpTextBox.PasswordChar = '•';
            this.otpTextBox.Size = new System.Drawing.Size(337, 29);
            this.otpTextBox.TabIndex = 22;
            this.otpTextBox.TextChanged += new System.EventHandler(this.otpTextBox_TextChanged);
            // 
            // passwordLabel
            // 
            this.passwordLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.passwordLabel.Location = new System.Drawing.Point(0, 0);
            this.passwordLabel.Margin = new System.Windows.Forms.Padding(3, 0, 3, 10);
            this.passwordLabel.Name = "passwordLabel";
            this.passwordLabel.Size = new System.Drawing.Size(370, 48);
            this.passwordLabel.TabIndex = 21;
            this.passwordLabel.Text = "Одноразовый пароль из приложения Яндекс Ключ:";
            this.passwordLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // captchaPictureBox
            // 
            this.captchaPictureBox.Location = new System.Drawing.Point(0, 93);
            this.captchaPictureBox.Name = "captchaPictureBox";
            this.captchaPictureBox.Size = new System.Drawing.Size(370, 100);
            this.captchaPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.captchaPictureBox.TabIndex = 25;
            this.captchaPictureBox.TabStop = false;
            this.captchaPictureBox.Visible = false;
            // 
            // captchaTextBox
            // 
            this.captchaTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.captchaTextBox.Location = new System.Drawing.Point(0, 279);
            this.captchaTextBox.Margin = new System.Windows.Forms.Padding(0, 0, 0, 3);
            this.captchaTextBox.MaxLength = 255;
            this.captchaTextBox.Name = "captchaTextBox";
            this.captchaTextBox.Size = new System.Drawing.Size(370, 29);
            this.captchaTextBox.TabIndex = 26;
            this.captchaTextBox.Visible = false;
            // 
            // captchaLabel
            // 
            this.captchaLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.captchaLabel.Location = new System.Drawing.Point(-1, 245);
            this.captchaLabel.Margin = new System.Windows.Forms.Padding(0, 10, 0, 10);
            this.captchaLabel.Name = "captchaLabel";
            this.captchaLabel.Size = new System.Drawing.Size(370, 24);
            this.captchaLabel.TabIndex = 27;
            this.captchaLabel.Text = "Введите код:";
            this.captchaLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.captchaLabel.Visible = false;
            // 
            // loadingLabel
            // 
            this.loadingLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.loadingLabel.Location = new System.Drawing.Point(0, 93);
            this.loadingLabel.Name = "loadingLabel";
            this.loadingLabel.Size = new System.Drawing.Size(370, 100);
            this.loadingLabel.TabIndex = 28;
            this.loadingLabel.Text = "Загрузка";
            this.loadingLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.loadingLabel.Visible = false;
            // 
            // loadingTimer
            // 
            this.loadingTimer.Interval = 150;
            this.loadingTimer.Tick += new System.EventHandler(this.loadingTimer_Tick);
            // 
            // listenCheckBox
            // 
            this.listenCheckBox.Appearance = System.Windows.Forms.Appearance.Button;
            this.listenCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.listenCheckBox.Image = global::Winter.Properties.Resources.ListenCaptchaIcon;
            this.listenCheckBox.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.listenCheckBox.Location = new System.Drawing.Point(-1, 196);
            this.listenCheckBox.Name = "listenCheckBox";
            this.listenCheckBox.Size = new System.Drawing.Size(372, 36);
            this.listenCheckBox.TabIndex = 29;
            this.listenCheckBox.Text = "Прослушать код";
            this.listenCheckBox.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.listenCheckBox.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.listenCheckBox.UseVisualStyleBackColor = true;
            this.listenCheckBox.Visible = false;
            this.listenCheckBox.CheckedChanged += new System.EventHandler(this.listenCheckBox_CheckedChanged);
            // 
            // OtpUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.listenCheckBox);
            this.Controls.Add(this.loadingLabel);
            this.Controls.Add(this.captchaLabel);
            this.Controls.Add(this.captchaTextBox);
            this.Controls.Add(this.captchaPictureBox);
            this.Controls.Add(this.showHideCheckBox);
            this.Controls.Add(this.loginButton);
            this.Controls.Add(this.otpTextBox);
            this.Controls.Add(this.passwordLabel);
            this.Location = new System.Drawing.Point(15, 15);
            this.Name = "OtpUserControl";
            this.Size = new System.Drawing.Size(370, 391);
            ((System.ComponentModel.ISupportInitialize)(this.captchaPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.CheckBox listenCheckBox;

        private System.Windows.Forms.Timer loadingTimer;

        private System.Windows.Forms.Label loadingLabel;

        private System.Windows.Forms.Label captchaLabel;

        public System.Windows.Forms.TextBox captchaTextBox;

        private System.Windows.Forms.PictureBox captchaPictureBox;

        private System.Windows.Forms.CheckBox showHideCheckBox;
        private System.Windows.Forms.Button loginButton;
        public System.Windows.Forms.TextBox otpTextBox;
        private System.Windows.Forms.Label passwordLabel;

        #endregion
    }
}
