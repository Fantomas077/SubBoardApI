using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SubBoard.Domain.Entities;
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
        [HttpGet]
        public async Task<IActionResult> GetAllCategory()
        {
            var categories = await _db.Category.ToListAsync();
            return Ok(categories);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var obj = await _db.Category.FirstOrDefaultAsync(r => r.Id == id);
            if (obj == null)
            {
                return NotFound();
            }
            return Ok(obj);
        }
        [HttpPost]
        public async Task<IActionResult> AddCategory(Category category)
        {
            await _db.Category.AddAsync(category);
            await _db.SaveChangesAsync();

            return Ok(category);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateCategory(Category category)
        {
            var existing = await _db.Category.FirstOrDefaultAsync(r => r.Id == category.Id);

            if (existing == null)
            {
                return NotFound();
            }

            existing.Name = category.Name;
            existing.Icon = category.Icon;

            await _db.SaveChangesAsync();

            return Ok(existing);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            var existing = await _db.Category.FirstOrDefaultAsync(r => r.Id == id);

            if (existing == null)
            {
                return NotFound();
            }

            _db.Category.Remove(existing);
            await _db.SaveChangesAsync();

            return Ok(existing);
        }


    }
}
