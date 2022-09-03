using System;
using System.IO;
using System.Threading.Tasks;
using Discord;
using Discord.WebSocket;

namespace DiscordMusicBot
{
    internal class Program
    {
        /* The contents of this file will be primarily
         for handling the connection to the bot. In here should be the
        vial things needed to connect the program to discord. 
        Consider this the bridge between DMB and Discord. */

        static DiscordSocketClient client;
        static string token = File.ReadAllText("token.txt");


        static void Main(string[] args)
        {
            MainAsyncProcess();
            while (true) ;
        }

        static async void MainAsyncProcess()
        {
            Console.WriteLine("========Discord Music Bot v1========\nBy Jason Chesters-salt");
            Console.WriteLine("Attempting to open connection to Discord...");
            client = new DiscordSocketClient();
            client.Log += DiscordLog;
            client.Disconnected += ConnectionLost;
            client.Ready += BotReady;

            await client.LoginAsync(TokenType.Bot, token);
            await client.StartAsync();
            await Task.Delay(-1);
            await client.StopAsync();
            client.Dispose();
        }

        private static async Task BotReady()
        {
            Console.WriteLine("Bot Ready!");
            await LoadCommands();
        }

        private static async Task LoadCommands()
        {
            SlashCommandBuilder globalCommand = new SlashCommandBuilder();
            globalCommand.WithName("test-command");
            globalCommand.WithDescription("Test Command Description");
            try
            {
                SlashCommandProperties scp = globalCommand.Build();
                await client.CreateGlobalApplicationCommandAsync(scp);
            }
            catch(Exception ex)
            {
                Console.WriteLine("An error occured when trying to define the commands");
            }
        }

        private static Task ConnectionLost(Exception arg)
        {
            Console.WriteLine("BOT ATTEMPTING TO RECONNECT!");
            ConnectBot();
            return Task.CompletedTask;
        }

        static async void ConnectBot()
        {
            await client.LoginAsync(TokenType.Bot, token);
            await client.StartAsync();
        }

        private static Task DiscordLog(LogMessage arg)
        {
            Console.WriteLine(arg.ToString());
            return Task.CompletedTask;
        }
    }
}
