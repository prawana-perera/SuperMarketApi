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
dotnet run watch
```

Test using GET `https://localhost:5001/api/categories`