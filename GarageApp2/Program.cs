using GarageApp2;
namespace GarageApp2;


class Program
{   
        
    static void Main()
    {   
        // Download cars list or create new list.

        using var db = new CarsContext();
        db.Database.EnsureCreated();

        
        if(!db.Cars.Any())
        {
            //Starter cars
            db.Cars.Add(new Combustion("Ford", "Mondeo", 15000, 2022, 6.5m));
            db.Cars.Add(new Hybrid("Peugeot", "508PSE", 35000, 2021, 3.5m, 10.5m));
            db.Cars.Add(new Electric("Tesla", "Model Y", 53000, 2026, 15));
            db.SaveChanges();
        }

        while(true)
        {
            Console.WriteLine("\n=== GarageApp Menager ===");
            Console.WriteLine(@"
            1. Show car list
            2. Add car
            3. Remove car
            4. Calculate costs
            5. Exit");
            var choice = Console.ReadLine();

            switch(choice)
            {
                case "1": CarService.ListCars(db); break;
                case "2": CarService.AddCar(db); break;
                case "3": CarService.RemoveCar(db); break;
                case "4": CarService.CalculateCosts(db); break;
                case "5": return;
                default: Console.WriteLine("Unknown option"); break;
            }
        }

    }
}

