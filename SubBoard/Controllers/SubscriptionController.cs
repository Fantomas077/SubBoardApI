using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SubBoard.Api.Dtos;
using SubBoard.Domain.Entities;
using SubBoard.Infrastructure.Data;

namespace SubBoard.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubscriptionController : ControllerBase
    {
        private readonly AppDbContext _db;
        public SubscriptionController(AppDbContext db)
        {
            _db = db;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var subs = await _db.Subscriptions
                .Include(c => c.Category)
                .Select(s => new SubscriptionDto
                {
                    Id = s.Id,
                    Name = s.Name,
                    Price = s.Price,
                    Frequency = s.Frequency,
                    RenewDate = s.RenewDate,
                    Status = s.Status,
                    CategoryId = s.CategoryId,
                    CategoryName = s.Category.Name
                })
                .ToListAsync();

            return Ok(subs);
        }

        [HttpPost]
        public async Task<IActionResult> AddSubscription(Subscription subscription)
        {
            var category = await _db.Category.FirstOrDefaultAsync(r => r.Id == subscription.CategoryId);
            if (category == null)
            {
                return BadRequest("Category not valid");
            }

            await _db.Subscriptions.AddAsync(subscription);
            await _db.SaveChangesAsync();

            // Convertir en DTO
            var dto = new SubscriptionDto
            {
                Id = subscription.Id,
                Name = subscription.Name,
                Price = subscription.Price,
                Frequency = subscription.Frequency,
                RenewDate = subscription.RenewDate,
                Status = subscription.Status,
                CategoryId = subscription.CategoryId,
                CategoryName = category.Name
            };

            return Ok(dto);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var s = await _db.Subscriptions
                .Include(c => c.Category)
                .Where(x => x.Id == id)
                .Select(s => new SubscriptionDto
                {
                    Id = s.Id,
                    Name = s.Name,
                    Price = s.Price,
                    Frequency = s.Frequency,
                    RenewDate = s.RenewDate,
                    Status = s.Status,
                    CategoryId = s.CategoryId,
                    CategoryName = s.Category.Name
                })
                .FirstOrDefaultAsync();

            if (s == null)
                return NotFound();

            return Ok(s);
        }

        [HttpPut]
        public async Task<IActionResult> Update(Subscription subscription)
        {
            var existing = await _db.Subscriptions.FirstOrDefaultAsync(r => r.Id == subscription.Id);
            if (existing == null)
            {
                return NotFound();
            }

            existing.Name = subscription.Name;
            existing.Price = subscription.Price;
            existing.Status = subscription.Status;
            existing.Frequency = subscription.Frequency;
            existing.RenewDate = subscription.RenewDate;
            existing.CategoryId = subscription.CategoryId;

            await _db.SaveChangesAsync();

            var category = await _db.Category.FirstOrDefaultAsync(c => c.Id == existing.CategoryId);

            var dto = new SubscriptionDto
            {
                Id = existing.Id,
                Name = existing.Name,
                Price = existing.Price,
                Frequency = existing.Frequency,
                RenewDate = existing.RenewDate,
                Status = existing.Status,
                CategoryId = existing.CategoryId,
                CategoryName = category?.Name
            };

            return Ok(dto);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var existing = await _db.Subscriptions.FirstOrDefaultAsync(r => r.Id == id);
            if (existing == null)
            {
                return NotFound();
            }
            _db.Subscriptions.Remove(existing);
            await _db.SaveChangesAsync();
            return Ok();
        }
    }
}
