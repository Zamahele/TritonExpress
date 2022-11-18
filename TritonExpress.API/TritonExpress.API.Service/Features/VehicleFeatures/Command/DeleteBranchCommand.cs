using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TritonExpress.API.Persistence;

namespace TritonExpress.API.Service.Features.VehicleFeatures.Command
{
    public class DeleteVehicleCommand : IRequest<int>
    {
        public int Id { get; set; }
        public class DeleteVehicleCommandHandler : IRequestHandler<DeleteVehicleCommand, int>
        {
            private readonly IApplicationDbContext context;
            public DeleteVehicleCommandHandler(IApplicationDbContext context)
            {
                this.context = context;
            }
            public async Task<int> Handle(DeleteVehicleCommand request, CancellationToken cancellationToken)
            {
                var Vehicle = await context.Vehicles.FirstOrDefaultAsync(x => x.VehicleId == request.Id);
                if (Vehicle == null)
                {
                    return default;
                }
                context.Vehicles.Remove(Vehicle);
                await context.SaveChangesAsync();
                return Vehicle.VehicleId;
            }
        }
    }
}
