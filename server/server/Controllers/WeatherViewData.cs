using System.Collections.Generic;

namespace server.Controllers
{
    public class WeatherViewData
    {
        public string City { get; set; }
        public WeatherDTO Current { get; set; }
        public List<WeatherDTO> NextFiveDays { get; set; }
    }
}