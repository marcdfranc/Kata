using Applicattion.Baskets;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kata.Controllers
{

    public class BasketController : BaseApiController
    {
        [HttpPost]
        public async Task<IActionResult> Create(Basket basket)
        {
            return HandleResult(await Mediator.Send(new Create.Command { Basket = basket }));
        }
    }
}
