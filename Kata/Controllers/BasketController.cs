using Applicattion.Baskets;
using Domain;
using Domain.Dto;
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
        [HttpGet]
        public async Task<IActionResult> Detail()
        {
            return HandleResult(await Mediator.Send(new Detail.Query()));
        }

        [HttpPost]
        public async Task<IActionResult> Create(Basket basket)
        {
            return HandleResult(await Mediator.Send(new Create.Command { Basket = basket }));
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddItem(BasketItemDto basket)
        {
            return HandleResult(await Mediator.Send(new AddItem.Command { basketItem = basket }));
        }
    }
}
