using DynuSharp.Data.Dns.Record;

namespace DynuSharp.Test.Data.Faker.Dns;
internal class DnsRecordTestData
{
    public static int ToGenerate = 3;
    public static IEnumerable<object[]> GetDnsRecordsArray()
    {
        var list = new List<DnsRecordBase>();
        list.AddRange(new DnsRecordAAAAFaker().Generate(ToGenerate));
        list.AddRange(new DnsRecordAFaker().Generate(ToGenerate));
        list.AddRange(new DnsRecordCAAFaker().Generate(ToGenerate));
        list.AddRange(new DnsRecordCNAMEFaker().Generate(ToGenerate));
        list.AddRange(new DnsRecordHINFOFaker().Generate(ToGenerate));
        list.AddRange(new DnsRecordLOCFaker().Generate(ToGenerate));
        list.AddRange(new DnsRecordMXFaker().Generate(ToGenerate));
        list.AddRange(new DnsRecordNSFaker().Generate(ToGenerate));
        list.AddRange(new DnsRecordPTRFaker().Generate(ToGenerate));
        list.AddRange(new DnsRecordRPFaker().Generate(ToGenerate));
        list.AddRange(new DnsRecordSOAFaker().Generate(ToGenerate));
        list.AddRange(new DnsRecordSPFFaker().Generate(ToGenerate));
        list.AddRange(new DnsRecordSRVFaker().Generate(ToGenerate));
        list.AddRange(new DnsRecordSSHFPFaker().Generate(ToGenerate));
        list.AddRange(new DnsRecordTLSAFaker().Generate(ToGenerate));
        list.AddRange(new DnsRecordTXTFaker().Generate(ToGenerate));
        list.AddRange(new DnsRecordURIFaker().Generate(ToGenerate));
        yield return new object[] { list.ToArray() };
    }



    public static IEnumerable<object[]> GetDnsRecords()
    {
        yield return new object[] { new DnsRecordAAAAFaker().Generate() };
        yield return new object[] { new DnsRecordAFaker().Generate() };
        yield return new object[] { new DnsRecordCAAFaker().Generate() };
        yield return new object[] { new DnsRecordCNAMEFaker().Generate() };
        yield return new object[] { new DnsRecordHINFOFaker().Generate() };
        yield return new object[] { new DnsRecordLOCFaker().Generate() };
        yield return new object[] { new DnsRecordMXFaker().Generate() };
        yield return new object[] { new DnsRecordNSFaker().Generate() };
        yield return new object[] { new DnsRecordPTRFaker().Generate() };
        yield return new object[] { new DnsRecordRPFaker().Generate() };
        yield return new object[] { new DnsRecordSOAFaker().Generate() };
        yield return new object[] { new DnsRecordSPFFaker().Generate() };
        yield return new object[] { new DnsRecordSRVFaker().Generate() };
        yield return new object[] { new DnsRecordSSHFPFaker().Generate() };
        yield return new object[] { new DnsRecordTLSAFaker().Generate() };
        yield return new object[] { new DnsRecordTXTFaker().Generate() };
        yield return new object[] { new DnsRecordURIFaker().Generate() };
    }

    public static IEnumerable<object[]> GetDnsRecordFakers()
    {
        yield return new object[] { new DnsRecordAAAAFaker() };
        yield return new object[] { new DnsRecordAFaker() };
        yield return new object[] { new DnsRecordCAAFaker() };
        yield return new object[] { new DnsRecordCNAMEFaker() };
        yield return new object[] { new DnsRecordHINFOFaker() };
        yield return new object[] { new DnsRecordLOCFaker() };
        yield return new object[] { new DnsRecordMXFaker() };
        yield return new object[] { new DnsRecordNSFaker() };
        yield return new object[] { new DnsRecordPTRFaker() };
        yield return new object[] { new DnsRecordRPFaker() };
        yield return new object[] { new DnsRecordSOAFaker() };
        yield return new object[] { new DnsRecordSPFFaker() };
        yield return new object[] { new DnsRecordSRVFaker() };
        yield return new object[] { new DnsRecordSSHFPFaker() };
        yield return new object[] { new DnsRecordTLSAFaker() };
        yield return new object[] { new DnsRecordTXTFaker() };
        yield return new object[] { new DnsRecordURIFaker() };
    }


}
