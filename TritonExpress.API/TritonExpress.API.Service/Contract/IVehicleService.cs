using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TritonExpress.API.Domain.Entities;

namespace TritonExpress.API.Service.Contract
{
    public interface IVehicleService
    {
        Task<IQueryable<Vehicle>> GetAllVehicles();
        Task<Vehicle> GetVehicleById(int vehicleId);
        Task<int> InsertVehicle(Vehicle vehicle);
        Task UpdateVehicle(Vehicle vehicle);
        Task DeleteVehicle(int vehicleId);
    }
}
