using Telegram.Bot;
using Telegram.Bot.Polling;
using Telegram.Bot.Types.Enums;
using WeatherBot.Handlers;

namespace WeatherBot
{
    public class Program
    {        
        private static readonly ITelegramBotClient _client = new TelegramBotClient(Config.Config.TOKEN);
        private static readonly ReceiverOptions _receiverOptions = new()
        {
            AllowedUpdates = new[] { UpdateType.Message },
            ThrowPendingUpdates = true,
        };
        private static readonly CancellationTokenSource _cts = new();

        static async Task Main()
        {                        
            _client.StartReceiving
            (
                UpdateBotHandler.UpdateHandlerAsync,
                ErrorBotHandler.ErrorHandlerAsync,
                _receiverOptions,
                _cts.Token
            );
            
            Console.WriteLine("Start WeatherParserBot");

            await Task.Delay(-1);
        }
    }
}