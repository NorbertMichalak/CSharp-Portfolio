using Microsoft.AspNetCore.Mvc;
using GarageApp3.Data;
using GarageApp3.Models;
using GarageApp3.Services;
using Microsoft.EntityFrameworkCore;



namespace GarageApp3.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CarsController : ControllerBase
{
    private readonly CarsContext _db;
    private readonly CarService _carService;

    public CarsController(CarsContext db, CarService carService)
    {
        _db = db;
        _carService = carService;
    }


    // GET api/cars
    [HttpGet]
    public IActionResult GetAll()
    {
        return Ok(_db.Cars.ToList());
    }

    [HttpGet("{id}")]
    public ActionResult<Car> Get(int id)
    {
        var car = _db.Cars.Find(id);

        if(car == null)
            return NotFound();

        return car;
    }

    [HttpGet("{id}/cost")]
    public IActionResult GetCost(int id, decimal fuelPrice, decimal energyPrice)
    {
        var car = _db.Cars.Find(id);

        if(car == null)
            return NotFound();

        return Ok(_carService.CalculateCostPer100km(car, fuelPrice, energyPrice));
    }

    [HttpGet("cost")]
    public IActionResult GetCostAll(decimal fuelPrice, decimal energyPrice)
    {   
        var cars = _db.Cars.ToList();

        var results = cars.Select(car => new
    {
        car.Id,
        car.Make,
        car.Model,
        CostPer100km = _carService.CalculateCostPer100km(car, fuelPrice, energyPrice)
    });

        return Ok(results);
    }

    [HttpGet("cheapestCar")]
    public IActionResult GetCheapestCar(decimal fuelPrice, decimal energyPrice)
    {   
        var cars = _db.Cars.ToList();

        var results = cars.Select(car => new
    {
        car.Id,
        car.Make,
        car.Model,
        CostPer100km = _carService.CalculateCostPer100km(car, fuelPrice, energyPrice)
    });

        var cheapestCar = results.MinBy(r => r.CostPer100km);
        return Ok(cheapestCar);
    }

    // POST
    [HttpPost]
    public async Task<IActionResult> Create(Car car)
    {   
        try
        {
        _db.Cars.Add(car);
        await _db.SaveChangesAsync();
        return CreatedAtAction(nameof(GetAll), new {id = car.Id}, car);
        }

        catch (DbUpdateException ex)
        {
            return StatusCode(500, $"Database error: {ex.Message}");  
        }
    }

    // PUT

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, Car car)
    {
        if (id != car.Id)
        return BadRequest();
           
        var existingCar = _db.Cars.Find(id);
        if(existingCar is null)
            return NotFound();

        existingCar.Make = car.Make;
        existingCar.Model = car.Model;
        existingCar.Price = car.Price;
        existingCar.Year = car.Year;

        if (existingCar is Electric existingElectric && car is Electric updatedElectric)
        existingElectric.ConsumptionkWh = updatedElectric.ConsumptionkWh;

        if (existingCar is Combustion existingCombustion && car is Combustion updatedCombustion)
            existingCombustion.Consumption = updatedCombustion.Consumption;

        if (existingCar is Hybrid existingHybrid && car is Hybrid updatedHybrid)
        {
            existingHybrid.Consumption = updatedHybrid.Consumption;
            existingHybrid.ConsumptionkWh = updatedHybrid.ConsumptionkWh;
        }

    try
    {
        await _db.SaveChangesAsync();           
    
        return NoContent();
    }
        catch(DbUpdateException ex)
        {
            return StatusCode(500, $"Database error: {ex.Message}");
        }
    }

    // DELETE

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var car = _db.Cars.Find(id);
   
        if (car is null)
            return NotFound();

        try
        {    
            _db.Cars.Remove(car);
            await _db.SaveChangesAsync();
    
            return NoContent();
        }

        catch(DbUpdateException ex)
        {
            return StatusCode(500, $"Database error: {ex.Message}");
        }  
    }
}