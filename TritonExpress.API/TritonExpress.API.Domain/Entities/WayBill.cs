using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TritonExpress.API.Domain.Entities
{
    public class WayBill
    {
        public int WayBillId { get; set; }
        public string WaybillNo { get; set; }
        public DateTime WaybillDate { get; set; }
        public string Status { get; set; }
        public DateTime ETADate { get; set; }
        public DateTime ETATime { get; set; }
        public int Quantity { get; set; }
        public int Weight { get; set; }
    }
}
