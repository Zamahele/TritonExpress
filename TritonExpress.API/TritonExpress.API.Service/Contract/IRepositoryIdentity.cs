using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace TritonExpress.API.Service.Contract
{
    public interface IRepositoryIdentity<T> where T : class
    {
        string requestUrl { get; set; }
        HttpResponseMessage GetToken(string userName);
    }
}
