

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TritonExpress.API.Service.Contract;

namespace TritonExpress.API.Service.Implementation
{
    public class RepositoryIdentity<T> : IRepositoryIdentity<T> where T : class
    {
        public string requestUrl { get; set; }

        public HttpResponseMessage GetToken(string userName)
        {
            var response = HttpRequestIdentityBase.httpClient.GetAsync(requestUrl + "/" + userName).Result;
            return response;
        }
    }
}
