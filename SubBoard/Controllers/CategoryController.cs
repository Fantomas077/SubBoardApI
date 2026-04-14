using Microsoft.AspNetCore.Mvc;
using SubBoard.Application.Dtos.Category;
using SubBoard.Application.Services;

namespace SubBoard.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _service;

        public CategoryController(ICategoryService service)
        {
            _service = service;
        }

        // GET ALL
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var categories = await _service.GetAllAsync();
            return Ok(categories);
        }

        // GET BY ID
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var category = await _service.GetByIdAsync(id);
            return Ok(category);
        }

        // POST
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateCategoryDto dto)
        {
            await _service.AddAsync(dto);
            return Ok(new { message = "Category created successfully" });
        }

        // PUT
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateCategoryDto dto)
        {
            await _service.UpdateAsync(dto);
            return Ok(new { message = "Category updated successfully" });
        }

        // DELETE
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.DeleteAsync(id);
            return Ok(new { message = "Category deleted successfully" });
        }
    }
}
