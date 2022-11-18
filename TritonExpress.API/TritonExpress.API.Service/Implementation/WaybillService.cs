using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TritonExpress.API.Domain.Entities;
using TritonExpress.API.Service.Contract;

namespace TritonExpress.API.Service.Implementation
{
    public class WaybillService : IWaybillService
    {
        private readonly IRepository<WayBill> repository;
        public WaybillService(IRepository<WayBill> repository)
        {
            this.repository = repository;
            this.repository.requestUrl = "WayBill";
        }

        public async Task DeleteWayBill(int wayBillId)
        {
            await repository.Remove(wayBillId);
        }

        public async Task<IQueryable<WayBill>> GetAllWayBills()
        {
            return await repository.GetAll();
        }

        public async Task<WayBill> GetWayBillById(int wayBillId)
        {
            return await repository.GetById(wayBillId);
        }

        public async Task<int> InsertWayBill(WayBill wayBill)
        {
            return await repository.Insert(wayBill);
        }

        public async Task UpdateWayBill(WayBill wayBillId)
        {
            await repository.Update(wayBillId, wayBillId.WayBillId);
        }
    }
}
