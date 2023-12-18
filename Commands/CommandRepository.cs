using Telegram.Bot;
using Telegram.Bot.Types;
using WeatherBot.Weather;

namespace WeatherBot.Commands
{
    public static class CommandRepository
    {
        private static ITelegramBotClient? _clent;
        private static CancellationToken? _token;

        private static readonly Dictionary<string, Action<Chat>> _dict = new()
        {
            { "/start", chat => _clent?.SendTextMessageAsync(chat, "Hello") },
            { "/today", async chat => _clent?.SendTextMessageAsync(chat, (await OpenWeatherParser.ParseAsync()).ToString()) }
        };        

        public static void UpdateReferences(ITelegramBotClient client, CancellationToken token)
        {
            _clent = client;
            _token = token;
        }
        public static bool IsCommand(string name)
        {
            return _dict.ContainsKey(name);
        }
        public static void InvokeCommand(string name, Update update)
        {
            if (update.Message == null)
            {
                return;
            }          
            if (_dict.TryGetValue(name, out Action<Chat>? action))
            {
                action?.Invoke(update.Message.Chat);
            }
        }
    }
}
