using System.Text.Json.Serialization;

namespace Robin.NetStandard;

public class Error
{
    [JsonPropertyName("domain")]
    public string Domain { get; set; }

    [JsonPropertyName("reason")]
    public string Reason { get; set; }

    [JsonPropertyName("message")]
    public string Message { get; set; }
}