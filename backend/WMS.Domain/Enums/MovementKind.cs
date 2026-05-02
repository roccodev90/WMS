namespace WMS.Domain.Enums;

/// <summary>
/// Tipo di movimento.
/// </summary>
public enum MovementKind
{
    Putaway = 0, // deposito
    Pick = 1, // prelievo
    Transfer = 2, // trasferimento
    Replenishment = 3 // rifornimento
}
