using System;
using System.Collections.Generic;


namespace Domain
{
    public class Product
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        // this would be a FK, but to gain time I've put statics values
        public string type { get; set; }
        public ICollection<BasketItem> Baskets { get; set; }
    }
}
