using BlazingDataStore.Common;
using System;
using System.Text.Json.Serialization;

namespace BlazingDataStore.Models
{
    public class Person
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("height")]
        [JsonConverter(typeof(ParseStringConverter))]
        public decimal Height { get; set; }

        [JsonPropertyName("mass")]
        [JsonConverter(typeof(ParseStringConverter))]
        public decimal Mass { get; set; }

        [JsonPropertyName("hair_color")]
        public string HairColor { get; set; }

        [JsonPropertyName("skin_color")]
        public string SkinColor { get; set; }

        [JsonPropertyName("eye_color")]
        public string EyeColor { get; set; }

        [JsonPropertyName("birth_year")]
        public string BirthYear { get; set; }

        [JsonPropertyName("gender")]
        public string Gender { get; set; }

        [JsonPropertyName("homeworld")]
        public string Homeworld { get; set; }

        [JsonPropertyName("films")]
        public string[] Films { get; set; }

        [JsonPropertyName("species")]
        public string[] Species { get; set; }

        [JsonPropertyName("vehicles")]
        public string[] Vehicles { get; set; }

        [JsonPropertyName("starships")]
        public string[] Starships { get; set; }

        [JsonPropertyName("created")]
        public DateTime Created { get; set; }

        [JsonPropertyName("edited")]
        public DateTime Edited { get; set; }

        [JsonPropertyName("url")]
        public string Url { get; set; }
    }
}
