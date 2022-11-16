using System;

namespace TritonExpress.API.Service.Contract
{
    public interface IDateTimeService
    {
        DateTime NowUtc { get; }
    }
}
