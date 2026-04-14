using Mapster;
using SubBoard.Application.Dtos.Subscription;
using SubBoard.Application.Repositories.IRepositories;
using SubBoard.Application.Services;
using SubBoard.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SubBoard.Infrastructure.Services
{
    public class SubscriptionService : ISubscriptionService
    {
        public readonly ISubscriptionRepository _rep;
        public SubscriptionService(ISubscriptionRepository rep)
        {
            _rep = rep;
        }

        public async Task AddAsync(CreateSubscriptionDto dto)
        {
            var subscription = dto.Adapt<Subscription>();
            await _rep.AddAsync(subscription);

        }

        public async Task DeleteAsync(int id)
        {
            var existing = await _rep.GetByIdAsync(id);
            if(existing==null)
            {
                throw new Exception("Not found");
            }
            await _rep.DeleteAsync(id);
        }

        public async Task<IEnumerable<SubscriptionDto>> GetAllAsync()
        {
            var subscription = await _rep.GetAllAsync();
            return  subscription.Adapt<IEnumerable<SubscriptionDto>>();
          
        }

        public async Task<SubscriptionDto?> GetById(int id)
        {
            var subscription = await _rep.GetByIdAsync(id);
            if(subscription==null)
            {
                return null;
            }
            return  subscription.Adapt<SubscriptionDto>();
        }

        public async Task UpdateAsync(UpdateSubscriptionDto dto)
        {
            var subscription = await _rep.GetByIdAsync(dto.Id);
            if (subscription == null)
            {
                throw new Exception("Not Found");
            }
            dto.Adapt(subscription);
            await _rep.UpdateAsync(subscription);
        }
    }
}
