using System.Text.Json.Serialization;

namespace DynuSharp.Data.Email.Type;
public sealed class StoreForwardEmailService : DynuEmailServiceBase
{
    [JsonPropertyName("type")]
    public override EmailType Type => EmailType.EmailStoreForward;

    [JsonPropertyName("etrnHost")]
    public string EtrnHost { get; set; } = string.Empty;

    [JsonPropertyName("etrnPort")]
    public int EtrnPort { get; set; }

    [JsonPropertyName("etrnConnectionSecurity")]
    public EtrnConnectionSecurityType EtrnConnectionSecurity { get; set; }

    [JsonPropertyName("etrnRetryInterval")]
    public int EtrnRetryInterval { get; set; }

    public override bool Equals(object? obj)
    {
        if (!base.Equals(obj) || obj is not StoreForwardEmailService other)
            return false;

        return EtrnHost.Equals(other.EtrnHost, StringComparison.Ordinal) &&
               EtrnPort == other.EtrnPort &&
               EtrnConnectionSecurity == other.EtrnConnectionSecurity &&
               EtrnRetryInterval == other.EtrnRetryInterval;
    }

    public override int GetHashCode() => HashCode.Combine(base.GetHashCode(), EtrnHost, EtrnPort, EtrnConnectionSecurity, EtrnRetryInterval);
}
