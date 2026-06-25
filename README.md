![.NET](https://img.shields.io/badge/.NET-9.0-purple)
![PostgreSQL](https://img.shields.io/badge/PostgreSQL-17-blue)
![Docker](https://img.shields.io/badge/Docker-Compose-blue)
![Tests](https://img.shields.io/badge/xUnit-Tests-green)

# Order Delivery Management System

A delivery order management system developed as a test assignment using **ASP.NET 9**, **Entity Framework Core**, **PostgreSQL**, **MediatR**, and **Clean Architecture** principles.

---

## Features

### Create Order

Create a new delivery order with:

* Sender city
* Sender address
* Receiver city
* Receiver address
* Cargo weight
* Pickup date

Each order receives an automatically generated order number.

### Get Order By Id

Retrieve a specific order by its identifier.

### Get Orders

Retrieve all created orders.

### Domain Validation

The system validates:

* City names
* Addresses
* Cargo weight
* Pickup date

All business rules are enforced within the Domain Layer.

---

## Architecture

### Request Flow

```text
Client
   │
   ▼
OrdersController
   │
   ▼
MediatR
   │
   ▼
Command / Query Handler
   │
   ▼
Repository
   │
   ▼
Entity Framework Core
   │
   ▼
PostgreSQL
```

### Clean Architecture

```text
┌─────────────────────────────┐
│          API Layer          │
├─────────────────────────────┤
│      Application Layer      │
├─────────────────────────────┤
│         Domain Layer        │
├─────────────────────────────┤
│    Infrastructure Layer     │
└─────────────────────────────┘
```

---

## Solution Structure

```text
src/
├── OrderService.API
├── OrderService.Application
├── OrderService.Domain
└── OrderService.Infrastructure

tests/
└── OrderService.Domain.Tests
```

---

## Technology Stack

### Backend

* ASP.NET 9
* Entity Framework Core
* MediatR
* PostgreSQL
* Swagger/OpenAPI
* CQRS
* Clean Architecture
* Result Pattern

### Testing

* xUnit
* FluentAssertions

### Infrastructure

* Docker
* Docker Compose

---

## Design Decisions

### Result Pattern

Business validation errors are handled using a custom Result Pattern instead of exceptions.

Example:

```csharp
var result = Order.Create(
    senderCity,
    senderAddress,
    receiverCity,
    receiverAddress,
    weight,
    pickupDate);

if (result.IsFailure)
{
    return result.Error;
}
```

### CQRS + MediatR

Commands and queries are separated using MediatR.

```text
Controller
    ↓
MediatR
    ↓
Handler
    ↓
Repository
    ↓
Database
```

---

## Running the Application

### Prerequisites

* Docker Desktop

No local PostgreSQL installation is required.

---

### Start Application

```bash
docker compose up --build
```

The application will:

* Start PostgreSQL
* Start ASP.NET API
* Apply Entity Framework migrations automatically
* Expose Swagger UI

---

## Swagger

Available at:

```text
http://localhost:8080/swagger
```

---

## API Endpoints

### Create Order

```http
POST /api/orders
```

Request example:

```json
{
  "senderCity": "Moscow",
  "senderAddress": "Lenina 1",
  "receiverCity": "Saint Petersburg",
  "receiverAddress": "Nevsky 10",
  "weight": 100.5,
  "pickUpDate": "2026-01-01T12:00:00Z"
}
```

Response:

```json
"ORD-250626-ABC123"
```

---

### Get Order By Id

```http
GET /api/orders/{id}
```

---

### Get All Orders

```http
GET /api/orders
```

---

## Error Handling

The API uses a custom Result Pattern together with centralized error mapping.

Examples:

| Error            | Status Code               |
| ---------------- | ------------------------- |
| Validation Error | 400 Bad Request           |
| Order Not Found  | 404 Not Found             |
| Unexpected Error | 500 Internal Server Error |

---

## Testing

Run all tests:

```bash
dotnet test
```

Covered scenarios:

* Successful order creation
* Invalid city validation
* Invalid address validation
* Invalid weight validation
* Invalid pickup date validation

---

## Current Status

### Completed

* Domain Layer
* Application Layer
* Infrastructure Layer
* API Layer
* CQRS with MediatR
* PostgreSQL Integration
* Entity Framework Core
* Docker Compose Support
* Automatic Database Migrations
* Swagger Documentation
* Unit Tests

### Planned

* React Frontend
* Integration Tests
* Pagination
* Filtering
* Order Status Tracking

---

## Author

Developed as a test assignment.
