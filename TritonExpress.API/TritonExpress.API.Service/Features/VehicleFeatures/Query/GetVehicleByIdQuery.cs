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

namespace TritonExpress.API.Service.Features.VehicleFeatures.Query
{
    public class GetLocationByIdQuery:IRequest<Vehicle>
    {
        public int id { get; set; }
        public class GetVehicleByIdQueryHandler : IRequestHandler<GetLocationByIdQuery, Vehicle>
        {
            private readonly IApplicationDbContext context;
            public GetVehicleByIdQueryHandler(IApplicationDbContext context)
            {
                this.context = context;
            }
            public async Task<Vehicle> Handle(GetLocationByIdQuery request, CancellationToken cancellationToken)
            {
                return await context.Vehicles.FirstOrDefaultAsync(x => x.VehicleId == request.id);
            }
        }
    }
}
