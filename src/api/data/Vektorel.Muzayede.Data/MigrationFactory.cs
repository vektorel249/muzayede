using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.Diagnostics;

namespace Vektorel.Muzayede.Data;

public class MigrationFactory : IDesignTimeDbContextFactory<MuzayedeContext>
{
    public MuzayedeContext CreateDbContext(string[] args)
    {
        var configuration = new ConfigurationBuilder()
                .SetBasePath(Path.Combine(Directory.GetCurrentDirectory()))
                .AddJsonFile("appsettings.json", optional: false)
                .Build();

        var connectionString = configuration.GetConnectionString("Main");

        var optionsBuilder = new DbContextOptionsBuilder<MuzayedeContext>();
        optionsBuilder.UseSqlServer(connectionString);

        return new MuzayedeContext(optionsBuilder.Options);
    }
}