using System.Text.Json;
using System.Text.Json.Serialization;

namespace Robin.NetStandard.Converters
{
    public class OrganizationIdConverter:JsonConverter<OrganizationId>
    {
        public override OrganizationId? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if (reader.TokenType == JsonTokenType.String)
            {
                var value = reader.GetString();
                if (!string.IsNullOrWhiteSpace(value))
                {
                    return new OrganizationId(value);
                }
            }
            
            return reader.TokenType == JsonTokenType.Number ? new OrganizationId(reader.GetInt32()) : null;
        }

        public override void Write(Utf8JsonWriter writer, OrganizationId value, JsonSerializerOptions options)
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
