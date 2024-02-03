namespace DynuSharp.Authentication;
/// <summary>
/// Interface to manage API authentication.
/// </summary>
public interface IAuthentication : IDisposable
{
    /// <summary>
    /// Indicates whether the authentication is expired.
    /// </summary>
    bool IsExpired { get; }

    /// <summary>
    /// Adds authentication headers to an HttpClient instance.
    /// </summary>
    /// <param name="client">The HttpClient to add the headers to.</param>
    Task AddHeadersToClient(HttpClient client);

    /// <summary>
    /// Refreshes the authentication for an HttpClient instance.
    /// </summary>
    /// <param name="client">The HttpClient to refresh the authentication for.</param>
    Task RefreshAuthentication(HttpClient client);
}
