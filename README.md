# CQRS and DDD Sample Project (.NET 8)

This repository is a reference implementation for **Domain-Driven Design (DDD)** and **CQRS** in a .NET 8 project.  
It shows how to build a clean, modular, and testable architecture for a simple `Product` domain.

---

## 📌 Features
- Domain Layer:
  - Entities (`Product`)
  - Value Objects (`Money`)
  - Domain Events (`ProductCreatedEvent`)
  - Interfaces (`IProductRepository`)
- Application Layer:
  - DTOs (`ProductDto`)
  - Services (`ProductService`)
  - Use Cases:
    - Commands (`AddProductCommand`, `AddProductHandler`)
    - Queries (`GetProductsQuery`, `GetProductsHandler`)
- Infrastructure Layer:
  - EF Core DbContext
  - Repository Implementation (`ProductRepository`)
- Web API Layer:
  - Controller (`ProductsController`)
  - Service registration (`ServiceCollectionExtensions`)
- Following **CQRS + DDD principles**

---

## 📂 Project Structure

    CQRS-And-DDD
    │
    ├── Application
    │ ├── DTOs
    │ ├── Services
    │ └── UseCases
    │ └── Products
    │ ├── Commands
    │ └── Queries
    │
    ├── Domain
    │ ├── Entities
    │ ├── Events
    │ ├── Interfaces
    │ └── ValueObjects
    │
    ├── Infrastructure
    │ ├── EFCore
    │ └── Repositories
    │
    └── WebApi
    ├── Controllers
    ├── Configurations
    └── appsettings.json

## 📦 Packages Used

This project uses the following NuGet packages:

- **Microsoft.EntityFrameworkCore** → ORM for database access  
- **Microsoft.EntityFrameworkCore.SqlServer** → SQL Server provider for EF Core  
- **Microsoft.EntityFrameworkCore.Tools** → For running migrations and scaffolding  
- **Microsoft.Extensions.DependencyInjection** → For dependency injection and service registration  
- **MediatR** → For handling CQRS (commands and queries)


## 📖 Why this Project?

This project is designed as a reference and learning material for:

Applying DDD in .NET 8

Using CQRS with Commands and Queries

Structuring code into layers for separation of concerns

Building testable and maintainable systems

## 🌍 Multilingual Note

This repository is mainly documented in English for global use.

لمشروع فيه تعليقات بالعربي والإنجليزي عشان يكون مرجع سهل لأي مطور مبتدئ أو محترف.


---

## 🚀 How to Run

Clone the repository:

    git clone https://github.com/your-username/CQRS-And-DDD.git
   
Navigate to the project:

    cd CQRS-And-DDD

Update the connection string in appsettings.json.

Run EF Core migrations (if needed):

    dotnet ef database update
    
Run the Web API:

    dotnet run --project WebApi
    
Test endpoints via Swagger or Postman:

`POST /api/products → Add a product`

`GET /api/products → Get all products`


## 🧪 Example Request

`POST /api/products`
    
    {
      "name": "Laptop",
      "price": 1200
    }

Response

      {
        "id": "a7c2f68e-1234-5678-9abc-def123456789"
      }


## 📜 License

MIT License. Free to use and modify.

