using DynuSharp.Data;

namespace DynuSharp.Exceptions;
public sealed class ParseException : DynuApiException
{
    public ParseException(ApiError apiError, Exception innerException) : base(apiError, innerException) { }
}
