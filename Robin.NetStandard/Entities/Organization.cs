using Robin.NetStandard.Converters;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Robin.NetStandard.Entities
{
    public class Organization:Entity
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("is_organization")]
        public bool IsOrganization { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("slug")]
        public string Slug { get; set; }

        [JsonPropertyName("avatar")]
        public string Uri { get; set; }

        [JsonPropertyName("updated_at")]
        [JsonConverter(typeof(DateTimeOffsetParseConverter))]
        public DateTimeOffset UpdatedAt { get; set; }

        [JsonPropertyName("created_at")]
        [JsonConverter(typeof(DateTimeOffsetParseConverter))]
        public DateTimeOffset CreatedAt { get; set; }
    }
}
