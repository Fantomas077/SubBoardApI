using SubBoard.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SubBoard.Application.Dtos.Subscription
{
    public class UpdateSubscriptionDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public Frequency Frequency { get; set; }
        public DateTime RenewDate { get; set; }
        public Status Status { get; set; }
        public int CategoryId { get; set; }
    }

}
