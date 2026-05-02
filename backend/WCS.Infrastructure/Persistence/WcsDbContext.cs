using Microsoft.EntityFrameworkCore;
using WCS.Domain.Entities;

namespace WCS.Infrastructure.Persistence;

public sealed class WcsDbContext : DbContext
{
    public WcsDbContext(DbContextOptions<WcsDbContext> options)
        : base(options)
    {
    }

    public DbSet<Product> Products => Set<Product>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(WcsDbContext).Assembly);
        base.OnModelCreating(modelBuilder);
    }
}
