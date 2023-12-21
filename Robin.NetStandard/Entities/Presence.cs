using Robin.NetStandard.Converters;
using System.Runtime.InteropServices;
using System.Text.Json.Serialization;

namespace Robin.NetStandard.Entities
{
    public class Presence:Entity
    {
        [JsonPropertyName("location_id")]
        public int LocationId { get; set; }

        [JsonPropertyName("space_id")]
        public int SpaceId { get; set; }

        [JsonPropertyName("user_id")]
        public int UserId { get; set; }

        [JsonPropertyName("device_id")]
        public int DeviceId { get; set; }

        [JsonPropertyName("last_seen_at")]
        [JsonConverter(typeof(DateTimeOffsetParseConverter))]
        public DateTimeOffset? LastSeenAt { get; set; }

        [JsonPropertyName("arrived_at")]
        [JsonConverter(typeof(DateTimeOffsetParseConverter))]
        public DateTimeOffset? ArrivedAt { get; set; }

        [JsonPropertyName("expired_at")]
        [JsonConverter(typeof(DateTimeOffsetParseConverter))]
        public DateTimeOffset? ExpiredAt { get; set; }

        [JsonPropertyName("session_ttl")]
        public int SessionTtl { get; set; }

        [JsonPropertyName("session_active")]
        public bool SessionActive { get; set; }

        [JsonPropertyName("user")]
        public User User { get; set; }
    }
}
