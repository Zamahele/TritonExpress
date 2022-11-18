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
    public class GetAllocationByIdQuery:IRequest<Allocation>
    {
        public int Id { get; set; }
        public class GetLocationByIdQueryHandler : IRequestHandler<GetAllocationByIdQuery, Allocation>
        {
            private readonly IApplicationDbContext context;
            public GetLocationByIdQueryHandler(IApplicationDbContext context)
            {
                this.context = context;
            }
            public async Task<Allocation> Handle(GetAllocationByIdQuery request, CancellationToken cancellationToken)
            {
                return await context.AllLocations.Include(a => a.Vehicle).Include(a => a.WayBill).FirstOrDefaultAsync(x => x.AllocationId == request.Id);
            }
        }
    }
}
