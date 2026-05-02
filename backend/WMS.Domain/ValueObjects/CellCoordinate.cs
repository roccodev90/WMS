namespace WMS.Domain.ValueObjects;

/// <summary>
/// Indirizzo di una cella di stoccaggio (corridoio, campata, livello).
/// </summary>
public sealed class CellCoordinate : ValueObject
{
    public int Aisle { get; private set; }
    public int Bay { get; private set; }
    public int Level { get; private set; }

    private CellCoordinate()
    {
    }

    /// <summary>
    /// Crea una nuova coordinata di cella.
    /// </summary>
    /// <param name="aisle">Numero del corridoio.</param>
    /// <param name="bay">Numero della campata.</param>
    /// <param name="level">Numero del livello.</param>
    public CellCoordinate(int aisle, int bay, int level)
    {
        if (aisle < 0)
            throw new ArgumentOutOfRangeException(nameof(aisle));
        if (bay < 0)
            throw new ArgumentOutOfRangeException(nameof(bay));
        if (level < 0)
            throw new ArgumentOutOfRangeException(nameof(level));

        Aisle = aisle;
        Bay = bay;
        Level = level;
    }

    /// <summary>
    /// Ottiene i componenti di uguaglianza per la coordinata della cella.
    /// </summary>
    /// <returns>Componenti di uguaglianza.</returns>
    protected override IEnumerable<object?> GetEqualityComponents()
    {
        yield return Aisle;
        yield return Bay;
        yield return Level;
    }
}
