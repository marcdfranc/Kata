using System;

namespace Domain.Profiles
{
    public class ProductProfile
    {
        public Guid BasketId { get; set; }
        public string Basket { get; set; }
        public Guid ProductId { get; set; }
        public string Product { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public string Promotion { get; set; }
        public decimal Total { get; set; }
    }
}
