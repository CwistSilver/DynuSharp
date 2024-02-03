using Bogus;
using DynuSharp.Data.Dns.Record;

namespace DynuSharp.Test.Data.Faker.Dns;
public sealed class DnsRecordURIFaker : Faker<DnsRecordURI>
{
    public DnsRecordURIFaker()
    {
        DnsRecordBaseFakerInitializer.AddRules(this);
        RuleFor(o => o.RecordType, _ => RecordType.URI);
        RuleFor(o => o.TargetUri, f => f.Internet.Url());
        RuleFor(o => o.Priority, f => f.Random.Int(0, 100));
        RuleFor(o => o.Weight, f => f.Random.Int(0, 100));
    }
}

