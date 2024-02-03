using DynuSharp.Security;
using System.Security.Authentication;

namespace DynuSharp.Authentication;
/// <summary>
/// Provides methods and properties for handling API key authentication.
/// </summary>
public sealed class ApiKeyAuthentication : IAuthentication
{
    private readonly string _apiKeyEnvironmentKey;
    private readonly ISecureMemoryStorage _secureMemoryStorage;

    public bool IsExpired => false;

    /// <summary>
    /// Initializes a new instance of the ApiKeyAuthentication class using the provided API key.
    /// </summary>
    /// <param name="apiKey">The API key to use for authentication.</param>
    /// <exception cref="AuthenticationException">Thrown when the API key is null or empty.</exception>
    public ApiKeyAuthentication(string apiKey)
    {
        if (string.IsNullOrEmpty(apiKey))
            throw new AuthenticationException($"The API-Key has no value! To use the {nameof(ApiKeyAuthentication)} a valid API key is needed.");

        _secureMemoryStorage = new SecureMemoryStorage();
        _apiKeyEnvironmentKey = _secureMemoryStorage.Add(apiKey);
    }

    public ApiKeyAuthentication(string apiKey, ISecureMemoryStorage secureMemoryStorage)
    {
        if (string.IsNullOrEmpty(apiKey))
            throw new AuthenticationException($"The API-Key has no value! To use the {nameof(ApiKeyAuthentication)} a valid API key is needed.");

        _secureMemoryStorage = secureMemoryStorage;
        _apiKeyEnvironmentKey = _secureMemoryStorage.Add(apiKey);
    }

    public Task AddHeadersToClient(HttpClient client)
    {
        var apiKey = _secureMemoryStorage.Get<string>(_apiKeyEnvironmentKey);

        client.DefaultRequestHeaders.Add(AuthenticationHeader.ApiKeyHeader, apiKey);
        return Task.CompletedTask;
    }

    public Task RefreshAuthentication(HttpClient client)
    {
        client.DefaultRequestHeaders.Remove(AuthenticationHeader.ApiKeyHeader);
        var apiKey = _secureMemoryStorage.Get<string>(_apiKeyEnvironmentKey);
        client.DefaultRequestHeaders.Add(AuthenticationHeader.ApiKeyHeader, apiKey);
        return Task.CompletedTask;
    }

    public void Dispose()
    {
        _secureMemoryStorage.Dispose();
    }
}
