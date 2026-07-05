using System.Globalization;
using MovieMenagerJSON;



class Program
{
    
    static string fileName = "movies.json";

    static void Main(string[] args)
    {
        CultureInfo.CurrentCulture = CultureInfo.GetCultureInfo("de-DE");

        // Download movies list or create new list.

        List<Movie> movies = MovieRepository.LoadFromFile(fileName);
        if(movies.Count == 0)
        {
            //Starter movies
            movies.Add(new Movie("Alien", Genre.SciFi, 1979, 4.99m));
            movies.Add(new Movie("Dumb and Dumber", Genre.Comedy, 1994, 5.99m));
            movies.Add(new Movie("Truman Show",Genre.Drama, 1998, 5.49m ));
            MovieRepository.SaveToFile(movies, fileName);
        }

        while(true)
        {
            Console.WriteLine("\n=== VHS Movies Manager JSON ===");
            Console.WriteLine("1) List movies");
            Console.WriteLine("2) Add movie");
            Console.WriteLine("3) Remove movie");
            Console.WriteLine("0) Exit");
            Console.Write("Choice: ");
            var choice = Console.ReadLine();

            switch(choice)
            {
                case "1": MovieService.ListMovies(movies); break;
                case "2": MovieService.AddMovie(movies); MovieRepository.SaveToFile(movies, fileName); break;
                case "3": MovieService.RemoveMovie(movies); MovieRepository.SaveToFile(movies, fileName); break;
                case "0": return;
                default: Console.WriteLine("NIeznana opcja "); break;
            }
        }
    }
}



