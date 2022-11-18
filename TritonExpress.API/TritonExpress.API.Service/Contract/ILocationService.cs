using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TritonExpress.API.Domain.Entities;

namespace TritonExpress.API.Service.Contract
{
    public interface IAllocationService
    {
        Task<IQueryable<Allocation>> GetAllLocations();
        Task<Allocation> GetAllLocationById(int LocationId);
        Task<int> InsertAllLocation (Allocation location);
        Task UpdateAllLocation(Allocation location);
        Task DeleteAllLocation(int Id);
    }
}
