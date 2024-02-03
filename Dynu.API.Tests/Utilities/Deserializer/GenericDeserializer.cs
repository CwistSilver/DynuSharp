using Bogus;
using DynuSharp.Test.Data.Faker.Dns;
using DynuSharp.Data.Dns.Record;
using DynuSharp.Utilities.Deserializer;
using DynuSharp.Utilities.Json;
using System.Text.Json;

namespace DynuSharp.Test.Utilities.Deserializer;
public class GenericDeserializer
{

    [Theory]
    [MemberData(nameof(DnsRecordTestData.GetDnsRecords), MemberType = typeof(DnsRecordTestData))]
    public void TestDnsRecords(DnsRecordBase record)
    {
        // Arrange
        var objectInstanceType = record.GetType();
        var deserializer = new GenericDeserializer<DnsRecordBase, RecordType>(nameof(DnsRecordBase.RecordType), "recordType");
        var jsonElement = JsonDocument.Parse(JsonSerializer.Serialize(record, objectInstanceType, GloabalJsonOptions.OptionsForDeserialize)).RootElement;

        // Act
        var result = deserializer.Deserialize(jsonElement);

        // Assert
        Assert.NotNull(result);
        Assert.IsType(objectInstanceType, result);
        Assert.Equal(record, result);
    }


    [Theory]
    [MemberData(nameof(DnsRecordTestData.GetDnsRecordFakers), MemberType = typeof(DnsRecordTestData))]
    public void TestGenericDnsRecords<T>(Faker<T> faker) where T : DnsRecordBase
    {
        // Arrange
        var fakeData = faker.Generate();
        var deserializer = new GenericDeserializer<DnsRecordBase, RecordType>(nameof(DnsRecordBase.RecordType), "recordType");
        var jsonElement = JsonDocument.Parse(JsonSerializer.Serialize(fakeData, GloabalJsonOptions.OptionsForDeserialize)).RootElement;

        // Act
        var result = deserializer.Deserialize<T>(jsonElement);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(fakeData, result);
    }

    [Theory]
    [MemberData(nameof(DnsRecordTestData.GetDnsRecordsArray), MemberType = typeof(DnsRecordTestData))]
    public void TestDnsRecordsArray(DnsRecordBase[] records)
    {
        // Arrange
        var deserializer = new GenericDeserializer<DnsRecordBase, RecordType>(nameof(DnsRecordBase.RecordType), "recordType");

        List<JsonElement> jsonElements = new();
        foreach (var record in records)
        {
            var objectInstanceType = record.GetType();
            var element = JsonDocument.Parse(JsonSerializer.Serialize(record, objectInstanceType, GloabalJsonOptions.OptionsForDeserialize)).RootElement;
            jsonElements.Add(element);

        }
        string jsonArrayString = "[" + string.Join(",", jsonElements.ConvertAll(element => JsonSerializer.Serialize(element))) + "]";
        var jsonElement = JsonDocument.Parse(jsonArrayString).RootElement;

        // Act
        var result = deserializer.DeserializeArray(jsonElement);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(records.Length, result.Count);
        for (int i = 0; i < records.Length; i++)
            Assert.Equal(records[i], result[i]);
    }

    [Theory]
    [MemberData(nameof(DnsRecordTestData.GetDnsRecordFakers), MemberType = typeof(DnsRecordTestData))]
    public void TestGenericDnsRecordsArray<T>(Faker<T> faker) where T : DnsRecordBase
    {
        // Arrange
        var deserializer = new GenericDeserializer<DnsRecordBase, RecordType>(nameof(DnsRecordBase.RecordType), "recordType");

        var records = faker.Generate(3);
        List<JsonElement> jsonElements = new();
        foreach (var record in records)
        {
            var objectInstanceType = record.GetType();
            var element = JsonDocument.Parse(JsonSerializer.Serialize(record, objectInstanceType, GloabalJsonOptions.OptionsForDeserialize)).RootElement;
            jsonElements.Add(element);

        }
        string jsonArrayString = "[" + string.Join(",", jsonElements.ConvertAll(element => JsonSerializer.Serialize(element))) + "]";
        var jsonElement = JsonDocument.Parse(jsonArrayString).RootElement;

        // Act
        var result = deserializer.DeserializeArray<T>(jsonElement);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(records.Count, result.Count);
        for (int i = 0; i < records.Count; i++)
            Assert.Equal(records[i], result[i]);
    }
}
