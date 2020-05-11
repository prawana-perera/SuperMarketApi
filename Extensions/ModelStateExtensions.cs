using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Supermarket.API.Models;

namespace Supermarket.API.Extensions
{
  public static class ModelStateExtensions
  {
    /*
     This extension on the ModelState is not necessary as adding [ApiController] on the controller adds validation translation
     automatically.
    */
    public static List<ErrorDTO> GetErrorMessages(this ModelStateDictionary dictionary)
    {
      return dictionary
        .Where(m => m.Value.ValidationState == ModelValidationState.Invalid)
                       .Select(m => new ErrorDTO
                       {
                         Field = m.Key,
                         Errors = m.Value.Errors.Select(e => e.ErrorMessage).ToList()
                       })
                       .ToList();
    }
  }
}