using Bogus;
using DynuSharp.Data.Dns.Record;

namespace DynuSharp.Test.Data.Faker.Dns;
public sealed class DnsRecordTLSAFaker : Faker<DnsRecordTLSA>
{
    public DnsRecordTLSAFaker()
    {
        DnsRecordBaseFakerInitializer.AddRules(this);
        RuleFor(o => o.RecordType, _ => RecordType.TLSA);
        RuleFor(o => o.CertificateUsage, f => f.Random.Byte(0, 3));
        RuleFor(o => o.Selector, f => f.Random.Byte(0, 1));
        RuleFor(o => o.MatchingType, f => f.Random.Byte(0, 2));
        RuleFor(o => o.CertificateAssociatedData, f => f.Random.Hexadecimal(64));
    }
}
