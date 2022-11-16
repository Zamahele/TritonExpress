using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TritonExpress.API.Domain.Entities
{
    public class Branch
    {
        public int BranchId { get; set; }
        public string BranchName { get; set; }
        public string Address { get; set; }
        public int ZipCode { get; set; }
        public string PhoneNumber { get; set; }
    }
}
