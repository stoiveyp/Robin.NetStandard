using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Robin.NetStandard
{
    public class ApiResponse<T>
    {
        [JsonPropertyName("meta")]
        public ApiMetadata Meta { get; set; }

        [JsonPropertyName("data")]
        public T? Data { get; set; }
    }
}
