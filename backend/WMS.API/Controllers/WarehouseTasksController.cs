using MediatR;
using Microsoft.AspNetCore.Mvc;
using WMS.Application.DTOs;
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

    /// <summary>
    /// Ottiene un task di magazzino per ID.
    /// </summary>
    /// <param name="id">L'ID del task di magazzino.</param>
    /// <param name="cancellationToken">Il token di cancellazione.</param>
    /// <returns>Il task di magazzino per ID.</returns>
    [HttpGet("{id:guid}")]
    [ProducesResponseType(typeof(WarehouseTaskDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<WarehouseTaskDto>> GetById(Guid id, CancellationToken cancellationToken)
    {
        var dto = await _mediator.Send(new GetWarehouseTaskByIdQuery(id), cancellationToken);
        return dto is null ? NotFound() : Ok(dto);
    }
}
