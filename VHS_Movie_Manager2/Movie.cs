namespace VHS_Movie_Manager2
{
    public enum Genre {Action = 1, Comedy = 2, Drama = 3, Horror = 4, SciFi = 5}

    public class Movie
    {   
        public int Id { get; set; }
        public string? Title { get; set; }
        public Genre Genre { get; set; }
        public int ReleaseYear { get; set; }
        public decimal Price { get; set; }
        public bool IsRented { get; private set; }

        public Movie() { } // Required by EF Core

        public Movie(string title, Genre genre, int releaseyear, decimal price)
        {
            Title = title;
            Genre = genre;
            ReleaseYear = releaseyear;
            Price = price;
            IsRented = false; // Always available upon addition.
        }
            // Methods for changing the film's state
            public void Rent() => IsRented = true;
            public void Return() => IsRented = false;

        public override string ToString()
        {
            return $"{Title} | {Genre} | {ReleaseYear} | {Price:0.00} € ";
        }
        
    }
}