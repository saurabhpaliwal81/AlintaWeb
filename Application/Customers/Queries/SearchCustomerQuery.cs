using Application.Common.Interfaces;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Customers.Queries
{
    public class SearchCustomerQuery : IRequest<IEnumerable<CustomerDto>>
    {
        public string name { get; set; }
    }

    public class SearchCustomerQueryHandler : IRequestHandler<SearchCustomerQuery, IEnumerable<CustomerDto>>
    {
        private readonly IApplicationDbContext _context;

        public SearchCustomerQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<CustomerDto>> Handle(SearchCustomerQuery request, CancellationToken cancellationToken)
        {
            if (string.IsNullOrEmpty(request.name))
            {
                return await Task.FromResult(_context.Customers
                .OrderBy(x => x.Id)
                .Select(x => new CustomerDto
                {
                    Id = x.Id,
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    DateOfBirth = x.DateOfBirth,
                }).ToList());
            }
            else
            {
                return await Task.FromResult(_context.Customers
                .Where(x => x.FirstName.Contains(request.name) || x.LastName.Contains(request.name))
                .OrderBy(x => x.Id)
                .Select(x => new CustomerDto
                {
                    Id = x.Id,
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    DateOfBirth = x.DateOfBirth,
                }).ToList());
            }
        }
    }
}