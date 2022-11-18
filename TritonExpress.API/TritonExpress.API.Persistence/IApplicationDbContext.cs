using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using TritonExpress.API.Domain.Entities;
using TritonExpress.API.Domain.Entities.Authentication;

namespace TritonExpress.API.Persistence
{
    public interface IApplicationDbContext
    {
        DbSet<Vehicle> Vehicles { get; set; }
        DbSet<Allocation> Locations { get; set; }
        DbSet<WayBill> WayBills { get; set; }
        DbSet<Branch> Branches { get; set; }
        DbSet<Lookup> Status { get; set; }
        DbSet<AspNetUsers> AspNetUsers { get; set; }
        Task<int> SaveChangesAsync();
    }
}
