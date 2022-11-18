﻿using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TritonExpress.API.Domain.Entities;
using TritonExpress.API.Persistence;

namespace TritonExpress.API.Service.Features.LocationFeatures.Query
{
    public class GetBranchByIdQuery:IRequest<Allocation>
    {
        public int id { get; set; }
        public class GetLocationByIdQueryHandler : IRequestHandler<GetBranchByIdQuery, Allocation>
        {
            private readonly IApplicationDbContext context;
            public GetLocationByIdQueryHandler(IApplicationDbContext context)
            {
                this.context = context;
            }
            public async Task<Allocation> Handle(GetBranchByIdQuery request, CancellationToken cancellationToken)
            {
                return await context.Locations.FirstOrDefaultAsync(x => x.AllocationId == request.id);
            }
        }
    }
}
