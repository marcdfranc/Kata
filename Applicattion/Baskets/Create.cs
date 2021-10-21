using Applicattion.Core;
using Domain;
using MediatR;
using Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Applicattion.Baskets
{
    public class Create
    {
        public class Command : IRequest<Result<Unit>>
        {
            public Basket Basket { get; set; }
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
                _context.Add(request.Basket);

                if (await _context.SaveChangesAsync() > 0)
                {
                    var result = Result<Unit>.Success(Unit.Value);
                    return result;
                }
                else
                {
                    return Result<Unit>.Failure("Failed to create Basket.");
                }
            }
        }

    }
}
