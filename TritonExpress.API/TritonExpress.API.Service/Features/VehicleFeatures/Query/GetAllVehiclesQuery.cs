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
    public class GetAllVehicleQuery : IRequest<IEnumerable<Vehicle>>
    {
        public class GetAllVehiclesQueryHanndler : IRequestHandler<GetAllVehicleQuery, IEnumerable<Vehicle>>
        {
            private readonly IApplicationDbContext context;
            public GetAllVehiclesQueryHanndler(IApplicationDbContext context)
            {
                this.context = context;
            }
            public async Task<IEnumerable<Vehicle>> Handle(GetAllVehicleQuery request, CancellationToken cancellationToken)
            {
                return await context.Vehicles.Include(x=>x.Branch).ToListAsync();
            }
        }
    }
}
