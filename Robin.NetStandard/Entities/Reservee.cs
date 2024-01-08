using System.Text.Json.Serialization;

namespace Robin.NetStandard.Entities;

public class Reservee:Entity
{
    [JsonPropertyName("email")]
    public string Email { get; set; }

    [JsonPropertyName("user_id")]
    public long UserId { get; set; }

    [JsonPropertyName("visitor_id")]
    public string VisitorId { get; set; }

    [JsonPropertyName("participation_status")]
    public string ParticipationStatus { get; set; }
}