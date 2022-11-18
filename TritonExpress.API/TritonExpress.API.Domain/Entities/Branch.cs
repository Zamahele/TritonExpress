using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TritonExpress.API.Domain.Entities.Base;

namespace TritonExpress.API.Domain.Entities
{
    public class Branch : EntityBase
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BranchId { get; set; }
        [Required(ErrorMessage ="*")]
        [DisplayName("Branch Name")]
        public string BranchName { get; set; }
        [Required(ErrorMessage = "*")]
        [DisplayName("Address")]
        public string Address { get; set; }
        [Required(ErrorMessage = "*")]
        [DisplayName("Zip Code")]
        public int ZipCode { get; set; }
        [Required(ErrorMessage = "*")]
        [DisplayName("Phone Number")]
        public string PhoneNumber { get; set; }
    }
}
