﻿using MediatR;
using Vektorel.Muzayede.Common;
using Vektorel.Muzayede.Data;
using Vektorel.Muzayede.Modules.Domain.Queries.Dtos.Proposals;

namespace Vektorel.Muzayede.Modules.Domain.Queries.Proposals;

public class GetClosedProposalsRequest : IRequest<Result<GetProposalsResult>>
{
}

internal class GetClosedProposalsQuery : IRequestHandler<GetClosedProposalsRequest, Result<GetProposalsResult>>
{
    private readonly MuzayedeContext context;

    public GetClosedProposalsQuery(MuzayedeContext context)
    {
        this.context = context;
    }
    public Task<Result<GetProposalsResult>> Handle(GetClosedProposalsRequest request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}