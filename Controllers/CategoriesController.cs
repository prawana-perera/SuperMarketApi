using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Supermarket.API.Extensions;
using Supermarket.API.Models;
using Supermarket.API.Services;

namespace Supermarket.API.Controllers
{
  [Route("/api/[controller]")]
  public class CategoriesController : Controller
  {
    private readonly ICategoryService _catergoryService;
    private readonly IMapper _mapper;

    public CategoriesController(ICategoryService categoryService, IMapper mapper)
    {
      _catergoryService = categoryService;
      _mapper = mapper;
    }

    [HttpGet]
    public async Task<IEnumerable<CategoryDTO>> GetAllAsync()
    {
      var categories = await _catergoryService.ListAsync();
      return _mapper.Map<IEnumerable<Category>, IEnumerable<CategoryDTO>>(categories);
    }

    [HttpPost]
    public async Task<ActionResult<CategoryDTO>> PostAsync([FromBody] CreateCategoryDTO categoryDTO)
    {
      if(!ModelState.IsValid)
      {
        return BadRequest(ModelState.GetErrorMessages());
      }

      var category = _mapper.Map<CreateCategoryDTO, Category>(categoryDTO);
      category = await _catergoryService.SaveAsync(category);

      return _mapper.Map<Category, CategoryDTO>(category);
    }
  }
}