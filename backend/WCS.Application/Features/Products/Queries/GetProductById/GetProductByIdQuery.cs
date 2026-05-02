using MediatR;
using WCS.Application.DTOs;

namespace WCS.Application.Features.Products.Queries.GetProductById;

public sealed record GetProductByIdQuery(Guid Id) : IRequest<ProductDto?>;
