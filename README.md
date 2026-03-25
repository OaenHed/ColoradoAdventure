# ColoradoAdventure
## Colorado Adventure - Kayaking Trip Booking App

A full-featured ASP.NET Core 10 MVC web application for booking Colorado River kayaking trips.

### Features
- Browse 10 unique Colorado River kayaking tours (Beginner → Expert)
- Filter tours by difficulty level and price range
- User registration, login, and profile management via ASP.NET Identity
- Online booking system with date selection and group size
- "My Bookings" dashboard with cancellation support
- Admin dashboard: manage tours, bookings, and users
- Responsive design with custom adventure-themed CSS

### Tech Stack
- ASP.NET Core 10 MVC
- Entity Framework Core with SQL Server
- ASP.NET Core Identity
- Bootstrap 5 + Font Awesome 6

---

## 🖥️ Getting Started in Visual Studio

### Prerequisites

Before you begin, make sure the following are installed:

| Tool | Where to get it |
|------|----------------|
| **Visual Studio 2022** (v17.8 or later) | [visualstudio.microsoft.com](https://visualstudio.microsoft.com/) — Community edition is free |
| **.NET 10 SDK** | Included with Visual Studio 2022 17.12+, or [dotnet.microsoft.com/download](https://dotnet.microsoft.com/download) |
| **SQL Server LocalDB** | Included automatically with Visual Studio when the **ASP.NET and web development** workload is installed |

> **Visual Studio workload check:** Open the Visual Studio Installer → click **Modify** on your VS 2022 install → make sure **ASP.NET and web development** is checked → click **Modify** to apply.

---

### Step 1 — Clone the Repository

**Option A — Clone inside Visual Studio (recommended):**
1. Open Visual Studio 2022.
2. On the start screen, click **Clone a repository**.
3. Paste the repository URL:
   ```
   https://github.com/OaenHed/ColoradoAdventure.git
   ```
4. Choose a local folder (e.g. `C:\Projects\ColoradoAdventure`).
5. Click **Clone**. Visual Studio will clone the repo and open it automatically.

**Option B — Clone with Git, then open in Visual Studio:**
```bash
git clone https://github.com/OaenHed/ColoradoAdventure.git
cd ColoradoAdventure
start ColoradoAdventure.csproj
```

---

### Step 2 — Open the Project

If the project didn't open automatically after cloning:
1. Go to **File → Open → Project/Solution**.
2. Navigate to your cloned folder and select **`ColoradoAdventure.csproj`**.
3. Click **Open**.

Visual Studio will automatically restore all NuGet packages. You can watch the progress in the bottom status bar. Wait until it says **Ready**.

---

### Step 3 — Create and Seed the Database

The app uses **SQL Server LocalDB**, which ships with Visual Studio, so no extra database installation is needed.

Run the Entity Framework migrations using the **Package Manager Console**:

1. In Visual Studio, go to **Tools → NuGet Package Manager → Package Manager Console**.
2. In the console panel that opens at the bottom, run:
   ```powershell
   Add-Migration InitialCreate
   ```
3. Then apply the migration to create the database:
   ```powershell
   Update-Database
   ```

This creates a `ColoradoAdventureDb` database in LocalDB and seeds it with 10 sample Colorado River tours automatically.

> **Tip:** If the `Add-Migration` command isn't found, run `Install-Package Microsoft.EntityFrameworkCore.Tools` first, or ensure the **Default Project** dropdown in the PMC toolbar is set to `ColoradoAdventure`.

---

### Step 4 — Run the Application

Press **F5** (or click the green ▶ **Run** button) to build and launch the app in your browser.

Visual Studio will:
- Build the project
- Start the Kestrel development web server
- Open your default browser at `https://localhost:{port}`

You should see the Colorado Adventure homepage with the hero section and featured tours. 🚣

---

### Step 5 — Create an Account

1. Click **Sign Up** in the top-right corner.
2. Fill in your email and a password (min 6 chars, must include upper + lowercase + digit).
3. Click **Register**.

You are now logged in and can browse tours and make bookings.

---

### Step 6 — (Optional) Grant Yourself Admin Access

The admin dashboard (`/Admin`) requires the **Admin** role. To assign it:

1. Register an account normally (Step 5).
2. Open the **SQL Server Object Explorer** in Visual Studio:
   - Go to **View → SQL Server Object Explorer**
3. Expand **(localdb)\MSSQLLocalDB → Databases → ColoradoAdventureDb → Tables**.
4. Right-click **dbo.AspNetRoles** → **View Data** and add a row:
   - `Id`: any GUID (e.g. `admin-role-id-1234`)
   - `Name`: `Admin`
   - `NormalizedName`: `ADMIN`
   - `ConcurrencyStamp`: any GUID
5. Right-click **dbo.AspNetUsers** → **View Data**, find your user, and copy the `Id`.
6. Right-click **dbo.AspNetUserRoles** → **View Data** and add a row:
   - `UserId`: your user Id from step 5
   - `RoleId`: the Id you set in step 4
7. Restart the app (Stop and press F5 again). The **Admin** menu will now appear in the navbar.

---

### Connection String

The default connection string in `appsettings.json` points to LocalDB and works out-of-the-box on any machine with Visual Studio installed:

```json
"DefaultConnection": "Server=(localdb)\\mssqllocaldb;Database=ColoradoAdventureDb;Trusted_Connection=True;MultipleActiveResultSets=true"
```

If you have a full SQL Server instance, replace `(localdb)\\mssqllocaldb` with your server name (e.g. `localhost` or `.\SQLEXPRESS`).

---

## ⌨️ CLI / dotnet run (Alternative)

If you prefer the command line over Visual Studio:

```bash
# 1. Restore packages
dotnet restore

# 2. Create and apply the database
dotnet ef migrations add InitialCreate
dotnet ef database update

# 3. Run the app
dotnet run
```

---

## 🌐 IIS Deployment

The project includes a `web.config` pre-configured for IIS with the ASP.NET Core Module v2 (in-process hosting). To deploy:

1. **Publish** from Visual Studio: right-click the project → **Publish** → choose **IIS** or **Folder** → follow the wizard.
2. Copy the published output to your IIS site folder.
3. Ensure the **.NET Hosting Bundle** is installed on the IIS server ([download here](https://dotnet.microsoft.com/download)).
4. Set the Application Pool to **No Managed Code**.
5. Update `appsettings.json` (or use environment variables) with your production connection string.

---

## 📁 Project Structure

```
ColoradoAdventure/
├── Controllers/       # HomeController, ToursController, BookingsController, AdminController
├── Data/              # ApplicationDbContext with EF Core seed data (10 tours)
├── Models/            # Tour, Booking, Review, ApplicationUser, enums
├── Views/             # Razor views for all controllers + Shared layout
├── wwwroot/css/       # adventure.css — custom outdoor adventure theme
├── appsettings.json   # Connection string and app configuration
└── web.config         # IIS hosting configuration
```
