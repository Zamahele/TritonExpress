using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.IO;
using System.Threading.Tasks;
using TritonExpress.API.Domain.Entities;

namespace TritonExpress.API.Persistence
{
    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {
        // This constructor is used of runit testing
        public ApplicationDbContext()
        {

        }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }

        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<WayBill> WayBills { get; set; }
        public DbSet<Branch> Branches { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder
                .UseSqlServer("Data Source = C5994\\SQLEXPRESS; Initial Catalog = TritonExpressDb; Integrated Security = True");
            }
        }

        public async Task<int> SaveChangesAsync()
        {
            return await base.SaveChangesAsync();
        }
    }
}
