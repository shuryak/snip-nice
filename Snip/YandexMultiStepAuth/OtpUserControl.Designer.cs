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
            this.showHideCheckBox = new System.Windows.Forms.CheckBox();
            this.loginButton = new System.Windows.Forms.Button();
            this.otpTextBox = new System.Windows.Forms.TextBox();
            this.passwordLabel = new System.Windows.Forms.Label();
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
            this.otpTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.otpTextBox.Location = new System.Drawing.Point(0, 58);
            this.otpTextBox.Margin = new System.Windows.Forms.Padding(0, 0, 0, 3);
            this.otpTextBox.MaxLength = 255;
            this.otpTextBox.Name = "otpTextBox";
            this.otpTextBox.PasswordChar = '•';
            this.otpTextBox.Size = new System.Drawing.Size(337, 29);
            this.otpTextBox.TabIndex = 22;
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
            // OtpUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.showHideCheckBox);
            this.Controls.Add(this.loginButton);
            this.Controls.Add(this.otpTextBox);
            this.Controls.Add(this.passwordLabel);
            this.Name = "OtpUserControl";
            this.Size = new System.Drawing.Size(370, 391);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.CheckBox showHideCheckBox;
        private System.Windows.Forms.Button loginButton;
        public System.Windows.Forms.TextBox otpTextBox;
        private System.Windows.Forms.Label passwordLabel;

        #endregion
    }
}
