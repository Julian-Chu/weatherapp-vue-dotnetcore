using System;
using System.Net;
using System.Net.Http;
using Microsoft.AspNetCore.Http;
using server.Model;
using server.Models;

namespace server.Services
{
    public interface IWeatherForecastService
    {
        WeatherForecastResponse GetWeatherForecastData();
    }

    public class WeatherForecastService : IWeatherForecastService
    {
        public WeatherForecastResponse GetWeatherForecastData()
        {
            var apikey = Environment.GetEnvironmentVariable("OPENWEATHER_APIKEY");
            var client = new HttpClient();
            var resp = client.GetAsync(
                    $"https://api.openweathermap.org/data/2.5/forecast?q=furth,de&appid={apikey}")
                .Result;

            if (resp.StatusCode == HttpStatusCode.OK)
            {
                return WeatherForecastResponse.FromJson(resp.Content.ReadAsStringAsync().Result);
            }

            var errorResponse = WeatherForecastErrorResponse.FromJson(resp.Content.ReadAsStringAsync().Result);
            return new WeatherForecastResponse() {StatusCode = errorResponse.Cod, Message = errorResponse.Message};
        }
    }
}