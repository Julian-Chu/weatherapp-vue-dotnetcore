using System.Collections.Generic;
using Newtonsoft.Json;

namespace server.Controllers
{
    public class WeatherViewData
    {
        [JsonProperty("city")]
        public string City { get; set; }
        [JsonProperty("current")]
        public WeatherDTO Current { get; set; }
        [JsonProperty("nextFiveDays")]
        public List<WeatherDTO> NextFiveDays { get; set; }
        [JsonProperty("Message")]
        public string Message { get; set; }
    }
}