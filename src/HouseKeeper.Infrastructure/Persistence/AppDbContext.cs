using Microsoft.EntityFrameworkCore;

namespace HouseKeeper.Infrastructure.Persistence;

/// <summary>
/// This class represents the connection context to a database.
/// 
/// It declares the different tables present in the database and loads
/// all the tables configurations with OnModelCreating.
/// This allows to keep the AppDbContext class fairly lightweight and
/// shifts the individual tables configurations in their own class.
/// </summary>
/// <param name="options">The options configured at registration, such as the provider and connection string</param>
public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    // Place here the different DbSet<>().
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
    }
}
