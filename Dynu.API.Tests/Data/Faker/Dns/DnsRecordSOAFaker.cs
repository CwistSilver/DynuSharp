using Bogus;
using DynuSharp.Data.Dns.Record;

namespace DynuSharp.Test.Data.Faker.Dns;
public sealed class DnsRecordSOAFaker : Faker<DnsRecordSOA>
{
    public DnsRecordSOAFaker()
    {
        DnsRecordBaseFakerInitializer.AddRules(this);
        RuleFor(o => o.RecordType, _ => RecordType.SOA);

        RuleFor(o => o.MasterName, f => f.Internet.DomainName());
        RuleFor(o => o.ResponsibleName, f => f.Internet.UserName());
        RuleFor(o => o.Refresh, f => f.Random.Int(0, 10000));
        RuleFor(o => o.Retry, f => f.Random.Int(0, 10000));
        RuleFor(o => o.Expire, f => f.Random.Int(0, 10000));
        RuleFor(o => o.NegativeTTL, f => f.Random.Int(0, 10000));
    }
}
