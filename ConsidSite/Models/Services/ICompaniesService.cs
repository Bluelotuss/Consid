using System;
using System.Collections.Generic;
using ConsidSite.Models.ViewModels;

namespace ConsidSite.Models.Services
{
    public interface ICompaniesService
    {
        public Companies Add(CreateCompanyViewModel createCompanyViewModel);
        public List<Companies> All();
        public Companies FindBy(Guid id);
        public Companies Edit(Guid id, CreateCompanyViewModel company);
        public bool Remove(Guid id);
    }
}
