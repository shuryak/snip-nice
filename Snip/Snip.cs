﻿#region File Information
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

using System.IO;
using Winter.Players;
using Yandex.Music.Client;

namespace Winter
{
    using System;
    using System.Globalization;
    using System.Reflection;
    using System.Resources;
    using System.Windows.Forms;
    using Microsoft.Win32;

    public partial class Snip : Form
    {
        #region Fields

        private KeyboardHook _keyboardHook = new KeyboardHook();
        private readonly YandexMusicClient _ymClient = new YandexMusicClient();

        #endregion

        #region Constructor

        public Snip()
        {
            Globals.ResourceManager = ResourceManager.CreateFileBasedResourceManager("Strings", Application.StartupPath + @"/Resources", null);

            // Immediately set all of the localization
            SetLocalizedMessages();

            Globals.DefaultTrackFormat = LocalizedMessages.TrackFormat;
            Globals.DefaultSeparatorFormat = " " + LocalizedMessages.SeparatorFormat + " ";
            Globals.DefaultArtistFormat = LocalizedMessages.ArtistFormat;
            Globals.DefaultAlbumFormat = LocalizedMessages.AlbumFormat;
            Globals.DefaultRightSeparatorFormat = LocalizedMessages.RightSeparatorFormat;

            this.InitializeComponent();

            this.Load += new EventHandler(this.Snip_Load);
            this.FormClosing += new FormClosingEventHandler(this.Snip_FormClosing);

            // Set the icon of the system tray icon.
            this.notifyIcon.Icon = Properties.Resources.SnipIcon;
            Globals.SnipNotifyIcon = this.notifyIcon;

            // Minimize the main window.
            this.WindowState = FormWindowState.Minimized;

            // Create a blank media player so that the initial call to Unload() won't fuck shit up.
            Globals.CurrentPlayer = new MediaPlayer();

            this.LoadSettings();
            this.timerScanMediaPlayer.Enabled = true;

            // Register global hotkeys
            this.ToggleHotkeys();

            if (CheckVersion.IsNewVersionAvailable())
            {
                this.toolStripMenuItemSnipVersion.Text = LocalizedMessages.NewVersionAvailable;
                this.toolStripMenuItemSnipVersion.Enabled = true;
                this.toolStripMenuItemSnipVersion.Click += ToolStripMenuItemSnipVersion_Click;
            }
        }

        #endregion

        #region Methods

        private static void SetLocalizedMessages()
        {
            LocalizedMessages.SnipForm = Globals.ResourceManager.GetString("SnipForm");
            LocalizedMessages.NewVersionAvailable = Globals.ResourceManager.GetString("NewVersionAvailable");
            LocalizedMessages.NoPlayer = Globals.ResourceManager.GetString("NoPlayer");
            LocalizedMessages.Spotify = Globals.ResourceManager.GetString("Spotify");
            LocalizedMessages.Itunes = Globals.ResourceManager.GetString("Itunes");
            LocalizedMessages.YandexMusic = Globals.ResourceManager.GetString("YandexMusic");
            LocalizedMessages.VLC = Globals.ResourceManager.GetString("VLC");
            LocalizedMessages.SwitchedToPlayer = Globals.ResourceManager.GetString("SwitchedToPlayer");
            LocalizedMessages.PlayerIsNotRunning = Globals.ResourceManager.GetString("PlayerIsNotRunning");
            LocalizedMessages.NoTrackPlaying = Globals.ResourceManager.GetString("NoTrackPlaying");
            LocalizedMessages.SetOutputFormat = Globals.ResourceManager.GetString("SetOutputFormat");
            LocalizedMessages.SaveInformationSeparately = Globals.ResourceManager.GetString("SaveInformationSeparately");
            LocalizedMessages.SaveAlbumArtwork = Globals.ResourceManager.GetString("SaveAlbumArtwork");
            LocalizedMessages.KeepSpotifyAlbumArtwork = Globals.ResourceManager.GetString("KeepSpotifyAlbumArtwork");
            LocalizedMessages.ImageResolutionSmall = Globals.ResourceManager.GetString("ImageResolutionSmall");
            LocalizedMessages.ImageResolutionMedium = Globals.ResourceManager.GetString("ImageResolutionMedium");
            LocalizedMessages.ImageResolutionLarge = Globals.ResourceManager.GetString("ImageResolutionLarge");
            LocalizedMessages.CacheSpotifyMetadata = Globals.ResourceManager.GetString("CacheSpotifyMetadata");
            LocalizedMessages.SaveTrackHistory = Globals.ResourceManager.GetString("SaveTrackHistory");
            LocalizedMessages.DisplayTrackPopup = Globals.ResourceManager.GetString("DisplayTrackPopup");
            LocalizedMessages.EmptyFile = Globals.ResourceManager.GetString("EmptyFile");
            LocalizedMessages.EnableHotkeys = Globals.ResourceManager.GetString("EnableHotkeys");
            LocalizedMessages.ShowFileInFolder = Globals.ResourceManager.GetString("ShowFileInFolder");
            LocalizedMessages.ExitApplication = Globals.ResourceManager.GetString("ExitApplication");
            LocalizedMessages.ItunesException = Globals.ResourceManager.GetString("ItunesException");
            LocalizedMessages.SetOutputFormatForm = Globals.ResourceManager.GetString("SetOutputFormatForm");
            LocalizedMessages.SetTrackFormat = Globals.ResourceManager.GetString("SetTrackFormat");
            LocalizedMessages.SetSeparatorFormat = Globals.ResourceManager.GetString("SetSeparatorFormat");
            LocalizedMessages.SetArtistFormat = Globals.ResourceManager.GetString("SetArtistFormat");
            LocalizedMessages.SetAlbumFormat = Globals.ResourceManager.GetString("SetAlbumFormat");
            LocalizedMessages.SetRightSeparatorFormat = Globals.ResourceManager.GetString("SetRightSeparatorFormat");
            LocalizedMessages.ButtonDefaults = Globals.ResourceManager.GetString("ButtonDefaults");
            LocalizedMessages.ButtonSave = Globals.ResourceManager.GetString("ButtonSave");
            LocalizedMessages.TrackFormat = Globals.ResourceManager.GetString("TrackFormat");
            LocalizedMessages.SeparatorFormat = Globals.ResourceManager.GetString("SeparatorFormat");
            LocalizedMessages.ArtistFormat = Globals.ResourceManager.GetString("ArtistFormat");
            LocalizedMessages.AlbumFormat = Globals.ResourceManager.GetString("AlbumFormat");
            LocalizedMessages.RightSeparatorFormat = Globals.ResourceManager.GetString("RightSeparatorFormat");
        }

        private void KeyboardHook_KeyPressed(object sender, KeyPressedEventArgs e)
        {
            switch (e.Key)
            {
                case Keys.OemOpenBrackets:
                    Globals.CurrentPlayer.ChangeToPreviousTrack();
                    break;

                case Keys.OemCloseBrackets:
                    Globals.CurrentPlayer.ChangeToNextTrack();
                    break;

                case Keys.OemMinus:
                    Globals.CurrentPlayer.DecreasePlayerVolume();
                    break;

                case Keys.Oemplus:
                    Globals.CurrentPlayer.IncreasePlayerVolume();
                    break;

                case Keys.M:
                    Globals.CurrentPlayer.MutePlayerAudio();
                    break;

                case Keys.Enter:
                    Globals.CurrentPlayer.PlayOrPauseTrack();
                    break;

                case Keys.P:
                    Globals.CurrentPlayer.PauseTrack();
                    break;

                case Keys.Back:
                    Globals.CurrentPlayer.StopTrack();
                    break;
            }
        }

        private void Snip_Load(object sender, EventArgs e)
        {
            // Hide the window from ever showing.
            this.Hide();
        }

        private void Snip_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Empty file, clear artwork and save settings automatically when the form is being closed.
            TextHandler.UpdateTextAndEmptyFilesMaybe(LocalizedMessages.NoTrackPlaying);
            Globals.CurrentPlayer.SaveBlankImage();
            Settings.Save();
        }

        private void LoadSettings()
        {
            Settings.Load();

            this.TogglePlayer(Globals.PlayerSelection);

            this.toolStripMenuItemSaveSeparateFiles.Checked = Globals.SaveSeparateFiles;
            this.toolStripMenuItemSaveAlbumArtwork.Checked = Globals.SaveAlbumArtwork;
            this.toolStripMenuItemKeepSpotifyAlbumArtwork.Checked = Globals.KeepSpotifyAlbumArtwork;

            this.ToggleArtwork(Globals.ArtworkResolution);

            this.toolStripMenuItemCacheSpotifyMetadata.Checked = Globals.CacheSpotifyMetadata;
            this.toolStripMenuItemSaveHistory.Checked = Globals.SaveHistory;
            this.toolStripMenuItemDisplayTrackPopup.Checked = Globals.DisplayTrackPopup;
            this.toolStripMenuItemEmptyFileIfNoTrackPlaying.Checked = Globals.EmptyFileIfNoTrackPlaying;
            this.toolStripMenuItemEnableHotkeys.Checked = Globals.EnableHotkeys;
        }

        private void ToggleHotkeys()
        {
            if (this.toolStripMenuItemEnableHotkeys.Checked)
            {
                if (this._keyboardHook == null)
                {
                    this._keyboardHook = new KeyboardHook();
                }

                this._keyboardHook.KeyPressed += new EventHandler<KeyPressedEventArgs>(KeyboardHook_KeyPressed);
                this._keyboardHook.RegisterHotkey(ModifierHookKeys.Control | ModifierHookKeys.Alt, Keys.OemOpenBrackets);    // [
                this._keyboardHook.RegisterHotkey(ModifierHookKeys.Control | ModifierHookKeys.Alt, Keys.OemCloseBrackets);   // ]
                this._keyboardHook.RegisterHotkey(ModifierHookKeys.Control | ModifierHookKeys.Alt, Keys.Oemplus);            // +
                this._keyboardHook.RegisterHotkey(ModifierHookKeys.Control | ModifierHookKeys.Alt, Keys.OemMinus);           // -
                this._keyboardHook.RegisterHotkey(ModifierHookKeys.Control | ModifierHookKeys.Alt, Keys.Enter);              // Enter
                this._keyboardHook.RegisterHotkey(ModifierHookKeys.Control | ModifierHookKeys.Alt, Keys.Back);               // Backspace
                this._keyboardHook.RegisterHotkey(ModifierHookKeys.Control | ModifierHookKeys.Alt, Keys.M);                  // M
                this._keyboardHook.RegisterHotkey(ModifierHookKeys.Control | ModifierHookKeys.Alt, Keys.P);                  // P
            }
            else
            {
                if (this._keyboardHook != null)
                {
                    this._keyboardHook.Dispose();
                    this._keyboardHook = null;
                }
            }
        }

        private void PlayerSelectionCheck(object sender, EventArgs e)
        {
            if (sender == this.toolStripMenuItemNoPlayer)
            {
                this.TogglePlayer(Globals.MediaPlayerSelection.NoPlayer);
            }
            else if (sender == this.toolStripMenuItemSpotify)
            {
                this.TogglePlayer(Globals.MediaPlayerSelection.Spotify);
            }
            else if (sender == this.toolStripMenuItemItunes)
            {
                this.TogglePlayer(Globals.MediaPlayerSelection.Itunes);
            }
            else if (sender == this.toolStripMenuItemYandexMusic)
            {
                this.TogglePlayer(Globals.MediaPlayerSelection.YandexMusic);
            }
            else if (sender == this.toolStripMenuItemVLC)
            {
                this.TogglePlayer(Globals.MediaPlayerSelection.VLC);
            }
        }

        private void TogglePlayer(Globals.MediaPlayerSelection player)
        {
            this.toolStripMenuItemNoPlayer.Checked   = player == Globals.MediaPlayerSelection.NoPlayer;
            this.toolStripMenuItemSpotify.Checked    = player == Globals.MediaPlayerSelection.Spotify;
            this.toolStripMenuItemItunes.Checked     = player == Globals.MediaPlayerSelection.Itunes;
            this.toolStripMenuItemYandexMusic.Checked     = player == Globals.MediaPlayerSelection.YandexMusic;
            this.toolStripMenuItemVLC.Checked        = player == Globals.MediaPlayerSelection.VLC;
            
            Globals.CurrentPlayer.Unload();
            string playerName = string.Empty;
            
            switch (player)
            {
                case Globals.MediaPlayerSelection.NoPlayer:
                    Globals.CurrentPlayer = new NoPlayer();
                    playerName = LocalizedMessages.NoPlayer;
                    break;
                case Globals.MediaPlayerSelection.Spotify:
                    Globals.CurrentPlayer = new Spotify();
                    playerName = LocalizedMessages.Spotify;
                    break;
                case Globals.MediaPlayerSelection.Itunes:
                    Globals.CurrentPlayer = new Itunes();
                    playerName = LocalizedMessages.Itunes;
                    break;
                case Globals.MediaPlayerSelection.YandexMusic:
                    Globals.CurrentPlayer = new YandexMusic(_ymClient);
                    playerName = LocalizedMessages.YandexMusic;
                    break;
                case Globals.MediaPlayerSelection.VLC:
                    Globals.CurrentPlayer = new VLC();
                    playerName = LocalizedMessages.VLC;
                    break;
            }

            Globals.CurrentPlayer.Load();

            Globals.PlayerSelection = player;

            if (playerName == LocalizedMessages.NoPlayer)
            {
                TextHandler.UpdateTextAndEmptyFilesMaybe(LocalizedMessages.NoPlayer);
            }
            else
            {
                TextHandler.UpdateTextAndEmptyFilesMaybe(
                    string.Format(
                        CultureInfo.InvariantCulture,
                        LocalizedMessages.SwitchedToPlayer,
                        playerName));
            }
        }

        private void ToolStripMenuItemSaveSeparateFiles_Click(object sender, EventArgs e)
        {
            this.toolStripMenuItemSaveSeparateFiles.Checked = !this.toolStripMenuItemSaveSeparateFiles.Checked;
            Globals.SaveSeparateFiles = this.toolStripMenuItemSaveSeparateFiles.Checked;
        }

        private void ToolStripMenuItemSaveAlbumArtwork_Click(object sender, EventArgs e)
        {
            this.toolStripMenuItemSaveAlbumArtwork.Checked = !this.toolStripMenuItemSaveAlbumArtwork.Checked;
            Globals.SaveAlbumArtwork = this.toolStripMenuItemSaveAlbumArtwork.Checked;
        }

        private void ToolStripMenuItemKeepSpotifyAlbumArtwork_Click(object sender, EventArgs e)
        {
            this.toolStripMenuItemKeepSpotifyAlbumArtwork.Checked = !this.toolStripMenuItemKeepSpotifyAlbumArtwork.Checked;
            Globals.KeepSpotifyAlbumArtwork = this.toolStripMenuItemKeepSpotifyAlbumArtwork.Checked;
        }

        private void ToolStripMenuItemCacheSpotifyMetadata_Click(object sender, EventArgs e)
        {
            this.toolStripMenuItemCacheSpotifyMetadata.Checked = !this.toolStripMenuItemCacheSpotifyMetadata.Checked;
            Globals.CacheSpotifyMetadata = this.toolStripMenuItemCacheSpotifyMetadata.Checked;
        }

        private void ToolStripMenuItemSaveHistory_Click(object sender, EventArgs e)
        {
            this.toolStripMenuItemSaveHistory.Checked = !this.toolStripMenuItemSaveHistory.Checked;
            Globals.SaveHistory = this.toolStripMenuItemSaveHistory.Checked;
        }

        private void ToolStripMenuItemDisplayTrackPopup_Click(object sender, EventArgs e)
        {
            this.toolStripMenuItemDisplayTrackPopup.Checked = !this.toolStripMenuItemDisplayTrackPopup.Checked;
            Globals.DisplayTrackPopup = this.toolStripMenuItemDisplayTrackPopup.Checked;
        }

        private void ToolStripMenuItemExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void TimerScanMediaPlayer_Tick(object sender, EventArgs e)
        {
            // Make sure this is set before starting the timer.
            //if (Globals.DebuggingIsEnabled)
            //{
            //Debug.MeasureMethod(Globals.CurrentPlayer.Update); // Writes a LOT of data
            //}
            //else
            //{
            Globals.CurrentPlayer.Update();
            //}
        }

        private void ToolStripMenuItemSetFormat_Click(object sender, EventArgs e)
        {
            OutputFormat outputFormat = null;

            try
            {
                outputFormat = new OutputFormat();
                outputFormat.ShowDialog();
            }
            finally
            {
                if (outputFormat != null)
                {
                    outputFormat.Dispose();
                }
            }

            RegistryKey registryKey = Registry.CurrentUser.OpenSubKey(
                string.Format(
                    CultureInfo.InvariantCulture,
                    "SOFTWARE\\{0}\\{1}",
                    AssemblyInformation.AssemblyTitle,
                    Assembly.GetExecutingAssembly().GetName().Version.Major));

            if (registryKey != null)
            {
                Globals.TrackFormat = Convert.ToString(registryKey.GetValue("Track Format", Globals.DefaultTrackFormat), CultureInfo.CurrentCulture);

                Globals.SeparatorFormat = Convert.ToString(registryKey.GetValue("Separator Format", Globals.DefaultSeparatorFormat), CultureInfo.CurrentCulture);

                Globals.ArtistFormat = Convert.ToString(registryKey.GetValue("Artist Format", Globals.DefaultArtistFormat), CultureInfo.CurrentCulture);

                Globals.AlbumFormat = Convert.ToString(registryKey.GetValue("Album Format", Globals.DefaultAlbumFormat), CultureInfo.CurrentCulture);

                Globals.RightSeparatorFormat = Convert.ToString(registryKey.GetValue("Right Separator Format", Globals.DefaultRightSeparatorFormat), CultureInfo.CurrentCulture);
                
                registryKey.Close();
            }
        }
        
        private void AlbumArtworkResolutionCheck(object sender, EventArgs e)
        {
            if (sender == this.toolStripMenuItemSmall)
            {
                this.ToggleArtwork(Globals.AlbumArtworkResolution.Small);
            }
            else if (sender == this.toolStripMenuItemMedium)
            {
                this.ToggleArtwork(Globals.AlbumArtworkResolution.Medium);
            }
            else if (sender == this.toolStripMenuItemLarge)
            {
                this.ToggleArtwork(Globals.AlbumArtworkResolution.Large);
            }
        }

        private void ToggleArtwork(Globals.AlbumArtworkResolution artworkResolution)
        {
            this.toolStripMenuItemSmall.Checked  = artworkResolution == Globals.AlbumArtworkResolution.Small;
            this.toolStripMenuItemMedium.Checked = artworkResolution == Globals.AlbumArtworkResolution.Medium;
            this.toolStripMenuItemLarge.Checked  = artworkResolution == Globals.AlbumArtworkResolution.Large;
            Globals.ArtworkResolution = artworkResolution;
        }

        private void ToolStripMenuItemEmptyFileIfNoTrackPlaying_Click(object sender, EventArgs e)
        {
            this.toolStripMenuItemEmptyFileIfNoTrackPlaying.Checked = !this.toolStripMenuItemEmptyFileIfNoTrackPlaying.Checked;
            Globals.EmptyFileIfNoTrackPlaying = this.toolStripMenuItemEmptyFileIfNoTrackPlaying.Checked;
        }

        private void ToolStripMenuItemEnableHotkeys_Click(object sender, EventArgs e)
        {
            this.toolStripMenuItemEnableHotkeys.Checked = !this.toolStripMenuItemEnableHotkeys.Checked;
            this.ToggleHotkeys();
            Globals.EnableHotkeys = this.toolStripMenuItemEnableHotkeys.Checked;
        }

        private void ToolStripMenuItemSnipVersion_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/dlrudie/Snip/releases/latest");
        }

        #endregion

        private void ToolStripMenuItemShowFileInFolder_Click(object sender, EventArgs e)
        {
            string txtPath = Application.StartupPath + @"\Snip.txt";
            if (!File.Exists(txtPath))
            {
                return;
            }
            
            string argument = $@"/select, ""{txtPath}""";

            System.Diagnostics.Process.Start("explorer.exe", argument);
        }
    }
}
