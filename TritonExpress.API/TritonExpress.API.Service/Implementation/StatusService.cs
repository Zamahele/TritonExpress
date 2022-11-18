using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TritonExpress.API.Domain.Entities;
using TritonExpress.API.Service.Contract;

namespace TritonExpress.API.Service.Implementation
{
    public class StatusService : IStatusService
    {
        private readonly IRepository<Lookup> repository;
        public StatusService(IRepository<Lookup> repository)
        {
            this.repository = repository;
            this.repository.requestUrl = "Status";
        }
        public async Task<IQueryable<Lookup>> GetStatuses()
        {
            return await repository.GetAll();
        }
    }
}
