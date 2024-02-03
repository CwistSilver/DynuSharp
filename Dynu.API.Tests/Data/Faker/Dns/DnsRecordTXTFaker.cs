using Bogus;
using DynuSharp.Data.Dns.Record;

namespace DynuSharp.Test.Data.Faker.Dns;
public sealed class DnsRecordTXTFaker : Faker<DnsRecordTXT>
{
    public DnsRecordTXTFaker()
    {
        DnsRecordBaseFakerInitializer.AddRules(this);
        RuleFor(o => o.RecordType, _ => RecordType.TXT);
        RuleFor(o => o.TextData, f => f.Lorem.Sentence());
    }
}

