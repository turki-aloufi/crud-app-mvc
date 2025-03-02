# Employee Management System

This is a simple Employee Management System built using ASP.NET Core MVC with Entity Framework Core and SQL Server.

## Prerequisites

Before running the project, ensure you have the following installed:
- .NET SDK (6.0 or later)
- SQL Server (Express, LocalDB, or full version)
- Visual Studio or VS Code with C# extensions

## Setup Instructions

### 1. Clone the Repository
```bash
git clone https://github.com/turki-aloufi/crud-app-mvc.git
cd WebApplication3
```

### 2. Configure SQL Server Connection
Modify the `appsettings.json` file with your SQL Server connection string:
```json
"ConnectionStrings": {
  "DefaultConnection": "Server=YOUR_SERVER_NAME;Database=EmployeeDB;Trusted_Connection=True;MultipleActiveResultSets=true"
}
```
Replace `YOUR_SERVER_NAME` with your actual SQL Server instance name.

### 3. Apply Migrations & Seed Database
Run the following commands to create the database and apply migrations:
```bash
dotnet ef database update
```

### 4. Run the Application
Start the application with:
```bash
dotnet run
```
Then, open your browser and navigate to `https://localhost:5001/Employee`

## Features
- Add, Edit, and Delete Employees
- Store Employee Name, Position, and Salary
- User-friendly UI with Bootstrap styling

## Troubleshooting
- If you encounter connection issues, ensure SQL Server is running and accessible.
- If migrations fail, delete the `Migrations` folder and run:
```bash
dotnet ef migrations add InitialCreate
```
Then re-run `dotnet ef database update`.

## License
This project is open-source under the MIT License.


