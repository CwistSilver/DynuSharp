using Bogus;
using DynuSharp.Data.Dns.Record;

namespace DynuSharp.Test.Data.Faker.Dns;
public sealed class DnsRecordLOCFaker : Faker<DnsRecordLOC>
{
    public DnsRecordLOCFaker()
    {
        DnsRecordBaseFakerInitializer.AddRules(this);
        RuleFor(o => o.RecordType, _ => RecordType.LOC);
        RuleFor(o => o.Latitude, f => f.Address.Latitude());
        RuleFor(o => o.Longitude, f => f.Address.Longitude());
        RuleFor(o => o.Altitude, f => f.Random.Double(0, 10000));
        RuleFor(o => o.Size, f => f.Random.Double(0, 10000));
        RuleFor(o => o.HorizontalPrecision, f => f.Random.Double(0, 10000));
        RuleFor(o => o.VerticalPrecision, f => f.Random.Double(0, 10000));
    }
}

