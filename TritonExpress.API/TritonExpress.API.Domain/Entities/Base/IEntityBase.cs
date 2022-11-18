using System;

namespace TritonExpress.API.Domain.Entities.Base
{
    public interface IEntityBase
    {

        DateTimeOffset CreatedOn { get; set; }

        string CreatedBy { get; set; }

        DateTimeOffset UpdatedOn { get; set; }

        string UpdatedBy { get; set; }
    }
}