using Microsoft.EntityFrameworkCore;
using WMS.Domain.Enums;
using WMS.Domain.Interfaces;
using WMS.Infrastructure.Persistence;

namespace WMS.Infrastructure.Repositories;

public sealed class WarehouseTaskQueries : IWarehouseTaskQueries
{
    private readonly WmsDbContext _context;

    /// <summary>
    /// Crea un nuovo repository per i task di magazzino.
    /// </summary>
    /// <param name="context">Il contesto del database.</param>
    public WarehouseTaskQueries(WmsDbContext context) => _context = context;

    /// <summary>
    /// Verifica se esiste almeno un task Pending o Active che ha come destinazione la location indicata.
    /// </summary>
    /// <param name="targetLocationId">L'ID della location di destinazione.</param>
    /// <param name="cancellationToken">Il token di cancellazione.</param>
    /// <returns>True se esiste almeno un task Pending o Active che ha come destinazione la location indicata.</returns>
    public Task<bool> HasPendingOrActiveTaskForTargetLocationAsync(
        Guid targetLocationId,
        CancellationToken cancellationToken = default) =>
        _context.WarehouseTasks.AnyAsync(
            t => t.TargetLocationId == targetLocationId
                 && (t.State == WarehouseTaskState.Pending || t.State == WarehouseTaskState.Active),
            cancellationToken);
}
