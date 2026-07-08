// Showing all movies

using VHS_Movie_Manager2;
class MovieService
{

    public static void ListMovies(MovieContext db)
    {   
        var movies = db.Movies.ToList();
        if(movies.Count == 0)
        {
            Console.WriteLine("Brak filmow");
            return;
        }

        int i = 1;
        foreach ( var m in movies)
            Console.WriteLine($"{i++}. {m}");
    }

    // Adding a new movie
    public static void AddMovie(MovieContext db)
    {
        Console.WriteLine("Adding a new movie...");

        string title = InputHelper.ReadNonEmpty("Title: ");
        Genre genre = InputHelper.ReadGenre();
        int releaseyear = InputHelper.ReadInt("Production year: ", 1900, 2100);
        decimal price = InputHelper.ReadDecimal("Price [€]: ", 1, 100);

        var movie = new Movie(title, genre, releaseyear, price);
        db.Movies.Add(movie);
        Console.WriteLine("Added: " + movie);

        db.SaveChanges();
    }

    // Deleting movie
    public static void RemoveMovie(MovieContext db)
    {   
        var movies = db.Movies.ToList();
        if(movies.Count == 0)
        {
            Console.WriteLine("There are no movie to remove");
            return;
        }

        ListMovies(db);

            int index = InputHelper.ReadInt("Provide the number of movie to be deleted: ", 1, movies.Count);
            var removed = movies[index - 1 ];
            

            Console.WriteLine($"Deleted: {removed.Title}");

            db.Movies.Remove(removed);
            db.SaveChanges();

    }

    
}