using Microsoft.EntityFrameworkCore;
using GarageApp2;
public class CarsContext : DbContext
{
    public DbSet<Car> Cars => Set<Car>();

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        options.UseSqlite("Data Source=cars.db");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Car>()
            .HasDiscriminator<string>("CarType")
            .HasValue<Combustion>("combustion")
            .HasValue<Hybrid>("hybrid")
            .HasValue<Electric>("electric");
    }
}