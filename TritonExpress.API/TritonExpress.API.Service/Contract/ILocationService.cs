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
        Task<IQueryable<Allocation>> GetAllLocations();
        Task<Allocation> GetLocationById(int LocationId);
        Task<int> InsertLocation (Allocation location);
        Task UpdateLocation(Allocation location);
    }
}
