using Bogus;
using DynuSharp.Data.Dns.Record;

namespace DynuSharp.Test.Data.Faker.Dns;
public sealed class DnsRecordPTRFaker : Faker<DnsRecordPTR>
{
    public DnsRecordPTRFaker()
    {
        DnsRecordBaseFakerInitializer.AddRules(this);
        RuleFor(o => o.RecordType, _ => RecordType.PTR);
        RuleFor(o => o.Host, f => $"{f.Random.Int(1, 255)}.{f.Random.Int(1, 255)}.{f.Random.Int(1, 255)}.{f.Random.Int(1, 255)}.in-addr.arpa");
    }
}