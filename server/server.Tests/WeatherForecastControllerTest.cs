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
        public void Get_OK()
        {
            service.GetWeatherForecastData().Returns(new WeatherForecastResponse(){StatusCode = StatusCodes.Status200OK});
            
            var result =  controller.Get().Result as OkObjectResult;
            Assert.NotNull(result);
            Assert.AreEqual(StatusCodes.Status200OK,result.StatusCode );
        }
        
        [Test]
        public void Get_ServiceUnavailable_When_Service_ReturnsUnauthorized()
        {
            service.GetWeatherForecastData().Returns(new WeatherForecastResponse(){StatusCode = StatusCodes.Status401Unauthorized});
            
            var result =  controller.Get().Result as StatusCodeResult;
            
            Assert.NotNull(result);
            Assert.AreEqual(StatusCodes.Status503ServiceUnavailable,result.StatusCode);
        }
        [Test]
        public void Get_NotFound_When_Service_ReturnsNotFound ()
        {
            service.GetWeatherForecastData().Returns(new WeatherForecastResponse(){StatusCode = StatusCodes.Status404NotFound});
            
            var result =  controller.Get().Result as StatusCodeResult;
            
            Assert.NotNull(result);
            Assert.AreEqual(StatusCodes.Status404NotFound,result.StatusCode);
        }
    }
}