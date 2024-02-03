using DynuSharp.Utilities.Json;
using DynuSharp.Client.Dns.Group;
using DynuSharp.Exceptions;
using System.Text.Json.Serialization;

namespace DynuSharp.Data.Dns;
/// <summary>
/// Represents a DNS group, providing specific attributes such as its name and whether it is password protected.
/// </summary>
public sealed class DnsGroup
{
    /// <summary>
    /// The unique identifier for the DNS group.
    /// <para>Note: Read-only for API requests (This property is not considered when creating or updating through API requests).</para>
    /// </summary>
    [JsonPropertyName("id")]
    [IgnoreOnPost]
    public int Id { get; set; }

    /// <summary>
    /// The name of the DNS group.
    /// <para>Note: Changing the group name is not allowed during update operations; attempting to do so will result in a <see cref="DynuApiException"/>.</para>
    /// </summary>
    [JsonPropertyName("groupName")]
    public string GroupName { get; set; } = string.Empty;

    /// <summary>
    /// The password of the DNS group, which is used only when creating a new group or updating an existing group.<br/>
    /// This property is not transmitted during <see cref="IDnsGroupClient.GetListAsync"/> method calls.
    /// <para>Note: Setting a group password requires membership. </para>
    /// <para>
    /// Learn more about 
    /// <a href="https://www.dynu.com/en-US/Blog/Article?Article=Use-group-passwords-to-safeguard-your-IP-updates" target="_blank">
    /// Group password protected
    /// </a>
    /// </para>
    /// </summary>
    [JsonPropertyName("groupPassword")]
    public string? GroupPassword { get; set; }

    /// <summary>
    /// Indicates whether the DNS group is password protected.
    /// <para>Note: Read-only for API requests (This property is not considered when creating or updating through API requests).</para>
    /// <para>
    /// Learn more about 
    /// <a href="https://www.dynu.com/en-US/Blog/Article?Article=Use-group-passwords-to-safeguard-your-IP-updates" target="_blank">
    /// Group password protected
    /// </a>
    /// </para>
    /// </summary>
    [JsonPropertyName("passwordProtected")]
    [IgnoreOnPost]
    public bool PasswordProtected { get; set; }

    public override bool Equals(object? obj)
    {
        if (obj is null || obj is not DnsGroup other)
            return false;

        if (ReferenceEquals(this, obj))
            return true;

        return Id == other.Id &&
               GroupName.Equals(other.GroupName, StringComparison.Ordinal) &&
               string.Equals(GroupPassword, other.GroupPassword, StringComparison.Ordinal);
    }

    public override int GetHashCode() => HashCode.Combine(Id, GroupName, GroupPassword);
}