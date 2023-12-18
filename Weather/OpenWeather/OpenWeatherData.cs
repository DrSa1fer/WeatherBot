using Newtonsoft.Json;
using WeatherBot.Weather.Data.OpenWeatherJson;


namespace WeatherBot.Weather.Data
{
    public class OpenWeatherData
    {
        public string Origin { get; }
        public Root? Root { get; }

        public OpenWeatherData(string str)
        {
            Origin = str;
            Root = JsonConvert.DeserializeObject<Root>(str);
        }
        public override string ToString()
        {
            string result = "";
            if (Root != null)
            {
                result += $"City: {Root.Name}\n";
                result += $"Weather: {Root.Weather[0].Description}\n";
                result += $"Temperature: {(Root.Main?.Temp - 32) * 5 / 9} °C\n";
                result += $"Wind:\n";
                result += $" * deg: {Root.Wind?.Deg}\n";
                result += $" * speed: {Root.Wind?.Speed}\n";
                result += $"Cloud: {Root.Clouds?.All}\n";
                result += $"Date: {DateTime.Now}";                
            }

            return result; 
        }
    }
}
namespace WeatherBot.Weather.Data.OpenWeatherJson
{
    public class Clouds
    {
        public int? All { get; set; }
    }

    public class Coord
    {
        public double? Lon { get; set; }
        public double? Lat { get; set; }
    }

    public class Main
    {
        public double? Temp { get; set; }
        public double? FeelsLike { get; set; }
        public double? TempMin { get; set; }
        public double? TempMax { get; set; }
        public int? Pressure { get; set; }
        public int? Humidity { get; set; }
    }

    public class Root
    {
        public Coord? Coord { get; set; }
        public List<Weather>? Weather { get; set; }
        public string? Base { get; set; }
        public Main? Main { get; set; }
        public int? Visibility { get; set; }
        public Wind? Wind { get; set; }
        public Clouds? Clouds { get; set; }
        public int? Dt { get; set; }
        public Sys? Sys { get; set; }
        public int? Timezone { get; set; }
        public int? Id { get; set; }
        public string? Name { get; set; }
        public int? Cod { get; set; }
    }

    public class Sys
    {
        public int? Type { get; set; }
        public int? Id { get; set; }
        public string? Country { get; set; }
        public int? Sunrise { get; set; }
        public int? Sunset { get; set; }
    }

    public class Weather
    {
        public int? Id { get; set; }
        public string? Main { get; set; }
        public string? Description { get; set; }
        public string? Icon { get; set; }
    }

    public class Wind
    {
        public double? Speed { get; set; }
        public int? Deg { get; set; }
        public double? Gust { get; set; }
    }

}