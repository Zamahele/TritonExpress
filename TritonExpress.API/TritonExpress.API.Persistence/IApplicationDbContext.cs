using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using TritonExpress.API.Domain.Entities;

namespace TritonExpress.API.Persistence
{
    public interface IApplicationDbContext
    {
        DbSet<Vehicle> Vehicles { get; set; }
        DbSet<Location> Locations { get; set; }
        DbSet<WayBill> WayBills { get; set; }
        DbSet<Branch> Branches { get; set; }

        Task<int> SaveChangesAsync();
    }
}
