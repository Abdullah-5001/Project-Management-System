# Project Hub

A small ASP.NET Core 8 Razor Pages CRUD app for managing project records with SQLite and Entity Framework Core.

## Run locally

1. Install the .NET 8 SDK. No SQL Server or SSMS is required.
2. Start the app:

   ```powershell
   dotnet run
   ```

3. Open the URL shown by the app. Use **Projects** to add, edit, view, or delete records.

The app stores data in `projectmanagement.db` in the project directory. The database and table are created automatically on first startup. `database.sql` is also provided for users who want to create the SQLite schema manually with the `sqlite3` command-line tool.
