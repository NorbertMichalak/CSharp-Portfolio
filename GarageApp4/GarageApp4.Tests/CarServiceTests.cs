using Xunit;
using GarageApp4.Models;
using GarageApp4.Services;

namespace GarageApp4.Tests;

public class CarServiceTests
{
    private readonly CarService _sut;

    public CarServiceTests()
    {
        _sut = new CarService();
    }

    [Fact]
    public void CalculateCostPer100km_Combustion_ReturnsCorrectValue()
    {
        var car = new Combustion { Consumption = 6.5m };
        var result = _sut.CalculateCostPer100km(car, 2.0m, 0m);
        Assert.Equal(13.0m, result);
    }

    [Fact]
    public void CalculateCostPer100km_Electric_ReturnsCorrectValue()
    {
        var car = new Electric { ConsumptionkWh = 15m };
        var result = _sut.CalculateCostPer100km(car, 0m, 0.30m);
        Assert.Equal(4.5m, result);
    }

    [Fact]
    public void CalculateCostPer100km_Hybrid_ReturnsCorrectValue()
    {
        var car = new Hybrid { Consumption = 3.5m, ConsumptionkWh = 10.5m };
        var result = _sut.CalculateCostPer100km(car, 2.0m, 0.30m);
        Assert.Equal(10.15m, result);
    }

    [Fact]
    public void CalculateCostPer100km_UnknownCarType_ThrowsArgumentException()
    {
        var car = new Car();
        Assert.Throws<ArgumentException>(() =>
            _sut.CalculateCostPer100km(car, 2.0m, 0.30m));
    }

    [Theory]
    [InlineData(6.5, 2.0, 13.0)]
    [InlineData(8.0, 1.5, 12.0)]
    [InlineData(10.0, 2.5, 25.0)]
    public void CalculateCostPer100km_Combustion_Theory(
        decimal consumption, decimal fuelPrice, decimal expected)
    {
        var car = new Combustion { Consumption = consumption };
        var result = _sut.CalculateCostPer100km(car, fuelPrice, 0m);
        Assert.Equal(expected, result);
    }
}