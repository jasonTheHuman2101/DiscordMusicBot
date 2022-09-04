using Discord.WebSocket;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DiscordMusicBot
{
    static class CommandHandler
    {
        public static async Task CommandExecuted(SocketSlashCommand arg)
        {
            //Gets the command arguments from the response. For some reason, i was unable to access the options directly
            List<SocketSlashCommandDataOption> options = new List<SocketSlashCommandDataOption>();
            foreach (SocketSlashCommandDataOption option in arg.Data.Options)
            {
                options.Add(option);
            }
            
            Uri result; //Needed to use the url tester below
            bool isValidURL = Uri.TryCreate((string)options[0].Value, UriKind.Absolute, out result); //Test if the link is valid

            if (!isValidURL) //invalid link, warn user
            {
                await arg.RespondAsync($"The link provided is an invalid URL");
            }
            else //The link is a valid url
            {
                await arg.RespondAsync($"Valid link!");
            }
        }
    }
}
