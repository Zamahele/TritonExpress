using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TritonExpress.API.Domain.Entities;
using TritonExpress.API.Service.Contract;

namespace TritonExpress.API.Service.Implementation
{
    public class VehicleService : IVehicleService
    {
        private readonly IRepository<Vehicle> repository;
        public VehicleService(IRepository<Vehicle> repository)
        {
            this.repository = repository;
            this.repository.requestUrl = "Vehicle";
        }

        public async Task DeleteVehicle(int vehicleId)
        {
            await repository.Remove(vehicleId);
        }

        public async Task<IQueryable<Vehicle>> GetAllVehicles()
        {
            return await repository.GetAll();
        }

        public Task<Vehicle> GetVehicleById(int vehicleId)
        {
            return repository.GetById(vehicleId);
        }

        public async Task<int> InsertVehicle(Vehicle vehicle)
        {
            return await repository.Insert(vehicle);
        }

        public async Task UpdateVehicle(Vehicle vehicle)
        {
           await repository.Update(vehicle, vehicle.VehicleId);
        }
    }
}
