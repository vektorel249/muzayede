using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Vektorel.Muzayede.Common.Options;
using Vektorel.Muzayede.Data.Extensions;
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
        builder.Services.AddMediatR(config =>
        {
            config.RegisterServicesFromAssembly(UserModuleAssemblyMarker.GetAssembly());
            config.RegisterServicesFromAssembly(DomainModuleAssemblyMarker.GetAssembly());

            // tüm projeleri tarayacaðý için yavaþlar uzun vadede
            //config.RegisterServicesFromAssemblies(AppDomain.CurrentDomain.GetAssemblies());
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

        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        var app = builder.Build();

        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }
        
        app.UseHttpsRedirection();
        app.UseAuthentication();
        app.UseAuthorization();
        app.MapControllers();
        app.Run();
    }
}
