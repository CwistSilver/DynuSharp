using DynuSharp.Data;

namespace DynuSharp.Exceptions;
public sealed class DynuAuthenticationException : DynuApiException
{
    public DynuAuthenticationException(ApiError apiError, Exception innerException) : base(apiError, innerException) { }
}