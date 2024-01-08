using System.Text.Json.Serialization;

namespace Robin.NetStandard.Entities;

public class Confirmation:Entity
{
    [JsonPropertyName("user_id")]
    public string UserId { get; set; }

    [JsonPropertyName("device_id")]
    public string DeviceId { get; set; }
}