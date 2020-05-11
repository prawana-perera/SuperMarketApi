using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Supermarket.API.Exceptions;
using Supermarket.API.Models;
using Supermarket.API.Persistence.Contexts;
using System.Linq;

namespace Supermarket.API.Services
{
  public class CategoryService : ICategoryService
  {
    protected readonly AppDbContext _context;

    public CategoryService(AppDbContext context)
    {
      _context = context;
    }

    public async Task<Category> GetById(int id)
    {
      var category = await _context.Categories.FindAsync(id);

      if (category == null)
        throw new NotFoundException($"Category with id = {id} not found.");

      return category;
    }

    public async Task<IEnumerable<Category>> FindAll()
    {
      return await _context.Categories.ToListAsync();
    }

    public async Task<Category> Create(Category category)
    {
      var categoriesCount = (from cat in _context.Categories
                        where cat.Name.Equals(category.Name)
                        select cat).Count();

      if(categoriesCount > 0) 
        throw new DuplicateException($"Category with name = {category.Name} already exist");

      _context.Categories.Add(category);
      await _context.SaveChangesAsync();

      return category;
    }

    public async Task<Category> Update(Category category)
    {
      var categoryToUpdate = await _context.Categories.FindAsync(category.Id);

      // Category must exist
      if (categoryToUpdate == null)
        throw new NotFoundException($"Category with id = {category.Id} not found.");

      // Can't update it to another existing category name
      var existngCategory = (from cat in _context.Categories
                        where cat.Name.Equals(category.Name)
                        select cat).FirstOrDefault();

      if(existngCategory != null && existngCategory.Id != category.Id) {
        throw new DuplicateException($"Another category with name = {category.Name} already exist");
      }

      // Can update, so copy updatable properties
      categoryToUpdate.Name = category.Name;

      _context.Categories.Update(categoryToUpdate);
      await _context.SaveChangesAsync();

      return category;
    }
  }
}