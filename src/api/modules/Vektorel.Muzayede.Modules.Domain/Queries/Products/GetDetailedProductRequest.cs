using MediatR;
using Microsoft.EntityFrameworkCore;
using Vektorel.Muzayede.Common;
using Vektorel.Muzayede.Data;
using Vektorel.Muzayede.Modules.Domain.Queries.Dtos.Products;

namespace Vektorel.Muzayede.Modules.Domain.Queries.Products;

public class GetDetailedProductRequest : IRequest<Result<DetailedProductDto>>
{
    public GetDetailedProductRequest(Guid id)
    {
        Id = id;
    }

    public Guid Id { get; }
}

internal class GetDetailedProductQuery : IRequestHandler<GetDetailedProductRequest, Result<DetailedProductDto>>
{
    private readonly MuzayedeContext context;

    public GetDetailedProductQuery(MuzayedeContext context)
    {
        this.context = context;
    }

    public async Task<Result<DetailedProductDto>> Handle(GetDetailedProductRequest request, CancellationToken cancellationToken)
    {
        var product = await context.Products.SingleAsync(f => f.Id == request.Id && f.IsActive, cancellationToken);

        var result = new DetailedProductDto
        {
            Name = product.Name,
            CreatedAt = product.CreatedAt,
            Price = product.CurrentPrice,
            Description = product.Description,
        };

        result.Comments = await context.Comments.Where(f => f.IsActive && f.ProductId == request.Id)
                                                .Select(s => new ProductCommentViewDto
                                                {
                                                    User = s.User.DisplayName,
                                                    CreatedAt = s.CreatedAt,
                                                    Comment = s.Content,
                                                })
                                                .ToListAsync(cancellationToken);

        result.Proposals = await context.Proposals.Where(f => f.IsActive && f.BoardProduct.Id == request.Id)
                                                  .Select(s => new ProductProposalViewDto
                                                  {
                                                      DisplayName = s.User.DisplayName,
                                                      CreatedAt = s.CreatedAt,
                                                      Price = s.Amount
                                                  })
                                                  .ToListAsync(cancellationToken);

        return Result<DetailedProductDto>.Success(result);
    }
}