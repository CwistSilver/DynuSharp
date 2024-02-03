using System.Text.Json.Serialization;

namespace DynuSharp.Data.Domain;
public sealed class NameServer
{
    /// <summary>
    /// The name of the name server associated with a specific domain.
    /// Predefined NameServers can be found here <see cref="NameServers"/> class.
    /// </summary>
    [JsonPropertyName("nameServer")]
    public string Name { get; set; } = string.Empty;

    public override bool Equals(object? obj)
    {
        if (obj is null || !(obj is NameServer other))
            return false;

        if (ReferenceEquals(this, obj))
            return true;

        return string.Equals(Name, other.Name, StringComparison.OrdinalIgnoreCase);
    }
    public override int GetHashCode() => Name.ToLowerInvariant().GetHashCode();

    public static bool operator ==(NameServer? left, NameServer? right)
    {
        if (ReferenceEquals(left, right))
            return true;

        if (left is null || right is null)
            return false;

        return left.Equals(right);
    }

    public static bool operator !=(NameServer? left, NameServer? right) => !(left == right);
}
