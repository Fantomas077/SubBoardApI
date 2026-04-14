using System;
using System.Collections.Generic;

namespace SubBoard.Application.Dtos.Dashboard
{
    public class DashboardDto
    {
        // Total des dépenses du mois en cours
        public decimal TotalMonthly { get; set; }

        // Total des dépenses annuelles
        public decimal TotalYearly { get; set; }

        // Nombre d'abonnements actifs
        public int ActiveSubscriptions { get; set; }

        // Nombre d'abonnements inactifs
        public int InactiveSubscriptions { get; set; }

        public List<CategoryTotalDto> TotalByCategory { get; set; }
        public List<MonthlySpendingDto> MonthlySpending { get; set; }


    }


}
