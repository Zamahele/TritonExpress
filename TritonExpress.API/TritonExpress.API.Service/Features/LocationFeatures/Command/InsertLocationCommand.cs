using MediatR;
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
    public class InsertBranchComman : Location,IRequest<int>
    {
        public class InsertLocationCommanHandler : IRequestHandler<InsertBranchComman, int>
        {
            private readonly IApplicationDbContext context;
            public InsertLocationCommanHandler(IApplicationDbContext context)
            {
                this.context = context;
            }
            public async Task<int> Handle(InsertBranchComman request, CancellationToken cancellationToken)
            {
                var Location = new Location();
                Location.Address = request.Address;
                Location.ZipCode = request.ZipCode;
                Location.BrancheId = request.BrancheId;

                await context.Locations.AddAsync(Location);
                await context.SaveChangesAsync();
                return Location.LocationId;
            }
        }
    }
}
