using System.Net;
using System.Text.Json.Serialization;

namespace Robin.NetStandard;

public class ApiMetadata
{
    [JsonPropertyName("status_code")]
    public HttpStatusCode HttpStatus { get; set; }

    [JsonPropertyName("status")]
    public string Status { get; set; }

    [JsonPropertyName("message")]
    public string Message { get; set; }

    [JsonPropertyName("more_info")]
    public Dictionary<string, object> MoreInfo { get; set; }

    [JsonPropertyName("errors")]
    public Error[] Errors { get; set; }
}