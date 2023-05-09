using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Service.DTOs;
using Service.Interfaces;
using Service.Pagination;

namespace TimesheetAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoriesService _categoryService;
        public CategoriesController(ICategoriesService categoriesService)
        {
            _categoryService = categoriesService;
        }
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] QueryParameters parameters)
        {
            var categories = await _categoryService.GetCategoriesAsync(parameters);
            var metadata = new
            {
                categories.TotalCount,
                categories.PageSize,
                categories.CurrentPage,
                categories.TotalPages,
                categories.HasNext,
                categories.HasPrevious
            };
            Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(metadata));
            return Ok(categories);
        }
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CategoryDTO categoryDTO)
        {
            await _categoryService.CreateCategoryAsync(categoryDTO);
            return Ok();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _categoryService.DeleteCategoryAsync(id);
            return Ok();
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var category = await _categoryService.GetCategoryByIdAsync(id);
            return Ok(category);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id,[FromBody] CategoryDTO categoryDTO)
        {
            await _categoryService.UpdateCategoryAsync(id,categoryDTO);
            return Ok();
        }

    }
}
