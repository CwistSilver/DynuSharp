namespace DynuSharp.Data.Monitor;

using DynuSharp.Data.Email.Type;
using DynuSharp.Utilities.Json;
using System;
using System.Text.Json.Serialization;

public class MonitorBase
{
    /// <summary>
    /// The unique identifier for the monitor.
    /// <para>Note: Read-only for API requests (This property is not considered when creating or updating through API requests).</para>
    /// </summary>
    [JsonPropertyName("id")]
    [IgnoreOnPost]
    public int Id { get; init; }

    /// <summary>
    /// The name of the monitor.
    /// </summary>
    [JsonPropertyName("name")]
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// The type of the monitor, which is set to DNS for this class.
    /// </summary>
    [JsonPropertyName("type")]
    public virtual MonitorType Type { get; }

    /// <summary>
    /// The interval, in minutes, between checks for the monitor.
    /// </summary>
    [JsonPropertyName("checkInterval")]
    public int CheckInterval { get; set; }

    /// <summary>
    /// The current state of the monitor.
    /// <para>Note: Read-only for API requests (This property is not considered when creating or updating through API requests).</para>
    /// </summary>
    [JsonPropertyName("state")]
    [IgnoreOnPost]
    public MonitorState State { get; init; }

    /// <summary>
    /// A boolean value indicating whether the monitor is paused.
    /// </summary>
    [JsonPropertyName("paused")]
    public bool Paused { get; set; }

    /// <summary>
    /// The date and time of the last check performed by the monitor.
    /// <para>Note: Read-only for API requests (This property is not considered when creating or updating through API requests).</para>
    /// </summary>
    [JsonPropertyName("lastCheck")]
    [IgnoreOnPost]
    public DateTime LastCheck { get; init; }

    /// <summary>
    /// The date and time of the next check to be performed by the monitor.
    /// <para>Note: Read-only for API requests (This property is not considered when creating or updating through API requests).</para>
    /// </summary>
    [JsonPropertyName("nextCheck")]
    [IgnoreOnPost]
    public DateTime? NextCheck { get; init; }

    /// <summary>
    /// The date and time of the last successful check performed by the monitor.
    /// <para>Note: Read-only for API requests (This property is not considered when creating or updating through API requests).</para>
    /// </summary>
    [JsonPropertyName("lastSuccessfulCheck")]
    [IgnoreOnPost]
    public DateTime LastSuccessfulCheck { get; init; }

    public override bool Equals(object? obj)
    {
        if (obj is null || obj is not MonitorBase other)
            return false;

        if (ReferenceEquals(this, obj))
            return true;

        return Id == other.Id &&
               Name.Equals(other.Name, StringComparison.Ordinal) &&
               Type == other.Type &&
               CheckInterval == other.CheckInterval &&
               State == other.State &&
               Paused == other.Paused &&
               LastCheck == other.LastCheck &&
               NextCheck == other.NextCheck &&
               LastSuccessfulCheck == other.LastSuccessfulCheck;
    }

    public override int GetHashCode()
    {
        var hashCode = new HashCode();
        hashCode.Add(Id);
        hashCode.Add(Name);
        hashCode.Add(Type);
        hashCode.Add(CheckInterval);
        hashCode.Add(State);
        hashCode.Add(Paused);
        hashCode.Add(LastCheck);
        hashCode.Add(NextCheck);
        hashCode.Add(LastSuccessfulCheck);
        return hashCode.ToHashCode();
    }
}