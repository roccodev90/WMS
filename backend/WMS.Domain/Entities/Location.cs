using WMS.Domain.Enums;
using WMS.Domain.ValueObjects;

namespace WMS.Domain.Entities;

/// <summary>
/// Localizzazione di un contenitore in un magazzino.
/// </summary>
public sealed class Location : BaseEntity
{
    public CellCoordinate Coordinate { get; private set; } = null!;
    public ShelfKind ShelfKind { get; private set; }

    private Location()
    {
    }

    /// <summary>
    /// Crea una nuova localizzazione.
    /// </summary>
    /// <param name="coordinate">Coordinate della localizzazione.</param>
    /// <param name="shelfKind">Tipo di scaffale.</param>
    public Location(CellCoordinate coordinate, ShelfKind shelfKind)
    {
        ArgumentNullException.ThrowIfNull(coordinate);
        Id = Guid.NewGuid();
        Coordinate = coordinate;
        ShelfKind = shelfKind;
    }
}
