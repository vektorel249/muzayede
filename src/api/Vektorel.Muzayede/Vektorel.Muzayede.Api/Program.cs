using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Vektorel.Muzayede.Api.Middlewares;
using Vektorel.Muzayede.Common.Helpers;
using Vektorel.Muzayede.Common.Options;
using Vektorel.Muzayede.Data;
using Vektorel.Muzayede.Data.Extensions;
using Vektorel.Muzayede.Entities.Identity;
using Vektorel.Muzayede.Modules.Domain;
using Vektorel.Muzayede.Modules.Users;

namespace Vektorel.Muzayede.Api;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.Configure<DatabaseOptions>(builder.Configuration.GetSection(nameof(DatabaseOptions)));
        builder.Services.Configure<JwtOptions>(builder.Configuration.GetSection(nameof(JwtOptions)));
        var databaseOptions = builder.Configuration.GetSection(nameof(DatabaseOptions)).Get<DatabaseOptions>();
        var jwtOptions = builder.Configuration.GetSection(nameof(JwtOptions)).Get<JwtOptions>();

        builder.Services.AddControllers();
        builder.Services.AddData(databaseOptions);
        builder.Services.AddScoped<CurrentUserInfo>();
        builder.Services.AddMediatR(config =>
        {
            config.RegisterServicesFromAssembly(UserModuleAssemblyMarker.GetAssembly());
            config.RegisterServicesFromAssembly(DomainModuleAssemblyMarker.GetAssembly());

            // tüm projeleri tarayacaðý için yavaþlar uzun vadede
            //config.RegisterServicesFromAssemblies(AppDomain.CurrentDomain.GetAssemblies());
        });

        builder.Services.AddCors(config =>
        {
            if (builder.Environment.IsDevelopment())
            {
                config.AddPolicy(builder.Environment.EnvironmentName, policyBuilder =>
                {
                    policyBuilder.AllowAnyHeader()
                                 .AllowAnyMethod()
                                 .AllowAnyOrigin();
                });
            }
            else if (builder.Environment.IsProduction())
            {
                //BAÞKA CONFIG     (SADECE MUZAYEDE MÜÞTERÝ UYGULAMASINA ÝZÝN VER )
            }
        });

        builder.Services.AddAuthentication(options =>
                        {
                            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                        })
                        .AddJwtBearer(options => 
                        {
                            options.RequireHttpsMetadata = true;
                            options.TokenValidationParameters = new TokenValidationParameters
                            {
                               ValidIssuer = "https://vektorel.com",
                               ValidateIssuer = false,
                               ValidAudience = "ApiUsers",
                               ValidateAudience = false,
                               IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtOptions.Secret)),
                               RequireExpirationTime = true,
                            };
                        });

        builder.Services.AddAuthorization();

        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        var app = builder.Build();

        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }
        
        app.UseHttpsRedirection();
        app.UseCors(builder.Environment.EnvironmentName);
        app.UseAuthentication();
        app.UseAuthorization();
        app.UseMiddleware<CurrentUserControlMiddleware>();
        app.MapControllers();
        app.Run();
    }
}
