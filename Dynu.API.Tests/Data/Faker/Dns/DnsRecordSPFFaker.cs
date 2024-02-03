using Bogus;
using DynuSharp.Data.Dns.Record;

namespace DynuSharp.Test.Data.Faker.Dns;
public sealed class DnsRecordSPFFaker : Faker<DnsRecordSPF>
{
    public DnsRecordSPFFaker()
    {
        DnsRecordBaseFakerInitializer.AddRules(this);
        RuleFor(o => o.RecordType, _ => RecordType.SPF);
        RuleFor(o => o.TextData, f => $"v=spf1 include:{f.Internet.DomainName()} ~all");
    }
}
