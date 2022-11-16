using MediatR;
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
    public class InsertVehicleComman : Vehicle,IRequest<int>
    {
        public class InsertVehichleCommanHandler : IRequestHandler<InsertVehicleComman, int>
        {
            private readonly IApplicationDbContext context;
            public InsertVehichleCommanHandler(IApplicationDbContext context)
            {
                this.context = context;
            }
            public async Task<int> Handle(InsertVehicleComman request, CancellationToken cancellationToken)
            {
                var vehicle = new Vehicle();
                vehicle.RegistrationNo = request.RegistrationNo;
                vehicle.Year = request.Year;
                vehicle.Make = request.Make;
                vehicle.Model = request.Model;
                vehicle.BranchId = request.BranchId;

                await context.Vehicles.AddAsync(vehicle);
                await context.SaveChangesAsync();
                return vehicle.VehicleId;
            }
        }
    }
}
