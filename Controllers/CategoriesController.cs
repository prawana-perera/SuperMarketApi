using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Supermarket.API.Extensions;
using Supermarket.API.Models;
using Supermarket.API.Services;

namespace Supermarket.API.Controllers
{
  [ApiController]
  [Route("/api/[controller]")]
  public class CategoriesController : ControllerBase
  {
    private readonly ICategoryService _catergoryService;
    private readonly IMapper _mapper;

    public CategoriesController(ICategoryService categoryService, IMapper mapper)
    {
      _catergoryService = categoryService;
      _mapper = mapper;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<CategoryDTO>>> GetAll()
    {
      var categories = await _catergoryService.FindAll();
      return Ok(_mapper.Map<IEnumerable<Category>, IEnumerable<CategoryDTO>>(categories));
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<CategoryDTO>> GetById(int id)
    {
      var category = await _catergoryService.GetById(id);
      return Ok(_mapper.Map<Category, CategoryDTO>(category));
    }

    [HttpPost]
    public async Task<ActionResult<CategoryDTO>> Create(CategoryDTO categoryDTO)
    {
      // This is automatically handled by added [ApiController] to this controller, also [FromBody is also handled by this attribute]
      // if (!ModelState.IsValid)
      // {
      //   return BadRequest(ModelState.GetErrorMessages());
      // }

      var category = _mapper.Map<CategoryDTO, Category>(categoryDTO);
      category = await _catergoryService.Create(category);

      return CreatedAtAction(
                nameof(GetById),
                new { id = category.Id },
                _mapper.Map<Category, CategoryDTO>(category));
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<CategoryDTO>> Update(int id, [FromBody] CategoryDTO categoryDTO)
    {
      if(categoryDTO.Id != id) {
        return BadRequest();
      }
    
      var category = _mapper.Map<CategoryDTO, Category>(categoryDTO);
      category = await _catergoryService.Update(category);

      return Ok(_mapper.Map<Category, CategoryDTO>(category));
    }
  }
}