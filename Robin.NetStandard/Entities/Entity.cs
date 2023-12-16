using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Robin.NetStandard.Entities
{
    public abstract class Entity
    {
        [JsonExtensionData]
        public Dictionary<string,object> OtherProperties { get; set; }
    }
}
