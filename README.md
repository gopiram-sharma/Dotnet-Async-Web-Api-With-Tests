# Modern Dot Net Api

> This is a clean, modular, and production-ready ASP.NET Core Web API template built with best practices in mind.  
> It uses the latest .NET 8 and C# 12 features, supports a layered architecture, and integrates popular tools like EF Core, AutoMapper, FluentValidation, Serilog, Docker, and Health Checks.  
> Ideal for rapid backend API development with maintainability and testability.

[![.NET](https://img.shields.io/badge/.NET-8-blueviolet.svg)](https://dotnet.microsoft.com/)
[![Build](https://img.shields.io/badge/build-passing-brightgreen.svg)]()
[![License](https://img.shields.io/badge/license-MIT-blue.svg)]()
[![Tests](https://img.shields.io/badge/tests-passing-brightgreen.svg)]()

A modern, layered ASP.NET Core Web API project with:

- ✅ Clean architecture (API / Application / Infrastructure / Domain)
- ✅ .NET 8 + C# 12
- ✅ EF Core + SQL Server
- ✅ Repository + Unit of Work patterns
- ✅ DTOs + AutoMapper
- ✅ FluentValidation
- ✅ Serilog structured logging
- ✅ Health checks
- ✅ Docker support
- ✅ GitHub Codespaces ready
- ✅ xUnit tests with Moq + FluentAssertions

---

## 📁 Project Structure
```bash
ModernDotNetApi/
│
├── src/
│ ├── ModernDotNetApi.Api # API layer (Controllers, DI, Swagger)
│ ├── ModernDotNetApi.Application # Services, DTOs, interfaces
│ ├── ModernDotNetApi.Domain # Domain models, interfaces
│ ├── ModernDotNetApi.Infrastructure # EF Core, SQL Server, Repositories
│ └── ModernDotNetApi.Tests # xUnit tests
│
├── docker-compose.yml
├── ModernDotNetApi.sln

```

---

## 🚀 Getting Started in GitHub Codespaces

### 🐘 Launch SQL Server

```bash
docker-compose up -d
```

### 🛠 Apply EF Core Migrations
```bash
dotnet tool install --global dotnet-ef

dotnet ef migrations add InitialCreate --project src/ModernDotNetApi.Infrastructure --startup-project src/ModernDotNetApi.Api

dotnet ef database update --project src/ModernDotNetApi.Infrastructure --startup-project src/ModernDotNetApi.Api
```

### ▶ Run the API

```bash
dotnet run --project src/ModernDotNetApi.Api
```

### 🔍 Swagger UI

https://localhost:5001/swagger


### 🧪 Running Tests

Tests are inside src/ModernDotNetApi.Tests
```bash
dotnet test src/ModernDotNetApi.Tests
```

### 🔍 Health Checks

https://localhost:5001/health


### 🐳 Docker Tips

```bash
docker-compose down

docker-compose up --build -d
```

### 🧼 Clean Migrations (if needed)
```bash
rm -r src/ModernDotNetApi.Infrastructure/Migrations

dotnet ef migrations add InitialCreate --project src/ModernDotNetApi.Infrastructure --startup-project src/ModernDotNetApi.Api

dotnet ef database update --project src/ModernDotNetApi.Infrastructure --startup-project src/ModernDotNetApi.Api
```


🔍 Swagger UI

https://localhost:5001/swagger
