using DynuSharp.Data;

namespace DynuSharp.Exceptions;
public sealed class NotAMemberException : DynuApiException
{
    public NotAMemberException(ApiError apiError, Exception innerException) : base(apiError, innerException) { }
}
