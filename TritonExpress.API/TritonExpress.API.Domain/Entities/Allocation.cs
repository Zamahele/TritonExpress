using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TritonExpress.API.Domain.Entities.Base;

namespace TritonExpress.API.Domain.Entities
{
    public class Allocation : EntityBase
    {
        public int AllocationId { get; set; }
        public int VehicleId { get; set; }
        public Vehicle Vehicle { get; set; }
        public int WayBillId { get; set; }
        public WayBill WayBill { get; set; }
    }
}
