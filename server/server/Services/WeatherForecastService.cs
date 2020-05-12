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
        WeatherForecastResponse GetWeatherForecastData(int zipCode, string cityName);
    }

    public class WeatherForecastService : IWeatherForecastService
    {
        public WeatherForecastResponse GetWeatherForecastData(int zipCode, string cityName)
        {
            var apikey = Environment.GetEnvironmentVariable("OPENWEATHER_APIKEY");
            var client = new HttpClient();
            var queryParam = String.IsNullOrEmpty(cityName)? $"zip={zipCode}":$"q={cityName}";
            var resp = client.GetAsync(
                    $"https://api.openweathermap.org/data/2.5/forecast?{queryParam},de&appid={apikey}")
                .Result;

            if (resp.StatusCode == HttpStatusCode.OK)
            {
                return WeatherForecastResponse.FromJson(resp.Content.ReadAsStringAsync().Result);
            }

            var errorResponse = WeatherForecastErrorResponse.FromJson(resp.Content.ReadAsStringAsync().Result);
            return new WeatherForecastResponse() {StatusCode = errorResponse.StatusCode, Message = errorResponse.Message};
        }
    }
}