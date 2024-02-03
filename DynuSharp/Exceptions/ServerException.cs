using DynuSharp.Data;

namespace DynuSharp.Exceptions;
public sealed class ServerException : DynuApiException
{
    public ServerException(ApiError apiError, Exception innerException) : base(apiError, innerException) { }
}
