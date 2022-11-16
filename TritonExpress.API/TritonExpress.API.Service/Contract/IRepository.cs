using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TritonExpress.API.Service.Contract
{
    public interface IRepository<T> where T : class
    {
        string requestUrl { get; set; }
        Task<int> Insert(T target);
        Task<IQueryable<T>> GetAll();
        Task<T> GetById(int key);
        Task<IQueryable<T>> GetListById(int key);
        Task Remove(int id);
        Task Update(T target, int id);
    }
}
