using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TritonExpress.API.Domain.Entities
{
    public class Location
    {
        public int LocationId { get; set; }
        public string Address { get; set; }
        public int ZipCode { get; set; }
        public int BrancheId { get; set; }
    }
}
