using SubBoard.Application.Dtos.Subscription;
using System;
using System.Collections.Generic;
using System.Text;

namespace SubBoard.Application.Services
{
    public interface ISubscriptionService
    {
        Task AddAsync(CreateSubscriptionDto dto);
        Task UpdateAsync(UpdateSubscriptionDto dto);
        Task DeleteAsync(int id);
        Task<IEnumerable<SubscriptionDto>> GetAllAsync();
        Task<SubscriptionDto?> GetById(int id);
    }
}
