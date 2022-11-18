

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TritonExpress.API.Service.Contract;

namespace TritonExpress.API.Service.Implementation
{
    public class Repository<T> : IRepository<T> where T : class
    {
        public string requestUrl { get; set; }

        public Task<int> Insert(T target)
        {
            var response = HttpRequestBase.httpClient.PostAsJsonAsync(requestUrl, target).Result;
            if (!response.IsSuccessStatusCode)
            {
                //Log
                throw new Exception(response.ToString());
            }
            return response.Content.ReadAsAsync<int>();
        }

        public async Task Update(T target, int id)
        {
            var response = await HttpRequestBase.httpClient.PutAsJsonAsync(requestUrl + "/" + id, target);
            if (!response.IsSuccessStatusCode)
            {
                var x = response.Content.ReadAsStringAsync().Result;

                throw new Exception(response.ToString());
            }
        }


        public async Task<IQueryable<T>> GetAll()
        {
            var response = await HttpRequestBase.httpClient.GetAsync(requestUrl);
            if (!response.IsSuccessStatusCode)
                throw new Exception(response.ToString());
            var result = response.Content.ReadAsAsync<IEnumerable<T>>().Result;
            return result.AsQueryable();
        }

        public async Task<T> GetById(int key)
        {
            var response = await HttpRequestBase.httpClient.GetAsync(requestUrl + "/" + key);
            if (!response.IsSuccessStatusCode)
                throw new Exception(response.ToString());
            var result = response.Content.ReadAsAsync<T>().Result;
            return result;
        }

        public async Task Remove(int id)
        {
            var response = await HttpRequestBase.httpClient.DeleteAsync(requestUrl + "/" + id);
            if (!response.IsSuccessStatusCode)
                throw new Exception(response.ToString());
        }

        public async Task<IQueryable<T>> GetListById(int key)
        {
            var response = await HttpRequestBase.httpClient.GetAsync(requestUrl + "/" + key);
            if (!response.IsSuccessStatusCode)
                throw new Exception(response.ToString());
            var result = response.Content.ReadAsAsync<IEnumerable<T>>().Result;
            return result.AsQueryable();
        }

        public HttpResponseMessage GetToken(string userName)
        {
            var response =  HttpRequestBase.httpClient.GetAsync(requestUrl + "/" + userName).Result;
            return response;
        }
    }
}
