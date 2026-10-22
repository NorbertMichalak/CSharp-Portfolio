namespace GarageApp4.Models;

using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;


public interface IFuel
{
    void ShowFuelConsumption();
}

public interface IkWh
{
    void ShowEnergyConsumption();
}

[JsonDerivedType(typeof(Combustion), "combustion")]
[JsonDerivedType(typeof(Hybrid), "hybrid")]
[JsonDerivedType(typeof(Electric), "electric")]
public class Car
{   
    public int Id { get; set; }

    public Car() { }
    public Car(string make, string model, decimal price, int year)
    {
        Make = make;
        Model = model;
        Price = price;
        Year = year;
    }
    [Required]
    public string Make {get; set;}
    [Required]
    public string Model {get; set;}
    [Range(1, 1000000)]
    public decimal Price {get; set;}
    [Range(1900, 2030)]
    public int Year {get; set;}

    public override string ToString()
    {
        return $"{Make} | {Model} | Price: {Price:N0} € | {Year}";
    }
}

public class Combustion : Car, IFuel
{
    public Combustion() { }
    public Combustion(string make, string model, decimal price, int year, decimal consumption)
    :base(make, model, price, year)
    {
        Consumption = consumption;
    }
    [Range(1,30)]
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
    public Hybrid() { }
    public Hybrid(string make, string model, decimal price, int year, decimal consumption, decimal consumptionkWh)
    :base(make, model, price, year)
    {
        Consumption = consumption;
        ConsumptionkWh = consumptionkWh;
    }
    [Range(1, 30)]
    public decimal Consumption {get; set;}
    [Range(1, 50)]
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
    public Electric() { }
    public Electric(string make, string model, decimal price, int year, decimal consumptionkWh)
    :base(make, model, price, year)
    {
        ConsumptionkWh = consumptionkWh;
    }
    [Range(1, 50)]
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


