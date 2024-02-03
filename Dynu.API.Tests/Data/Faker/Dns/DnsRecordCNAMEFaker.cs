using Bogus;
using DynuSharp.Data.Dns.Record;

namespace DynuSharp.Test.Data.Faker.Dns;
public sealed class DnsRecordCNAMEFaker : Faker<DnsRecordCNAME>
{
    public DnsRecordCNAMEFaker()
    {
        DnsRecordBaseFakerInitializer.AddRules(this);
        RuleFor(o => o.RecordType, _ => RecordType.CNAME);
        RuleFor(o => o.Host, f => f.Internet.DomainName());
    }
}

