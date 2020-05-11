using System.Collections.Generic;
using System.Threading.Tasks;
using Supermarket.API.Models;
using Supermarket.API.Persistence.Contexts;
using Supermarket.API.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Supermarket.API.Repositories
{
  public class CategoryRepository : BaseRepository, ICategoryRepository
    {
        public CategoryRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Category>> FindAll()
        {
            return await _context.Categories.ToListAsync();
        }
  }
}