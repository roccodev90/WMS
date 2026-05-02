using FluentValidation;

namespace WMS.Application.Features.WarehouseTasks.Commands.CreateMovementTask;

public sealed class CreateMovementTaskCommandValidator : AbstractValidator<CreateMovementTaskCommand>
{
    /// <summary>
    /// Crea un nuovo validatore per il comando di creazione di un task di movimento.
    /// </summary>  
    public CreateMovementTaskCommandValidator()
    {
        RuleFor(x => x.TargetLocationId).NotEmpty();
        RuleFor(x => x.Priority).GreaterThanOrEqualTo(0);
        RuleFor(x => x.MovementKind).IsInEnum();
    }
}
