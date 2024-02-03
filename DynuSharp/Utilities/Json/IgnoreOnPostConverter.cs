using System.Text.Json;
using System.Text.Json.Serialization;

namespace DynuSharp.Utilities.Json;
internal sealed class IgnoreOnPostConverter<T> : JsonConverter<T>
{
    public override T Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        // Implementieren Sie die Deserialisierung (Sie können die Standardimplementierung aufrufen)
        return JsonSerializer.Deserialize<T>(ref reader, options);
    }

    public override void Write(Utf8JsonWriter writer, T value, JsonSerializerOptions options)
    {
        writer.WriteStartObject();

        var properties = typeof(T).GetProperties();
        foreach (var prop in properties)
        {
            var ignoreOnPost = prop.GetCustomAttributes(typeof(IgnoreOnPostAttribute), false).FirstOrDefault();
            if (ignoreOnPost == null)
            {
                var propValue = prop.GetValue(value);

                var jsonPropertyNameAttribute = prop.GetCustomAttributes(typeof(JsonPropertyNameAttribute), false).FirstOrDefault() as JsonPropertyNameAttribute;
                string jsonPropertyName = jsonPropertyNameAttribute?.Name ?? prop.Name;

                writer.WritePropertyName(jsonPropertyName);
                JsonSerializer.Serialize(writer, propValue, prop.PropertyType, options);
            }
        }


        writer.WriteEndObject();
    }
}