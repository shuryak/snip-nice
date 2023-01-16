using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Windows.Forms;
using Svg;
using Yandex.Music.Client;

namespace Winter
{
    public partial class QrCodeAuthUserControl : YmAuthUserControl
    {
        public QrCodeAuthUserControl(YandexMusicClient ymClient) : base(ymClient)
        {
            InitializeComponent();
        }

        private async void QrCodeAuthUserControl_Load(object sender, EventArgs e)
        {
            await Task.Run(LoadQr);
        }
        
        private void LoadQr()
        {
            string authQrCodeLink = _ymClient.GetAuthQRLink();
            
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(authQrCodeLink);
            request.Method = "GET";
            request.KeepAlive = true;
            
            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            using (Stream stream = response.GetResponseStream())
            {
                SvgDocument svg = SvgDocument.Open<SvgDocument>(stream);
                Bitmap bitmap = svg.Draw(rasterWidth: 265, rasterHeight: 265);
                pictureBoxAuthQrCode.Image = bitmap;
            }

            labelQrCodeLoading.Visible = false;
            timerQrCodeLoading.Enabled = false;
        }

        private void timerQrCodeLoading_Tick(object sender, EventArgs e)
        {
            if (labelQrCodeLoading.Text.Count(x => x == '.') < 3)
            {
                labelQrCodeLoading.Text += '.';
            }
            else
            {
                labelQrCodeLoading.Text = "Загрузка";
            }
        }

        private async void buttonQrAuthorize_Click(object sender, EventArgs e)
        {
            await Task.Run(AuthorizeQr);
        }

        private void AuthorizeQr()
        {
            buttonQrAuthorize.Enabled = false;
            Application.UseWaitCursor = true;
            try 
            {
                _ymClient.AuthorizeByQR();
                _ymClient.Authorize(_ymClient.GetAccessToken().AccessToken);
                
                buttonQrAuthorize.Enabled = true;
                Application.UseWaitCursor = false;
                if (_ymClient.IsAuthorized)
                {
                    CloseParentForm();
                    MessageBox.Show("Авторизация прошла успешно");
                }
                else
                {
                    MessageBox.Show("QR-код не отсканирован");
                }
            }
            catch (Exception)
            {
                buttonQrAuthorize.Enabled = true;
                Application.UseWaitCursor = false;
                MessageBox.Show("QR-код не отсканирован");
            }
        }
    }
}
