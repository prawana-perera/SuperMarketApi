using System.Collections.Generic;
using System.Threading.Tasks;
using Supermarket.API.Models;

namespace Supermarket.API.Repositories
{
  public interface ICategoryRepository
  {
    Task<IEnumerable<Category>> FindAll();
  }
}