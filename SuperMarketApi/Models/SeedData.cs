using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Supermarket.API.Persistence.Contexts;
using System.Linq;
using Microsoft.Extensions.Logging;

namespace Supermarket.API.Models
{
  public class SeedData
  {

    public static void Initialize(IServiceProvider serviceProvider)
    {
      using (var context = new AppDbContext(serviceProvider.GetRequiredService<DbContextOptions<AppDbContext>>()))
      {
        if (!context.Categories.Any())
        {
          var logger = serviceProvider.GetRequiredService<ILogger<SeedData>>();
          logger.LogInformation("Seeding dev database with mock data...");

          context.Categories.AddRange(
            new Category
            {
              Name = "Home Office"
            },
            new Category
            {
              Name = "Cleaning"
            }
          );

          context.SaveChanges();
        }
      }
    }
  }
}