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
                Token = "OTc4NjM3Mzg2OTg2NzA5MDQy.GYNPw4.a2xfkue76fVagfDFLOaHRK3ZHihH4wzoSADIRA",
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
