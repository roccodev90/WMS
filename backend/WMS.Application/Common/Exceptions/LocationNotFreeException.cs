namespace WMS.Application.Common.Exceptions;

public sealed class LocationNotFreeException : Exception
{
    public LocationNotFreeException(Guid locationId)
        : base($"La location di destinazione non è libera (task in corso): {locationId}")
    {
        LocationId = locationId;
    }

    public Guid LocationId { get; }
}
