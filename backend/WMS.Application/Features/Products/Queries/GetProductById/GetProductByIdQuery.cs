using MediatR;
using WMS.Application.DTOs;

namespace WMS.Application.Features.Products.Queries.GetProductById;

public sealed record GetProductByIdQuery(Guid Id) : IRequest<ProductDto?>;
