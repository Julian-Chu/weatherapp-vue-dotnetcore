using System;
using System.Net.Http;

namespace server.Services
{
    public interface IWeatherForecastService
    {
        HttpResponseMessage GetWeatherForecastData();
    }

    public class WeatherForecastService : IWeatherForecastService
    {
        public HttpResponseMessage GetWeatherForecastData()
        {
            var apikey = Environment.GetEnvironmentVariable("OPENWEATHER_APIKEY");
            var client = new HttpClient();
            var resp = client.GetAsync(
                    $"https://api.openweathermap.org/data/2.5/forecast?q=furth,de&appid={apikey}")
                .Result;
            return resp;
        }
    }
}