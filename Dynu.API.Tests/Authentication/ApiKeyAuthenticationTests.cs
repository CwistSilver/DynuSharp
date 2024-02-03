using DynuSharp.Authentication;
using DynuSharp.Security;
using Moq;

namespace DynuSharp.Test.Authentication;
public class ApiKeyAuthenticationTests
{
    private const string ValidApiKey = "validApiKey";
    private Mock<ISecureMemoryStorage> _mockSecureMemoryStorage;
    private ApiKeyAuthentication _apiKeyAuthentication;

    public ApiKeyAuthenticationTests()
    {
        _mockSecureMemoryStorage = new Mock<ISecureMemoryStorage>();
        _mockSecureMemoryStorage.Setup(s => s.Add(It.IsAny<string>())).Returns("key");
        _mockSecureMemoryStorage.Setup(s => s.Get<string>(It.IsAny<string>())).Returns(ValidApiKey);

        _apiKeyAuthentication = new ApiKeyAuthentication(ValidApiKey, _mockSecureMemoryStorage.Object);
    }

    [Fact]
    public void AddHeadersToClient_ShouldAddApiKeyHeader()
    {
        var httpClient = new HttpClient();

        _apiKeyAuthentication.AddHeadersToClient(httpClient);

        Assert.True(httpClient.DefaultRequestHeaders.Contains(AuthenticationHeader.ApiKeyHeader));
        Assert.Equal(ValidApiKey, httpClient.DefaultRequestHeaders.GetValues(AuthenticationHeader.ApiKeyHeader).First());
    }

    [Fact]
    public void RefreshAuthentication_ShouldRefreshApiKeyHeader()
    {
        var httpClient = new HttpClient();
        httpClient.DefaultRequestHeaders.Add(AuthenticationHeader.ApiKeyHeader, "oldApiKey");

        _apiKeyAuthentication.RefreshAuthentication(httpClient);

        Assert.True(httpClient.DefaultRequestHeaders.Contains(AuthenticationHeader.ApiKeyHeader));
        Assert.Equal(ValidApiKey, httpClient.DefaultRequestHeaders.GetValues(AuthenticationHeader.ApiKeyHeader).First());
    }

    [Fact]
    public void Dispose_ShouldDisposeSecureMemoryStorage()
    {
        _apiKeyAuthentication.Dispose();

        _mockSecureMemoryStorage.Verify(s => s.Dispose(), Times.Once);
    }
}
