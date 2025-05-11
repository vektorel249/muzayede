using MediatR;
using Microsoft.EntityFrameworkCore;
using Vektorel.Muzayede.Common;
using Vektorel.Muzayede.Data;
using Vektorel.Muzayede.Modules.Domain.Queries.Dtos.Products;

namespace Vektorel.Muzayede.Modules.Domain.Queries.Products;

public class GetPagedProductsRequest : IRequest<Result<GetPagedProducts>>
{
    public GetPagedProductsRequest(int page, int count)
    {
        Page = page;
        Count = count > 50 ? 50 : count;
    }

    public int Page { get; }
    public int Count { get; }
}


internal class GetPagedProductsQuery : IRequestHandler<GetPagedProductsRequest, Result<GetPagedProducts>>
{
    private readonly MuzayedeContext context;

    public GetPagedProductsQuery(MuzayedeContext context)
    {
        this.context = context;
    }
    public async Task<Result<GetPagedProducts>> Handle(GetPagedProductsRequest request, CancellationToken cancellationToken)
    {
        if (request.Count <= 0 || request.Page <= 0)
        {
            return Result<GetPagedProducts>.Fail("parametre hatası");
        }
        var products = await context.Products.Where(f => f.IsActive)
                                             .Skip((request.Page - 1) * request.Count)
                                             .Take(request.Count)
                                             .Select(s => new ProductDto
                                             {
                                                 Id = s.Id,
                                                 Name = s.Name,
                                             })
                                             .ToListAsync(cancellationToken);
        return Result<GetPagedProducts>.Success(new GetPagedProducts(products));
    }
}