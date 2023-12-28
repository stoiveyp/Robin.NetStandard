using Robin.NetStandard.Converters;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Robin.NetStandard.Auth
{
    public class AuthData
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("type")]
        public string Type { get; set; }

        [JsonPropertyName("type_id")]
        public int TypeId { get; set; }

        [JsonPropertyName("ip")]
        public string IP { get; set; }

        [JsonPropertyName("agent")]
        public string Agent { get; set; }

        [JsonPropertyName("scopes")]
        public string[] Scopes { get; set; }

        [JsonPropertyName("last_accessed_at")]
        public AccessDateTime LastAccessedAt { get; set; }

        [JsonPropertyName("expire_at")]
        [JsonConverter(typeof(DateTimeOffsetParseConverter))]
        public DateTimeOffset? ExpireAt { get; set; }

        [JsonPropertyName("created_at")]
        [JsonConverter(typeof(DateTimeOffsetParseConverter))]
        public DateTimeOffset? CreatedAt { get; set; }
    }
}
