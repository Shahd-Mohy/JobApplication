# JobApplication API

.NET 10 Web API, clean architecture (Domain / Application / Infrastructure / API).
ASP.NET Core Identity + JWT, two roles (Candidate, Recruiter), Swagger UI.

## Requirements
- Visual Studio 2026 (18.x) or the .NET 10 SDK
- SQL Server on `.` (default instance). Change `ConnectionStrings:DefaultConnection` in appsettings.json if yours differs.

## Run it (first time)
1. Open `JobApplication.API.slnx` and wait for the NuGet restore to finish.
2. If you already have an old `JobApplication` database, delete it (SSMS -> right-click -> Delete).
3. Tools -> NuGet Package Manager -> Package Manager Console, then run:

       Add-Migration InitialCreate -Project JobApplication.Infrastructure -StartupProject JobApplication.API
       Update-Database -Project JobApplication.Infrastructure -StartupProject JobApplication.API

4. Press the green **https** button. Swagger opens at https://localhost:7237/swagger
5. Register -> Login -> copy `token` -> Authorize (paste the token only) -> call the endpoints.
   Or open `JobApplication.API/JobApplication.API.http` in Visual Studio and run the requests top to bottom.

## Notes
- Passwords need 8+ characters with upper, lower, a digit and a symbol (e.g. `Test@1234`).
- 5 wrong passwords lock the account for 5 minutes.
- Keep `Swashbuckle.AspNetCore` at 9.0.6. Version 10+ uses Microsoft.OpenApi 2.x and breaks the Swagger code in Program.cs.
- `appsettings.Development.json` contains a DEV-ONLY JWT secret so the project runs immediately.
  Before you publish the repo, move it to user-secrets (right-click the API project -> Manage User Secrets)
  and use a different key in production.
- Uploaded CVs are saved under `JobApplication.API/Uploads/cvs` (git-ignored, not served as static files).
