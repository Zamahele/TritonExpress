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

namespace TritonExpress.API.Service.Features.BranchFeatures.Command
{
    public class UpdateBranchCopmmand: Branch,IRequest<Branch>
    {
        public class UpdateBranchCopmmanHandler : IRequestHandler<UpdateBranchCopmmand, Branch>
        {
            private readonly IApplicationDbContext context;
            public UpdateBranchCopmmanHandler(IApplicationDbContext context)
            {
                this.context = context;
            }
            public async Task<Branch> Handle(UpdateBranchCopmmand request, CancellationToken cancellationToken)
            {
                var branch = await context.Branches.FirstOrDefaultAsync(x => x.BranchId == request.BranchId);

                branch.BranchId = request.BranchId;
                branch.BranchName = request.BranchName;
                branch.Address = request.Address;
                branch.PhoneNumber = request.PhoneNumber;
                branch.ZipCode = request.ZipCode;

                context.Branches.Update(branch);
                await context.SaveChangesAsync();
                return branch;
                        
            }
        }
    }
}
