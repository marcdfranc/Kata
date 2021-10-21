using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domain
{
    public class Basket
    {
        public Guid Id { get; set; }

        [Required]
        public string Description { get; set; }

        public bool IsOpen { get; set; } = true;

        // public ICollection<BasketItem> Products { get; set; }
    }
}
