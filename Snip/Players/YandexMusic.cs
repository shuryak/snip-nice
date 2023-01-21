using System.Collections.Generic;
using System.Timers;
using Winter.YandexMultiStepAuth;
using Yandex.Music.Api.Models.Artist;
using Yandex.Music.Api.Models.Queue;
using Yandex.Music.Api.Models.Track;
using Yandex.Music.Client;

namespace Winter.Players
{
    internal sealed class YandexMusic : MediaPlayer
    {
        private YandexMusicClient _ymClient;
        private const double UpdateYandexMusicTrackInformationDefaultInterval = 2000;
        private Timer _updateYandexMusicTrackInformation;

        public YandexMusic(YandexMusicClient ymClient)
        {
            _ymClient = ymClient;
        }
        
        public override void Load()
        {
            base.Load();
            
            _updateYandexMusicTrackInformation = new Timer(UpdateYandexMusicTrackInformationDefaultInterval);
            _updateYandexMusicTrackInformation.Elapsed += UpdateYandexMusicTrackInformation_Elapsed;
            _updateYandexMusicTrackInformation.AutoReset = true;
            _updateYandexMusicTrackInformation.Enabled = true;
            
            AuthorizeSnip();
        }
        
        public override void Unload()
        {
            base.Unload();
            _ymClient = null;
        }

        private void AuthorizeSnip()
        {
            if (_ymClient.IsAuthorized) return;
            StartForm startForm = new StartForm(_ymClient);
            startForm.Show();
        }
        
        private void UpdateYandexMusicTrackInformation_Elapsed(object sender, ElapsedEventArgs e)
        {
            string queueId = _ymClient.QueuesList().Queues[0].Id;
            YQueue queue = _ymClient.GetQueue(queueId);
            string trackId = queue.Tracks[(int)queue.CurrentIndex].TrackId;

            if (LastTitle != trackId)
            {
                YTrack track = _ymClient.GetTrack(trackId);
                
                List<YArtist> artistsList = track.Artists;
                string artists = string.Empty;
                foreach (YArtist artist in artistsList)
                {
                    artists += artist.Name + ", ";
                }
                artists = artists.Substring(0, artists.LastIndexOf(',')); // Removes last comma

                string title = track.Title;
                string albumId = queue.Tracks[(int)queue.CurrentIndex].AlbumId;
                string albumTitle = _ymClient.GetAlbum(albumId).Title;
                
                TextHandler.UpdateText(title, artists, albumTitle, trackId);
            }

            LastTitle = trackId;
        }
    }
}
