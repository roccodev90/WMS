namespace WMS.Domain.Enums;

/// <summary>
/// Stato di un task di magazzino.
/// </summary>
public enum WarehouseTaskState
{
    Pending = 0, // in attesa
    Active = 1, // in corso
    Completed = 2 // completato
}
