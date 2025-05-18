using Microsoft.Extensions.DependencyInjection;
using Vektorel.Muzayede.Common.Options;

namespace Vektorel.Muzayede.DistributedCache.Extensions;

public static class ServiceCollectionExtensions
{
    public static void AddRedis(this IServiceCollection services, RedisOptions options)
    {
        var redisService = new RedisService($"{options.Address}:{options.Port}");
        services.AddSingleton(redisService);
    }
}
