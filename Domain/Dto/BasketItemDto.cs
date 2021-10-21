using System;

namespace Domain.Dto
{
    public class BasketItemDto
    {
        public Guid ProductId { get; set; }
        public Guid BasketId { get; set; }
        public int Quantity { get; set; }
    }
}
