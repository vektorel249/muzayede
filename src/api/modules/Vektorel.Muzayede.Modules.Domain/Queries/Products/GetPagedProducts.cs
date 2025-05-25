using MediatR;
using Microsoft.EntityFrameworkCore;
using Vektorel.Muzayede.Common;
using Vektorel.Muzayede.Common.Helpers;
using Vektorel.Muzayede.Data;
using Vektorel.Muzayede.Modules.Domain.Queries.Dtos.Products;

namespace Vektorel.Muzayede.Modules.Domain.Queries.Products;

public class GetPagedProductsRequest : IRequest<Result<List<ProductDto>>>
{
    public GetPagedProductsRequest(int page, int count)
    {
        Page = page;
        Count = count > 50 ? 50 : count;
    }

    public int Page { get; }
    public int Count { get; }
}


internal class GetPagedProductsQuery : IRequestHandler<GetPagedProductsRequest, Result<List<ProductDto>>>
{
    private readonly MuzayedeContext context;
    private readonly CurrentUserInfo currentUserInfo;

    public GetPagedProductsQuery(MuzayedeContext context, CurrentUserInfo currentUserInfo)
    {
        this.context = context;
        this.currentUserInfo = currentUserInfo;
    }
    public async Task<Result<List<ProductDto>>> Handle(GetPagedProductsRequest request, CancellationToken cancellationToken)
    {
        if (request.Count <= 0 || request.Page <= 0)
        {
            return Result<List<ProductDto>>.Fail("parametre hatası");
        }
        var products = await context.Products.Where(f => f.IsActive && f.OwnerId == currentUserInfo.UserIdAsString)
                                             .Skip((request.Page - 1) * request.Count)
                                             .Take(request.Count)
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