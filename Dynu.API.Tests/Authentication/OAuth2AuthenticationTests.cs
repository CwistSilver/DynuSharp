using DynuSharp.Authentication;
using DynuSharp.Data.Authentication;
using DynuSharp.Security;
using Moq;
using Moq.Protected;
using System.Net;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;

namespace DynuSharp.Test.Authentication;
public class OAuth2AuthenticationTests
{
    private const string ValidSecret = "validSecret";
    private readonly string ValidClientId = Guid.NewGuid().ToString();

    private Mock<ISecureMemoryStorage> _mockSecureMemoryStorage;
    private OAuth2Authentication _oAuth2Authentication;
    private Mock<HttpMessageHandler> _mockHttpMessageHandler;
    private HttpClient _mockHttpClient;

    public OAuth2AuthenticationTests()
    {
        _mockSecureMemoryStorage = new Mock<ISecureMemoryStorage>();
        _mockSecureMemoryStorage.Setup(s => s.Add(ValidSecret)).Returns("keySecret");
        _mockSecureMemoryStorage.Setup(s => s.Add(ValidClientId)).Returns("keyClientId");
        _mockSecureMemoryStorage.Setup(s => s.Get<string>("keySecret")).Returns(ValidSecret);
        _mockSecureMemoryStorage.Setup(s => s.Get<string>("keyClientId")).Returns(ValidClientId);

        _oAuth2Authentication = new OAuth2Authentication(ValidClientId, ValidSecret, _mockSecureMemoryStorage.Object);

        _mockHttpMessageHandler = new Mock<HttpMessageHandler>();
        _mockHttpClient = new HttpClient(_mockHttpMessageHandler.Object)
        {
            BaseAddress = new Uri("http://localhost")
        };
    }

    [Fact]
    public async Task AddHeadersToClient_ShouldAddOAuth2Header()
    {
        SetupHttpMessageHandlerMock(HttpStatusCode.OK, new AuthenticationHeaderValue("Bearer", "token"));

        await _oAuth2Authentication.AddHeadersToClient(_mockHttpClient);

        Assert.True(_mockHttpClient.DefaultRequestHeaders.Authorization.Scheme.Contains("Bearer"));
    }

    [Fact]
    public async Task RefreshAuthentication_ShouldRefreshOAuth2Header()
    {
        _mockHttpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", "oldToken");

        SetupHttpMessageHandlerMock(HttpStatusCode.OK, new AuthenticationHeaderValue("Bearer", "newToken"));

        await _oAuth2Authentication.RefreshAuthentication(_mockHttpClient);

        Assert.True(_mockHttpClient.DefaultRequestHeaders.Authorization.Scheme.Contains("Bearer"));
        Assert.NotEqual("oldToken", _mockHttpClient.DefaultRequestHeaders.Authorization.Parameter);
    }

    [Fact]
    public void Dispose_ShouldDisposeSecureMemoryStorage()
    {
        _oAuth2Authentication.Dispose();

        _mockSecureMemoryStorage.Verify(s => s.Dispose(), Times.Once);
    }

    private void SetupHttpMessageHandlerMock(HttpStatusCode statusCode, AuthenticationHeaderValue authHeader)
    {
        var httpRequestMessage = new HttpRequestMessage();
        httpRequestMessage.Headers.Authorization = authHeader;

        var oAuth2Reponse = new OAuth2Reponse() { AccessToken = "token", ExpiresIn = 3600, TokenType = "Bearer" };
        var content = new StringContent(JsonSerializer.Serialize(oAuth2Reponse), Encoding.UTF8, "application/json");

        var httpReponseMessage = new HttpResponseMessage
        {
            StatusCode = statusCode,
            Content = content
        };

        _mockHttpMessageHandler
            .Protected()
            .Setup<Task<HttpResponseMessage>>(
                "SendAsync",
                            ItExpr.Is<HttpRequestMessage>(request => request.Method == HttpMethod.Get),
                ItExpr.IsAny<CancellationToken>()
            )
            .ReturnsAsync(httpReponseMessage);
    }

}
