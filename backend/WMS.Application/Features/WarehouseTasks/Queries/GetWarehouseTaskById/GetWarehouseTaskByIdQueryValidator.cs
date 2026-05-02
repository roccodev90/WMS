using FluentValidation;

namespace WMS.Application.Features.WarehouseTasks.Queries.GetWarehouseTaskById;

/// <summary>
/// Validatore per la query per ottenere un task di magazzino per ID.
/// </summary>
public sealed class GetWarehouseTaskByIdQueryValidator : AbstractValidator<GetWarehouseTaskByIdQuery>
{
    /// <summary>
    /// Crea un nuovo validatore per la query per ottenere un task di magazzino per ID.
    /// </summary>
    public GetWarehouseTaskByIdQueryValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
    }
}
