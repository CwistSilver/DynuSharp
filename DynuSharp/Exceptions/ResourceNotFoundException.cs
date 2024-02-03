using DynuSharp.Data;

namespace DynuSharp.Exceptions;
public sealed class ResourceNotFoundException : DynuApiException
{
    public ResourceNotFoundException(ApiError apiError, Exception innerException) : base(apiError, innerException) { }
}
