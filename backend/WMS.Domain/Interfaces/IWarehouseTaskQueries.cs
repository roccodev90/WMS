namespace WMS.Domain.Interfaces;

/// <summary>
/// Query specifiche sui task di magazzino (disponibilità ubicazioni, ecc.).
/// </summary>
public interface IWarehouseTaskQueries
{
    /// <summary>
    /// True se esiste almeno un task Pending o Active che ha come destinazione la location indicata.
    /// </summary>
    Task<bool> HasPendingOrActiveTaskForTargetLocationAsync(
        Guid targetLocationId,
        CancellationToken cancellationToken = default);
}
