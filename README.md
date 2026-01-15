# FeatureGate API

A dynamic Feature Gate (Feature Toggle) implementation using **.NET 10**, **PostgreSQL**, and **Clean Architecture**. This project demonstrates how to enable or disable API features at runtime via database configuration.

## 🚀 Features

- **Clean Architecture**: Organized into Domain, Application, Infrastructure, and Web layers within a single project.
- **Dynamic Gating**: custom `FeatureGateAttribute` that intercepts requests and checks feature status in PostgreSQL.
- **Database Driven**: Toggle features using a simple SQL update or the provided management API.
- **Interactive Documentation**: Swagger UI integrated for easy testing.
- **Automatic Migrations**: Database schema and seed data are applied automatically on startup.

## 🛠️ Tech Stack

- **Framework**: .NET 10
- **Database**: PostgreSQL (via Entity Framework Core & Npgsql)
- **Cache**: Redis (Configuration ready)
- **API Doc**: Swagger (Swashbuckle)

## 📋 Prerequisites

- [.NET 10 SDK](https://dotnet.microsoft.com/download/dotnet/10.0)
- [PostgreSQL](https://www.postgresql.org/download/)
- [Redis](https://redis.io/download/) (Optional, configuration provided)

## ⚙️ Configuration

Update the connection string in `appsettings.json` to match your environment:

```json
"ConnectionStrings": {
  "DefaultConnection": "Host=localhost;Port=5432;Database=ECommerceDb;Username=postgres;Password=Admin123!"
},
"Redis": "localhost:6379"
```

## 🏃 Getting Started

1. **Clone the repository.**
2. **Navigate to the project root:**
   ```bash
   cd FeatureGate
   ```
3. **Restore and Build:**
   ```bash
   dotnet restore
   dotnet build
   ```
4. **Run the application:**
   ```bash
   dotnet run --project FeatureGate.Api.csproj
   ```
   *The database will be automatically created and seeded on first run.*

## 🔍 Usage

### 1. Interactive API (Swagger)
Visit `https://localhost:<port>/swagger` to explore the endpoints.

### 2. Testing the Feature Gate
The `UsersController` is partially restricted by default:
- **GET** `/api/users`: **Enabled** (Returns static users).
- **POST** `/api/users`: **Disabled** (Returns 403 Forbidden).

### 3. Toggling Features
To enable a feature like "UserCreate":
1.  Check existing features via **GET** `/api/features`.
2.  Update the state via **PUT** `/api/features` with the payload:
    ```json
    {
      "id": 2,
      "name": "UserCreate",
      "isEnabled": true
    }
    ```
3.  The **POST** `/api/users` endpoint will now be accessible instantly!

## 📁 Project Structure

```text
FeatureGate/
├── Domain/            # Entities and Interfaces
├── Application/       # Services and DTOs
├── Infrastructure/    # Data Context, Repositories, Migrations
├── Web/               # Filter logic (FeatureGateAttribute)
├── Controllers/       # API Endpoints
└── Program.cs         # DI and Middleware Configuration
```

## 📝 License
This project is open-source and available under the MIT License.