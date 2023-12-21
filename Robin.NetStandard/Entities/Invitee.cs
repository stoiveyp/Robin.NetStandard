using System.Text.Json.Serialization;
using Robin.NetStandard.Converters;

namespace Robin.NetStandard.Entities;

public class Invitee
{
    [JsonPropertyName("id")]
    public string Id { get; set; }
    
    [JsonPropertyName("event_id")]
    public string EventId { get; set; }
    
    [JsonPropertyName("user_id")]
    public int? UserId { get; set; }
    
    [JsonPropertyName("email")]
    public string Email { get; set; }
    
    [JsonPropertyName("display_name")]
    public string DisplayName { get; set; }
    
    [JsonPropertyName("response_status")]
    public string ResponseStatus { get; set; }
    
    [JsonPropertyName("is_organizer")]
    public bool IsOrganizer { get; set; }
    
    [JsonPropertyName("is_resource")]
    public bool IsResource { get; set; }
    
    [JsonPropertyName("updated_at")]
    [JsonConverter(typeof(DateTimeOffsetParseConverter))]
    public DateTimeOffset? UpdatedAt { get; set; }
    
    [JsonPropertyName("created_at")]
    [JsonConverter(typeof(DateTimeOffsetParseConverter))]
    public DateTimeOffset? CreatedAt { get; set; }
}