using Robin.NetStandard.Converters;
using System.Text.Json.Serialization;

namespace Robin.NetStandard.Entities
{
    public class User:Entity
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("slug")]
        public string Slug { get; set; }

        [JsonPropertyName("avatar")]
        public Uri Avatar { get; set; }

        [JsonPropertyName("primary_email")]
        public EmailAddress PrimaryEmail { get; set; }

        [JsonPropertyName("updated_at")]
        [JsonConverter(typeof(DateTimeOffsetParseConverter))]
        public DateTimeOffset? UpdatedAt { get; set; }

        [JsonPropertyName("created_at")]
        [JsonConverter(typeof(DateTimeOffsetParseConverter))]
        public DateTimeOffset? CreatedAt { get; set; }

        [JsonPropertyName("disabled_at")]
        [JsonConverter(typeof(DateTimeOffsetParseConverter))]
        public DateTimeOffset? DisabledAt{ get; set; }

        [JsonPropertyName("title")]
        public string Title { get; set; }

        [JsonPropertyName("account")]
        public Organization Account { get; set; }
    }
}
