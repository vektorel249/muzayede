using StackExchange.Redis;

namespace Vektorel.Muzayede.DistributedCache;

public class RedisService
{
    private readonly ConnectionMultiplexer redis;
    private readonly IDatabase db;

    public RedisService(string connectionString)
    {
        redis = ConnectionMultiplexer.Connect(connectionString);
        db = redis.GetDatabase();
    }

    public async Task SetStringAsync(string key, string value, TimeSpan? expiry = null)
    {
        await db.StringSetAsync(key, value, expiry);
    }

    public async Task<string?> GetStringAsync(string key)
    {
        return await db.StringGetAsync(key);
    }
}
