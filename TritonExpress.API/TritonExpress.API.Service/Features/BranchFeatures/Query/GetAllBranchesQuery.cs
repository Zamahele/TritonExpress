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

namespace TritonExpress.API.Service.Features.BranchFeatures.Query
{
    public class GetAllBranchesQuery : IRequest<IEnumerable<Branch>>
    {
        public class GetAllBranchsQueryHanndler : IRequestHandler<GetAllBranchesQuery, IEnumerable<Branch>>
        {
            private readonly IApplicationDbContext context;
            public GetAllBranchsQueryHanndler(IApplicationDbContext context)
            {
                this.context = context;
            }
            public async Task<IEnumerable<Branch>> Handle(GetAllBranchesQuery request, CancellationToken cancellationToken)
            {
                return await context.Branches.ToListAsync();
            }
        }
    }
}
