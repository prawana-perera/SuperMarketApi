using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using Supermarket.API.Persistence.Contexts;
using Supermarket.API.Repositories;
using Supermarket.API.Services;
using AutoMapper;
using Supermarket.API.Mapping;
using Supermarket.API.Middleware;

namespace SuperMarketApi
{
  public class Startup
  {
    public Startup(IConfiguration configuration)
    {
      Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    // This method gets called by the runtime. Use this method to add services to the container.
    public void ConfigureServices(IServiceCollection services)
    {
      services.AddControllers();

      // Register
      services.AddDbContext<AppDbContext>(options =>
      {
        options.UseInMemoryDatabase("SupermarketDb");
      });

      services.AddScoped<ICategoryRepository, CategoryRepository>();
      services.AddScoped<ICategoryService, CategoryService>();

      services.AddAutoMapper(typeof(ModelToDtoProfile));
      services.AddAutoMapper(typeof(DtoToModelProfile));
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
      }

      // Hook in the global error-handling middleware
      app.UseMiddleware(typeof(ErrorHandlingMiddleware));

      app.UseHttpsRedirection();

      app.UseRouting();

      app.UseAuthorization();

      app.UseEndpoints(endpoints =>
      {
        endpoints.MapControllers();
      });
    }
  }
}
