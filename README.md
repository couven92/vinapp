Vinapp
=========================

## Dependencies
* [npm](https://nodejs.org/en/)
* npm install //installs all npm dependencies from package.json

Watch sass: execute `npm run build-css`

## Asp.Net Core
1. Load Vinapp.sln in Visual Studio. It is located in `/api/Vinapp/`
2. Restore packages by running `dotnet restore` from pmc, and build the solution.
3. Run the project with  `F5`


## Entity Framework
* Start Powershell and run `dotnet ef database update`. (It want work from VS PMC). For more EF commands, see: [official page](https://github.com/aspnet/EntityFramework.Docs/blob/master/entity-framework/core/miscellaneous/cli/dotnet.md)
* To verify the database was created, open `SQL Server Object Explorer` window in VS and expand `(localdb)\MSSQLLocalDB`. There should be a database `Vinapp.Context`
