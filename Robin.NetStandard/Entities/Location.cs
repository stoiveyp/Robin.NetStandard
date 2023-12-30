using Robin.NetStandard.Converters;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Robin.NetStandard.Entities
{
    public class Location:Entity
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("account_id")]
        public int AccountId { get; set; }

        [JsonPropertyName("campus_id")]
        public int? CampusId { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }

        [JsonPropertyName("address")]
        public string Address { get; set; }

        [JsonPropertyName("image")]
        public Uri Image { get; set; }

        [JsonPropertyName("latitude")]
        public double Latitude { get; set; }

        [JsonPropertyName("longitude")]
        public double Longitude { get; set; }

        [JsonPropertyName("is_visitor_management_enabled")]
        public bool? IsVisitorManagementEnabled { get; set; }

        [JsonPropertyName("updated_at")]
        [JsonConverter(typeof(DateTimeOffsetParseConverter))]
        public DateTimeOffset? UpdatedAt { get; set; }

        [JsonPropertyName("created_at")]
        [JsonConverter(typeof(DateTimeOffsetParseConverter))]
        public DateTimeOffset? CreatedAt { get; set; }

        [JsonPropertyName("working_hours")] 
        public WorkingDay[] WorkingHours { get; set; }
    }
}
