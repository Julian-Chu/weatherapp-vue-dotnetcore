using System.Collections.Generic;
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
    public class ForecastControllerTests
    {
        private ForecastController _controller;
        private ILogger<ForecastController> _mockLogger;
        private IWeatherForecastService _mockService;
        private const int DummyZipCode = 0;
        private const string DummyCityName = "";

        [SetUp]
        public void Setup()
        {
            _mockService = Substitute.For<IWeatherForecastService>();
            _mockLogger = Substitute.For<ILogger<ForecastController>>();
            _controller = new ForecastController(_mockLogger, _mockService);
        }

        [Test]
        public void Get_OK()
        {
            _mockService.GetWeatherForecastData(DummyZipCode, DummyCityName).Returns(new WeatherForecastResponse()
                {
                StatusCode = StatusCodes.Status200OK, City = new City() {Name = "ok"},
                List = new List<WeatherData>() {new WeatherData() {Main = new MainClass() {Humidity = 99, Temp = 20}}}
            });

            var result = _controller.Get(DummyZipCode, DummyCityName).Result as OkObjectResult;
            Assert.NotNull(result);
            Assert.AreEqual(StatusCodes.Status200OK, result.StatusCode);
        }

        [Test]
        public void Get_ServiceUnavailable_When_Service_ReturnsUnauthorized()
        {
            _mockService.GetWeatherForecastData(DummyZipCode, DummyCityName).Returns(new WeatherForecastResponse()
                {StatusCode = StatusCodes.Status401Unauthorized});

            var result = _controller.Get(DummyZipCode, DummyCityName).Result as StatusCodeResult;

            Assert.NotNull(result);
            Assert.AreEqual(StatusCodes.Status503ServiceUnavailable, result.StatusCode);
        }

        [Test]
        public void Get_NotFound_When_Service_ReturnsNotFound()
        {
            _mockService.GetWeatherForecastData(DummyZipCode, DummyCityName).Returns(new WeatherForecastResponse()
                {StatusCode = StatusCodes.Status404NotFound, Message = "notfound"});

            var result = _controller.Get(DummyZipCode, DummyCityName).Result as NotFoundResult;
            Assert.NotNull(result);
            Assert.AreEqual(StatusCodes.Status404NotFound, result.StatusCode);
        }
        [Test]
        public void Get_BadRequest_When_Service_ReturnsBadRequest()
        {
            _mockService.GetWeatherForecastData(DummyZipCode, DummyCityName).Returns(new WeatherForecastResponse()
                {StatusCode = StatusCodes.Status400BadRequest, Message = "test"});

            var resp = _controller.Get(DummyZipCode, DummyCityName);
            var result = resp.Result as BadRequestObjectResult;
            Assert.NotNull(result);
            var data = result.Value as WeatherViewData;
            Assert.AreEqual(StatusCodes.Status400BadRequest, result.StatusCode);
            Assert.AreEqual("test", data?.Message );
        }
    }
}