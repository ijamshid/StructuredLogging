# StructuredLogging

## 📚 Project Description

This is a **.NET 8 Web API project** named `LoggingDemo` that demonstrates how to implement structured logging using `ILogger` alongside a clean repository pattern for managing a collection of books.

The project provides a simple RESTful API with full CRUD operations for books and logs each key operation (such as creating, retrieving, updating, and deleting records) in a structured, traceable way. This makes it easy to monitor application behavior, diagnose issues, and maintain clean code separation between controllers, data models, DTOs, and repositories.

### 🎯 Key Features:

* ASP.NET Core Web API (using .NET 8)
* Clean repository pattern implementation
* Structured logging with `ILogger<T>`
* DTOs for safe data transfer
* Fully asynchronous CRUD operations
* Clear, developer-friendly API endpoints

### 📊 API Endpoints:

| Method | Endpoint          | Description                  |
| :----- | :---------------- | :--------------------------- |
| GET    | `/api/books`      | Retrieve a list of all books |
| GET    | `/api/books/{id}` | Retrieve a single book by ID |
| POST   | `/api/books`      | Add a new book               |
| PUT    | `/api/books/{id}` | Update an existing book      |
| DELETE | `/api/books/{id}` | Delete a book by ID          |

### 📝 Technologies Used:

* ASP.NET Core 8 Web API
* C#
* ILogger for structured logging
* Repository Pattern
* DTO (Data Transfer Object)
* Entity Framework Core (if applicable)

### 📂 Project Structure:

```
LoggingDemo/
├── Controllers/
│   └── BooksController.cs
├── DTOs/
│   └── BookDTO.cs
├── Models/
│   └── Book.cs
├── Repositories/
│   └── IBookRepository.cs
│   └── BookRepository.cs
├── Program.cs
└── LoggingDemo.csproj
```

---

