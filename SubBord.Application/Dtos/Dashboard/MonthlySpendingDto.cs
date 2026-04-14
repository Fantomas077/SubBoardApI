using System;
using System.Collections.Generic;
using System.Text;

namespace SubBoard.Application.Dtos.Dashboard
{
    public class MonthlySpendingDto
    {
        public string Month { get; set; }
        public decimal Total { get; set; }
    }
}
