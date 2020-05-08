using System.Collections.Generic;
using System.Threading.Tasks;
using Supermarket.API.Models;

namespace Supermarket.API.Services
{
  public interface ICategoryService
  {
    Task<Category> GetAsync(int id);
    Task<IEnumerable<Category>> ListAsync();
    Task<Category> SaveAsync(Category category);
    Task<Category> UpdateAsync(Category category);
  }
}