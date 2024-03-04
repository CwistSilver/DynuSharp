using DynuSharp.Utilities.Json;
using DynuSharp.Exceptions;
using System.Text.Json.Serialization;

namespace DynuSharp.Data.DnsWebRedirect;
public class DnsWebRedirectBase
{
    /// <summary>
    /// The unique identifier for the web redirect.
    /// <para>Note: Read-only for API requests (This property is not considered when creating or updating through API requests).</para>
    /// </summary>
    [JsonPropertyName("id")]
    [IgnoreOnPost]
    public int Id { get; set; }

    /// <summary>
    /// The unique identifier for the domain associated with the web redirect.
    /// <para>Note: Read-only for API requests (This property is not considered when creating or updating through API requests).</para>
    /// </summary>
    [JsonPropertyName("domainId")]
    [IgnoreOnPost]
    public int DomainId { get; set; }

    /// <summary>
    /// The name of the domain associated with the web redirect.
    /// <para>Note: Read-only for API requests (This property is not considered when creating or updating through API requests).</para>
    /// </summary>
    [JsonPropertyName("domainName")]
    [IgnoreOnPost]
    public string DomainName { get; set; } = string.Empty;

    /// <summary>
    /// The name of the node associated with the web redirect.
    /// <para>Note: Must be unique and, once set, cannot be changed during update operations; attempting to do so will result in a <see cref="DynuApiException"/>.</para>
    /// </summary>
    [JsonPropertyName("nodeName")]
    public string NodeName { get; set; } = string.Empty;


    /// <summary>
    /// The hostname associated with the web redirect.
    /// <para>Note: Read-only for API requests (This property is not considered when creating or updating through API requests).</para>
    /// </summary>
    [JsonPropertyName("hostname")]
    [IgnoreOnPost]
    public string Hostname { get; set; } = string.Empty;

    /// <summary>
    /// The type of web redirect, which can either be URL forwarding (UF) or port forwarding (PF).
    /// </summary>
    [JsonPropertyName("redirectType")]
    public virtual RedirectType RedirectType { get; }

    /// <summary>
    /// The current state of the web redirect, indicating whether it is active or not.
    /// </summary>
    [JsonPropertyName("state")]
    public bool State { get; set; }

    /// <summary>
    /// The date and time when the web redirect was last updated.
    /// <para>Note: Read-only for API requests (This property is not considered when creating or updating through API requests).</para>
    /// </summary>
    [JsonPropertyName("updatedOn")]
    [IgnoreOnPost]
    public DateTime UpdatedOn { get; set; }

    /// <summary>
    /// Indicates whether to use dynamic IPv4 address for the redirect.
    /// </summary>
    [JsonPropertyName("useDynamicIPv4Address")]
    public bool UseDynamicIPv4Address { get; set; }

    /// <summary>
    /// Indicates whether to use dynamic IPv6 address for the redirect.
    /// </summary>
    [JsonPropertyName("useDynamicIPv6Address")]
    public bool UseDynamicIPv6Address { get; set; }

    /// <summary>
    /// Indicates whether to cloak the redirect.
    /// </summary>
    [JsonPropertyName("cloak")]
    public bool Cloak { get; set; }

    /// <summary>
    /// Indicates whether to include the query string in the redirect.
    /// </summary>
    [JsonPropertyName("includeQueryString")]
    public bool IncludeQueryString { get; set; }

    /// <summary>
    /// Indicates whether to perform a 301 redirect.
    /// </summary>
    [JsonPropertyName("redirect301")]
    public bool Redirect301 { get; set; }

    /// <summary>
    /// The title to use for the redirect, which might be displayed in search results.
    /// </summary>
    [JsonPropertyName("title")]
    public string Title { get; set; } = string.Empty;

    /// <summary>
    /// The meta keywords to use for the redirect, which can influence SEO.
    /// </summary>
    /// <remarks>
    /// Example values: 
    /// "plumbing, water supply, contract work"
    /// </remarks>
    [JsonPropertyName("metaKeywords")]
    public string MetaKeywords { get; set; } = string.Empty;

    /// <summary>
    /// The meta description to use for the redirect, which might be displayed in search results.
    /// </summary>
    /// <remarks>
    /// Example value: 
    /// "Our company performs general plumbing and contract work."
    /// </remarks>
    [JsonPropertyName("metaDescription")]
    public string MetaDescription { get; set; } = string.Empty;

    public override bool Equals(object? obj)
    {
        if (obj is null || obj is not DnsWebRedirectBase other)
            return false;

        if (ReferenceEquals(this, obj))
            return true;

        return Id == other.Id &&
               DomainId == other.DomainId &&
               DomainName.Equals(other.DomainName, StringComparison.Ordinal) &&
               NodeName.Equals(other.NodeName, StringComparison.Ordinal) &&
               Hostname.Equals(other.Hostname, StringComparison.Ordinal) &&
               RedirectType == other.RedirectType &&
               State == other.State &&
               UpdatedOn == other.UpdatedOn &&
               UseDynamicIPv4Address == other.UseDynamicIPv4Address &&
               UseDynamicIPv6Address == other.UseDynamicIPv6Address &&
               Cloak == other.Cloak &&
               IncludeQueryString == other.IncludeQueryString &&
               Redirect301 == other.Redirect301 &&
               Title.Equals(other.Title, StringComparison.Ordinal) &&
               MetaKeywords.Equals(other.MetaKeywords, StringComparison.Ordinal) &&
               MetaDescription.Equals(other.MetaDescription, StringComparison.Ordinal);
    }

    public override int GetHashCode()
    {
        var hashCode = new HashCode();
        hashCode.Add(Id);
        hashCode.Add(DomainId);
        hashCode.Add(DomainName);
        hashCode.Add(NodeName);
        hashCode.Add(Hostname);
        hashCode.Add(RedirectType);
        hashCode.Add(State);
        hashCode.Add(UpdatedOn);
        hashCode.Add(UseDynamicIPv4Address);
        hashCode.Add(UseDynamicIPv6Address);
        hashCode.Add(Cloak);
        hashCode.Add(IncludeQueryString);
        hashCode.Add(Redirect301);
        hashCode.Add(Title);
        hashCode.Add(MetaKeywords);
        hashCode.Add(MetaDescription);
        return hashCode.ToHashCode();
    }
}