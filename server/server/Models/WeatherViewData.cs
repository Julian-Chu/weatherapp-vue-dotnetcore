using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using server.Controllers;

namespace server.Models
{
    public class WeatherViewData
    {
        [JsonProperty("city")]
        public string City { get; set; }
        [JsonProperty("current")]
        public WeatherDTO Current { get; set; }
        [JsonProperty("nextFiveDays")]
        public List<WeatherDTO> NextFiveDays { get; set; }
        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("datetime")]
        public long DateTime { get; set; }
    }
}