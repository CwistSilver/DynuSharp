using System.Text.Json.Serialization;

namespace DynuSharp.Data.Dns.Record;
/// <summary>
/// Represents a DNS record with LOC (Location) type, which is used to specify geographical location information for a domain.
/// <para>
/// Learn more about
/// <a href="https://www.dynu.com/Resources/DNS-Records/LOC-Record" target="_blank">
/// LOC Records
/// </a>
/// </para>
/// </summary>
public sealed class DnsRecordLOC : DnsRecordBase
{
    // <summary>
    /// The type of DNS record, which is set to LOC for this class, signifying that it represents a geographical location record.
    /// </summary>
    [JsonPropertyName("recordType")]
    public override RecordType RecordType => RecordType.LOC;

    /// <summary>
    /// The latitude of the geographical location, in degrees. It should be in the range of -90.0 to +90.0.
    /// </summary>
    [JsonPropertyName("latitude")]
    public double Latitude { get; set; }

    /// <summary>
    /// The longitude of the geographical location, in degrees. It should be in the range of -180.0 to +180.0.
    /// </summary>
    [JsonPropertyName("longitude")]
    public double Longitude { get; set; }

    /// <summary>
    /// The altitude of the geographical location, in meters above mean sea level. 
    /// </summary>
    [JsonPropertyName("altitude")]
    public double Altitude { get; set; }

    /// <summary>
    /// The diameter of a sphere enclosing the described entity, in meters.
    /// </summary>
    [JsonPropertyName("size")]
    public double Size { get; set; }

    /// <summary>
    /// The horizontal precision of the data, in meters.
    /// </summary>
    [JsonPropertyName("horizontalPrecision")]
    public double HorizontalPrecision { get; set; }

    /// <summary>
    /// The vertical precision of the data, in meters.
    /// </summary>
    [JsonPropertyName("verticalPrecision")]
    public double VerticalPrecision { get; set; }

    public override bool Equals(object? obj)
    {
        if (!base.Equals(obj) || obj is not DnsRecordLOC other)
            return false;

        return Latitude == other.Latitude &&
               Longitude == other.Longitude &&
               Altitude == other.Altitude &&
               Size == other.Size &&
               HorizontalPrecision == other.HorizontalPrecision &&
               VerticalPrecision == other.VerticalPrecision;
    }

    public override int GetHashCode() => HashCode.Combine(base.GetHashCode(), Latitude, Longitude, Altitude, Size, HorizontalPrecision, VerticalPrecision);
}