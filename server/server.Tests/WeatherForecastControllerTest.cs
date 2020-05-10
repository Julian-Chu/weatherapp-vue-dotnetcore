using Castle.Core.Logging;
using Microsoft.Extensions.Logging;
using NSubstitute;
using NUnit.Framework;
using server.Controllers;
using server.Services;

namespace server.Tests
{
    public class Tests
    {
            WeatherForecastController controller;
        [SetUp]
        public void Setup()
        {
            var service = Substitute.For<IWeatherForecastService>();
            var logger = Substitute.For<ILogger<WeatherForecastController>>();
            controller = new WeatherForecastController(logger);
        }

        [Test]
        public void Get()
        {
            
        }
    }
}