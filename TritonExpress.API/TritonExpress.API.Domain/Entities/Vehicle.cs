using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TritonExpress.API.Domain.Entities
{
    public class Vehicle
    {
        public int VehicleId { get; set; }
        public string Model { get; set; }
        public string Make { get; set; }
        public int Year { get; set; }
        public string RegistrationNo { get; set; }
    }
}
