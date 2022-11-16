using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TritonExpress.API.Domain.Entities;

namespace TritonExpress.API.Service.Contract
{
    public interface IWaybillService
    {
        Task<IQueryable<WayBill>> GetAllWayBills();
        Task<WayBill> GetWayBillById(int wayBillId);
        Task<int> InsertWayBill(WayBill wayBill);
        Task UpdateWayBill(WayBill wayBillId);
    }
}
