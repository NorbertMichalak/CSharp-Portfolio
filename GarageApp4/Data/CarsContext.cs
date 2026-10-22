using Microsoft.EntityFrameworkCore;
using GarageApp4.Models;

namespace GarageApp4.Data;
public class CarsContext : DbContext
{
    public DbSet<Car> Cars => Set<Car>();
    public DbSet<User> Users => Set<User>();

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

        modelBuilder.Entity<User>()
            .HasIndex(u => u.Username)
            .IsUnique();
    }
}