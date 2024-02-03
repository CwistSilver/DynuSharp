using Bogus;
using DynuSharp.Data.Dns.Record;

namespace DynuSharp.Test.Data.Faker.Dns;
public sealed class DnsRecordSSHFPFaker : Faker<DnsRecordSSHFP>
{
    public DnsRecordSSHFPFaker()
    {
        DnsRecordBaseFakerInitializer.AddRules(this);
        RuleFor(o => o.RecordType, _ => RecordType.SSHFP);
        RuleFor(o => o.Algorithm, f => f.Random.Byte(0, 4));
        RuleFor(o => o.FingerPrintType, f => f.Random.Byte(0, 2));
        RuleFor(o => o.FingerPrint, f => f.Random.Hexadecimal(40));
    }
}

