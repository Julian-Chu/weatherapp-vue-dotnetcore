using System.Net;
using System.Net.Http;
using Castle.Core.Logging;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NSubstitute;
using NUnit.Framework;
using server.Controllers;
using server.Models;
using server.Services;

namespace server.Tests
{
    public class Tests
    {
        WeatherForecastController controller;
        IWeatherForecastService service;

        [SetUp]
        public void Setup()
        {
            service = Substitute.For<IWeatherForecastService>();
            var logger = Substitute.For<ILogger<WeatherForecastController>>();
            controller = new WeatherForecastController(logger, service);
        }

        [Test]
        public void Get()
        {
            service.GetWeatherForecastData().Returns(new WeatherForecastResponse(){StatusCode = StatusCodes.Status200OK});
            
            var result =  controller.Get().Result as OkObjectResult;
            Assert.NotNull(result);
            Assert.AreEqual(StatusCodes.Status200OK,result.StatusCode );
        }
    }
}