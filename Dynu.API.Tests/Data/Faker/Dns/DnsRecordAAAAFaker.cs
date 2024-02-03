using Bogus;
using DynuSharp.Data.Dns.Record;

namespace DynuSharp.Test.Data.Faker.Dns;
public sealed class DnsRecordAAAAFaker : Faker<DnsRecordAAAA>
{
    public DnsRecordAAAAFaker()
    {
        DnsRecordBaseFakerInitializer.AddRules(this);
        RuleFor(o => o.RecordType, _ => RecordType.AAAA);

        RuleFor(o => o.Group, f => f.Lorem.Word());
        RuleFor(o => o.IPv6Address, f => f.Internet.Ipv6Address().ToString());
    }
}
