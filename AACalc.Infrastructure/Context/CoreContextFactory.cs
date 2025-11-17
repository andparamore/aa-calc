using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace AACalc.Infrastructure.Context;

public sealed class CoreContextFactory : IDesignTimeDbContextFactory<CoreContext>
{
    public CoreContext CreateDbContext(string[] args)
    {
        var env = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Development";

        var basePath = Directory.GetCurrentDirectory(); // Infrastructure
        var webApiPath = Path.GetFullPath(Path.Combine(basePath, "..", "AACalc.WebApi"));

        var cfg = new ConfigurationBuilder()
            .SetBasePath(Directory.Exists(webApiPath) ? webApiPath : basePath)
            .AddJsonFile("appsettings.json", optional: true)
            .AddJsonFile($"appsettings.{env}.json", optional: true)
            .AddEnvironmentVariables()
            .Build();

        var conn =
            Environment.GetEnvironmentVariable("ConnectionStrings__AppDb")
            ?? cfg.GetConnectionString("AppDb")
            ?? "Host=localhost;Port=5432;Database=item_store;Username=user;Password=pass";
        
        var options = new DbContextOptionsBuilder<CoreContext>()
            .UseNpgsql(conn, o =>
            {
                o.MigrationsAssembly(typeof(CoreContext).Assembly.FullName);
            })
            .Options;

        return new CoreContext(options);
    }
}