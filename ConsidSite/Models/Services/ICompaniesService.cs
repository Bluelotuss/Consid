using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ConsidSite.Models.ViewModels;

namespace ConsidSite.Models.Services
{
    public interface ICompaniesService
    {
        public Task<Companies> Add(CreateCompanyViewModel createCompanyViewModel);
        public Task<List<Companies>> All();
        public Task<Companies> FindBy(Guid id);
        public Task<Companies> Edit(Guid id, CreateCompanyViewModel company);
        public Task<bool> Remove(Guid id);
    }
}
