using Vektorel.Muzayede.Admin.Helpers;
using Vektorel.Muzayede.Common.Options;
using Vektorel.Muzayede.DistributedCache.Extensions;

namespace Vektorel.Muzayede.Admin
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.Configure<RedisOptions>(builder.Configuration.GetSection(nameof(RedisOptions)));
            var redisOptions = builder.Configuration.GetSection(nameof(RedisOptions)).Get<RedisOptions>();

            builder.Services.AddControllersWithViews();
            builder.Services.AddHttpClient<MuzayedeApiClient>();
            builder.Services.AddScoped<UserAgentInfo>();
            builder.Services.AddRedis(redisOptions);

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseAuthorization();
            app.UseMiddleware<UserAgentMiddleware>();
            app.UseMiddleware<TokenCheckMiddleware>();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
