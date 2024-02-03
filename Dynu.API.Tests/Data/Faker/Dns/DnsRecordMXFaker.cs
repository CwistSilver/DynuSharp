using Bogus;
using DynuSharp.Data.Dns.Record;

namespace DynuSharp.Test.Data.Faker.Dns;
public sealed class DnsRecordMXFaker : Faker<DnsRecordMX>
{
    public DnsRecordMXFaker()
    {
        DnsRecordBaseFakerInitializer.AddRules(this);
        RuleFor(o => o.RecordType, _ => RecordType.MX);
        RuleFor(o => o.Host, f => f.Internet.DomainName());
        RuleFor(o => o.Priority, f => f.Random.Int(0, 100));
    }
}

