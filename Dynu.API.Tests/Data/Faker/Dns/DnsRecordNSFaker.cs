using Bogus;
using DynuSharp.Data.Dns.Record;

namespace DynuSharp.Test.Data.Faker.Dns;
public sealed class DnsRecordNSFaker : Faker<DnsRecordNS>
{
    public DnsRecordNSFaker()
    {
        DnsRecordBaseFakerInitializer.AddRules(this);
        RuleFor(o => o.RecordType, _ => RecordType.NS);
        RuleFor(o => o.Host, f => f.Internet.DomainName());
    }
}