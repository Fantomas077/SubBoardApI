using SubBoard.Application.Dtos.Dashboard;
using SubBoard.Application.Dtos.Subscription;
using System;
using System.Collections.Generic;
using System.Text;

namespace SubBoard.Application.Services
{
    public interface IDashboardService
    {
        Task <decimal> TotalMontly();
        Task <decimal> TotalYearly();
        Task<int> ActiveSubscriptions();
        Task<int> InactiveSubscriptions();
        Task<List<CategoryTotalDto>> TotalByCategory();
        Task<DashboardDto> GetDashboardAsync();
        Task<List<MonthlySpendingDto>> MonthlySpending();

    }
}
