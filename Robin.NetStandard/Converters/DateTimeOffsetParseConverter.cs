using System.Diagnostics;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Robin.NetStandard.Converters;

public class DateTimeOffsetParseConverter : JsonConverter<DateTimeOffset>
{
    public override DateTimeOffset Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        return DateTimeOffset.Parse(reader.GetString());
    }

    public override void Write(Utf8JsonWriter writer, DateTimeOffset  value, JsonSerializerOptions options)
    {
        writer.WriteStringValue(value.ToString("O"));
    }
}