using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TritonExpress.API.Domain.Entities;

namespace TritonExpress.API.Persistence.Seeds
{
    public static class DefualtStatus
    {
        public static List<Lookup> LookupList()
        {
            return new List<Lookup>() 
            {
                new Lookup{Id = 1,Name = "Packing"},
                new Lookup{Id = 2,Name = "On Transit"},
                new Lookup{Id = 3, Name = "Delived"},
            };
        }
    }
}
