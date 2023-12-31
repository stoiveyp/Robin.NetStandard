using System.Diagnostics;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Robin.NetStandard.Converters;

public class DateTimeOffsetParseConverter : JsonConverter<DateTimeOffset?>
{
    public static string ToStringFormat = "yyyy-MM-ddTHH:mm:sszzz";

    public override DateTimeOffset? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        var value = reader.GetString();
        if (value == null)
        {
            return null;
        }
        return DateTimeOffset.Parse(value);
    }

    public override void Write(Utf8JsonWriter writer, DateTimeOffset? value, JsonSerializerOptions options)
    {
        if (value == null)
        {
            writer.WriteNullValue();
            return;
        }

        writer.WriteStringValue(value.Value.ToString(ToStringFormat));
    }
}