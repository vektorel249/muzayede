using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vektorel.Muzayede.Common;
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

    public CreateProductCommand(MuzayedeContext context)
    {
        this.context = context;
    }
    public async Task<Result<bool>> Handle(CreateProductRequest request, CancellationToken cancellationToken)
    {
        var product = new Product
        {
            Name = request.Name,
            CurrentPrice = request.Price,
            Description = request.Description,
            OwnerId = "70f4cbb0-ac1d-4e86-888a-265b3ffad82d",
            IsActive = true
        };

        context.Products.Add(product);
        await context.SaveChangesAsync(cancellationToken);
        return Result<bool>.Success(true);
    }
}