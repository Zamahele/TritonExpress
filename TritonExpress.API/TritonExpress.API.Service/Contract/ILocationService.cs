using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TritonExpress.API.Domain.Entities;

namespace TritonExpress.API.Service.Contract
{
    public interface ILocationService
    {
        Task<IQueryable<Location>> GetAllLocations();
        Task<Location> GetLocationById(int LocationId);
        Task<int> InsertLocation (Location location);
        Task UpdateLocation(Location location);
    }
}
