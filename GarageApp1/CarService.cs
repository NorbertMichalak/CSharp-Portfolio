// Showing all cars

namespace GarageApp;
class CarService
{

    public static void ListCars(List<Car> cars)
    {
        if(cars.Count == 0)
        {
            Console.WriteLine("No cars");
            return;
        }

        int i = 1;
        foreach ( var c in cars)
            Console.WriteLine($"{i++}. {c}");
    }

    // Adding a new car
    public static void AddCar(List<Car>cars)
    {
        Console.WriteLine("Adding a new car...");

        string make = InputHelper.ReadNonEmpty("Make: ");
        string model = InputHelper.ReadNonEmpty("Model: ");
        decimal price = InputHelper.ReadDecimal("Price [€]: ", 1, 1000000);
        int year = InputHelper.ReadInt("Production year: ", 1900, 2027);
        int fuelType = InputHelper.ReadInt("Fuel type (1-Combustion, 2-Hybrid, 3-Electric): ", 1, 3);

        switch(fuelType)
        {
            case 1:
                decimal consumption = InputHelper.ReadDecimal("Consumption [l/100km]: ", 1, 30);
                cars.Add(new Combustion(make, model, price, year, consumption));
                break;
            case 2:
                decimal consumption2 = InputHelper.ReadDecimal("Consumption [l/100km]: ", 1, 30);
                decimal kwh2 = InputHelper.ReadDecimal("Energy consumption/100km: ", 1, 50);
                cars.Add(new Hybrid(make, model, price, year, consumption2, kwh2));
                break;
            case 3:
                decimal kwh3 = InputHelper.ReadDecimal("Energy consumption KWh/100km: ", 1, 50);
                cars.Add(new Electric(make, model, price, year, kwh3));
                break;
        }
            Console.WriteLine("Added: " + cars[^1]);
    }

    // Deleting car
    public static void RemoveCar(List<Car> cars)
    {
        if(cars.Count == 0)
        {
            Console.WriteLine("There are no cars to remove");
            return;
        }

        ListCars(cars);

            int index = InputHelper.ReadInt("Provide the number of car to be deleted: ", 1, cars.Count);
            var removed = cars[index - 1 ];
            cars.RemoveAt(index - 1 );

            Console.WriteLine($"Deleted: {removed.Make}");

    }

    // Calculate Costs

    public static void CalculateCosts(List<Car> cars)
    {
        decimal fuelPrice = InputHelper.ReadDecimal("Fuel price per liter: ", 0.1m, 10m);
        decimal energyPrice = InputHelper.ReadDecimal("Electricity price per kWh: ", 0.1m, 5m);

        foreach (Car c in cars)
        {
            if (c is Combustion combustion)
                Console.WriteLine($"{combustion.Make} {combustion.Model} - cost 100km: {combustion.CostPer100km(fuelPrice):F2} EUR");
            
            else if (c is Hybrid hybrid)
                Console.WriteLine($"{hybrid.Make} {hybrid.Model} - cost 100km: {hybrid.CostPer100km(fuelPrice, energyPrice):F2} EUR");
            
            else if (c is Electric electric)
                Console.WriteLine($"{electric.Make} {electric.Model} - cost 100km: {electric.CostPer100km(energyPrice):F2} EUR");
            else
                Console.WriteLine($"[WARNING] Unknown car type: {c.GetType().Name} - {c.Make} {c.Model}");
        }
    }

    
}