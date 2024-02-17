using Robin.NetStandard.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Robin.NetStandard.Entities
{
    public class Seat
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("space_id")]
        public int SpaceId { get; set; }

        [JsonPropertyName("zone_id")]
        public int ZoneId { get; set; }

        [JsonPropertyName("is_reservable")]
        public bool IsReservable { get; set; }

        [JsonPropertyName("is_disabled")]
        public bool IsDisabled { get; set; }

        [JsonPropertyName("disabled_at")]
        [JsonConverter(typeof(DateTimeOffsetParseConverter))]
        public DateTimeOffset? DisabledAt { get; set; }

        [JsonPropertyName("created_at")]
        [JsonConverter(typeof(DateTimeOffsetParseConverter))]
        public DateTimeOffset? CreatedAt { get; set; }

        [JsonPropertyName("updated_at")]
        [JsonConverter(typeof(DateTimeOffsetParseConverter))]
        public DateTimeOffset? UpdatedAt { get; set; }
    }
}
