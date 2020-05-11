using System.Collections.Generic;

namespace Supermarket.API.Models
{
  public class Category
  {
    public int Id { get; set; }
    public string Name { get; set; }
    public IList<Product> Products { get; set; } = new List<Product>();

    // Contrived method for unit testing learning
    public bool IsGoodCategory()
    {
        return Name != null && Name != "Books";
    }
  }
}