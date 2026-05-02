using MediatR;
using Microsoft.AspNetCore.Mvc;
using WCS.Application.DTOs;
using WCS.Application.Features.Products.Queries.GetProductById;

namespace WCS.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public sealed class ProductsController : ControllerBase
{
    private readonly IMediator _mediator;

    public ProductsController(IMediator mediator) => _mediator = mediator;

    [HttpGet("{id:guid}")]
    [ProducesResponseType(typeof(ProductDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<ProductDto>> GetById(Guid id, CancellationToken cancellationToken)
    {
        var dto = await _mediator.Send(new GetProductByIdQuery(id), cancellationToken);
        return dto is null ? NotFound() : Ok(dto);
    }
}
