using System.Text.Json.Serialization;

namespace Robin.NetStandard.Entities
{
    public class FreeBusy:Entity
    {
        [JsonPropertyName("has_presence")]
        public bool HasPresence { get; set; }

        [JsonPropertyName("space")]
        public Space Space { get; set; }

        [JsonPropertyName("busy")]
        public Busy[] Busy { get; set; }
    }
}
