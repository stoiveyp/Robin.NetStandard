using System.Text.Json;
using System.Text.Json.Serialization;

namespace Robin.NetStandard.Converters
{
    public class EmptyObjectDataConverter : JsonConverter<object>
    {
        public override bool CanConvert(Type typeToConvert)
        {
            return true;
        }

        public override object Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if (typeToConvert.IsArray && reader.TokenType == JsonTokenType.StartObject)
            {
                while (reader.TokenType != JsonTokenType.EndObject && reader.Read())
                {

                }
                return null!;
            }

            return JsonSerializer.Deserialize(ref reader, typeToConvert, options)!;
        }

        public override void Write(Utf8JsonWriter writer, object value, JsonSerializerOptions options)
        {
            JsonSerializer.Serialize(writer, value, options);
        }
    }
}
