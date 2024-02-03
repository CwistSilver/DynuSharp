using DynuSharp.Data.Limit;

namespace DynuSharp.Client.Monitor.Limit;
public interface ILimitClient
{
    /// <summary>
    /// Limits associated with monitoring.
    /// </summary>
    /// <returns>Limits associated with monitoring.</returns>
    Task<LimitBase> Get();
}
