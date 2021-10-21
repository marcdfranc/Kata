using Applicattion.Core;
using AutoMapper;
using AutoMapper.QueryableExtensions;
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
    public class Detail
    {
        public class Query : IRequest<Result<BasketDto>>
        {

        }

        public class Handler : IRequestHandler<Query, Result<BasketDto>>
        {
            private readonly DataContext _context;
            private readonly IMapper _mapper;

            public Handler(DataContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<Result<BasketDto>> Handle(Query request, CancellationToken cancellationToken)
            {
                var basket = await _context.Baskets
                    .ProjectTo<BasketDto>(_mapper.ConfigurationProvider)
                    .FirstOrDefaultAsync(b => b.IsOpen);

                return Result<BasketDto>.Success(basket);
            }
        }
    }
}
