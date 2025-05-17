using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vektorel.Muzayede.Entities.Identity;
using Vektorel.Muzayede.Common;
using Vektorel.Muzayede.Data;
using Microsoft.EntityFrameworkCore;
using static System.Runtime.InteropServices.JavaScript.JSType;

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
        public string id { get; }
        public GetSelectedProductRequest(string id)
        {
            this.id = id;
        }
    }

    public class GetSelectedProductRequestHandle : IRequestHandler<GetSelectedProductRequest, Result<SelectProductDto>>
    {
        public readonly MuzayedeContext muzayedeContext;

        public GetSelectedProductRequestHandle(MuzayedeContext muzayedeContext)
        {
            this.muzayedeContext = muzayedeContext;
        }

        public  async Task<Result<SelectProductDto>> Handle(GetSelectedProductRequest request, CancellationToken cancellationToken)
        {
             SelectProductDto data=null;

            if (!string.IsNullOrEmpty(request.id) && Guid.TryParse(request.id, out var id))
            {

                 data = await muzayedeContext.Products.Where(w => w.Id == id).Select(s => new SelectProductDto
                {
                    Name = s.Name,
                    Description = s.Description,
                    CurrentPrice = s.CurrentPrice

                }).FirstOrDefaultAsync(cancellationToken);

                return Result<SelectProductDto>.Success(data);
            }

            if (data==null)
            {
                return Result<SelectProductDto>.Fail("Ürün bulunamadı");
            }
            return Result<SelectProductDto>.Fail("Birşeyler ters gitti");


           
        }
    }
}
