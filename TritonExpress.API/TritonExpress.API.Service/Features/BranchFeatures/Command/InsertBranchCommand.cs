using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TritonExpress.API.Domain.Entities;
using TritonExpress.API.Persistence;

namespace TritonExpress.API.Service.Features.BranchFeatures.Command
{
    public class InsertBranchCommand : Branch,IRequest<int>
    {
        public class InsertBranchCommanHandler : IRequestHandler<InsertBranchCommand, int>
        {
            private readonly IApplicationDbContext context;
            public InsertBranchCommanHandler(IApplicationDbContext context)
            {
                this.context = context;
            }
            public async Task<int> Handle(InsertBranchCommand request, CancellationToken cancellationToken)
            {
                var branch = new Branch();
                branch.BranchName = request.BranchName;

                await context.Branches.AddAsync(branch);
                await context.SaveChangesAsync();
                return branch.BranchId;
            }
        }
    }
}
