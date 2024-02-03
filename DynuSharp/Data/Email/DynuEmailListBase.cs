using DynuSharp.Utilities.Json;
using System.Text.Json.Serialization;

namespace DynuSharp.Data.Email;
public class DynuEmailListBase
{
    [JsonPropertyName("id")]
    [IgnoreOnPost]
    public int Id { get; init; }

    [JsonPropertyName("domainId")]
    [IgnoreOnPost]
    public int DomainId { get; init; }

    [JsonPropertyName("domainName")]
    public string DomainName { get; set; } = string.Empty;

    [JsonPropertyName("type")]
    public EmailListType Type { get; set; }

    [JsonPropertyName("data")]
    public string Data { get; set; } = string.Empty;

    [JsonPropertyName("state")]
    public bool State { get; set; }

    public override bool Equals(object? obj)
    {
        if (obj is null || obj is not DynuEmailListBase other)
            return false;

        if (ReferenceEquals(this, obj))
            return true;

        return Id == other.Id &&
               DomainId == other.DomainId &&
               DomainName.Equals(other.DomainName, StringComparison.Ordinal) &&
               Type == other.Type &&
               Data.Equals(other.Data, StringComparison.Ordinal) &&
               State == other.State;
    }

    public override int GetHashCode()
    {
        var hashCode = new HashCode();
        hashCode.Add(Id);
        hashCode.Add(DomainId);
        hashCode.Add(DomainName);
        hashCode.Add(Type);
        hashCode.Add(Data);
        hashCode.Add(State);
        return hashCode.ToHashCode();
    }
}
