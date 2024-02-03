using DynuSharp.Data;
using System.Text.Json.Serialization;

namespace DynuSharp.Exceptions;
public class DynuApiException : Exception
{
    public const string ApiHelpLink = "https://www.dynu.com/Support/API";

    [JsonPropertyName("statusCode")]
    public int StatusCode { get; set; }

    [JsonPropertyName("type")]
    public string Type { get; set; } = string.Empty;

    public DynuApiException(int statusCode, string type, string message) : base(message)
    {
        StatusCode = statusCode;
        Type = type;
        HelpLink = ApiHelpLink;
    }

    public DynuApiException(ApiError apiError) : base(apiError.Message)
    {
        StatusCode = apiError.StatusCode;
        Type = apiError.Type;
        HelpLink = ApiHelpLink;
    }

    public DynuApiException(ApiError apiError, Exception innerException) : base(apiError.Message, innerException)
    {
        StatusCode = apiError.StatusCode;
        Type = apiError.Type;
        HelpLink = ApiHelpLink;
    }
}
