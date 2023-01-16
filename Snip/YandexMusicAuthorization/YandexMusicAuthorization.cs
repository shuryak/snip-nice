using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using Yandex.Music.Api.Models.Queue;
using Yandex.Music.Client;

namespace Winter
{
    public partial class YandexMusicAuthorization : Form
    {
        private readonly YandexMusicClient _ymClient;
        
        public YandexMusicAuthorization(YandexMusicClient ymClient)
        {
            _ymClient = ymClient;
            InitializeComponent();
        }

        private void ShowQueue()
        {
            YQueue queue = _ymClient.GetQueue(_ymClient.QueuesList().Queues[0].Id);
            if (queue.CurrentIndex != null)
            {
                MessageBox.Show(_ymClient.GetTrack(queue.Tracks[(int)queue.CurrentIndex].TrackId).Title);
            }
        }

        private async void buttonCodeAuthorize_Click(object sender, EventArgs e)
        {
            await Task.Run(ShowQueue);
        }
    }
}
