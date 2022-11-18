using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TritonExpress.API.Persistence;

namespace TritonExpress.API.Service.Features.WayBillFeatures.Command
{
    public class DeleteWayBillCommand : IRequest<int>
    {
        public int Id { get; set; }
        public class DeleteWayBillCommandHandler : IRequestHandler<DeleteWayBillCommand, int>
        {
            private readonly IApplicationDbContext context;
            public DeleteWayBillCommandHandler(IApplicationDbContext context)
            {
                this.context = context;
            }
            public async Task<int> Handle(DeleteWayBillCommand request, CancellationToken cancellationToken)
            {
                var WayBill = await context.WayBills.FirstOrDefaultAsync(x => x.WayBillId == request.Id);
                if (WayBill == null)
                {
                    return default;
                }
                context.WayBills.Remove(WayBill);
                await context.SaveChangesAsync();
                return WayBill.WayBillId;
            }
        }
    }
}
