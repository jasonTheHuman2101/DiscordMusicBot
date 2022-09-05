using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using YoutubeDLSharp;

namespace DiscordMusicBot
{
    /// <summary>
    /// this class will handle all the interaction between the application and YouTube.
    /// </summary>
    internal class SongHandler
    {
        YoutubeDL ytdl;

        public SongHandler()
        {
            ytdl = new YoutubeDL()
            {
                YoutubeDLPath = "binaries/yt-dlp.exe",
                FFmpegPath = "binaries/ffmpeg/ffmpeg.exe",
                OutputFolder = "downloads/"
            };
        }

        public async Task DownloadSong(string url)
        {

        }
    }
}
