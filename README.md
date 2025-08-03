# LotusApi2025

This repository contains a minimal Clean Architecture setup for a .NET Web API using MySQL.

## Structure
- `src/Domain` – domain entities and logic
- `src/Application` – application interfaces and use cases
- `src/Infrastructure` – Entity Framework Core setup and repository implementations
- `src/Api` – ASP.NET Core Web API project
- `LotusApi2025.sln` – solution containing all projects

## Building
Ensure the .NET 8 SDK is installed. Then build the solution:

```bash
dotnet build LotusApi2025.sln
```

## Running
Update `appsettings.json` or environment variables with the `Default` connection string for MySQL, then run:

```bash
dotnet run
```

Swagger UI will be available in development at `/swagger`.

## Testing

Run the unit tests:

```bash
dotnet test
```
