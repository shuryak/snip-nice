using System;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using Yandex.Music.Client;

namespace Winter.YandexMultiStepAuth
{
    public partial class OtpUserControl : StepUserControl
    {
        private readonly ImageList _imageList;
        
        public OtpUserControl(YandexMusicClient ymClient) : base(ymClient)
        {
            _imageList = new ImageList();
            _imageList.Images.AddRange(new Image[]
            {
                Properties.Resources.ShowPasswordIcon,
                Properties.Resources.HidePasswordIcon
            });
            InitializeComponent();
            showHideCheckBox.ImageList = _imageList;
        }
        
        private void showHideCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (showHideCheckBox.ImageIndex == 0)
            {
                otpTextBox.PasswordChar = '\0';
                showHideCheckBox.ImageIndex = 1;
                showHideCheckBox.Checked = true;
            }
            else
            {
                otpTextBox.PasswordChar = '•';
                showHideCheckBox.ImageIndex = 0;
                showHideCheckBox.Checked = false;
            }
        }
        
        private async void loginButton_Click(object sender, EventArgs e)
        {
            Application.UseWaitCursor = true;
            loginButton.Enabled = false;
            otpTextBox.Enabled = false;

            bool ok = await Task.Run(() => TryAuthorize(otpTextBox.Text));
            
            if (ok)
            {
                ParentForm.Close();
                MessageBox.Show("Авторизация прошла успешно");
            }
            else
            {
                MessageBox.Show("Введён неверный одноразовый пароль");
            }
            
            otpTextBox.Enabled = true;
            loginButton.Enabled = true;
            Application.UseWaitCursor = false;
        }
        
        private Task<bool> TryAuthorize(string otp)
        {
            bool ok;
            try
            {
                ok = _ymClient.AuthorizeByAppPassword(otp);
            }
            catch (Exception e)
            {
                ok = false;
            }

            return Task.FromResult(ok);
        }
    }
}
