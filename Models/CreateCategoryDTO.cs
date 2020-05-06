using System.ComponentModel.DataAnnotations;

namespace Supermarket.API.Models
{
  public class CreateCategoryDTO
  {
    [Required]
    [MaxLength(30)]
    public string Name { get; set; }
  }
}