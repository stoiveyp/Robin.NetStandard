using System.Text.Json;
using System.Text.Json.Serialization;

namespace Robin.NetStandard.Converters
{
    public class OrganizationIdConverter:JsonConverter<RobinId>
    {
        public override RobinId? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if (reader.TokenType == JsonTokenType.String)
            {
                var value = reader.GetString();
                if (!string.IsNullOrWhiteSpace(value))
                {
                    return new RobinId(value);
                }
            }
            
            return reader.TokenType == JsonTokenType.Number ? new RobinId(reader.GetInt32()) : null;
        }

        public override void Write(Utf8JsonWriter writer, RobinId value, JsonSerializerOptions options)
        {
            if (value.Id.HasValue)
            {
                writer.WriteNumberValue(value.Id.Value);
            }

            if (!string.IsNullOrWhiteSpace(value.Slug))
            {
                writer.WriteStringValue(value.Slug);
            }
        }
    }
}
