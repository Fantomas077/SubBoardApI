using SubBoard.Application.Dtos.Dashboard;
using SubBoard.Application.Dtos.Subscription;
using SubBoard.Application.Repositories.IRepositories;
using SubBoard.Application.Services;
using SubBoard.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace SubBoard.Infrastructure.Services
{
    public class DashboardService : IDashboardService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly ISubscriptionRepository _subscriptionRepository;
        public DashboardService(ICategoryRepository categoryRepository, ISubscriptionRepository subscriptionRepository)
        {
            _categoryRepository = categoryRepository;
            _subscriptionRepository = subscriptionRepository;
        }

        public async Task<int> ActiveSubscriptions()
        {
            var sub = await _subscriptionRepository.GetAllAsync();
            var ActivSub = sub.Where(r => r.Status == Status.Active).Count();
            return ActivSub;
        }

        public async Task<int> InactiveSubscriptions()
        {
            var sub = await _subscriptionRepository.GetAllAsync();
            var ActivSub = sub.Where(r => r.Status == Status.Paused || r.Status == Status.Canceled).Count();
            return ActivSub;
        }


        public async Task<decimal> TotalMontly()
        {

            var sub = await _subscriptionRepository.GetAllAsync();
            var Total = sub.Sum(r => r.Price);
            return Total;
        }

        public async Task<decimal> TotalYearly()
        {
            var sub = await _subscriptionRepository.GetAllAsync();
            var GetYear = DateTime.Today.Year;
            var GetYearSub = sub.Where(r => r.RenewDate.Year == GetYear);
            var Total = GetYearSub.Sum(r => r.Price);

            return Total;
        }

        public async Task<List<CategoryTotalDto>> TotalByCategory()
        {
            var sub = await _subscriptionRepository.GetAllAsync();

            var result = sub
                .GroupBy(r => r.Category)
                .Select(g => new CategoryTotalDto
                {
                    Category = g.Key.Name,
                    Total = g.Sum(x => x.Price)
                })
                .ToList();

            return result;
        }

        public async Task<List<MonthlySpendingDto>> MonthlySpending()
        {
            var sub = await _subscriptionRepository.GetAllAsync();

            var result = sub
                .GroupBy(r => r.RenewDate.Month)
                .Select(g => new MonthlySpendingDto
                {
                    Month = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(g.Key),
                    Total = g.Sum(x => x.Price)
                })
                .ToList();

            return result;
        }
        public async Task<DashboardDto> GetDashboardAsync()
        {
            return new DashboardDto
            {
                TotalMonthly = await TotalMontly(),
                TotalYearly = await TotalYearly(),
                ActiveSubscriptions = await ActiveSubscriptions(),
                InactiveSubscriptions = await InactiveSubscriptions(),
                TotalByCategory = await TotalByCategory(),
                MonthlySpending = await MonthlySpending()
            };
        }

    }
}
