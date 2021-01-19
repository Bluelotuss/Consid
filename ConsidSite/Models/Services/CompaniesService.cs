using System;
using System.Collections.Generic;
using ConsidSite.Models.Data;
using ConsidSite.Models.ViewModels;

namespace ConsidSite.Models.Services
{
    public class CompaniesService : ICompaniesService
    {
        private readonly ICompaniesRepo _companiesRepo;

        public CompaniesService(ICompaniesRepo companiesRepo)
        {
            _companiesRepo = companiesRepo;
        }

        public Companies Add(CreateCompanyViewModel createCompanyViewModel)
        {
            Companies company = _companiesRepo.Create(createCompanyViewModel.Name, createCompanyViewModel.OrganizationNumber, createCompanyViewModel.Notes);

            return company;
        }
        public List<Companies> All()
        {
            List<Companies> companies = _companiesRepo.Read();

            return companies;
        }

        public Companies FindBy(Guid id)
        {
            Companies company = _companiesRepo.Read(id);

            return company;
        }

        public Companies Edit(Guid id, CreateCompanyViewModel company)
        {
            Companies editedCompany = new Companies() { Id = id, Name = company.Name, OrganizationNumber = company.OrganizationNumber, Notes = company.Notes };

            _companiesRepo.Update(editedCompany);

            return editedCompany;
        }

        public bool Remove(Guid id)
        {
            bool removedCompany = _companiesRepo.Delete(FindBy(id));

            return removedCompany;
        }
    }
}
