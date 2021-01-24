using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ConsidSite.Models.Data
{
    public interface ICompaniesRepo
    {
        Task<Companies> Create(string name, long organizationNumber, string notes);
        Task<List<Companies>> Read();
        Task<Companies> Read(Guid id);
        Task<Companies> Update(Companies company);
        Task<bool> Delete(Companies company);
    }
}