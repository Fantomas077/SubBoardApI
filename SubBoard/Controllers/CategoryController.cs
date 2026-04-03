using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SubBoard.Api.Dtos.Category;
using SubBoard.Infrastructure.Data;

namespace SubBoard.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly AppDbContext _db;

        public CategoryController(AppDbContext db)
        {
            _db = db;
        }

        // GET ALL
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var categories = await _db.Category
                .Select(c => new CategoryDto
                {
                    Id = c.Id,
                    Name = c.Name,
                    Icon = c.Icon
                })
                .ToListAsync();

            return Ok(categories);
        }

        // GET BY ID
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var category = await _db.Category.FindAsync(id);
            if(category==null)
            {
                return NotFound();
            }
            CategoryDto categoryDto = new CategoryDto()
            {
                Id=category.Id,
                Name = category.Name,
                Icon= category.Icon

            };
            return Ok(categoryDto);
        }

        // POST
        [HttpPost]
        public async Task<IActionResult> Add(CategoryDto dto)
        {
            var category = new SubBoard.Domain.Entities.Category
            {
                Name = dto.Name,
                Icon = dto.Icon
            };

            await _db.Category.AddAsync(category);
            await _db.SaveChangesAsync();

            dto.Id = category.Id;

            return Ok(dto);
        }

        // PUT
        [HttpPut]
        public async Task<IActionResult> Update(CategoryDto dto)
        {
            var existing = await _db.Category.FirstOrDefaultAsync(c => c.Id == dto.Id);
            if (existing == null)
                return NotFound();

            existing.Name = dto.Name;
            existing.Icon = dto.Icon;

            await _db.SaveChangesAsync();

            return Ok(dto);
        }

        // DELETE
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var existing = await _db.Category.FirstOrDefaultAsync(c => c.Id == id);
            if (existing == null)
                return NotFound();

            _db.Category.Remove(existing);
            await _db.SaveChangesAsync();

            return Ok();
        }
    }
}
