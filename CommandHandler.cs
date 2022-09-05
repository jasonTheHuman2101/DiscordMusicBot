using Discord.WebSocket;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DiscordMusicBot
{
    class CommandHandler
    {
        SongHandler sh;

        public CommandHandler()
        {
            sh = new SongHandler();
        }

        public async Task<Task> CommandExecuted(SocketSlashCommand arg)
        {
            //Gets the command arguments from the response. For some reason, i was unable to access the options directly
            List<SocketSlashCommandDataOption> options = new List<SocketSlashCommandDataOption>();
            foreach (SocketSlashCommandDataOption option in arg.Data.Options)
            {
                options.Add(option);
            }

            string url = (string)options[0].Value;
            if (!url.StartsWith("http")) { url = "https://" + url; }

            Uri result; //Needed to use the url tester below
            bool isValidURL = Uri.TryCreate(url, UriKind.Absolute, out result); //Test if the link is valid

            if (!isValidURL) //invalid link, warn user
            {
                await arg.RespondAsync($"The link provided is an invalid URL");
                return Task.CompletedTask;
            }
            else //The link is a valid url
            {
                await arg.RespondAsync($"Valid link!");
                sh.DownloadSong(url); //Don't run async. It takes time to do the download, so using async could bog the program down and cause it to disconnect
                return Task.CompletedTask;
            }
        }
    }
}
