using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TritonExpress.API.Domain.Entities;
using TritonExpress.API.Persistence;

namespace TritonExpress.API.Service.Features.LocationFeatures.Query
{
    public class GetAllAllocationsQuery : IRequest<IEnumerable<Allocation>>
    {
        public class GetAllLocationsQueryHanndler : IRequestHandler<GetAllAllocationsQuery, IEnumerable<Allocation>>
        {
            private readonly IApplicationDbContext context;
            public GetAllLocationsQueryHanndler(IApplicationDbContext context)
            {
                this.context = context;
            }
            public async Task<IEnumerable<Allocation>> Handle(GetAllAllocationsQuery request, CancellationToken cancellationToken)
            {
                return await context.AllLocations.Include(a => a.Vehicle).Include(a => a.WayBill).ToListAsync();
            }
        }
    }
}
