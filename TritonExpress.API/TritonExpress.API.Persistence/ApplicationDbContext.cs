using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using TritonExpress.API.Domain.Entities;
using TritonExpress.API.Domain.Entities.Authentication;
using TritonExpress.API.Persistence.Seeds;

namespace TritonExpress.API.Persistence
{
    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {
        private readonly ICurrentUserService _currentUserService;
        // This constructor is used of runit testing
        public ApplicationDbContext()
        {

        }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, ICurrentUserService currentUserService) : base(options)
        {
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            _currentUserService = currentUserService;
        }

        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<Allocation> Locations { get; set; }
        public DbSet<WayBill> WayBills { get; set; }
        public DbSet<Branch> Branches { get; set; }
        public DbSet<Lookup> Status { get; set; }
        public  DbSet<AspNetUsers> AspNetUsers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder
                .UseSqlServer("Data Source = C5994\\SQLEXPRESS; Initial Catalog = TritonExpressDb; Integrated Security = True");
            }
        }

        protected override void OnModelCreating (ModelBuilder modelBuilder)
        {
            List<Lookup> statuses = DefualtStatus.LookupList();
            modelBuilder.Entity<Lookup>().HasData(statuses);

            base.OnModelCreating (modelBuilder);
        }
        public override int SaveChanges(bool acceptAllChangesOnSuccess)
        {
            ChangeTracker.SetAuditProperties(_currentUserService);
            return base.SaveChanges(acceptAllChangesOnSuccess);
        }

        public override async Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
        {
            ChangeTracker.SetAuditProperties(_currentUserService);
            return await base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }

        public  async Task<int> SaveChangesAsync()
        {
            ChangeTracker.SetAuditProperties(_currentUserService);
            return await base.SaveChangesAsync();
        }
    }
}
