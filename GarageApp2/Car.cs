namespace GarageApp2;


public interface IFuel
{
    void ShowFuelConsumption();
}

public interface IkWh
{
    void ShowEnergyConsumption();
}


public class Car
{   
    public int Id { get; set; }
    public Car(string make, string model, decimal price, int year)
    {
        Make = make;
        Model = model;
        Price = price;
        Year = year;
    }

    public string Make {get; set;}
    public string Model {get; set;}
    public decimal Price {get; set;}
    public int Year {get; set;}

    public override string ToString()
    {
        return $"{Make} | {Model} | Price: {Price:N0} € | {Year}";
    }
}

public class Combustion : Car, IFuel
{
    public Combustion(string make, string model, decimal price, int year, decimal consumption)
    :base(make, model, price, year)
    {
        Consumption = consumption;
    }
    public decimal Consumption {get; set;}

    public override string ToString()
    {
        return $"{base.ToString()} | Fuel: {Consumption:F1} l/100km";
    }

    public void ShowFuelConsumption()
    {
        Console.WriteLine($"Consumption is {Consumption:F1} l/100km");
    }

    public decimal CostPer100km(decimal fuelPrice)
    {
        return Consumption * fuelPrice;
    }
}

public class Hybrid: Car, IFuel, IkWh
{
    public Hybrid(string make, string model, decimal price, int year, decimal consumption, decimal consumptionkWh)
    :base(make, model, price, year)
    {
        Consumption = consumption;
        ConsumptionkWh = consumptionkWh;
    }

    public decimal Consumption {get; set;}
    public decimal ConsumptionkWh {get; set;}

    public override string ToString()
    {
        return $"{base.ToString()} | Fuel: {Consumption:F1} l/100km | Electric: {ConsumptionkWh:F1} kWh/100km";
    }

    public void ShowFuelConsumption()
    {
        Console.WriteLine($"Consumption is {Consumption:F1} l/100km");
    }

    public void ShowEnergyConsumption()
    {
        Console.WriteLine($"Energy Consumption is  {ConsumptionkWh:F1} kWh/ 100km");
    }

    public decimal CostPer100km(decimal fuelPrice, decimal energyPrice)
    {
        return (Consumption * fuelPrice) + (ConsumptionkWh * energyPrice);
    }
}

public class Electric : Car, IkWh
{
    public Electric(string make, string model, decimal price, int year, decimal consumptionkWh)
    :base(make, model, price, year)
    {
        ConsumptionkWh = consumptionkWh;
    }

    public decimal ConsumptionkWh {get; set;}

    public override string ToString()
    {
        return $"{base.ToString()} | Electric: {ConsumptionkWh:F1} kWh/100km";
    }

    public void ShowEnergyConsumption()
    {
        Console.WriteLine($"Energy consumption is {ConsumptionkWh:F1} kWh/100km");
    }

    public decimal CostPer100km(decimal energyPrice)
    {
        return ConsumptionkWh * energyPrice;
    }
}


