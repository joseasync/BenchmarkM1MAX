using Newtonsoft.Json;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace BenchmarkM1MAX.Serializer;

public class WeatherSerializer
{
    public string SerializeWeatherForecastToJson(WeatherForecast weatherForecast)
    {
        string json = JsonSerializer.Serialize(weatherForecast);
        return json;
    }
    
    public string SerializeWeatherForecastToJsonUsingNewtonsoft(WeatherForecast weatherForecast)
    {
        string json = JsonConvert.SerializeObject(weatherForecast);
        return json;
    }
}