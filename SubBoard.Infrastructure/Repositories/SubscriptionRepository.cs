using Microsoft.EntityFrameworkCore;
using SubBoard.Application.Repositories.IRepositories;
using SubBoard.Domain.Entities;
using SubBoard.Infrastructure.Data;

namespace SubBoard.Infrastructure.Repositories
{
    public class SubscriptionRepository : ISubscriptionRepository
    {
        private readonly AppDbContext _db;

        public SubscriptionRepository(AppDbContext db)
        {
            _db = db;
        }

        public async Task AddAsync(Subscription subscription)
        {
            await _db.Subscriptions.AddAsync(subscription);
            await _db.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var existing = await _db.Subscriptions
                .FirstOrDefaultAsync(s => s.Id == id);

            if (existing != null)
            {
                _db.Subscriptions.Remove(existing);
                await _db.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Subscription>> GetAllAsync()
        {
            return await _db.Subscriptions
                .Include(s => s.Category)
                .ToListAsync();
        }

        public async Task<Subscription?> GetByIdAsync(int id)
        {
            return await _db.Subscriptions
                .Include(s => s.Category)
                .FirstOrDefaultAsync(s => s.Id == id);
        }

        public async Task UpdateAsync(Subscription subscription)
        {
            _db.Subscriptions.Update(subscription);
            await _db.SaveChangesAsync();
        }
    }
}
