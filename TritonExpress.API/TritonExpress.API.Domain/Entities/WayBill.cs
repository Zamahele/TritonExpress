using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TritonExpress.API.Domain.Entities.Base;

namespace TritonExpress.API.Domain.Entities
{
    public class WayBill : EntityBase
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
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
