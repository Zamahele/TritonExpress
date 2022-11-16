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
    public class GetAllBranchesQuery : IRequest<IEnumerable<Location>>
    {
        public class GetAllLocationsQueryHanndler : IRequestHandler<GetAllBranchesQuery, IEnumerable<Location>>
        {
            private readonly IApplicationDbContext context;
            public GetAllLocationsQueryHanndler(IApplicationDbContext context)
            {
                this.context = context;
            }
            public async Task<IEnumerable<Location>> Handle(GetAllBranchesQuery request, CancellationToken cancellationToken)
            {
                return await context.Locations.ToListAsync();
            }
        }
    }
}
