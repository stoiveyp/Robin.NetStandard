using System.Runtime.Serialization;

namespace Robin.NetStandard.Entities;

public enum ZoneType
{
    [EnumMember(Value = "Pod")]
    Pod,
    [EnumMember(Value = "Table")]
    Table
}