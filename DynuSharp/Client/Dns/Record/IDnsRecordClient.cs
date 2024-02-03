using DynuSharp.Data.Dns.Record;
using DynuSharp.Exceptions;

namespace DynuSharp.Client.Dns.Record;
public interface IDnsRecordClient
{
    /// <summary>
    /// Get a list of DNS records for DNS service.
    /// </summary>
    /// <param name="id">The id of the domain for DNS service.</param>
    /// <returns>A list of DNS records.</returns>
    Task<IReadOnlyList<DnsRecordBase>> GetListAsync(int id);

    /// <summary>
    /// Retrieves DNS records of the specified type <typeparamref name="T"/> for a given hostname.
    /// </summary>
    /// <param name="recordHostname">The hostname of the DNS records.</param>
    /// <returns>A list of DNS records of the type <typeparamref name="T"/></returns>
    /// <exception cref="ArgumentException">Thrown when T is of type DnsRecordBase</exception>
    Task<IReadOnlyList<T>> GetListOfTypeAsync<T>(string recordHostname) where T : DnsRecordBase;

    /// <summary>
    /// Retrieves DNS records of the specified <see cref="RecordType"/> for a given hostname.
    /// </summary>
    /// <param name="recordHostname">The hostname of the DNS records.</param>
    /// <param name="recordType">The record type of DNS records.</param>
    /// <returns>A list of DNS records matching the specified type.</returns>
    Task<IReadOnlyList<DnsRecordBase>> GetListOfTypeAsync(string recordHostname, RecordType recordType);

    /// <summary>
    /// Get details of a DNS record for DNS service.
    /// </summary>
    /// <param name="id">The id of the domain for DNS service.</param>
    /// <param name="recordId">The id of the DNS record for DNS service.</param>
    /// <returns>Details of a DNS record of type <typeparamref name="T"/>.</returns>
    Task<T> GetAsync<T>(int id, int recordId) where T : DnsRecordBase;

    /// <summary>
    /// Get details of a DNS record for DNS service.
    /// </summary>
    /// <param name="id">The id of the domain for DNS service.</param>
    /// <param name="recordId">The id of the DNS record for DNS service.</param>
    /// <returns>Details of a DNS record.</returns>
    Task<DnsRecordBase> GetAsync(int id, int recordId);

    /// <summary>
    /// Add a new DNS record for DNS service.
    /// </summary>
    /// <param name="id">The id of the domain for DNS service.</param>
    /// <param name="dnsRecord">The DNS record to add.</param>
    /// <exception cref="DynuApiException">Thrown when the addition fails due to various reasons such as authentication failure, resource not found, server error, etc.</exception>
    Task<DnsRecordBase> AddAsync(int id, DnsRecordBase dnsRecord);

    /// <summary>
    /// Update an existing DNS record for DNS service.
    /// </summary>
    /// <param name="id">The id of the domain for DNS service.</param>
    /// <param name="recordId">The id of the DNS record for DNS service.</param>
    /// <param name="dnsRecord">The DNS record to update.</param>
    /// <exception cref="DynuApiException">Thrown when the addition fails due to various reasons such as authentication failure, resource not found, server error, etc.</exception>
    Task<DnsRecordBase> UpdateAsync(int id, int recordId, DnsRecordBase dnsRecord);

    /// <summary>
    /// Remove a DNS record from DNS service.
    /// </summary>
    /// <param name="id">The id of the domain for DNS service.</param>
    /// <param name="recordId">The id of the DNS record for DNS service.</param>
    /// <exception cref="DynuApiException">Thrown when the addition fails due to various reasons such as authentication failure, resource not found, server error, etc.</exception>
    Task DeleteAsync(int id, int recordId);
}
