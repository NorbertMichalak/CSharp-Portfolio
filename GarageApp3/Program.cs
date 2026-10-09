using GarageApp3.Data;
using GarageApp3.Models;
using GarageApp3.Services;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<CarsContext>();
builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
    });
builder.Services.AddScoped<CarService>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Seed database
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<CarsContext>();
    db.Database.EnsureCreated();

    if(!db.Cars.Any())
        {
            //Starter cars
            db.Cars.Add(new Combustion("Ford", "Mondeo", 15000, 2022, 6.5m));
            db.Cars.Add(new Hybrid("Peugeot", "508PSE", 35000, 2021, 3.5m, 10.5m));
            db.Cars.Add(new Electric("Tesla", "Model Y", 53000, 2026, 15));
            db.SaveChanges();
        }
        
}
app.UseHttpsRedirection();
app.MapControllers();
app.Run();