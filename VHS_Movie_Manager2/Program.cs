using System.Globalization;
using VHS_Movie_Manager2;




class Program
{

    static void Main(string[] args)
    {
        CultureInfo.CurrentCulture = CultureInfo.GetCultureInfo("de-DE");

        // Download movies list or create new list.

        using var db = new MovieContext();
        db.Database.EnsureCreated();

        if(!db.Movies.Any())
        {
            //Starter movies
            db.Movies.Add(new Movie("Alien", Genre.SciFi, 1979, 4.99m));
            db.Movies.Add(new Movie("Dumb and Dumber", Genre.Comedy, 1994, 5.99m));
            db.Movies.Add(new Movie("Truman Show",Genre.Drama, 1998, 5.49m ));
            db.SaveChanges();
        }

        while(true)
        {
            Console.WriteLine("\n=== VHS Movies Manager EF Core & SQLite ===");
            Console.WriteLine("1) List movies");
            Console.WriteLine("2) Add movie");
            Console.WriteLine("3) Remove movie");
            Console.WriteLine("0) Exit");
            Console.Write("Choice: ");
            var choice = Console.ReadLine();

            switch(choice)
            {
                case "1": MovieService.ListMovies(db); break;
                case "2": MovieService.AddMovie(db); break;
                case "3": MovieService.RemoveMovie(db); break;
                case "0": return;
                default: Console.WriteLine("NIeznana opcja "); break;
            }
        }
    }
}



