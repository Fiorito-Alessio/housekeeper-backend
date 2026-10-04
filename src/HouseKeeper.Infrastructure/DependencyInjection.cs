using HouseKeeper.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace HouseKeeper.Infrastructure;

/// <summary>
/// Registers the infrastructure layer services (database provider, connection string...)
/// in the dependency injection container.
///
/// Keeping this registration here keeps Program.cs short and means the Api does not need
/// to know which database or ORM the infrastructure layer uses.
/// </summary>
public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("Default")
                               ?? throw new InvalidOperationException("Connection string 'Default' is missing.");

        services.AddDbContext<AppDbContext>(options => options.UseNpgsql(connectionString));
        
        // Register the other infrastructure services here (e.g. repository implementations).

        return services;
    }
}
