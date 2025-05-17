using MediatR;
using Vektorel.Muzayede.Common;
using Vektorel.Muzayede.Data;
using Microsoft.EntityFrameworkCore;

namespace Vektorel.Muzayede.Modules.Domain.Queries.Products
{
    public class SelectProductDto()
    {

        public string Name { get; set; }

        public string Description { get; set; }

        public decimal CurrentPrice { get; set; }

    }

    public class GetSelectedProductRequest : IRequest<Result<SelectProductDto>>
    {
        public Guid Id { get; }
        public GetSelectedProductRequest(Guid id)
        {
            this.Id = id;
        }
    }

    public class GetSelectedProductRequestHandle : IRequestHandler<GetSelectedProductRequest, Result<SelectProductDto>>
    {
        public readonly MuzayedeContext muzayedeContext;

        public GetSelectedProductRequestHandle(MuzayedeContext muzayedeContext)
        {
            this.muzayedeContext = muzayedeContext;
        }

        public async Task<Result<SelectProductDto>> Handle(GetSelectedProductRequest request, CancellationToken cancellationToken)
        {
            var data = await muzayedeContext.Products
                                            .Where(w => w.Id == request.Id)
                                            .Select(s => new SelectProductDto
                                            {
                                                Name = s.Name,
                                                Description = s.Description,
                                                CurrentPrice = s.CurrentPrice

                                            }).FirstOrDefaultAsync(cancellationToken);
            if (data == null)
            {
                return Result<SelectProductDto>.Fail("Ürün bulunamadı");
            }
            return Result<SelectProductDto>.Success(data);
        }
    }
}
