namespace GarageApp4.Services;

using System;
using GarageApp4.Models;

public class CarService
{
    public decimal CalculateCostPer100km(Car car, decimal fuelPrice, decimal energyPrice)
    {
        if (car is Combustion combustion)
                return combustion.CostPer100km(fuelPrice);
            
        else if (car is Hybrid hybrid)
                return hybrid.CostPer100km(fuelPrice, energyPrice);
            
        else if (car is Electric electric)
                return electric.CostPer100km(energyPrice);

        throw new ArgumentException($"Unknown car Type: {car.GetType().Name}");
            
    }
}