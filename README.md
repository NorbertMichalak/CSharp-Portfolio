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