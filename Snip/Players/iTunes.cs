#region File Information
/*
 * Copyright (C) 2012-2022 David Rudie
 *
 * This program is free software; you can redistribute it and/or modify
 * it under the terms of the GNU General Public License as published by
 * the Free Software Foundation; either version 3 of the License, or
 * (at your option) any later version.
 *
 * This program is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * GNU General Public License for more details.
 *
 * You should have received a copy of the GNU General Public License
 * along with this program; if not, write to the Free Software
 * Foundation, Inc., 51 Franklin Street, Fifth Floor, Boston, MA  02111, USA.
 */
#endregion

using System.Globalization;
using System.Windows.Forms;
using iTunesLib;

namespace Winter.Players
{
    internal sealed class Itunes : MediaPlayer
    {
        private iTunesApp _itunesApplication = null;
 
        // This will hold the volume prior to it being muted and restored from it.
        private int muteVolume = 0;

        private delegate void Router(object arg);

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Globalization", "CA1300:SpecifyMessageBoxOptions")]
        public override void Load()
        {
            try
            {
                _itunesApplication = new iTunesApp();

                _itunesApplication.OnPlayerPlayEvent += App_OnPlayerPlayEvent;
                _itunesApplication.OnPlayerPlayingTrackChangedEvent += App_OnPlayerPlayingTrackChangedEvent;
                _itunesApplication.OnPlayerStopEvent += App_OnPlayerStopEvent;
                _itunesApplication.OnQuittingEvent += App_OnPlayerQuittingEvent;
            }
            catch (System.Runtime.InteropServices.COMException comException)
            {
                MessageBox.Show(
                        LocalizedMessages.ItunesException + "\n\n" + comException.Message,
                        LocalizedMessages.SnipForm,
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
            }
        }

        public override void Unload()
        {
            base.Unload();

            if (_itunesApplication == null) return;
            _itunesApplication.OnPlayerPlayEvent -= App_OnPlayerPlayEvent;
            _itunesApplication.OnPlayerPlayingTrackChangedEvent -= App_OnPlayerPlayingTrackChangedEvent;
            _itunesApplication.OnPlayerStopEvent -= App_OnPlayerStopEvent;
            _itunesApplication.OnQuittingEvent -= App_OnPlayerQuittingEvent;

            _itunesApplication = null;
        }

        public override void ChangeToNextTrack()
        {
            _itunesApplication.NextTrack();
        }

        public override void ChangeToPreviousTrack()
        {
            _itunesApplication.PreviousTrack();
        }

        public override void IncreasePlayerVolume()
        {
            _itunesApplication.SoundVolume++;
        }

        public override void DecreasePlayerVolume()
        {
            _itunesApplication.SoundVolume--;
        }

        public override void MutePlayerAudio()
        {
            if (_itunesApplication.SoundVolume > 0)
            {
                muteVolume = _itunesApplication.SoundVolume;
                _itunesApplication.SoundVolume = 0;
            }
            else
            {
                _itunesApplication.SoundVolume = muteVolume;
            }
        }

        public override void PlayOrPauseTrack()
        {
            _itunesApplication.Play();
        }

        public override void PauseTrack()
        {
            _itunesApplication.Pause();
        }

        public override void StopTrack()
        {
            _itunesApplication.Stop();
        }

        private void App_OnPlayerPlayEvent(object sender)
        {
            IITTrack track = _itunesApplication.CurrentTrack;

            if (!string.IsNullOrEmpty(track.Artist) && !string.IsNullOrEmpty(track.Name) && string.IsNullOrEmpty(_itunesApplication.CurrentStreamTitle))
            {
                if (Globals.SaveAlbumArtwork)
                {
                    IITArtworkCollection artworkCollection = track.Artwork;

                    if (artworkCollection.Count > 0)
                    {
                        IITArtwork artwork = artworkCollection[1];

                        artwork.SaveArtworkToFile(DefaultArtworkFilePath);
                    }
                    else
                    {
                        SaveBlankImage();
                    }
                }

                TextHandler.UpdateText(track.Name, track.Artist, track.Album);
            }
            else if (string.IsNullOrEmpty(track.Artist) && !string.IsNullOrEmpty(track.Name) && string.IsNullOrEmpty(_itunesApplication.CurrentStreamTitle))
            {
                TextHandler.UpdateText(track.Name);
            }
            else if (!string.IsNullOrEmpty(_itunesApplication.CurrentStreamTitle))
            {
                TextHandler.UpdateText(_itunesApplication.CurrentStreamTitle);
            }
        }

        private void App_OnPlayerPlayingTrackChangedEvent(object sender)
        {
            IITTrack track = _itunesApplication.CurrentTrack;

            if (!string.IsNullOrEmpty(track.Artist) && !string.IsNullOrEmpty(track.Name) && string.IsNullOrEmpty(_itunesApplication.CurrentStreamTitle))
            {
                if (Globals.SaveAlbumArtwork)
                {
                    try
                    {
                        IITArtworkCollection artworkCollection = track.Artwork;
                        IITArtwork artwork = artworkCollection[1];

                        artwork.SaveArtworkToFile(DefaultArtworkFilePath);
                    }
                    catch
                    {
                        SaveBlankImage();
                        throw;
                    }
                }

                TextHandler.UpdateText(track.Name, track.Artist, track.Album);
            }
            else if (!string.IsNullOrEmpty(_itunesApplication.CurrentStreamTitle))
            {
                TextHandler.UpdateText(_itunesApplication.CurrentStreamTitle);
            }
        }

        private void App_OnPlayerStopEvent(object o)
        {
            if (Globals.SaveAlbumArtwork)
            {
                SaveBlankImage();
            }

            TextHandler.UpdateTextAndEmptyFilesMaybe(LocalizedMessages.NoTrackPlaying);
        }

        private void App_OnPlayerQuittingEvent()
        {
            if (Globals.SaveAlbumArtwork)
            {
                SaveBlankImage();
            }

            TextHandler.UpdateTextAndEmptyFilesMaybe(
                string.Format(
                    CultureInfo.InvariantCulture,
                    LocalizedMessages.PlayerIsNotRunning,
                    LocalizedMessages.Itunes));
        }
    }
}
