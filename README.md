# ColoradoAdventure
## Colorado Adventure - Kayaking Trip Booking App

A full-featured ASP.NET Core 8.0 MVC web application for booking Colorado River kayaking trips.

### Features
- Browse 10 unique Colorado River kayaking tours (Beginner → Expert)
- Filter tours by difficulty level and price range
- User registration, login, and profile management via ASP.NET Identity
- Online booking system with date selection and group size
- "My Bookings" dashboard with cancellation support
- Admin dashboard: manage tours, bookings, and users
- Responsive design with custom adventure-themed CSS

### Tech Stack
- ASP.NET Core 8.0 MVC
- Entity Framework Core with SQL Server
- ASP.NET Core Identity
- Bootstrap 5 + Font Awesome 6

### Setup Instructions

#### Prerequisites
- .NET 8.0 SDK
- SQL Server or SQL Server LocalDB

#### Getting Started

1. **Clone the repository** and navigate to the project folder.

2. **Restore dependencies:**
   ```bash
   dotnet restore
   ```

3. **Update the connection string** in `appsettings.json` if needed:
   ```json
   "DefaultConnection": "Server=(localdb)\\mssqllocaldb;Database=ColoradoAdventureDb;Trusted_Connection=True;"
   ```

4. **Run EF Core migrations:**
   ```bash
   dotnet ef migrations add InitialCreate
   dotnet ef database update
   ```

5. **Run the application:**
   ```bash
   dotnet run
   ```

6. **Seed the admin role** (optional — add a user manually via the app, then assign the Admin role in the database).

### Project Structure
```
ColoradoAdventure/
├── Controllers/       # HomeController, ToursController, BookingsController, AdminController
├── Data/              # ApplicationDbContext with EF Core seed data
├── Models/            # Tour, Booking, Review, ApplicationUser, enums
├── Views/             # Razor views for all controllers + Shared layout
└── wwwroot/css/       # adventure.css — custom theme
```
