using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TritonExpress.API.Persistence;

namespace TritonExpress.API.Service.Features.BranchFeatures.Command
{
    public class DeleteBranchCommand : IRequest<int>
    {
        public int Id { get; set; }
        public class DeleteBranchCommandHandler : IRequestHandler<DeleteBranchCommand, int>
        {
            private readonly IApplicationDbContext context;
            public DeleteBranchCommandHandler(IApplicationDbContext context)
            {
                this.context = context;
            }
            public async Task<int> Handle(DeleteBranchCommand request, CancellationToken cancellationToken)
            {
                var branch = await context.Branches.FirstOrDefaultAsync(x => x.BranchId == request.Id);
                if (branch == null)
                {
                    return default;
                }
                context.Branches.Remove(branch);
                return branch.BranchId;
            }
        }
    }
}
