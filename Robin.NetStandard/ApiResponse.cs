using Robin.NetStandard.Converters;
using System.Text.Json.Serialization;

namespace Robin.NetStandard
{
    public class ApiResponse<T>
    {
        [JsonPropertyName("meta")]
        public ApiMetadata Meta { get; set; }

        [JsonPropertyName("data")]
        [JsonConverter(typeof(EmptyObjectDataConverter))]
        public T? Data { get; set; }
    }
}
