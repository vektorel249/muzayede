using MediatR;
using Vektorel.Muzayede.Common;

namespace Vektorel.Muzayede.Modules.Domain.Queries.Statistics;

public class GetDailyProposalCountRequest : IRequest<Result<int>>
{
}

internal class GetDailyProposalCountQuery : IRequestHandler<GetDailyProposalCountRequest, Result<int>>
{
    public Task<Result<int>> Handle(GetDailyProposalCountRequest request, CancellationToken cancellationToken)
    {
        return Task.FromResult(Result<int>.Success(120));
    }
}