namespace DynuSharp.Data.Monitor;
using System.Text.Json.Serialization;

public sealed class MonitorKeyword : MonitorBase
{
    /// <summary>
    /// The type of the monitor, which is set to KEYWORD for this class.
    /// </summary>
    [JsonPropertyName("type")]
    public override MonitorType Type => MonitorType.KEYWORD;

    /// <summary>
    /// The URL that the keyword monitor should check.
    /// </summary>
    [JsonPropertyName("url")]
    public string Url { get; set; } = string.Empty;

    /// <summary>
    /// The keyword that the monitor should check for in the specified URL.
    /// </summary>
    [JsonPropertyName("keyword")]
    public string Keyword { get; set; } = string.Empty;

    /// <summary>
    /// Indicates whether the specified keyword should exist in the content of the checked URL.
    /// </summary>
    [JsonPropertyName("keywordExists")]
    public bool KeywordExists { get; set; }

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
        if (!base.Equals(obj) || obj is not MonitorKeyword other)
            return false;

        return Url.Equals(other.Url, StringComparison.Ordinal) &&
               Keyword.Equals(other.Keyword, StringComparison.Ordinal) &&
               KeywordExists == other.KeywordExists &&
               AuthenticationType.Equals(other.AuthenticationType, StringComparison.Ordinal) &&
               Username.Equals(other.Username, StringComparison.Ordinal) &&
               Password.Equals(other.Password, StringComparison.Ordinal);
    }

    public override int GetHashCode() => HashCode.Combine(base.GetHashCode(), Url, Keyword, KeywordExists, AuthenticationType, Username, Password);
}