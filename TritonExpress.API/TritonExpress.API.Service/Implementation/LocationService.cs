using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TritonExpress.API.Domain.Entities;
using TritonExpress.API.Service.Contract;

namespace TritonExpress.API.Service.Implementation
{
    public class LocationService : ILocationService
    {
        private readonly IRepository<Allocation> repository;
        public LocationService(IRepository<Allocation> repository)
        {
            this.repository = repository;
            this.repository.requestUrl = "Location";
        }
        public async Task<IQueryable<Allocation>> GetAllLocations()
        {
            return await repository.GetAll();
        }

        public Task<Allocation> GetLocationById(int LocationId)
        {
            return repository.GetById(LocationId);
        }

        public async Task<int> InsertLocation(Allocation location)
        {
            return await repository.Insert(location);
        }

        public async Task UpdateLocation(Allocation location)
        {
           await repository.Update(location, location.AllocationId);
        }
    }
}
