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

namespace TritonExpress.API.Service.Features.WayBillFeatures.Query
{
    public class GetWayBillByIdQuery:IRequest<WayBill>
    {
        public int Id { get; set; }
        public class GetWayBillByIdQueryHandler : IRequestHandler<GetWayBillByIdQuery, WayBill>
        {
            private readonly IApplicationDbContext context;
            public GetWayBillByIdQueryHandler(IApplicationDbContext context)
            {
                this.context = context;
            }
            public async Task<WayBill> Handle(GetWayBillByIdQuery request, CancellationToken cancellationToken)
            {
                return await context.WayBills.FirstOrDefaultAsync(x => x.WayBillId == request.Id);
            }
        }
    }
}
