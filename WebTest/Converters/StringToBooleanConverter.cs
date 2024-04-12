using System.Text.Json;
using System.Text.Json.Serialization;

namespace WebTest.Converters
{
    public class StringToBooleanConverter : JsonConverter<bool?>
    {
        public override bool? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if (reader.TokenType == JsonTokenType.String)
            {
                if (bool.TryParse(reader.GetString(), out var result))
                {
                    return result;
                }
            }

            return null;
        }

        public override void Write(Utf8JsonWriter writer, bool? value, JsonSerializerOptions options)
        {
            // Implement writing logic if needed
            throw new NotImplementedException();
        }
    }
}
