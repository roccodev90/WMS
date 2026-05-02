using Microsoft.EntityFrameworkCore;
using WMS.Domain.Entities;
using WMS.Domain.Interfaces;
using WMS.Infrastructure.Persistence;

namespace WMS.Infrastructure.Repositories;

public sealed class Repository<TEntity> : IRepository<TEntity>
    where TEntity : BaseEntity
{
    private readonly WmsDbContext _context;

    public Repository(WmsDbContext context) => _context = context;

    public async Task<TEntity?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default) =>
        await _context.Set<TEntity>().AsNoTracking().FirstOrDefaultAsync(e => e.Id == id, cancellationToken);

    public void Add(TEntity entity) => _context.Set<TEntity>().Add(entity);
}
