using Bogus;
using DynuSharp.Data.Dns.Record;

namespace DynuSharp.Test.Data.Faker.Dns;
public sealed class DnsRecordRPFaker : Faker<DnsRecordRP>
{
    public DnsRecordRPFaker()
    {
        DnsRecordBaseFakerInitializer.AddRules(this);
        RuleFor(o => o.RecordType, _ => RecordType.RP);
        RuleFor(o => o.MailBox, f => $"{f.Internet.UserName()}@{f.Internet.DomainName()}");
        RuleFor(o => o.TxtDomainName, f => f.Internet.DomainName());
    }
}
