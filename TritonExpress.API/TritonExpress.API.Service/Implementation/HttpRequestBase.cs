using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace TritonExpress.API.Service.Implementation
{
    public class HttpRequestBase
    {
        public static readonly HttpClient httpClient = new HttpClient(new HttpClientHandler { UseDefaultCredentials = true });
        static HttpRequestBase()
        {
            var config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
            var _url = config.GetValue<string>("AppSettings:Url");

            httpClient.BaseAddress = new Uri(_url);
            httpClient.DefaultRequestHeaders.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", "xxxx");
        }
    }
}
