using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using server.Models;
using server.Services;

namespace server.Controllers
{
    [ApiController]
    [Route("api/weather/[controller]")]
    public class ForecastController : ControllerBase
    {
        private readonly ILogger<ForecastController> _logger;
        private readonly IWeatherForecastService _service;

        public ForecastController(ILogger<ForecastController> logger,
            IWeatherForecastService service)
        {
            _logger = logger;
            _service = service;
        }

        [HttpGet]
        public ActionResult<WeatherViewData> Get(int zipCode, string cityName )
        {
            var resp = _service.GetWeatherForecastData(zipCode, cityName);
            switch (resp.StatusCode)
            {
                case StatusCodes.Status200OK:
                    return Ok(CreateWeatherViewData(resp));
                case StatusCodes.Status400BadRequest:
                    return new BadRequestObjectResult(CreateErrResponse(resp));
                case StatusCodes.Status404NotFound:
                    return NotFound();
            }

            _logger.LogError("apikey is expired or invalid");
            return StatusCode(StatusCodes.Status503ServiceUnavailable);
        }

        private WeatherViewData CreateErrResponse(WeatherForecastResponse resp)
        {
            var viewData = new WeatherViewData();
            viewData.Message = resp.Message;
            return viewData;
        }

        private  WeatherViewData CreateWeatherViewData(WeatherForecastResponse resp)
        {
            var viewData = new WeatherViewData();
            viewData.Message = resp.Message;
            viewData.City = resp.City.Name;
            viewData.Current = new WeatherDTO()
            {
                Humidity = resp.List[0].Main.Humidity,
                Temperature = ConvertToCelsius(resp.List[0].Main.Temp) // Kelvin to Celsius
            };
            viewData.DateTime = resp.List[0].Dt * 1000; // to ms
            viewData.NextFiveDays = new List<WeatherDTO>();
            const int dataPointsPerDay = 8;
            for (int i = 0; i < 5; i++)
            {
                var dailyWeatherData = resp.List.Skip(i * dataPointsPerDay).Take(dataPointsPerDay).ToList();
                var humidity = dailyWeatherData.Sum(data => data.Main.Humidity) /
                               (double) dataPointsPerDay;
                var temp = dailyWeatherData.Sum(data => data.Main.Temp) /
                           (double) dataPointsPerDay;
                var w = new WeatherDTO
                {
                    Humidity = Math.Round(humidity, 2),
                    Temperature = ConvertToCelsius(temp)  // Kelvin to Celsius
                };
                viewData.NextFiveDays.Add(w);
            }

            return viewData;
        }

        private static double ConvertToCelsius(double temp)
        {
            return Math.Round(temp - 273.15, 2);
        }
    }

    public class WeatherDTO
    {
        public double Humidity { get; set; }
        public double Temperature { get; set; }
    }
}