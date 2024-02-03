using Bogus;
using DynuSharp.Data.Dns.Record;

namespace DynuSharp.Test.Data.Faker.Dns;
public sealed class DnsRecordAFaker : Faker<DnsRecordA>
{
    public DnsRecordAFaker()
    {
        DnsRecordBaseFakerInitializer.AddRules(this);
        RuleFor(o => o.RecordType, _ => RecordType.A);

        RuleFor(o => o.Group, f => f.Lorem.Word());
        RuleFor(o => o.IPv4Address, f => f.Internet.Ip());
    }
}
