using System.ComponentModel.DataAnnotations;

namespace Supermarket.API.Models
{
  public class CategoryDTO
  {
    public int Id { get; set; }

    [Required]
    public string Name { get; set; }
  }
}