using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using Yandex.Music.Api.Models.Account;
using Yandex.Music.Client;

namespace Winter.YandexMultiStepAuth
{
    public partial class StartUserControl : StepUserControl
    {
        public StartUserControl(YandexMusicClient ymClient) : base(ymClient, true)
        {
            InitializeComponent();
        }

        private async void buttonLogin_Click(object sender, EventArgs e)
        {
            ParentForm.LoginTextBox.Enabled = false;
            buttonLogin.Enabled = false;
            Application.UseWaitCursor = true;

            try
            {
                YAuthTypes authTypes = await Task.Run(HandleLogin);

                if (authTypes.CanAuthorize != "true")
                {
                    Application.UseWaitCursor = false;
                    ParentForm.LoginTextBox.Enabled = true;
                    buttonLogin.Enabled = true;
                    
                    MessageBox.Show("Такого логина не существует или по нему невозможно авторизоваться ");
                    return;
                }

                Application.UseWaitCursor = false;
                buttonLogin.Enabled = true;

                // TODO: for debugging (remove in future)
                // string res = authTypes.AuthMethods.Aggregate(string.Empty, (current, authMethod) => current + (authMethod + Environment.NewLine));
                // MessageBox.Show(res);
                
                authTypes.PreferredAuthMethod = YAuthMethod.Otp; // TODO: for debugging (remove in future)
                
                switch (authTypes.PreferredAuthMethod)
                {
                    case YAuthMethod.Password:
                        ParentForm.ChangeStep(new PasswordUserControl(_ymClient));
                        break;
                    case YAuthMethod.MagicToken:
                        break;
                    case YAuthMethod.MagicLink:
                        break;
                    case YAuthMethod.Magic:
                        ParentForm.ChangeStep(new QrCodeUserControl(_ymClient));
                        break;
                    case YAuthMethod.Otp:
                        ParentForm.ChangeStep(new OtpUserControl(_ymClient));
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
            catch (AggregateException exceptions)
            {
                MessageBox.Show("Аккаунт заблокирован");
                // foreach (Exception ex in exceptions.InnerExceptions)
                // {
                //     MessageBox.Show(ex.Message);
                // }
            }
            
            buttonLogin.Enabled = true;
            Application.UseWaitCursor = false;
        }

        private Task<YAuthTypes> HandleLogin()
        {
            YAuthTypes authTypes = _ymClient.CreateAuthSession(ParentForm.LoginTextBox.Text);
            
            return Task.FromResult(authTypes);
        }
    }
}
