// <auto-generated />
//
// To parse this JSON data, add NuGet 'Newtonsoft.Json' then do:
//
//    using server.Model;
//
//    var weatherForecastErrorResponse = WeatherForecastErrorResponse.FromJson(jsonString);

namespace server.Model
{
    using System;
    using System.Collections.Generic;
    using Newtonsoft.Json;

    public partial class WeatherForecastErrorResponse
    {
        [JsonProperty("cod")]
        public int StatusCode { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }
    }

    public partial class WeatherForecastErrorResponse
    {
        public static WeatherForecastErrorResponse FromJson(string json) => JsonConvert.DeserializeObject<WeatherForecastErrorResponse>(json, server.Model.Converter.Settings);
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
}
