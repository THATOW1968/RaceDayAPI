# RaceDay API

RaceDay is a RESTful API built with ASP.NET Core Web API and Entity Framework Core.  
It is designed for the South African road running, walking, and cycling community.  
Organisers can manage events, categories, enrolments, and results, while Participants can register, enrol, and view their performance history.

## Project Setup

### Requirements:
- Visual Studio 2022 (or later)
- .NET 6 or .NET 7 SDK
- SQL Server installed locally or accessible remotely

### Steps
1. Clone or download this repository.
2. Open the solution in Visual Studio.
3. Install required NuGet packages:
   - `Microsoft.EntityFrameworkCore.SqlServer`
   - `Microsoft.EntityFrameworkCore.Tools`
4. Configure the database connection string in `appsettings.json`.

Example:
json
"ConnectionStrings": {
  "DefaultConnection": "Server=localhost;Database=RaceDayDB;Trusted_Connection=True;"
}
