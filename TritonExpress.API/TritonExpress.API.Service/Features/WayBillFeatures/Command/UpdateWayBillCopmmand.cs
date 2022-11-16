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

namespace TritonExpress.API.Service.Features.WayBillFeatures.Command
{
    public class UpdateWayBillCopmmand: WayBill,IRequest<WayBill>
    {
        public class UpdateWayBillCopmmanHandler : IRequestHandler<UpdateWayBillCopmmand, WayBill>
        {
            private readonly IApplicationDbContext context;
            public UpdateWayBillCopmmanHandler(IApplicationDbContext context)
            {
                this.context = context;
            }
            public async Task<WayBill> Handle(UpdateWayBillCopmmand request, CancellationToken cancellationToken)
            {
                var WayBill = await context.WayBills.FirstOrDefaultAsync(x => x.WayBillId == request.WayBillId);

                var WayBillId = request.WayBillId;
                WayBill.WaybillNo = request.WaybillNo;
                WayBill.WaybillDate = request.WaybillDate;
                WayBill.Status = request.Status;
                WayBill.ETADate = request.ETADate;
                WayBill.ETATime = request.ETATime;
                WayBill.Quantity = request.Quantity;
                WayBill.Weight = request.Weight;
                context.WayBills.Update(WayBill);
                await context.SaveChangesAsync();
                return WayBill;
                        
            }
        }
    }
}
