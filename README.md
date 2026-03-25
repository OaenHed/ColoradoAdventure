# ColoradoAdventure
## Colorado Adventure - Kayaking Trip Booking App

A full-featured ASP.NET Core 9 MVC web application for booking Colorado River kayaking trips.

### Features
- Browse 10 unique Colorado River kayaking tours (Beginner → Expert)
- Filter tours by difficulty level and price range
- User registration, login, and profile management via ASP.NET Identity
- Online booking system with date selection and group size
- "My Bookings" dashboard with cancellation support
- Admin dashboard: manage tours, bookings, and users
- Responsive design with custom adventure-themed CSS

### Tech Stack
- ASP.NET Core 9 MVC
- Entity Framework Core with SQL Server
- ASP.NET Core Identity
- Bootstrap 5 + Font Awesome 6

---

## 🖥️ Getting Started in Visual Studio

### Prerequisites

Before you begin, make sure the following are installed:

| Tool | Where to get it |
|------|----------------|
| **Visual Studio 2022** (v17.12 or later) | [visualstudio.microsoft.com](https://visualstudio.microsoft.com/) — Community edition is free |
| **.NET 9 SDK** | Included with Visual Studio 2022 17.12+, or [dotnet.microsoft.com/download](https://dotnet.microsoft.com/download) |
| **ASP.NET Core 9 Runtime** | Required to *run* the app. Download the **"ASP.NET Core Runtime 9.x"** installer from [dotnet.microsoft.com/download/dotnet/9.0](https://dotnet.microsoft.com/download/dotnet/9.0). *(Note: installing just the SDK is not enough — you need the runtime too. The full SDK installer from that page bundles both.)* |
| **SQL Server LocalDB** | Included automatically with Visual Studio when the **ASP.NET and web development** workload is installed |
| **dotnet-ef CLI tool** | Run `dotnet tool install --global dotnet-ef` in any terminal after installing the .NET SDK |

> **Visual Studio workload check:** Open the Visual Studio Installer → click **Modify** on your VS 2022 install → make sure **ASP.NET and web development** is checked → click **Modify** to apply.

> **Getting the `System.Runtime, Version=9.0.0.0` error?** This is almost always a build/restore issue. Follow these steps in order:
> 1. Make sure the **ASP.NET Core 9.x Runtime** is installed ([dotnet.microsoft.com/download/dotnet/9.0](https://dotnet.microsoft.com/download/dotnet/9.0)). The full SDK installer from that page bundles both SDK and runtime.
> 2. Run `dotnet restore` **followed by** `dotnet build` in the project folder. Just running `dotnet restore` is not enough — the build step generates the `runtimeconfig.json` that tells the host where to find the runtime.
> 3. If you see *"A compatible .NET SDK was not found"* before or alongside the error, your .NET SDK was not recognized. Verify your SDK with `dotnet --list-sdks` — you should see at least one `9.x.x` entry. If not, re-install the .NET 9 SDK.
> 4. Verify with `dotnet --list-runtimes` — you should see a line starting with `Microsoft.AspNetCore.App 9.`.

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
start ColoradoAdventure.slnx
```

---

### Step 2 — Open the Solution

If the project didn't open automatically after cloning:
1. Go to **File → Open → Project/Solution**.
2. Navigate to your cloned folder and select **`ColoradoAdventure.slnx`**.
3. Click **Open**.

> **Tip:** You can also double-click `ColoradoAdventure.slnx` in Windows Explorer to open it directly in Visual Studio. The `.slnx` format is the modern Visual Studio solution format introduced in VS 2022 and fully supported in .NET 9.

Visual Studio will automatically restore all NuGet packages. You can watch the progress in the bottom status bar. Wait until it says **Ready**.

---

### Step 3 — Create and Seed the Database

The app uses **SQL Server LocalDB**, which ships with Visual Studio, so no extra database installation is needed.

#### Option A — dotnet CLI (works in any terminal — recommended)

Open a terminal (PowerShell, Command Prompt, VS Code terminal, etc.) in the project folder and run:

```powershell
# Install the EF Core CLI tool globally (one-time, skip if already installed)
dotnet tool install --global dotnet-ef

# Restore NuGet packages (REQUIRED before running ef commands)
dotnet restore

# Build the project (REQUIRED — generates the correct runtime configuration)
dotnet build

# Create the migration
dotnet ef migrations add InitialCreate

# Apply the migration and seed the database
dotnet ef database update
```

> **Note:** If `dotnet-ef` was already installed at an older version you can upgrade it with `dotnet tool update --global dotnet-ef`.
>
> **NETSDK1004 error?** If you see `Assets file 'obj/project.assets.json' not found`, it means `dotnet restore` was not run first. Run `dotnet restore` and then retry the `dotnet ef` commands.

#### Option B — Visual Studio Package Manager Console

> ⚠️ These commands **only work inside Visual Studio's Package Manager Console** — they will not work in PowerShell, Command Prompt, or any other terminal. If you try to run `Add-Migration` outside of Visual Studio you will get a "not recognized as a cmdlet" error. Use Option A above if you are working in a regular terminal.

1. In Visual Studio, go to **Tools → NuGet Package Manager → Package Manager Console**.
2. Make sure the **Default Project** dropdown in the PMC toolbar is set to `ColoradoAdventure`.
3. Run:
   ```powershell
   Add-Migration InitialCreate
   ```
4. Then apply the migration:
   ```powershell
   Update-Database
   ```

---

Both options create a `ColoradoAdventureDb` database in LocalDB and seed it with 10 sample Colorado River tours automatically.

---

### Step 4 — Run the Application

Press **F5** (or click the green ▶ **Run** button) to build and launch the app in your browser.

Visual Studio will:
- Build the project
- Start the Kestrel development web server
- Automatically open your default browser

The app is available at:
- **HTTPS:** `https://localhost:7243` *(recommended)*
- **HTTP:** `http://localhost:5141`

> **Browser didn't open?** Manually navigate to `https://localhost:7243` in any browser while the app is running.

You should see the Colorado Adventure homepage with the hero section and featured tours. 🚣

#### Client-side (JavaScript) Debugging in Visual Studio

Visual Studio 2022 attaches the JavaScript debugger automatically when you launch with **Edge** or **Chrome**:

1. In the toolbar, click the arrow next to the ▶ Run button and select **Microsoft Edge** or **Google Chrome** as the browser.
2. Press **F5**. The browser will open and VS will attach to it.
3. Set breakpoints in any `.js` file (e.g. `wwwroot/js/site.js`) — execution will pause in Visual Studio, not in the browser DevTools.

> **Tip:** If you see the warning *"The WebRootPath was not found … bin\Debug\net9.0\wwwroot"*, the `workingDirectory` in `launchSettings.json` is already set to `$(ProjectDir)` which corrects this. Make sure you are using the **https** or **http** profile (shown in the VS run dropdown), not a manually created executable launch.

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
# 0. Install the EF Core CLI tool (one-time only — skip if already installed)
dotnet tool install --global dotnet-ef

# 1. Restore packages and build (both steps are required)
dotnet restore
dotnet build

# 2. Create and apply the database
dotnet ef migrations add InitialCreate
dotnet ef database update

# 3. Run the app
dotnet run
```

After `dotnet run` starts, the console will print lines like:

```
info: Microsoft.Hosting.Lifetime[14]
      Now listening on: https://localhost:7243
      Now listening on: http://localhost:5141
```

**Open your browser and go to `https://localhost:7243`** (or `http://localhost:5141` if you prefer HTTP).

> **Note:** Unlike Visual Studio, `dotnet run` does **not** open a browser automatically — you must open it yourself.  
> To stop the app, press **Ctrl+C** in the terminal.

---

## 🛠️ VS Code Debugging

The repository includes `.vscode/launch.json` and `.vscode/tasks.json` so you can debug in **Visual Studio Code** with full server-side *and* client-side support.

### Prerequisites

Install the **C# Dev Kit** extension (or the older **C#** extension) from the VS Code marketplace.

### Launch configurations

Open the project folder (`File → Open Folder`) in VS Code and use the **Run and Debug** panel (Ctrl+Shift+D). Three configurations are available:

| Configuration | What it does |
|---|---|
| **.NET (HTTPS)** | Starts the server and opens your default browser automatically. Good for server-side only debugging. |
| **.NET (HTTPS) + Edge (client-side debug)** | Starts the server, opens Edge, and attaches the VS Code JavaScript debugger so you can set breakpoints in `wwwroot/js` files. |
| **.NET (HTTPS) + Chrome (client-side debug)** | Same as above but uses Chrome. |

### How to use

1. Press **F5** (or click the green ▶ in the Run and Debug panel) and select one of the configurations above.
2. VS Code will build the project, start Kestrel, and open the browser automatically — no need to find the URL manually.
3. For the Edge/Chrome configurations, set a breakpoint in any `.js` file in `wwwroot/js/` — VS Code will pause execution there just like a C# breakpoint.

> **Note:** The `cwd` in each configuration is set to `${workspaceFolder}` (the project root), which ensures ASP.NET Core finds `wwwroot` correctly and prevents the *"WebRootPath was not found"* warning.

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
├── ColoradoAdventure.slnx  # Visual Studio solution file — open this in VS 2022
├── ColoradoAdventure.csproj
├── Controllers/       # HomeController, ToursController, BookingsController, AdminController
├── Data/              # ApplicationDbContext with EF Core seed data (10 tours)
├── Models/            # Tour, Booking, Review, ApplicationUser, enums
├── Views/             # Razor views for all controllers + Shared layout
├── wwwroot/css/       # adventure.css — custom outdoor adventure theme
├── appsettings.json   # Connection string and app configuration
└── web.config         # IIS hosting configuration
```
