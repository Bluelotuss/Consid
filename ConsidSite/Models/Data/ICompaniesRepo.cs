using System;
using System.Collections.Generic;

namespace ConsidSite.Models.Data
{
    public interface ICompaniesRepo
    {
        Companies Create(string name, long organizationNumber, string notes);
        List<Companies> Read();
        Companies Read(Guid id);
        Companies Update(Companies company);
        bool Delete(Companies company);
    }
}