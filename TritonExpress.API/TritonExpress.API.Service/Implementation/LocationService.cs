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
        private readonly IRepository<Location> repository;
        public LocationService(IRepository<Location> repository)
        {
            this.repository = repository;
            this.repository.requestUrl = "Location";
        }
        public async Task<IQueryable<Location>> GetAllLocations()
        {
            return await repository.GetAll();
        }

        public Task<Location> GetLocationById(int LocationId)
        {
            return repository.GetById(LocationId);
        }

        public async Task<int> InsertLocation(Location location)
        {
            return await repository.Insert(location);
        }

        public async Task UpdateLocation(Location location)
        {
           await repository.Update(location, location.LocationId);
        }
    }
}
