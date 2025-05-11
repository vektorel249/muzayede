using MediatR;
using Vektorel.Muzayede.Common;
using Vektorel.Muzayede.Data;
using Vektorel.Muzayede.Modules.Domain.Queries.Dtos.Proposals;

namespace Vektorel.Muzayede.Modules.Domain.Queries.Proposals;

public class GetActiveProposalsRequest : IRequest<Result<GetProposalsResult>>
{
}

internal class GetActiveProposalsQuery : IRequestHandler<GetActiveProposalsRequest, Result<GetProposalsResult>>
{
    private readonly MuzayedeContext context;

    public GetActiveProposalsQuery(MuzayedeContext context)
    {
        this.context = context;
    }
    public Task<Result<GetProposalsResult>> Handle(GetActiveProposalsRequest request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
