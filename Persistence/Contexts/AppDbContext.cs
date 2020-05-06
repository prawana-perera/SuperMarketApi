using Microsoft.EntityFrameworkCore;
using Supermarket.API.Models;

namespace Supermarket.API.Persistence.Contexts
{
  public class AppDbContext : DbContext
  {
    public DbSet<Category> Categories { get; set; }
    public DbSet<Product> Products { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }
  }
}