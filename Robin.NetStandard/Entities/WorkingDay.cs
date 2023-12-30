using System.Text.Json.Serialization;

namespace Robin.NetStandard.Entities;

public class WorkingDay
{
    [JsonPropertyName("day")]
    public int Day { get; set; }

    [JsonPropertyName("time_frames")] 
    public TimeFrame[] TimeFrames { get; set; } = Array.Empty<TimeFrame>();
}