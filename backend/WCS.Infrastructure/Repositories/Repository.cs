using Microsoft.EntityFrameworkCore;
using WCS.Domain.Entities;
using WCS.Domain.Interfaces;
using WCS.Infrastructure.Persistence;

namespace WCS.Infrastructure.Repositories;

public sealed class Repository<TEntity> : IRepository<TEntity>
    where TEntity : BaseEntity
{
    private readonly WcsDbContext _context;

    public Repository(WcsDbContext context) => _context = context;

    public async Task<TEntity?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default) =>
        await _context.Set<TEntity>().AsNoTracking().FirstOrDefaultAsync(e => e.Id == id, cancellationToken);

    public void Add(TEntity entity) => _context.Set<TEntity>().Add(entity);
}
