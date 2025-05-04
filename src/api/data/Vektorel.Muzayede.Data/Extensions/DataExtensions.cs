using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Vektorel.Muzayede.Common.Options;

namespace Vektorel.Muzayede.Data.Extensions;

public static class DataExtensions
{
    public static IServiceCollection AddData(this IServiceCollection services, DatabaseOptions options)
    {
        services.AddDbContext<MuzayedeContext>(builder =>
        {
            builder.UseSqlServer(options.Main);
        });
        return services;
    }
}
