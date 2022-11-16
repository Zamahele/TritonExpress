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
    public class UpdateBranchCopmman: Location,IRequest<Location>
    {
        public class UpdateLocationCopmmanHandler : IRequestHandler<UpdateBranchCopmman, Location>
        {
            private readonly IApplicationDbContext context;
            public UpdateLocationCopmmanHandler(IApplicationDbContext context)
            {
                this.context = context;
            }
            public async Task<Location> Handle(UpdateBranchCopmman request, CancellationToken cancellationToken)
            {
                var Location = await context.Locations.FirstOrDefaultAsync(x => x.LocationId == request.LocationId);

                var LocationId = request.LocationId;
                Location.Address = request.Address;
                Location.ZipCode = request.ZipCode;
                Location.BrancheId = request.BrancheId;
                context.Locations.Update(Location);
                await context.SaveChangesAsync();
                return Location;
                        
            }
        }
    }
}
