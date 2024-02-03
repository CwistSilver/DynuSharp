using DynuSharp.Client.Monitor.Limit;
using DynuSharp.Data.Monitor;

namespace DynuSharp.Client.Monitor;
public interface IMonitorClient
{
    /// <summary>
    /// Gets an object to interact with the limit-related functionalities of the DynuDNS service.
    /// </summary>
    ILimitClient Limits { get; }

    /// <summary>
    /// Retrieves a list of monitors.
    /// <para>REQUIRES MEMBERSHIP.</para> 
    /// </summary>
    /// <returns>A list of monitors.</returns>
    Task<IReadOnlyList<MonitorBase>> GetListAsync();

    /// <summary>
    /// Add a new monitor.
    /// <para>REQUIRES MEMBERSHIP.</para> 
    /// </summary>
    Task AddAsync(MonitorBase monitorBase);

    /// <summary>
    /// Get details of a monitor.
    /// <param name="id">The id of the monitor.</param>
    /// <para>REQUIRES MEMBERSHIP.</para> 
    /// </summary>
    /// <returns>Details of a monitor.</returns>
    Task<MonitorBase> GetAsync(int id);

    /// <summary>
    /// Delete a monitor.
    /// <param name="id">The id of the monitor.</param>
    /// <para>REQUIRES MEMBERSHIP.</para> 
    /// </summary>
    Task DeleteAsync(int id);

    /// <summary>
    /// Pause a monitor.
    /// <param name="id">The id of the monitor.</param>
    /// <para>REQUIRES MEMBERSHIP.</para> 
    /// </summary>
    Task PauseAsync(int id);

    /// <summary>
    /// Unpause a monitor.
    /// <param name="id">The id of the monitor.</param>
    /// <para>REQUIRES MEMBERSHIP.</para> 
    /// </summary>
    Task UnpauseAsync(int id);
}
