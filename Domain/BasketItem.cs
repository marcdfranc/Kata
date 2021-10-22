using System;

namespace Domain
{
    public class BasketItem
    {
        public Guid BasketId { get; set; }
        public Basket Basket { get; set; }
        public Guid ProductId { get; set; }
        public Product Product { get; set; }
        public int Quantity { get; set; }
        public decimal Total { get; set; }
    }
}
