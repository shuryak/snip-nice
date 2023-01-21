using System;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using Yandex.Music.Client;

namespace Winter.YandexMultiStepAuth
{
    public partial class PasswordUserControl : StepUserControl
    {
        private readonly ImageList _imageList;
        
        public PasswordUserControl(YandexMusicClient ymClient) : base(ymClient)
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
                passwordTextBox.PasswordChar = '\0';
                showHideCheckBox.ImageIndex = 1;
                showHideCheckBox.Checked = true;
            }
            else
            {
                passwordTextBox.PasswordChar = '•';
                showHideCheckBox.ImageIndex = 0;
                showHideCheckBox.Checked = false;
            }
        }

        private async void loginButton_Click(object sender, EventArgs e)
        {
            Application.UseWaitCursor = true;
            loginButton.Enabled = false;
            passwordTextBox.Enabled = false;

            bool ok = await Task.Run(() => TryAuthorize(ParentForm.LoginTextBox.Text, passwordTextBox.Text));
            
            if (ok)
            {
                ParentForm.Close();
                MessageBox.Show("Авторизация прошла успешно");
            }
            else
            {
                MessageBox.Show("Введён неверный пароль");
            }
            
            passwordTextBox.Enabled = true;
            loginButton.Enabled = true;
            Application.UseWaitCursor = false;
        }

        private Task<bool> TryAuthorize(string login, string password)
        {
            bool ok;
            try
            {
                ok = _ymClient.Authorize(login, password);
                if (ok)
                {
                    ok = _ymClient.Authorize(_ymClient.GetAccessToken().AccessToken);
                }
            }
            catch (Exception)
            {
                ok = false;
            }

            return Task.FromResult(ok);
        }
    }
}
