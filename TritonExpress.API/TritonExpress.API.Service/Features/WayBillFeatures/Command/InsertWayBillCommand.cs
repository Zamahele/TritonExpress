using MediatR;
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
    public class InsertWayBillComman : WayBill,IRequest<int>
    {
        public class InsertVehichleCommanHandler : IRequestHandler<InsertWayBillComman, int>
        {
            private readonly IApplicationDbContext context;
            public InsertVehichleCommanHandler(IApplicationDbContext context)
            {
                this.context = context;
            }
            public async Task<int> Handle(InsertWayBillComman request, CancellationToken cancellationToken)
            {
                var WayBill = new WayBill();
                WayBill.WaybillNo = request.WaybillNo;
                WayBill.WaybillDate = request.WaybillDate;
                WayBill.Status = request.Status;
                WayBill.ETADate = request.ETADate;
                WayBill.ETATime = request.ETATime;
                WayBill.Quantity = request.Quantity;
                WayBill.Weight = request.Weight;

                await context.WayBills.AddAsync(WayBill);
                await context.SaveChangesAsync();
                return WayBill.WayBillId;
            }
        }
    }
}
