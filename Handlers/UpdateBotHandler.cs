using Telegram.Bot;
using Telegram.Bot.Types;
using WeatherBot.Commands;

namespace WeatherBot.Handlers
{
    public class UpdateBotHandler
    {        
        public static async Task UpdateHandlerAsync(ITelegramBotClient client, Update update, CancellationToken token)
        {
            if (update.Message == null) return;

            string text = update.Message.Text!;

            if (!CommandRepository.IsCommand(text))
            {                
                await client.SendTextMessageAsync(update.Message.Chat, $"Unknown", cancellationToken: token);
                return;                    
            }
            CommandRepository.UpdateReferences(client, token);
            CommandRepository.InvokeCommand(text, update);
        }
    }
}
