using System.ComponentModel.DataAnnotations;

namespace TritonExpress.API.Domain
{
    public class BaseEntity
    {
        [Key]
        public int Id { get; set; }
    }
}
