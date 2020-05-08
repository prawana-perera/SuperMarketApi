using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Supermarket.API.Models;
using Supermarket.API.Persistence.Contexts;
using Supermarket.API.Repositories;

namespace Supermarket.API.Services
{
  public class CategoryService : ICategoryService
  {
    protected readonly AppDbContext _context;

    public CategoryService(AppDbContext context) {
      _context = context;
    }

    public async Task<Category> GetAsync(int id)
    {
      return await _context.Categories.FindAsync(id);
    }

    public async Task<IEnumerable<Category>> ListAsync()
    {
      return await _context.Categories.ToListAsync();
    }

    public async Task<Category> SaveAsync(Category category)
    {
      _context.Categories.Add(category);

      await _context.SaveChangesAsync();

      return category;
    }

    public async Task<Category> UpdateAsync(Category category)
    {
      _context.Categories.Update(category);
      await _context.SaveChangesAsync();

      return category;
    }
  }
}