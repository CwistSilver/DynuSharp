using Bogus;
using DynuSharp.Data.Dns.Record;

namespace DynuSharp.Test.Data.Faker.Dns;
public sealed class DnsRecordHINFOFaker : Faker<DnsRecordHINFO>
{
    public DnsRecordHINFOFaker()
    {
        DnsRecordBaseFakerInitializer.AddRules(this);
        RuleFor(o => o.RecordType, _ => RecordType.HINFO);
        RuleFor(o => o.CPU, f => f.Lorem.Word());
        RuleFor(o => o.OperatingSystem, f => f.Lorem.Word());
    }
}

