using System.Text.Json.Serialization;
using Robin.NetStandard.Converters;

namespace Robin.NetStandard.Entities;

public class TimeFrame
{
    [JsonPropertyName("start")]
    [JsonConverter(typeof(TimeOnlyParseConverter))]
    public TimeOnly? Start { get; set; }

    [JsonPropertyName("end")]
    [JsonConverter(typeof(TimeOnlyParseConverter))]
    public TimeOnly? End { get; set; }
}