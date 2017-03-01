Vinapp
=========================

## Installering av .net core + Visual studio
* Sjekk om du har DotNet installert, og evt hvilken versjon av CLI
* Run dotnet --version (displays Dot Net Core CLI version)
* Siste versjon av CLI er 1.0.0-preview2-1-003177
* DotNet Core 1.1 er siste versjon Dot Net runtime
* https://go.microsoft.com/fwlink/?LinkID=835014


## Frontend dependencies
* Download and install [npm](https://nodejs.org/en/)
* Run in cmd/terminal from the root of the project: `npm install` //installs all npm dependencies from package.json
* To watch changes in the sass file run: `npm run watch-css` (To only compile the sass once, run: `npm run build-css`)

## Asp.Net Core
1. Load Vinapp.sln in Visual Studio. It is located in `/api/Vinapp/`
2. Restore packages by running `dotnet restore` from pmc, and build the solution.
3. Run the project with  `F5`
4. The application can be found at localhost:9888/index.html
5. The API can be found at localhost:9888/swagger/index.html


## Entity Framework
* Start Powershell and run `dotnet ef database update`. (It want work from VS PMC). For more EF commands, see: [official page](https://github.com/aspnet/EntityFramework.Docs/blob/master/entity-framework/core/miscellaneous/cli/dotnet.md)
* To verify the database was created, open `SQL Server Object Explorer` window in VS and expand `(localdb)\MSSQLLocalDB`. There should be a database `Vinapp.Context`

##Vinapp idè og historie
![alt tag](https://cloud.githubusercontent.com/assets/1454269/23453078/3813df0e-fe67-11e6-89ce-09fd380932a3.png)
##Vinlotteriet i dag
* Manuell registrering
* Betaling basert på tillit
* Krever oppmøte på kontoret eller PA
* Feil i trekning
* Tar seg dårlig ut i et konsulentselskap
![alt tag](https://cloud.githubusercontent.com/assets/1454269/23453079/381673fe-fe67-11e6-930c-669c8c15aa17.jpg)

##Arkitektur
![alt tag](https://cloud.githubusercontent.com/assets/1454269/23453080/38168c54-fe67-11e6-948e-d44f123e3ada.png)
