using AutoMapper;
using MediatR;
using WCS.Application.DTOs;
using WCS.Domain.Entities;
using WCS.Domain.Interfaces;

namespace WCS.Application.Features.Products.Queries.GetProductById;

public sealed class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery, ProductDto?>
{
    private readonly IMapper _mapper;
    private readonly IRepository<Product> _repository;

    public GetProductByIdQueryHandler(IRepository<Product> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<ProductDto?> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _repository.GetByIdAsync(request.Id, cancellationToken);
        return entity is null ? null : _mapper.Map<ProductDto>(entity);
    }
}
