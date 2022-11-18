using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.Caching;
using System.Text;
using System.Threading.Tasks;
using TritonExpress.API.Domain.Entities;
using TritonExpress.API.Service.Contract;

namespace TritonExpress.API.Service.Implementation
{
    public class HttpRequestBase
    {
        public static readonly HttpClient httpClient = new HttpClient(new HttpClientHandler { UseDefaultCredentials = true });
        static HttpRequestBase()
        {
            var config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
            var _url = config.GetValue<string>("AppSettings:Url");

            var instance = new GetGeneratedToken();
            var token = instance.GetToken();

            httpClient.BaseAddress = new Uri(_url);
            httpClient.DefaultRequestHeaders.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
        }

        public class GetGeneratedToken
        {
            ObjectCache _memoryCache = MemoryCache.Default;
            public string GetToken()
            {
                var token = (Token)_memoryCache.Get("token");
                return token?.TokenCode;
            }
        }
    }
}
