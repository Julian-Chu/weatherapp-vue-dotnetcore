// <auto-generated />
//
// To parse this JSON data, add NuGet 'Newtonsoft.Json' then do:
//
//    using serverModels;
//
//    var weatherForecastResponse = WeatherForecastResponse.FromJson(jsonString);

using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace server.Models
{
    public partial class WeatherForecastResponse
    {
        [JsonProperty("cod")]
        public int StatusCode { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("cnt")]
        public int Cnt { get; set; }

        [JsonProperty("list")]
        public List<WeatherData> List { get; set; }

        [JsonProperty("city")]
        public City City { get; set; }
    }

    public partial class City
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("coord")]
        public Coord Coord { get; set; }

        [JsonProperty("country")]
        public string Country { get; set; }

        [JsonProperty("population")]
        public long Population { get; set; }

        [JsonProperty("timezone")]
        public long Timezone { get; set; }

        [JsonProperty("sunrise")]
        public long Sunrise { get; set; }

        [JsonProperty("sunset")]
        public long Sunset { get; set; }
    }


    public partial class WeatherData
    {
        [JsonProperty("dt")]
        public long Dt { get; set; }

        [JsonProperty("main")]
        public MainClass Main { get; set; }

        [JsonProperty("weather")]
        public List<WeatherThreeHours> WeathersList { get; set; }

        [JsonProperty("clouds")]
        public Clouds Clouds { get; set; }

        [JsonProperty("wind")]
        public Wind Wind { get; set; }

        [JsonProperty("rain", NullValueHandling = NullValueHandling.Ignore)]
        public Rain Rain { get; set; }

        [JsonProperty("sys")]
        public Sys Sys { get; set; }

        [JsonProperty("dt_txt")]
        public DateTimeOffset DtTxt { get; set; }
    }


    public partial class MainClass
    {
        [JsonProperty("temp")]
        public double Temp { get; set; }

        [JsonProperty("feels_like")]
        public double FeelsLike { get; set; }

        [JsonProperty("temp_min")]
        public double TempMin { get; set; }

        [JsonProperty("temp_max")]
        public double TempMax { get; set; }

        [JsonProperty("pressure")]
        public long Pressure { get; set; }

        [JsonProperty("sea_level")]
        public long SeaLevel { get; set; }

        [JsonProperty("grnd_level")]
        public long GrndLevel { get; set; }

        [JsonProperty("humidity")]
        public long Humidity { get; set; }

        [JsonProperty("temp_kf")]
        public double TempKf { get; set; }
    }

    public partial class Rain
    {
        [JsonProperty("3h")]
        public double The3H { get; set; }
    }

    public partial class Sys
    {
        [JsonProperty("pod")]
        public Pod Pod { get; set; }
    }

    public partial class WeatherThreeHours
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("main")]
        public MainEnum Main { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("icon")]
        public string Icon { get; set; }
    }


    public enum Pod { D, N };

    public enum MainEnum { Clear, Clouds, Rain };

    public partial class WeatherForecastResponse
    {
        public static WeatherForecastResponse FromJson(string json) => JsonConvert.DeserializeObject<WeatherForecastResponse>(json, Converter.Settings);
    }

    public static class Serialize
    {
        public static string ToJson(this WeatherForecastResponse self) => JsonConvert.SerializeObject(self, Converter.Settings);
    }

    internal class ParseStringConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(long) || t == typeof(long?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            long l;
            if (Int64.TryParse(value, out l))
            {
                return l;
            }
            throw new Exception("Cannot unmarshal type long");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (long)untypedValue;
            serializer.Serialize(writer, value.ToString());
            return;
        }

        public static readonly ParseStringConverter Singleton = new ParseStringConverter();
    }

    internal class PodConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(Pod) || t == typeof(Pod?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            switch (value)
            {
                case "d":
                    return Pod.D;
                case "n":
                    return Pod.N;
            }
            throw new Exception("Cannot unmarshal type Pod");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (Pod)untypedValue;
            switch (value)
            {
                case Pod.D:
                    serializer.Serialize(writer, "d");
                    return;
                case Pod.N:
                    serializer.Serialize(writer, "n");
                    return;
            }
            throw new Exception("Cannot marshal type Pod");
        }

        public static readonly PodConverter Singleton = new PodConverter();
    }

    internal class MainEnumConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(MainEnum) || t == typeof(MainEnum?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            switch (value)
            {
                case "Clear":
                    return MainEnum.Clear;
                case "Clouds":
                    return MainEnum.Clouds;
                case "Rain":
                    return MainEnum.Rain;
            }
            throw new Exception("Cannot unmarshal type MainEnum");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (MainEnum)untypedValue;
            switch (value)
            {
                case MainEnum.Clear:
                    serializer.Serialize(writer, "Clear");
                    return;
                case MainEnum.Clouds:
                    serializer.Serialize(writer, "Clouds");
                    return;
                case MainEnum.Rain:
                    serializer.Serialize(writer, "Rain");
                    return;
            }
            throw new Exception("Cannot marshal type MainEnum");
        }

        public static readonly MainEnumConverter Singleton = new MainEnumConverter();
    }
}
