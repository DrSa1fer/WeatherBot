using Telegram.Bot;

namespace WeatherBot.Handlers
{
    public class ErrorBotHandler
    {
        public static async Task ErrorHandlerAsync(ITelegramBotClient client, Exception e, CancellationToken token)
        {
            Console.WriteLine(e);
            await Task.Delay(1, token);
        }
    }
}
