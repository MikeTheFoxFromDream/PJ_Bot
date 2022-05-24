using DSharpPlus;
using System;
using System.Threading.Tasks;

namespace BotTest_486
{
    class Program
    {
        static void Main(string[] args)
        {
            MainAsync().GetAwaiter().GetResult();
        }

        static async Task MainAsync()
        {
            var discord = new DiscordClient(new DiscordConfiguration()
            {
                Token = "<token>",
                TokenType = TokenType.Bot,
                Intents = DiscordIntents.AllUnprivileged
            });

            discord.MessageCreated += async (s, e) =>
            {
                if (e.Message.Content.ToLower().StartsWith("!hello"))
                    await e.Message.RespondAsync("Hello World!");
                if (e.Message.Content.ToLower().StartsWith("!roll"))
                    await e.Message.RespondAsync(Commands.Roll(e.Message.Content));
                
            };

            await discord.ConnectAsync();
            await Task.Delay(-1);
        }
    }
}
