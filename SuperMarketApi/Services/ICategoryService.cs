using System.Collections.Generic;
using System.Threading.Tasks;
using Supermarket.API.Models;

namespace Supermarket.API.Services
{
  public interface ICategoryService
  {
    Task<Category> GetById(int id);
    Task<IEnumerable<Category>> FindAll();
    Task<Category> Create(Category category);
    Task<Category> Update(Category category);
  }
}