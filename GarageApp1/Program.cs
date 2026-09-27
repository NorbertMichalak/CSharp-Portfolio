namespace GarageApp;

class Program
{   
    const string fileName = "cars.json";
    static void Main()
    {   
        // Download cars list or create new list.

        List <Car> cars = CarRepository.LoadFromFile(fileName);
        if(cars.Count == 0)
        {
            //Starter cars
            cars.Add(new Combustion("Ford", "Mondeo", 15000, 2022, 6.5m));
            cars.Add(new Hybrid("Peugeot", "508PSE", 35000, 2021, 3.5m, 10.5m));
            cars.Add(new Electric("Tesla", "Model Y", 53000, 2026, 15));
            CarRepository.SaveToFile(cars, fileName);
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
                case "1": CarService.ListCars(cars); break;
                case "2": CarService.AddCar(cars); CarRepository.SaveToFile(cars, fileName); break;
                case "3": CarService.RemoveCar(cars); CarRepository.SaveToFile(cars, fileName); break;
                case "4": CarService.CalculateCosts(cars); break;
                case "5": return;
                default: Console.WriteLine("Unknown option"); break;
            }
        }

    }
}
