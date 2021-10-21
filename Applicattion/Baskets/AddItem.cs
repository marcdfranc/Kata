using Applicattion.Core;
using Domain;
using Domain.Dto;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Applicattion.Baskets
{
    public class AddItem
    {
        public class Command : IRequest<Result<Unit>>
        {
            public BasketItemDto basketItem { get; set; }
        }

        public class Handler : IRequestHandler<Command, Result<Unit>>
        {
            private readonly DataContext _context;

            public Handler(DataContext context)
            {
                this._context = context;
            }

       
            public async Task<Result<Unit>> Handle(Command request, CancellationToken cancellationToken)
            {
                var item = await _context.BasketItens
                    .Include(i => i.Product)
                    .SingleOrDefaultAsync(i => i.BasketId == request.basketItem.BasketId && i.ProductId == request.basketItem.ProductId);
                

                bool isNew = false; // check if insert or Update given item.

                if (item == null)
                {
                    isNew = true;

                    var product = await _context.Products.FirstOrDefaultAsync(p => p.Id == request.basketItem.ProductId);

                    var basket = await _context.Baskets.FirstOrDefaultAsync(b => b.Id == request.basketItem.BasketId);

                    item = new BasketItem()
                    {
                        Product = product,
                        Basket = basket,
                        Quantity = request.basketItem.Quantity
                    };
                }
                else
                {
                    item.Quantity += request.basketItem.Quantity;
                }

                item.Total = Calculator.Calcule(item.Quantity, item.Product.Price, item.Product.type);

                if (isNew)
                {
                    _context.Add<BasketItem>(item);
                }
                else
                {
                    _context.Update<BasketItem>(item);
                }

                var result = await _context.SaveChangesAsync() > 0;

                return result ? Result<Unit>.Success(Unit.Value) : Result<Unit>.Failure("Problem add item to basket.");
            }
        }
    }
}
