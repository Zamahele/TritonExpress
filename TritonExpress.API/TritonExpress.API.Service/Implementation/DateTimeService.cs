using System;
using TritonExpress.API.Service.Contract;

namespace TritonExpress.API.Service.Implementation
{
    public class DateTimeService : IDateTimeService
    {
        public DateTime NowUtc => DateTime.UtcNow;
    }
}