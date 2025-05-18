using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Vektorel.Muzayede.Common.Options;
using Vektorel.Muzayede.Entities.Identity;

namespace Vektorel.Muzayede.Data.Extensions;

public static class DataExtensions
{
    public static IServiceCollection AddData(this IServiceCollection services, DatabaseOptions options)
    {
        services.AddIdentity<User, IdentityRole>().AddEntityFrameworkStores<MuzayedeContext>().AddDefaultTokenProviders();
        services.AddDbContext<MuzayedeContext>(builder =>
        {
            builder.UseSqlServer(options.Main);
        });
        return services;
    }
}
