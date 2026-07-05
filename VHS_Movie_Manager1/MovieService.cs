// Showing all movies

using MovieMenagerJSON;
class MovieService
{

    public static void ListMovies(List<Movie> movies)
    {
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
    public static void AddMovie(List<Movie>movies)
    {
        Console.WriteLine("Adding a new movie...");

        string title = InputHelper.ReadNonEmpty("Title: ");
        Genre genre = InputHelper.ReadGenre();
        int releaseyear = InputHelper.ReadInt("Production year: ", 1900, 2100);
        decimal price = InputHelper.ReadDecimal("Price [€]: ", 1, 100);

        movies.Add(new Movie(title, genre, releaseyear, price));
        Console.WriteLine("Added: " +movies[^1]);
    }

    // Deleting movie
    public static void RemoveMovie(List<Movie> movies)
    {
        if(movies.Count == 0)
        {
            Console.WriteLine("There are no movie to remove");
            return;
        }

        ListMovies(movies);

            int index = InputHelper.ReadInt("Provide the number of movie to be deleted: ", 1, movies.Count);
            var removed = movies[index - 1 ];
            movies.RemoveAt(index - 1 );

            Console.WriteLine($"Deleted: {removed.Title}");

    }

    
}