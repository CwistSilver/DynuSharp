namespace DynuSharp.Client;

/// <summary>
/// Provides a way to get an authenticated HTTP client.
/// </summary>
public interface IConnection : IDisposable
{
    /// <summary>
    /// Retrieves a valid, potentially authenticated HTTP client.
    /// </summary>
    /// <returns>An authenticated HttpClient instance.</returns>
    Task<HttpClient> GetValidHttpClient();
}
