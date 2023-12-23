using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Persistence;

namespace Application.Activities;
public class List
{
    public class Query : IRequest<List<Activity>> {}
    public class Hnadler : IRequestHandler<Query, List<Activity>>
    {
        private readonly DataContext _context;

        public Hnadler(DataContext context)
        {
           _context = context;
        }

        public async Task<List<Activity>> Handle(Query request, CancellationToken cancellationToken)
        {
            return await _context.Activities.ToListAsync();
        }
    }
}
