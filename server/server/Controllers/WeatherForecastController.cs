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

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IWeatherForecastService service=null)
        {
            _logger = logger;
            _service = service??new WeatherForecastService();
        }

        [HttpGet]
        public ActionResult<IEnumerable<WeatherForecastResponse>> Get()
        {
            var resp = _service.GetWeatherForecastData();

            switch (resp.StatusCode)
            {
                case StatusCodes.Status200OK:
                    var list = new List<WeatherForecastResponse>() {resp};
                    return Ok(list);
                case StatusCodes.Status401Unauthorized:
                    _logger.LogError("apikey is expired or invalid");
                    return StatusCode(StatusCodes.Status503ServiceUnavailable);
            }


            return BadRequest();
        }
    }
}