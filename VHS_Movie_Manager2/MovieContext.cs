using Microsoft.EntityFrameworkCore;
using VHS_Movie_Manager2;
public class MovieContext : DbContext
{
    public DbSet<Movie> Movies => Set<Movie>();

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        options.UseSqlite("Data Source=movies.db");
    }
}