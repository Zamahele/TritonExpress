using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using TritonExpress.API.Domain.Entities;
using TritonExpress.API.Persistence;

namespace TritonExpress.API.Test.Unit.Persistence
{
    public class ApplicationDbContextTest
    {
        [Test]
        public void CanInsertVehicheIntoDatabase()
        {

            using var context = new ApplicationDbContext();
            var vehicle = new Vehicle();
            context.Vehicles.Add(vehicle);
            Assert.AreEqual(EntityState.Added, context.Entry(vehicle).State);
        }

        [Test]
        public void CanInsertBranchIntoDatabase()
        {

            using var context = new ApplicationDbContext();
            var branch = new Branch();
            context.Branches.Add(branch);
            Assert.AreEqual(EntityState.Added, context.Entry(branch).State);
        }

        [Test]
        public void CanInsertWayBillIntoDatabasee()
        {

            using var context = new ApplicationDbContext();
            var waybills = new WayBill();
            context.WayBills.Add(waybills);
            Assert.AreEqual(EntityState.Added, context.Entry(waybills).State);
        }

        [Test]
        public void CanInsertVehicheIntoDatabasee()
        {

            using var context = new ApplicationDbContext();
            var vehicle = new Vehicle();
            context.Vehicles.Add(vehicle);
            Assert.AreEqual(EntityState.Added, context.Entry(vehicle).State);
        }


    }
}
