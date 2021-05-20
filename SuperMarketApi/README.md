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

Test using GET `https://localhost:5001/api/categories`

TODO:
 - Handling exceptions in a nice way/globally so we can return status code and response
   - https://blog.jonblankenship.com/2020/04/12/global-exception-handling-in-aspnet-core-api/
 - Unit Testing
 - TBA

 # Docker
 Can run the app in docker:
 ```bash
dotnet publish -c Release
docker build -t supermarket-api .
docker run -p 5001:80 supermarket-api
 ```

## References
- https://medium.com/free-code-camp/an-awesome-guide-on-how-to-build-restful-apis-with-asp-net-core-87b818123e28
- https://blog.jonblankenship.com/2020/04/12/global-exception-handling-in-aspnet-core-api/
