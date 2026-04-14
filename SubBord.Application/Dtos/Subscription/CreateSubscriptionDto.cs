using SubBoard.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SubBoard.Application.Dtos.Subscription
{
    public class CreateSubscriptionDto
    {
        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [Range(0.01, 9999)]
        public decimal Price { get; set; }

        [Required]
        public Frequency Frequency { get; set; }

        [Required]
        public DateTime RenewDate { get; set; } = DateTime.Now;

        [Required]
        public Status Status { get; set; }

        [Required]
        public int CategoryId { get; set; }
    }


}
