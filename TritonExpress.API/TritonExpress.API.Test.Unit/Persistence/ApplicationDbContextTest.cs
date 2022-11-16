using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using TritonExpress.API.Domain.Entities;
using TritonExpress.API.Persistence;

namespace TritonExpress.API.Test.Unit.Persistence
{
    public class ApplicationDbContextTest
    {
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
