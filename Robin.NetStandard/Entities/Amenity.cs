using Robin.NetStandard.Converters;
using System.Text.Json.Serialization;

namespace Robin.NetStandard.Entities
{
    public class Amenity
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("account_id")]
        public int? AccountId { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("owner_types")]
        public string[] OwnerTypes { get; set; }

        [JsonPropertyName("updated_at")]
        [JsonConverter(typeof(DateTimeOffsetParseConverter))]
        public DateTimeOffset? UpdatedAt { get; set; }

        [JsonPropertyName("created_at")]
        [JsonConverter(typeof(DateTimeOffsetParseConverter))]
        public DateTimeOffset? CreatedAt { get; set; }
    }
}
