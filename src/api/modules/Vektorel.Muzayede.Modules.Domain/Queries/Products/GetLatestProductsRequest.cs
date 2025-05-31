using MediatR;
using Microsoft.EntityFrameworkCore;
using Vektorel.Muzayede.Common;
using Vektorel.Muzayede.Data;
using Vektorel.Muzayede.Modules.Domain.Queries.Dtos.Products;

namespace Vektorel.Muzayede.Modules.Domain.Queries.Products;

public class GetLatestProductsRequest : IRequest<Result<List<ProductDto>>>
{

}

internal class GetLatestProductsQuery : IRequestHandler<GetLatestProductsRequest, Result<List<ProductDto>>>
{
    private readonly MuzayedeContext context;

    public GetLatestProductsQuery(MuzayedeContext context)
    {
        this.context = context;
    }
    public async Task<Result<List<ProductDto>>> Handle(GetLatestProductsRequest request, CancellationToken cancellationToken)
    {
        var products = await context.Products.Where(f => f.IsActive)
                                             .OrderByDescending(o => o.CreatedAt)
                                             .Take(20)
                                             .Select(s => new ProductDto
                                             {
                                                 Id = s.Id,
                                                 Name = s.Name,
                                                 Price = s.CurrentPrice,
                                                 CreatedAt = s.CreatedAt,
                                             })
                                             .ToListAsync(cancellationToken);
        return Result<List<ProductDto>>.Success(products);
    }
}