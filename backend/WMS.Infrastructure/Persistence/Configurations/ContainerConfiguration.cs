using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WMS.Domain.Entities;

namespace WMS.Infrastructure.Persistence.Configurations;

/// <summary>
/// Configurazione dell'entità Container.
/// </summary>
public sealed class ContainerConfiguration : IEntityTypeConfiguration<Container>
{
    public void Configure(EntityTypeBuilder<Container> builder)
    {
        builder.ToTable("containers");
        builder.HasKey(c => c.Id);
        builder.Property(c => c.Sscc).HasMaxLength(18).IsRequired();
        builder.HasIndex(c => c.Sscc).IsUnique();
        builder.Property(c => c.Kind).HasConversion<int>();
    }
}
