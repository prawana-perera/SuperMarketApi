# Description
A sample repo containing my learning with .Net, C# and ASP.Net.

Some topics covered:
- [x] Setting up a .Net project/solution
- [x] Create a Web Api (REST)
  - [ ] Error handling and API response
  - [ ] App configuration
- [ ] Persistence using Entity Framework (EF)
- [x] Unit Testing
- [ ] Integration Testing
- [ ] Docker
- [ ] CI/CD
  - [ ] GitHub Actions
  - [ ] Azure Devops
- Upgrade to .Net Core V5
- [ ] TBA more topics...

## .Net Commands
### Creating a solution
```bash
# Create a new solution project
dotnet new sln -o SuperMarketApi
cd SuperMarketApi

# Create a new web api project
dotnet new webapi -o SuperMarketApi

# Add the web api project to the solution
dotnet sln add ./SuperMarketApi/SuperMarketApi.csproj

# Add a new test project using xunit
dotnet new xunit -o SuperMarketApi.Tests

# Add the the api project dependency to the test project
dotnet add ./SuperMarketApi.Tests/SuperMarketApi.Tests.csproj reference ./SuperMarketApi/SuperMarketApi.csproj

# Add the test project to the solution
dotnet sln add ./SuperMarketApi.Tests/SuperMarketApi.Tests.csproj
```

### Running Tests
```bash
dotnet test  SuperMarketApi.Tests/SuperMarketApi.Tests.csproj
dotnet test  SuperMarketApi.IntegrationTests/SuperMarketApi.IntegrationTests.csproj
```

### Others
```bash
# Restore (aka install) required packages
dotnet restore

# Generate a new API project
dotnet new webapi

# Adding packages  (e.g. npm install xxx --save)
dotnet add package Microsoft.EntityFrameworkCore.SqlServer
dotnet add package Microsoft.EntityFrameworkCore.InMemory
dotnet add package AutoMapper
dotnet add package AutoMapper.Extensions.Microsoft.DependencyInjection

# Create a migration file
dotnet ef migrations add InitialCreate

# Run any pending migrations
dotnet ef database update

# Run
dotnet run

# Run watch for changes
dotnet watch run
```

## References
- https://medium.com/free-code-camp/an-awesome-guide-on-how-to-build-restful-apis-with-asp-net-core-87b818123e28
- https://blog.jonblankenship.com/2020/04/12/global-exception-handling-in-aspnet-core-api/

### Testing
- https://wrightfully.com/assert-framework-comparison#equality
