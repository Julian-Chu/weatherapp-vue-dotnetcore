using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using server.Models;
using server.Services;

namespace server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly ILogger<WeatherForecastController> _logger;
        private readonly IWeatherForecastService _service;

        public WeatherForecastController(ILogger<WeatherForecastController> logger,
            IWeatherForecastService service = null)
        {
            _logger = logger;
            _service = service ?? new WeatherForecastService();
        }

        [HttpGet]
        public ActionResult<WeatherViewData> Get()
        {
            var resp = _service.GetWeatherForecastData();


            switch (resp.StatusCode)
            {
                case StatusCodes.Status200OK:
                    var viewData = new WeatherViewData();
                    viewData.City = resp.City.Name;
                    viewData.Current = new WeatherDTO()
                    {
                        Humidity = resp.List[0].Main.Humidity,
                        Temperature = resp.List[0].Main.Temp
                    };
                    viewData.NextFiveDays = new List<WeatherDTO>();
                    var pageSize = 8;
                    for (int i = 0; i < 5; i++)
                    {
                        var humidity = resp.List.Skip(i * pageSize).Take(pageSize).Sum(w => w.Main.Humidity) /
                                       (double) pageSize;
                        var temp = resp.List.Skip(i * pageSize).Take(pageSize).Sum(w => w.Main.Temp) /
                                   (double) pageSize;
                        var w = new WeatherDTO
                        {
                            Humidity = Math.Round(humidity, 2),
                            Temperature = Math.Round(temp, 2)
                        };
                        viewData.NextFiveDays.Add(w);
                    }

                    return Ok(viewData);
                case StatusCodes.Status404NotFound:
                    return NotFound();
            }

            _logger.LogError("apikey is expired or invalid");
            return StatusCode(StatusCodes.Status503ServiceUnavailable);
        }
    }

    public class WeatherViewData
    {
        public string City { get; set; }
        public WeatherDTO Current { get; set; }
        public List<WeatherDTO> NextFiveDays { get; set; }
    }

    public class WeatherDTO
    {
        public double Humidity { get; set; }
        public double Temperature { get; set; }
    }
}