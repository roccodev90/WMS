using WCS.Domain.Interfaces;
using WCS.Infrastructure.Persistence;

namespace WCS.Infrastructure.Repositories;

public sealed class UnitOfWork : IUnitOfWork
{
    private readonly WcsDbContext _context;

    public UnitOfWork(WcsDbContext context) => _context = context;

    public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default) =>
        _context.SaveChangesAsync(cancellationToken);
}
