using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Newtonsoft.Json;
using server.Controllers;

namespace server.Models
{
    public class WeatherViewData
    {
        [JsonPropertyName("city")]
        public string City { get; set; }
        [JsonPropertyName("current")]
        public WeatherDTO Current { get; set; }
        [JsonPropertyName("nextFiveDays")]
        public List<WeatherDTO> NextFiveDays { get; set; }
        [JsonPropertyName("message")]
        public string Message { get; set; }

        [JsonPropertyName("dateTime")]
        public long DateTime { get; set; }
    }
}