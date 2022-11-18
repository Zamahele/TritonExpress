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
using TritonExpress.API.Persistence.Seeds;

namespace TritonExpress.API.Service.Features.StatusFeatures.Query
{
    public class GetAllStatusQuery: IRequest<IEnumerable<Lookup>>
    {
        public class GetAllStatusQueryHandler : IRequestHandler<GetAllStatusQuery, IEnumerable<Lookup>>
        {
            public  async Task<IEnumerable<Lookup>> Handle(GetAllStatusQuery request, CancellationToken cancellationToken)
            {
                try
                {
                    var list = await Task.Run(() => DefualtStatus.LookupList());
                    return list;
                }
                catch (Exception ex)
                {
                    throw;
                }               
            }
        }
    }
}
