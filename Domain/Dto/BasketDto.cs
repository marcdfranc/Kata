using Domain.Profiles;
using System;
using System.Collections.Generic;

namespace Domain.Dto
{
    public class BasketDto
    {
        public Guid Id { get; set; }

        public string Description { get; set; }

        public bool IsOpen { get; set; } = true;

        public ICollection<ProductProfile> Products { get; set; }


    }
}
