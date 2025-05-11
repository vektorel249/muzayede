using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vektorel.Muzayede.Common;
using Vektorel.Muzayede.Data;

namespace Vektorel.Muzayede.Modules.Domain.Commands;

public class MakeProposalRequest : IRequest<Result<bool>>
{
    public Guid BoardProductId { get; set; }
    public decimal Amount { get; set; }
}

internal class MakeProposalCommand : IRequestHandler<MakeProposalRequest, Result<bool>>
{
    private readonly MuzayedeContext context;

    public MakeProposalCommand(MuzayedeContext context)
    {
        this.context = context;
    }
    public Task<Result<bool>> Handle(MakeProposalRequest request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}