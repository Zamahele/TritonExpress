using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TritonExpress.API.Domain.Entities;

namespace TritonExpress.API.Service.Contract
{
    public interface IBranchService
    {
        Task<IQueryable<Branch>> GetAllBranches();
        Task<Branch> GetBranchById(int BranchId);
        Task<int> InsertBranch(Branch Branch);
        Task UpdateBranch(Branch Branch);
        Task DeleteBranch(int BranchId);
    }
}
