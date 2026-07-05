using System.Text.Json;
using MovieMenagerJSON;

 // === JSON Save/Load ===
 class MovieRepository
{  
    public static void SaveToFile(List<Movie> movies, string fileName)
    {
        var options = new JsonSerializerOptions { WriteIndented = true};
        string json = JsonSerializer.Serialize(movies, options);
        File.WriteAllText(fileName, json);
    }

    public static List<Movie> LoadFromFile(string fileName)
    {
        if(!File.Exists(fileName)) return new List<Movie>();
        string json = File.ReadAllText(fileName);
        return JsonSerializer.Deserialize<List<Movie>>(json) ?? new List<Movie>();

    }
}