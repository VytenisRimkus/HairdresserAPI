
## Prerequisites
- .NET 7 SDK [download](https://www.microsoft.com/net/download)
- MySQL Server [download](https://dev.mysql.com/downloads/)

## MySQL Setup:
- Make sure MySQL Server is running.
- Create and save root password
- Update the appsettings.json with your MySQL connection string if necessary.

## Open and run the Project:
- Clone Repository

# Visual Studio
- Double click on the .sln file to open the project in Visual Studio.
- Press F5 or click on the IIS Express button to run.

# Visual Studio code
- Install dependencies (`dotnet restore`, this is done automatically if you use IDE)
- Build the app (`dotnet build`)
- Run the application (`dotnet run`)
- Navigate to `https://localhost:7131/swagger` to see if it works

## Adding/Creating a migration

# Add Migration
- Console: `dotnet ef migrations add InitialMigration --output-dir Migrations`

# List existing migrations

Run `dotnet ef migrations list`

# Applying a database migration

There are two options:

- 1. Just run the project and it will apply migration on startup
- 2. Console, run: `dotnet ef database update`

# Removing database migration

- Run `dotnet ef migrations remove`