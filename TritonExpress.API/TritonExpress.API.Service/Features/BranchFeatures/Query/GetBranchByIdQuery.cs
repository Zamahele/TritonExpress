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
    public class GetBranchByIdQuery:IRequest<Branch>
    {
        public int Id { get; set; }
        public class GetBranchByIdQueryHandler : IRequestHandler<GetBranchByIdQuery, Branch>
        {
            private readonly IApplicationDbContext context;
            public GetBranchByIdQueryHandler(IApplicationDbContext context)
            {
                this.context = context;
            }
            public async Task<Branch> Handle(GetBranchByIdQuery request, CancellationToken cancellationToken)
            {
                return await context.Branches.FirstOrDefaultAsync(x => x.BranchId == request.Id);
            }
        }
    }
}
