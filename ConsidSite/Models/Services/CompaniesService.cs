using System;
using System.Collections.Generic;
using System.Threading.Tasks;
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

        public async Task<Companies> Add(CreateCompanyViewModel createCompanyViewModel)
        {
            Companies company = await _companiesRepo.Create(createCompanyViewModel.Name, createCompanyViewModel.OrganizationNumber, createCompanyViewModel.Notes);

            return company;
        }

        public async Task<List<Companies>> All()
        {
            List<Companies> companies = await _companiesRepo.Read();

            return companies;
        }

        public async Task<Companies> FindBy(Guid id)
        {
            Companies company = await _companiesRepo.Read(id);

            return company;
        }

        public async Task<Companies> Edit(Guid id, CreateCompanyViewModel company)
        {
            Companies editedCompany = new Companies() { Id = id, Name = company.Name, OrganizationNumber = company.OrganizationNumber, Notes = company.Notes };

            await _companiesRepo.Update(editedCompany);

            return editedCompany;
        }

        public async Task<bool> Remove(Guid id)
        {
            bool removedCompany = await _companiesRepo.Delete(await FindBy(id));

            return removedCompany;
        }
    }
}
