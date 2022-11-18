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

namespace TritonExpress.API.Service.Features.LocationFeatures.Command
{
    public class UpdateAllocationCommand: Allocation,IRequest<Allocation>
    {
        public class UpdateLocationCopmmanHandler : IRequestHandler<UpdateAllocationCommand, Allocation>
        {
            private readonly IApplicationDbContext context;
            public UpdateLocationCopmmanHandler(IApplicationDbContext context)
            {
                this.context = context;
            }
            public async Task<Allocation> Handle(UpdateAllocationCommand request, CancellationToken cancellationToken)
            {
                var Location = await context.AllLocations.FirstOrDefaultAsync(x => x.AllocationId == request.AllocationId);

                var LocationId = request.AllocationId;
                Location.VehicleId = request.VehicleId;
                Location.WayBill = request.WayBill;
                Location.WayBillId = request.WayBillId;
                context.AllLocations.Update(Location);
                await context.SaveChangesAsync();
                return Location;
                        
            }
        }
    }
}
