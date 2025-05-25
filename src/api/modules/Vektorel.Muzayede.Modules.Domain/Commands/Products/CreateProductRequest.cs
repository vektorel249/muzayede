using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vektorel.Muzayede.Common;
using Vektorel.Muzayede.Common.Helpers;
using Vektorel.Muzayede.Data;
using Vektorel.Muzayede.Entities.Definition;

namespace Vektorel.Muzayede.Modules.Domain.Commands.Products;

public class CreateProductRequest : IRequest<Result<bool>>
{
    public string Name { get; set; }
    public decimal Price { get; set; }
    public string Description { get; set; }
}

internal class CreateProductCommand : IRequestHandler<CreateProductRequest, Result<bool>>
{
    private readonly MuzayedeContext context;
    private readonly CurrentUserInfo currentUser;

    public CreateProductCommand(MuzayedeContext context, CurrentUserInfo currentUser)
    {
        this.context = context;
        this.currentUser = currentUser;
    }
    public async Task<Result<bool>> Handle(CreateProductRequest request, CancellationToken cancellationToken)
    {
        var product = new Product
        {
            Name = request.Name,
            CurrentPrice = request.Price,
            Description = request.Description,
            OwnerId = currentUser.UserId.Value.ToString(),
            IsActive = true
        };

        context.Products.Add(product);
        await context.SaveChangesAsync(cancellationToken);
        return Result<bool>.Success(true);
    }
}