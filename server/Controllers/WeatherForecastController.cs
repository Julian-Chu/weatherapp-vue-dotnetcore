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

namespace server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public ActionResult<IEnumerable<WeatherForecastResponse>> Get()
        {
            var apikey = Environment.GetEnvironmentVariable("OPENWEATHER_APIKEY");
            var client = new HttpClient();
            var resp = client.GetAsync(
                    $"https://api.openweathermap.org/data/2.5/forecast?q=furth,de&appid={apikey}")
                .Result;

            switch (resp.StatusCode)
            {
                case HttpStatusCode.OK:
                    var weatherForecastResponse =
                        WeatherForecastResponse.FromJson(resp.Content.ReadAsStringAsync().Result);
                    return new List<WeatherForecastResponse>() {weatherForecastResponse};
                case HttpStatusCode.Unauthorized:
                    _logger.LogError("apikey is expired or invalid");
                    return StatusCode(StatusCodes.Status503ServiceUnavailable);
            }


            return BadRequest();
        }
    }
}