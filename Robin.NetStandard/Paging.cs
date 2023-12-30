using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Robin.NetStandard
{
    public class Paging
    {
        [JsonPropertyName("page")]
        public int Page { get; set; }

        [JsonPropertyName("per_page")]
        public int PerPage { get; set; }

        [JsonPropertyName("has_next_page")]
        public bool HasNextPage { get; set; }
    }
}
