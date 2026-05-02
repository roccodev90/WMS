using MediatR;
using Microsoft.AspNetCore.Mvc;
using WMS.Application.Common.Exceptions;
using WMS.Application.DTOs;
using WMS.Application.Features.WarehouseTasks.Commands.CreateMovementTask;
using WMS.Application.Features.WarehouseTasks.Queries.GetWarehouseTaskById;

namespace WMS.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public sealed class WarehouseTasksController : ControllerBase
{
    private readonly IMediator _mediator;

    /// <summary>
    /// Crea un nuovo controller per i task di magazzino.
    /// </summary>
    /// <param name="mediator">Il mediator.</param>
    public WarehouseTasksController(IMediator mediator) => _mediator = mediator;

    [HttpPost]
    [ProducesResponseType(typeof(CreateMovementTaskResponseDto), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status409Conflict)]
    public async Task<ActionResult<CreateMovementTaskResponseDto>> Create(
        [FromBody] CreateMovementTaskCommand command,
        CancellationToken cancellationToken)
    {
        try
        {
            var dto = await _mediator.Send(command, cancellationToken);
            return CreatedAtAction(nameof(GetById), new { id = dto.Id }, dto);
        }
        catch (LocationNotFoundException)
        {
            return NotFound();
        }
        catch (LocationNotFreeException)
        {
            return Conflict();
        }
    }

    [HttpGet("{id:guid}")]
    [ProducesResponseType(typeof(WarehouseTaskDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<WarehouseTaskDto>> GetById(Guid id, CancellationToken cancellationToken)
    {
        var dto = await _mediator.Send(new GetWarehouseTaskByIdQuery(id), cancellationToken);
        return dto is null ? NotFound() : Ok(dto);
    }
}
