# LotusApi2025

This repository contains a minimal Clean Architecture setup for a .NET Web API using MySQL.

## Structure
- `src/Domain` – domain entities and logic
- `src/Application` – application interfaces and use cases
- `src/Infrastructure` – Entity Framework Core setup and repository implementations
- `src/Api` – ASP.NET Core Web API project

## Building
Ensure the .NET 8 SDK is installed. Then run:

 
cd src/Api
 dotnet build
 

## Running
Update `appsettings.json` or environment variables with the `Default` connection string for MySQL, then run:

cd src/Api

dotnet run


Swagger UI will be available in development at `/swagger`.

## Authentication

JWT bearer authentication is enabled for the API. Update the `Authentication` section in `appsettings.json` (or override the values with environment variables) with your desired issuer, audience, secret key, token lifetime, and the list of in-memory users allowed to sign in.

To obtain an access token, send a `POST` request to `/api/auth/login` with a JSON body containing `username` and `password`. Use the returned bearer token in the `Authorization` header (`Authorization: Bearer <token>`) for subsequent requests.
