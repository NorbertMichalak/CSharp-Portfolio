# C# Portfolio

C# projects built while learning backend development.
Self-taught — written using docs, Google, and code review with AI tools.

## Projects

### ScoreManager
Console app for managing a list of scores.
Features: add, remove, update, display scores, calculate average, min, max.
Input validation and edge case handling included.
**Tech:** C#

---

### BankApp 1.0
Console banking app with a single account.
Features: deposit, withdrawal, balance check, input validation, overdraft protection.
**Tech:** C#

### BankApp 2.0
Extended version with two accounts.
Features: deposit, withdrawal, balance display, transaction history, transfers between accounts.
**Tech:** C#

### BankApp 3.0
Multi-account banking app with three account types: business, current, savings.
Features: interest rates, account fees, overdraft with debt limits, account freeze mechanism, transfer limits.
**Tech:** C#

---

### VHS Movie Manager 1.0
Console app for managing a VHS movie collection with JSON persistence.
Features: add, remove, search, enum-based genre system, input validation.
**Tech:** C#, System.Text.Json

### VHS Movie Manager 2.0
Upgrade from JSON persistence to SQLite database via Entity Framework Core.
**Tech:** C#, EF Core, SQLite

---

### GarageApp 1.0
Console app for managing a car garage with JSON persistence.
Polymorphic car hierarchy: Combustion, Hybrid, Electric.
Features: add, remove, list cars, calculate cost per 100km per vehicle type.
OOP concepts: inheritance, interfaces (IFuel, IkWh), polymorphism, JsonDerivedType for type-safe JSON serialization.
**Tech:** C#, System.Text.Json

### GarageApp 2.0
Upgrade from JSON to SQLite via Entity Framework Core.
TPH (Table-Per-Hierarchy) with discriminator column for polymorphic persistence.
**Tech:** C#, EF Core, SQLite

### GarageApp 3.0 - Vehicle Cost Calculator API
RESTful API for managing a car garage and calculating vehicle running costs.
Features: full CRUD, polymorphism with EF Core discriminator, cost calculation per 100km, cheapest vehicle finder, input validation, Swagger UI, async/await with error handling.
**Tech:** ASP.NET Core Web API, EF Core, SQLite, Swagger


### GarageApp 4.0 - Unit Tests & JWT Authentication
GarageApp 3.0 extended with unit tests and token-based authentication.
Features: xUnit unit tests (`[Fact]`, `[Theory]`, exception cases, JWT token generation), user registration and login, password hashing (ASP.NET Core `PasswordHasher`), JWT bearer tokens (issuer, audience, expiry validation), `[Authorize]` on POST / PUT / DELETE endpoints, Swagger UI with a Bearer authorize button.
**Tech:** ASP.NET Core Web API, EF Core, SQLite, xUnit, JWT, Swagger

**Run locally:**
```bash
cd GarageApp4
dotnet user-secrets set "Jwt:Key" "<random-string-min-32-chars>"
dotnet run --launch-profile https
```

The signing key is not in the repository on purpose; it is stored with .NET user-secrets.

**Try it in Swagger** (`https://localhost:7177/swagger`):
1. `POST /api/Auth/register` with a username and password
2. `POST /api/Auth/login` and copy the returned token
3. Click **Authorize** and paste the token (without the word `Bearer`)
4. Call `POST /api/Cars` with a body like the one below. Without a token it returns 401, with a token 201.
```json
{
  "$type": "combustion",
  "make": "Audi",
  "model": "A4",
  "price": 20000,
  "year": 2020,
  "consumption": 6
}
```
(`$type` must be the first field; other values: `hybrid`, `electric`.)

**Run tests:** `dotnet test` (from the `GarageApp4` folder)

**Note:** `/register` is open to everyone, a deliberate simplification for a portfolio project.