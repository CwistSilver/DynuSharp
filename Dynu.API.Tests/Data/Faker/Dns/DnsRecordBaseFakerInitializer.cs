using Bogus;
using DynuSharp.Data.Dns.Record;

namespace DynuSharp.Test.Data.Faker.Dns;
public static class DnsRecordBaseFakerInitializer
{
    public static void AddRules<T>(Faker<T> faker) where T : DnsRecordBase
    {
        faker.RuleFor(o => o.Id, f => f.Random.Int(0, 1_000_000));
        faker.RuleFor(o => o.DomainId, f => f.Random.Int(0, 1_000_000));
        faker.RuleFor(o => o.DomainName, f => f.Internet.DomainName());
        faker.RuleFor(o => o.NodeName, f => f.Lorem.Word());
        faker.RuleFor(o => o.Hostname, f => f.Internet.DomainName());
        faker.RuleFor(o => o.State, f => f.Random.Bool());
        faker.RuleFor(o => o.Content, f => f.Lorem.Text());
        faker.RuleFor(o => o.UpdatedOn, f => f.Date.Past());
    }
}
