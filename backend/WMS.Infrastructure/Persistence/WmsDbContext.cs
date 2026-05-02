using Microsoft.EntityFrameworkCore;
using WMS.Domain.Entities;

namespace WMS.Infrastructure.Persistence;

public sealed class WmsDbContext : DbContext
{
    public WmsDbContext(DbContextOptions<WmsDbContext> options)
        : base(options)
    {
    }

    public DbSet<Location> Locations => Set<Location>();
    public DbSet<Container> Containers => Set<Container>();
    public DbSet<WarehouseTask> WarehouseTasks => Set<WarehouseTask>();

    /// <summary>
    /// Configura le entità del modello.
    /// </summary>
    /// <param name="modelBuilder">Il costruttore del modello.</param>
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(WmsDbContext).Assembly);
        base.OnModelCreating(modelBuilder);
    }
}
