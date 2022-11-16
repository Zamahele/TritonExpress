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

namespace TritonExpress.API.Service.Features.VehicleFeatures.Command
{
    public class UpdateWayBillCopmman: Vehicle,IRequest<Vehicle>
    {
        public class UpdateVehicleCopmmanHandler : IRequestHandler<UpdateWayBillCopmman, Vehicle>
        {
            private readonly IApplicationDbContext context;
            public UpdateVehicleCopmmanHandler(IApplicationDbContext context)
            {
                this.context = context;
            }
            public async Task<Vehicle> Handle(UpdateWayBillCopmman request, CancellationToken cancellationToken)
            {
                var vehicle = await context.Vehicles.FirstOrDefaultAsync(x => x.VehicleId == request.VehicleId);

                var vehicleId = request.VehicleId;
                vehicle.RegistrationNo = request.RegistrationNo;
                vehicle.Year = request.Year;
                vehicle.Make = request.Make;
                vehicle.Model = request.Model;
                 context.Vehicles.Update(vehicle);
                await context.SaveChangesAsync();
                return vehicle;
                        
            }
        }
    }
}
