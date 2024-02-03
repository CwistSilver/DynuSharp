using System.Text.Json.Serialization;

namespace DynuSharp.Data;
public class ApiError
{
    [JsonPropertyName("statusCode")]
    public int StatusCode { get; set; }
    [JsonPropertyName("type")]
    public string Type { get; set; }
    [JsonPropertyName("message")]
    public string Message { get; set; }
}
