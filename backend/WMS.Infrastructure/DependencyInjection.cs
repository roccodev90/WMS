using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WMS.Domain.Interfaces;
using WMS.Infrastructure.Persistence;
using WMS.Infrastructure.Repositories;

namespace WMS.Infrastructure;

/// <summary>
/// Dependency injection per l'infrastruttura.
/// </summary>
public static class DependencyInjection
{
    /// <summary>
    /// Aggiunge l'infrastruttura al container di servizi.
    /// </summary>
    /// <param name="services">Il container di servizi.</param>
    /// <param name="configuration">La configurazione.</param>
    /// <returns>Il container di servizi.</returns>
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<WmsDbContext>(options =>
            options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));

        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
        services.AddScoped<IWarehouseTaskQueries, WarehouseTaskQueries>();

        return services;
    }
}
