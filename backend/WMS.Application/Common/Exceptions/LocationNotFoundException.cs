namespace WMS.Application.Common.Exceptions;

/// <summary>
/// Eccezione lanciata quando una location non è trovata.
/// </summary>  
public sealed class LocationNotFoundException : Exception
{   
    /// <summary>
    /// Crea una nuova eccezione quando una location non è trovata.
    /// </summary>
    /// <param name="locationId">L'ID della location non trovata.</param>
    public LocationNotFoundException(Guid locationId)
        : base($"Location non trovata: {locationId}")
    {
        LocationId = locationId;
    }

    public Guid LocationId { get; }
}
