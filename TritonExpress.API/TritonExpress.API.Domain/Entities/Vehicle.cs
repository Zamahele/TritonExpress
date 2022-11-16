using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TritonExpress.API.Domain.Entities
{
    public class Vehicle
    {
        [Key]
        public int VehicleId { get; set; }
        [Required(ErrorMessage = "*")]
        public string Model { get; set; }
        [Required(ErrorMessage = "*")]
        public string Make { get; set; }
        [Required(ErrorMessage = "*")]
        public int Year { get; set; }
        [Required(ErrorMessage = "*")]
        [DisplayName("Registration No")]
        public string RegistrationNo { get; set; }
        [DisplayName("Branch")]
        [ForeignKey("Branch")]
        public int BranchId { get; set; }
        public Branch Branch { get; set; }

    }
}
