using WeatherBot.Weather.Data;

namespace WeatherBot.Weather;

public class OpenWeatherParser
{
    public static float LifeTime { get; private set; } = 3600; //in sec

    public static OpenWeatherData? ParseResult { get; private set; }
    public static DateTime LastParseTime { get; private set; }
    
    public static async Task<OpenWeatherData> ParseAsync(string city = "krasnodar")
    {
        if(ParseResult != null && (LastParseTime - DateTime.Now).TotalSeconds < LifeTime)
        {
            return ParseResult;
        }

        var client = new HttpClient();
        var request = new HttpRequestMessage
        {
            Method = HttpMethod.Get,
            RequestUri = new Uri($"https://open-weather13.p.rapidapi.com/city/{city}"),
            Headers =
            {
                { "X-RapidAPI-Key", "16d22a2978msh8153e0364d9bed7p1f3d6fjsn3488c8e252e4" },
                { "X-RapidAPI-Host", "open-weather13.p.rapidapi.com" },
            },
        };
        using var response = await client.SendAsync(request);

        response.EnsureSuccessStatusCode();
        var body = await response.Content.ReadAsStringAsync();

        ParseResult = new OpenWeatherData(body);
        LastParseTime = DateTime.Now;

        return ParseResult;
    }
}