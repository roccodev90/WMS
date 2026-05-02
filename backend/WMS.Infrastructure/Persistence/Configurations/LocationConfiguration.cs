using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WMS.Domain.Entities;

namespace WMS.Infrastructure.Persistence.Configurations;

/// <summary>
/// Configurazione dell'entità Location.
/// </summary>
public sealed class LocationConfiguration : IEntityTypeConfiguration<Location>
{
    public void Configure(EntityTypeBuilder<Location> builder)
    {
        builder.ToTable("locations");
        builder.HasKey(l => l.Id);

        builder.OwnsOne(l => l.Coordinate, c =>
        {
            c.Property(x => x.Aisle).HasColumnName("coordinate_aisle");
            c.Property(x => x.Bay).HasColumnName("coordinate_bay");
            c.Property(x => x.Level).HasColumnName("coordinate_level");
        });

        builder.Property(l => l.ShelfKind).HasConversion<int>();
    }
}
