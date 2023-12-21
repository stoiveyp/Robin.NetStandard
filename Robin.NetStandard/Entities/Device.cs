using System.Text.Json;
using System.Text.Json.Serialization;
using Robin.NetStandard.Converters;

namespace Robin.NetStandard.Entities;

public class Device:Entity
{
    [JsonPropertyName("id")]
    public int Id { get; set; }
    
    [JsonPropertyName("account_id")]
    public int AccountId { get; set; }
    
    [JsonPropertyName("device_manifest_id")]
    public int DeviceManifestId { get; set; }
    
    [JsonPropertyName("name")]
    public string Name { get; set; }
    
    [JsonPropertyName("last_reported_at")]
    [JsonConverter(typeof(DateTimeOffsetParseConverter))]
    public DateTimeOffset? LastReportedAt { get; set; }
    
    [JsonPropertyName("created_at")]
    [JsonConverter(typeof(DateTimeOffsetParseConverter))]
    public DateTimeOffset? CreatedAt { get; set; }

    [JsonPropertyName("updated_at")]
    [JsonConverter(typeof(DateTimeOffsetParseConverter))]
    public DateTimeOffset? UpdatedAt { get; set; }
}