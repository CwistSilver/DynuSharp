using System.Text.Json.Serialization;

namespace DynuSharp.Data.Authentication;
public sealed class OAuth2Reponse
{
    [JsonPropertyName("access_token")]
    public string AccessToken { get; set; }
    [JsonPropertyName("token_type")]
    public string TokenType { get; set; }
    [JsonPropertyName("expires_in")]
    public int ExpiresIn { get; set; }
    [JsonPropertyName("roles")]
    public object[] Roles { get; set; }
}