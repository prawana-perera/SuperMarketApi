## Creating a solution
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

## Running Tests
```bash
dotnet test  SuperMarketApi.Tests/SuperMarketApi.Tests.csproj
```

## References

### Testing
- https://wrightfully.com/assert-framework-comparison#equality