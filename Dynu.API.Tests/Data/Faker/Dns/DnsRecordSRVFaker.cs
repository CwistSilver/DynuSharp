using Bogus;
using DynuSharp.Data.Dns.Record;

namespace DynuSharp.Test.Data.Faker.Dns;
public sealed class DnsRecordSRVFaker : Faker<DnsRecordSRV>
{
    public DnsRecordSRVFaker()
    {
        DnsRecordBaseFakerInitializer.AddRules(this);
        RuleFor(o => o.RecordType, _ => RecordType.SRV);
        RuleFor(o => o.Host, f => f.Internet.DomainName());
        RuleFor(o => o.Priority, f => f.Random.Int(0, 100));
        RuleFor(o => o.Weight, f => f.Random.Int(0, 100));
        RuleFor(o => o.Port, f => f.Random.Int(0, 65535));
    }
}

