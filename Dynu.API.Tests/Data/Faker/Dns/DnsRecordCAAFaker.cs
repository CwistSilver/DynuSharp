using Bogus;
using DynuSharp.Data.Dns.Record;

namespace DynuSharp.Test.Data.Faker.Dns;
public sealed class DnsRecordCAAFaker : Faker<DnsRecordCAA>
{
    public DnsRecordCAAFaker()
    {
        DnsRecordBaseFakerInitializer.AddRules(this);
        RuleFor(o => o.RecordType, _ => RecordType.CAA);
        RuleFor(o => o.Flags, f => f.Random.Byte(0, 255));
        RuleFor(o => o.Tag, f => f.PickRandom<CAATag>());
        RuleFor(o => o.Value, f => f.Internet.DomainName());
    }
}

