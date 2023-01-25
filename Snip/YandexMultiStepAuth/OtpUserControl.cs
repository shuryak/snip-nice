using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using NAudio.Wave;
using Yandex.Music.Api.Models.Account;
using Yandex.Music.Client;

namespace Winter.YandexMultiStepAuth
{
    public partial class OtpUserControl : StepUserControl
    {
        private readonly ImageList _imageList;

        private string _lastOtp;
        
        private string _captchaVoiceUrl;
        private string _captchaVoiceIntroUrl;

        private CancellationTokenSource _cancelTokenSource;
        
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
            string? checkBoxErrors = GetCheckBoxesErrors();
            if (checkBoxErrors != null)
            {
                MessageBox.Show(checkBoxErrors);
                return;
            }

            _lastOtp = otpTextBox.Text;
            
            Application.UseWaitCursor = true;
            loginButton.Enabled = false;
            otpTextBox.Enabled = false;
            captchaTextBox.Enabled = false;
            showHideCheckBox.Enabled = false;
            listenCheckBox.Checked = false;
            listenCheckBox.Enabled = false;
            
            if (captchaTextBox.Visible)
            {
                YAuthBase passCaptchaResult = await Task.Run(() => TryPassCaptcha(captchaTextBox.Text));

                if (passCaptchaResult.Status != YAuthStatus.Ok)
                {
                    MessageBox.Show("Неверно введены символы с картинки");
                }
            }
            
            YAuthBase authBase = await Task.Run(() => TryAuthorize(otpTextBox.Text));

            // TODO: for debugging (remove in future)
            // string print = authBase.Errors?.Aggregate(string.Empty, (current, err) => current + $"<{err}> ");
            // MessageBox.Show(print);

            if (authBase.Status == YAuthStatus.Ok)
            {
                ParentForm.Close();
                MessageBox.Show("Авторизация прошла успешно");
            }
            else if (authBase.Errors?.Contains(YAuthError.CaptchaRequired) != null)
            {
                ShowCaptcha();
            }
            else if(authBase.Errors?.Contains(YAuthError.CaptchaNotMatched) != null)
            {
                MessageBox.Show("Введена неверная капча");
            }
            else if (authBase.Errors?.Contains(YAuthError.PasswordNotMatched) != null)
            {
                MessageBox.Show("Введён неверный одноразовый пароль");
            }

            loginButton.Enabled = true;
            otpTextBox.Enabled = true;
            captchaTextBox.Enabled = true;
            showHideCheckBox.Enabled = true;
            listenCheckBox.Enabled = true;
            Application.UseWaitCursor = false;
        }

        private string? GetCheckBoxesErrors()
        {
            if (string.IsNullOrWhiteSpace(otpTextBox.Text)) return "Не введён одноразовый пароль";
            if (captchaTextBox.Visible && string.IsNullOrWhiteSpace(captchaTextBox.Text)) return "Не введен код";
            if (captchaTextBox.Visible && otpTextBox.Text == _lastOtp) return "Дождитесь нового одноразового пароля";
            
            return null;
        }

        private Task<YAuthBase> TryPassCaptcha(string solve)
        {
            return Task.FromResult(_ymClient.AuthorizeByCaptcha(solve));
        }
        
        private Task<YAuthBase> TryAuthorize(string otp)
        {
            YAuthBase authBase = _ymClient.AuthorizeByAppPassword(otp);
            return Task.FromResult(authBase);
        }

        private async void ShowCaptcha()
        {
            loginButton.Location = loginButton.Location with { Y = 314 };
            otpTextBox.Text = string.Empty;
            captchaPictureBox.Visible = false;
            captchaLabel.Visible = true;
            captchaTextBox.Visible = true;
            listenCheckBox.Visible = true;

            loadingTimer.Enabled = true;
            loadingLabel.Visible = true;
            
            string captchaLink = await Task.Run(GetCaptchaLink);
            Image captchaImage = await Task.Run(() => GetCaptcha(captchaLink));

            loadingTimer.Enabled = false;
            loadingLabel.Visible = false;
            captchaPictureBox.Visible = true;

            captchaPictureBox.Image = captchaImage;
        }
        
        private Task<string> GetCaptchaLink()
        {
            YAuthCaptcha captcha = _ymClient.GetCaptcha();

            _captchaVoiceUrl = captcha.Voice.Url;
            _captchaVoiceIntroUrl = captcha.Voice.IntroUrl;
            
            return Task.FromResult(captcha.ImageUrl);
        }
        
        private Task<Image> GetCaptcha(string link)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(link);
            request.Method = "GET";

            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            using (Stream stream = response.GetResponseStream())
            {
                Image captchaImage = Image.FromStream(stream);
                return Task.FromResult(captchaImage);
            }
        }

        private void loadingTimer_Tick(object sender, EventArgs e)
        {
            if (loadingLabel.Text.Count(x => x == '.') < 3) loadingLabel.Text += '.';
            else loadingLabel.Text = "Загрузка";
        }

        private void otpTextBox_TextChanged(object sender, EventArgs e)
        {
            loginButton.Enabled = otpTextBox.Text.Length >= 8;
        }

        private async void listenCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (!listenCheckBox.Checked)
            {
                _cancelTokenSource.Cancel();
                return;
            }

            _cancelTokenSource = new CancellationTokenSource();

            Task introTask = Task.Run(() => PlayAudioByUrlAsync(_captchaVoiceIntroUrl, _cancelTokenSource.Token), _cancelTokenSource.Token);
            await introTask;

            if (_cancelTokenSource.IsCancellationRequested) return;
            
            _cancelTokenSource = new CancellationTokenSource();
            
            Task codeTask = Task.Run(() => PlayAudioByUrlAsync(_captchaVoiceUrl, _cancelTokenSource.Token), _cancelTokenSource.Token);
            await codeTask;

            listenCheckBox.Checked = false;
        }
        
        private async Task PlayAudioByUrlAsync(string url, CancellationToken token)
        {
            TaskCompletionSource<object> tcs = new TaskCompletionSource<object>();
        
            MediaFoundationReader mf = new MediaFoundationReader(url);
            WasapiOut wasapiOut = new WasapiOut();
            
            token.Register(wasapiOut.Stop);
            
            void PlaybackStopped(object sender, StoppedEventArgs e)
            { 
                wasapiOut.PlaybackStopped -= PlaybackStopped;
                
                mf.Dispose();
                wasapiOut.Dispose();
                
                tcs.SetResult(null);
            }
            
            wasapiOut.PlaybackStopped += PlaybackStopped;
            
            wasapiOut.Init(mf);
            wasapiOut.Play();
        
            await tcs.Task;
        }
    }
}
