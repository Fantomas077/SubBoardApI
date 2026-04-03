using SubBoard.Domain.Entities;

namespace SubBoard.Application.Dtos
{
    public class SubscriptionDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public Frequency Frequency { get; set; }
        public DateTime RenewDate { get; set; }
        public Status Status { get; set; }
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }

    }
}
