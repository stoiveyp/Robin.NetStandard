using Robin.NetStandard.Converters;
using System.Text.Json.Serialization;

namespace Robin.NetStandard.Auth;

public class AccessDateTime
{
    [JsonPropertyName("date")]
    [JsonConverter(typeof(DateTimeOffsetParseConverter))]
    public DateTimeOffset? Date { get; set; }

    [JsonPropertyName("timezone_type")]
    public int TimezoneType { get; set; }

    [JsonPropertyName("timezone")]
    public string Timezone { get; set; }
}