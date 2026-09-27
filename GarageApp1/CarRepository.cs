using System.Text.Json;
namespace GarageApp;

// ===JSON Save/Load

class CarRepository
{
    public static void SaveToFile(List<Car> cars, string fileName)
    {
        var options = new JsonSerializerOptions { WriteIndented = true};
        string json = JsonSerializer.Serialize(cars, options);
        File.WriteAllText(fileName, json);
    }

    public static List<Car> LoadFromFile(string fileName)
    {
        if(!File.Exists(fileName)) return new List<Car>();
        string json = File.ReadAllText(fileName);
        return JsonSerializer.Deserialize<List<Car>>(json) ?? new List<Car>();
    }

}