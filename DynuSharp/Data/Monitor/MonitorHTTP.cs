using DynuSharp.Data.Domain;
using System.Text.Json.Serialization;

namespace DynuSharp.Data.Monitor;
public sealed class MonitorHTTP : MonitorBase
{
    /// <summary>
    /// The type of the monitor, which is set to HTTP for this class.
    /// </summary>
    [JsonPropertyName("type")]
    public override MonitorType Type => MonitorType.HTTP;

    /// <summary>
    /// The URL that the HTTP monitor should check.
    /// </summary>
    [JsonPropertyName("url")]
    public string Url { get; set; } = string.Empty;

    /// <summary>
    /// The type of authentication used for monitoring, if applicable.
    /// </summary>
    [JsonPropertyName("authenticationType")]
    public string AuthenticationType { get; set; } = string.Empty;

    /// <summary>
    /// The username used for authentication, if applicable.
    /// </summary>
    [JsonPropertyName("username")]
    public string Username { get; set; } = string.Empty;

    /// <summary>
    /// The password used for authentication, if applicable.
    /// </summary>
    [JsonPropertyName("password")]
    public string Password { get; set; } = string.Empty;

    public override bool Equals(object? obj)
    {
        if (!base.Equals(obj) || obj is not MonitorHTTP other)
            return false;

        return Url.Equals(other.Url, StringComparison.Ordinal) &&
               AuthenticationType.Equals(other.AuthenticationType, StringComparison.Ordinal) &&
               Username.Equals(other.Username, StringComparison.Ordinal) &&
               Password.Equals(other.Password, StringComparison.Ordinal);
    }

    public override int GetHashCode() => HashCode.Combine(base.GetHashCode(), Url, AuthenticationType, Username, Password);
}