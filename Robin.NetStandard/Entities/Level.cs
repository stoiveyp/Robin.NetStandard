﻿using Robin.NetStandard.Converters;
using System.Text.Json.Serialization;

namespace Robin.NetStandard.Entities
{
    public class Level:Entity
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("location_id")]
        public int LocationId { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("level_number")]
        public int? LevelNumber { get; set; }

        [JsonPropertyName("updated_at")]
        [JsonConverter(typeof(DateTimeOffsetParseConverter))]
        public DateTimeOffset? UpdatedAt { get; set; }

        [JsonPropertyName("created_at")]
        [JsonConverter(typeof(DateTimeOffsetParseConverter))]
        public DateTimeOffset? CreatedAt { get; set; }
    }
}
