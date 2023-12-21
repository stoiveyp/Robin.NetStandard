using System.Text.Json.Serialization;
using Robin.NetStandard.Converters;

namespace Robin.NetStandard.Entities;

public class Busy
{

    [JsonPropertyName("from")]
    [JsonConverter(typeof(DateTimeOffsetParseConverter))]
    public DateTimeOffset? From { get; set; }


    [JsonPropertyName("to")]
    [JsonConverter(typeof(DateTimeOffsetParseConverter))]
    public DateTimeOffset? To { get; set; }

    [JsonPropertyName("events")] 
    public Event[] Events { get; set; } = { };
}