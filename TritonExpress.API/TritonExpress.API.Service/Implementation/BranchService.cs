using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TritonExpress.API.Domain.Entities;
using TritonExpress.API.Service.Contract;

namespace TritonExpress.API.Service.Implementation
{
    public class BranchService: IBranchService
    {
        private readonly IRepository<Branch> repository;
        public BranchService(IRepository<Branch> repository)
        {
            this.repository = repository;
            this.repository.requestUrl = "Branch";
        }

        public async Task<IQueryable<Branch>> GetAllBranches()
        {
            return await repository.GetAll();
        }

        public Task<Branch> GetBranchById(int BranchId)
        {
            return repository.GetById(BranchId);
        }

        public async Task<int> InsertBranch(Branch Branch)
        {
            return await repository.Insert(Branch);
        }

        public async Task UpdateBranch(Branch Branch)
        {
           await repository.Update(Branch, Branch.BranchId);
        }

        public async Task DeleteBranch(int BranchId)
        {
           await repository.Remove(BranchId);
        }

    }
}
