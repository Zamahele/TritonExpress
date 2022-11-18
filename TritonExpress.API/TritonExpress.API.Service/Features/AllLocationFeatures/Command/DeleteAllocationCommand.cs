using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TritonExpress.API.Persistence;

namespace TritonExpress.API.Service.Features.LocationFeatures.Command
{
    public class DeleteAllocationCommand : IRequest<int>
    {
        public int Id { get; set; }
        public class DeleteVehicleCommandHandler : IRequestHandler<DeleteAllocationCommand, int>
        {
            private readonly IApplicationDbContext context;
            public DeleteVehicleCommandHandler(IApplicationDbContext context)
            {
                this.context = context;
            }
            public async Task<int> Handle(DeleteAllocationCommand request, CancellationToken cancellationToken)
            {
                var allocation = await context.AllLocations.FirstOrDefaultAsync(x => x.AllocationId == request.Id);
                if (allocation == null)
                {
                    return default;
                }
                context.AllLocations.Remove(allocation);
                await context.SaveChangesAsync();
                return allocation.VehicleId;
            }
        }
    }
}
