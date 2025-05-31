using MediatR;
using Microsoft.EntityFrameworkCore;
using Vektorel.Muzayede.Common;
using Vektorel.Muzayede.Data;
using Vektorel.Muzayede.DistributedCache;

namespace Vektorel.Muzayede.Modules.Domain.Queries.Statistics;

public class GetActiveProductCountRequest : IRequest<Result<int>>
{
}

internal class GetActiveProductCountQuery : IRequestHandler<GetActiveProductCountRequest, Result<int>>
{
    private readonly MuzayedeContext context;
    private readonly RedisService redis;

    public GetActiveProductCountQuery(MuzayedeContext context, RedisService redis)
    {
        this.context = context;
        this.redis = redis;
    }
    public async Task<Result<int>> Handle(GetActiveProductCountRequest request, CancellationToken cancellationToken)
    {
        var countCheck = await redis.GetStringAsync(nameof(GetActiveProductCountRequest));
        if (!string.IsNullOrEmpty(countCheck))
        {
            return Result<int>.Success(int.Parse(countCheck));
        }

        var count = await context.Products.CountAsync(f => f.IsActive, cancellationToken);
        await redis.SetStringAsync(nameof(GetActiveProductCountRequest), count.ToString(), TimeSpan.FromSeconds(30));
        return Result<int>.Success(count);
    }
}