using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Windows.Forms;
using Svg;
using Yandex.Music.Client;

namespace Winter.YandexMultiStepAuth
{
    public partial class QrCodeUserControl : StepUserControl
    {
        public QrCodeUserControl(YandexMusicClient ymClient) : base(ymClient)
        {
            InitializeComponent();
        }

        private async void QrCodeUserControl_Load(object sender, EventArgs e)
        {
            buttonAccept.Enabled = false;
            
            string qrCodeLink = await Task.Run(GetQrCodeLink);

            pictureBoxQrCode.Image = await Task.Run(() => GetQrCode(qrCodeLink));
            
            labelLoading.Visible = false;
            timerLoading.Enabled = false;
            buttonAccept.Enabled = true;
        }

        private void timerLoading_Tick(object sender, EventArgs e)
        {
            if (labelLoading.Text.Count(x => x == '.') < 3)
            {
                labelLoading.Text += '.';
            }
            else
            {
                labelLoading.Text = "Загрузка";
            }
        }

        private async void buttonAccept_Click(object sender, EventArgs e)
        {
            Application.UseWaitCursor = true;
            buttonAccept.Enabled = false;
            
            bool ok = await Task.Run(TryAuthorize);
            
            if (ok)
            {
                ParentForm.Close();
                MessageBox.Show("Авторизация прошла успешно");
            }
            else
            {
                MessageBox.Show("QR-код не отсканирован");
            }
            
            buttonAccept.Enabled = true;
            Application.UseWaitCursor = false;
        }

        private Task<bool> TryAuthorize()
        {
            bool ok;
            try
            {
                ok = _ymClient.AuthorizeByQR();
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
        
        private Task<string> GetQrCodeLink()
        {
            return Task.FromResult(_ymClient.GetAuthQRLink());
        }
        
        private Task<Bitmap> GetQrCode(string link)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(link);
            request.Method = "GET";

            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            using (Stream stream = response.GetResponseStream())
            {
                SvgDocument svg = SvgDocument.Open<SvgDocument>(stream);
                Bitmap bitmap = svg.Draw(rasterWidth: 265, rasterHeight: 265);
                return Task.FromResult(bitmap);
            }
        }
    }
}
