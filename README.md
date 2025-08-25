# Employee Portal MVC

A secure, role-based Employee Portal built using ASP .NET Core MVC, designed to streamline internal operations and access control within an organization.

## Features

- Role-Based Access: Different user roles (e.g., Admin, Manager, Employee) control access to specific portal areas.
- User Authentication & Authorization: Secure login flows using ASP .NET Identity, with protected routes.
- Dashboard & CRUD Operations: View, create, edit, and manage employee profiles and related data.
- Responsive UI: Stylish, mobile-first interface using Bootstrap or Tailwind CSS.
- Clean Architecture: Organized project structure with Controllers, Views, Models, and possibly Services/Repositories.
- Secure Practices: Includes error handling, validation, and protection against common web vulnerabilities.

## Project Structure

- ├── Controllers/             # MVC Controllers for handling HTTP requests
- ├── Models/                  # Domain and ViewModels
- ├── Views/                   # Razor views and layout files
- ├── Data/                    # Data access—DbContext and migrations
- ├── Services/                # Business logic services (optional)
- ├── wwwroot/                 # Static assets: CSS, JS, images
- ├── appsettings.json         # Application configuration (e.g., connection strings)
- ├── Program.cs               # App settings, middleware, routing setup
- ├── EmployeePortalMVC.csproj # Project file and dependencies
- └── README.md                # Project documentation


## Getting Started

### Prerequisites

- .NET SDK (8.0+)
- A running SQL Server instance (local or cloud-hosted)

### Installation

1. Clone the repository:
  git clone https://github.com/SirTebz/EmployeePortalMVC.git
  cd EmployeePortalMVC

2. Update appsettings.json to configure your database:
  "ConnectionStrings": {
  "DefaultConnection": "Server=.;Database=EmployeePortal;Trusted_Connection=True;"
  }

3.  Run database migrations:
  dotnet ef database update

4. Run the app locally:
   dotnet run

## How It Works

- Controllers route user requests to the appropriate actions (e.g., EmployeeController, AccountController).
- Models represent your domain data—employee profiles, roles, etc.
- Views (Razor pages) render UI and bind form data to models.
- Data Layer uses Entity Framework Core for database interactions, migrations, and schema updates.
- Authentication & Authorization via ASP .NET Identity ensures role-based access controls.

### License

- Distributed under the MIT License. See LICENSE for details.

