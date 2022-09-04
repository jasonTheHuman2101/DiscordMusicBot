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
            List<SocketSlashCommandDataOption> options = new List<SocketSlashCommandDataOption>();
            foreach (SocketSlashCommandDataOption option in arg.Data.Options)
            {
                options.Add(option);
            }

            await arg.RespondAsync($"Command Received. URL was {options[0].Value}");
        }
    }
}
