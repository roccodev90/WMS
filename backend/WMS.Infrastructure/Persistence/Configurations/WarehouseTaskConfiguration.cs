using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WMS.Domain.Entities;

namespace WMS.Infrastructure.Persistence.Configurations;

/// <summary>
/// Configurazione dell'entità WarehouseTask.
/// </summary>
public sealed class WarehouseTaskConfiguration : IEntityTypeConfiguration<WarehouseTask>
{
    public void Configure(EntityTypeBuilder<WarehouseTask> builder)
    {
        builder.ToTable("warehouse_tasks");
        builder.HasKey(t => t.Id);
        builder.Property(t => t.MovementKind).HasConversion<int>();
        builder.Property(t => t.State).HasConversion<int>();
        builder.Property(t => t.Priority).IsRequired();
    }
}
