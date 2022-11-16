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
    public class GetAllLocationQuery : IRequest<IEnumerable<WayBill>>
    {
        public class GetAllWayBillsQueryHanndler : IRequestHandler<GetAllLocationQuery, IEnumerable<WayBill>>
        {
            private readonly IApplicationDbContext context;
            public GetAllWayBillsQueryHanndler(IApplicationDbContext context)
            {
                this.context = context;
            }
            public async Task<IEnumerable<WayBill>> Handle(GetAllLocationQuery request, CancellationToken cancellationToken)
            {
                return await context.WayBills.ToListAsync();
            }
        }
    }
}
