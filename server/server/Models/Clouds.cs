using Newtonsoft.Json;

namespace server.Models
{
    public partial class Clouds
    {
        [JsonProperty("all")]
        public long All { get; set; }
    }
}