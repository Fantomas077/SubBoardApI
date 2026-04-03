using Microsoft.EntityFrameworkCore;
using SubBoard.Application.Repositories.IRepositories;
using SubBoard.Domain.Entities;
using SubBoard.Infrastructure.Data;

namespace SubBoard.Infrastructure.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly AppDbContext _db;

        public CategoryRepository(AppDbContext db)
        {
            _db = db;
        }

        public async Task<IEnumerable<Category>> GetAllAsync()
        {
            return await _db.Category.ToListAsync();
        }

        public async Task<Category?> GetByIdAsync(int id)
        {
            return await _db.Category.FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task AddAsync(Category category)
        {
            await _db.Category.AddAsync(category);
            await _db.SaveChangesAsync();
        }

        public async Task UpdateAsync(Category category)
        {
            _db.Category.Update(category);
            await _db.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var existing = await _db.Category.FirstOrDefaultAsync(c => c.Id == id);
            if (existing != null)
            {
                _db.Category.Remove(existing);
                await _db.SaveChangesAsync();
            }
        }
    }
}
