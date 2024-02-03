using System.Text.Json.Serialization;

namespace DynuSharp.Data.Limit;
/// <summary>
/// Represents a base class for defining limits, containing properties to track the active and remaining count of a particular resource.
/// </summary>
public class LimitBase
{
    /// <summary>
    /// The number of active instances of a resource.
    /// </summary>
    [JsonPropertyName("activeCount")]
    public int ActiveCount { get; set; }

    /// <summary>
    /// The number of remaining allocations available for a resource.
    /// </summary>
    [JsonPropertyName("remainingCount")]
    public int RemainingCount { get; set; }

    public override bool Equals(object? obj)
    {
        if (obj is null || obj is not LimitBase other)
            return false;

        if (ReferenceEquals(this, obj))
            return true;

        return ActiveCount == other.ActiveCount &&
               RemainingCount == other.RemainingCount;
    }

    public override int GetHashCode() => HashCode.Combine(ActiveCount, RemainingCount);
}
