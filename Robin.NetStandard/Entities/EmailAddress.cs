using System.Text.Json.Serialization;

namespace Robin.NetStandard.Entities;

public class EmailAddress
{
    [JsonPropertyName("email")]
    public string Email { get; set; }

    [JsonPropertyName("is_verified")]
    public bool IsVerified { get; set; }
}