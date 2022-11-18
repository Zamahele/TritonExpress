using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TritonExpress.API.Domain.Entities;
using TritonExpress.API.Service.Contract;

namespace TritonExpress.API.Service.Implementation
{
    public class AllocationService : IAllocationService
    {
        private readonly IRepository<Allocation> repository;
        public AllocationService(IRepository<Allocation> repository)
        {
            this.repository = repository;
            this.repository.requestUrl = "Allocation";
        }
        public async Task<IQueryable<Allocation>> GetAllLocations()
        {
            return await repository.GetAll();
        }

        public Task<Allocation> GetAllLocationById(int LocationId)
        {
            return repository.GetById(LocationId);
        }

        public async Task<int> InsertAllLocation(Allocation location)
        {
            return await repository.Insert(location);
        }

        public async Task UpdateAllLocation(Allocation location)
        {
           await repository.Update(location, location.AllocationId);
        }

        public async Task DeleteAllLocation(int Id)
        {
           await repository.Remove(Id);
        }
    }
}
