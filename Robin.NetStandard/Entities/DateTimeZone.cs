using System.Text.Json.Serialization;
using Robin.NetStandard.Converters;

namespace Robin.NetStandard.Entities;

public class DateTimeZone
{
    [JsonPropertyName("date_time")]
    [JsonConverter(typeof(DateTimeOffsetParseConverter))]
    public DateTimeOffset DateTime { get; set; }
   
    [JsonPropertyName("time_zone")]
    public string TimeZone { get; set; }
}