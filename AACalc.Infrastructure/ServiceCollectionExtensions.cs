using AACalc.Domain.Repositories;
using AACalc.Infrastructure.Context;
using AACalc.Infrastructure.Repositories;
using AACalc.Infrastructure.Uow;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AACalc.Infrastructure;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddCoreContext(this IServiceCollection services, IConfiguration configuration)
    {
        var conn = configuration.GetConnectionString("Core");
        services.AddDbContextPool<CoreContext>(opt =>
        {
            opt.UseNpgsql(conn, npg => 
            {
                npg.MigrationsAssembly("AACalc.Infrastructure");
            });
            
            opt.EnableSensitiveDataLogging();
            opt.EnableDetailedErrors();
        });
        
        services.AddDbContextFactory<CoreContext>(opt =>
            opt.UseNpgsql(conn, o =>
            {
                o.MigrationsAssembly("AACalc.Infrastructure");
            }));
        
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        
        return services;
    }
    
    public static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<IItemRepository, ItemRepository>();
        
        return services;
    }
}