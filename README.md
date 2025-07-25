# LaundrySystemAPI

This is a RESTful Web API developed with **ASP.NET Core 8** and **Entity Framework Core** using a **Code-First** approach. It simulates a laundry service system where customers can view their purchase history and washing machines can be added with validation logic.

---

## 🚀 Features

- ✅ Get customer purchase history  
  `GET /api/customers/{customerId}/purchases`

- ✅ Add a new washing machine with its available programs  
  `POST /washing-machines`

- 🔒 Validation rules:
  - Program price must be **≤ 25**
  - Machine max weight must be **≥ 8**
  - Washing machine serial must be unique

- 🧱 Architecture:
  - Controller → Service → DTO → Entity → DbContext

- 🛠️ Status code handling for:
  - Invalid data
  - Duplicate serial numbers
  - Missing programs

---

## 🧰 Tech Stack

- C#  
- .NET 8  
- Entity Framework Core  
- SQL Server  
- Swagger (OpenAPI via Swashbuckle)  

---

## 📦 How to Run Locally

1. Clone the repository  
2. Update your `appsettings.json` with your SQL Server connection string  
3. Open terminal and run:
   ```bash
   dotnet ef database update
   dotnet run
   ```
4. Swagger UI will be available at  
   `http://localhost:5000/swagger`

---

## 📄 Sample JSON – POST /washing-machines

```json
{
  "washingMachine": {
    "maxWeight": 9.52,
    "serialNumber": "WM2025/S1431/13"
  },
  "availablePrograms": [
    {
      "programName": "Quick Wash",
      "price": 12.99
    },
    {
      "programName": "Cotton Cycle",
      "price": 17.29
    }
  ]
}
```

---

## 👤 Author

**İbrahim Erdem Yeşil**  
Computer Science Student – PJAIT  
Backend Developer (.NET / C#)
