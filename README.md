# Order Delivery Management System

A simple order delivery management system built as a test assignment using ASP.NET 9, React, Entity Framework Core and Clean Architecture.

---

## Features

### Create Order

Create a new delivery order with:

* Sender city
* Sender address
* Receiver city
* Receiver address
* Weight
* Pickup date

### Orders List

View all created orders including:

* Order number
* Sender information
* Receiver information
* Cargo weight
* Pickup date

### Order Details

View a single order in read-only mode.

---

## Architecture

```text
┌─────────────────┐
│     React UI    │
└────────┬────────┘
         │ HTTP
         ▼
┌─────────────────┐
│    ASP.NET API  │
└────────┬────────┘
         │
         ▼
┌─────────────────┐
│  Application    │
│ Business Logic  │
└────────┬────────┘
         │
         ▼
┌─────────────────┐
│     Domain      │
│ Entities &      │
│ Validation      │
└────────┬────────┘
         │
         ▼
┌─────────────────┐
│ Infrastructure  │
│ EF Core + DB    │
└─────────────────┘
```

---

## Solution Structure

```text
src/
├── Order.API
├── Order.Application
├── Order.Domain
└── Order.Infrastructure

tests/
└── Order.Domain.Tests
```

---

## Technologies

### Backend

* ASP.NET 9
* Entity Framework Core
* Clean Architecture
* Result Pattern

### Frontend

* React
* TypeScript

### Database

* PostgreSQL

### Testing

* xUnit
* FluentAssertions

---

## Domain Validation

The domain layer validates:

* City names
* Addresses
* Cargo weight
* Pickup date

Example:

```csharp
var result = Order.Create(
    senderCity,
    senderAddress,
    receiverCity,
    receiverAddress,
    weight,
    pickupDate);
```

---

## Getting Started

### Clone repository

```bash
git clone <repository-url>
```

### Backend

```bash
cd src/Order.API

dotnet restore

dotnet ef database update

dotnet run
```

API will be available at:

```text
https://localhost:5001
```

### Frontend

```bash
cd frontend

npm install

npm run dev
```

Frontend will be available at:

```text
http://localhost:5173
```

---

## Running Tests

```bash
dotnet test
```

---

## Future Improvements

* Docker support
* Integration tests
* Swagger authentication
* CQRS with MediatR
* Order status tracking

---

## Author

Developed as a test assignment.
