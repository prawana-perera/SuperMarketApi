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
      var categories = await _catergoryService.ListAsync();
      return Ok(_mapper.Map<IEnumerable<Category>, IEnumerable<CategoryDTO>>(categories));
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<CategoryDTO>> GetById(int id)
    {
      var category = await _catergoryService.GetAsync(id);

      if (category == null)
      {
        return NotFound();
      }

      return Ok(_mapper.Map<Category, CategoryDTO>(category));
    }

    [HttpPost]
    public async Task<ActionResult<CategoryDTO>> Create([FromBody] CategoryDTO categoryDTO)
    {
      if (!ModelState.IsValid)
      {
        return BadRequest(ModelState.GetErrorMessages());
      }

      var category = _mapper.Map<CategoryDTO, Category>(categoryDTO);
      category = await _catergoryService.SaveAsync(category);

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

      // TODO not working WIP
      var category = await _catergoryService.GetAsync(id);

      if (category == null)
      {
        return NotFound();
      }

      if (!ModelState.IsValid)
      {
        return BadRequest(ModelState.GetErrorMessages());
      }

      category = _mapper.Map<CategoryDTO, Category>(categoryDTO);
      await _catergoryService.UpdateAsync(category);

      return Ok(_mapper.Map<Category, CategoryDTO>(category));
    }
  }
}