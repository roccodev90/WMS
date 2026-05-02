using WMS.Domain.Enums;

namespace WMS.Domain.Entities;

/// <summary>
/// Contenitore di stoccaggio.
/// </summary>
public sealed class Container : BaseEntity
{
    // GS1 SSCC (Serial Shipping Container Code)
    public string Sscc { get; private set; } = string.Empty;
    public ContainerKind Kind { get; private set; }

    private Container()
    {
    }

    /// <summary>
    /// Crea un nuovo contenitore.
    /// </summary>
    /// <param name="sscc">GS1 SSCC (Serial Shipping Container Code).</param>
    /// <param name="kind">Tipo di contenitore.</param>
    public Container(string sscc, ContainerKind kind)
    {
        if (string.IsNullOrWhiteSpace(sscc))
            throw new ArgumentException("SSCC obbligatorio.", nameof(sscc));

        sscc = sscc.Trim();
        if (sscc.Length != 18)
            throw new ArgumentException("SSCC deve essere di 18 caratteri (GS1).", nameof(sscc));

        foreach (var c in sscc)
        {
            if (c is < '0' or > '9')
                throw new ArgumentException("SSCC deve contenere solo cifre.", nameof(sscc));
        }

        Id = Guid.NewGuid();
        Sscc = sscc;
        Kind = kind;
    }
}
