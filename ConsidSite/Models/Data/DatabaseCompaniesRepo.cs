using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ConsidSite.Models.Data
{
    public class DatabaseCompaniesRepo : ICompaniesRepo
    {
        private readonly ConsidDBContext _companiesDbContext;

        public DatabaseCompaniesRepo(ConsidDBContext companiesDbContext)
        {
            _companiesDbContext = companiesDbContext;
        }

        public async Task<Companies> Create(string name, long organizationNumber, string notes)
        {
            Companies company = new Companies(name, organizationNumber, notes);

            _companiesDbContext.Companies.Add(company);

            if (await _companiesDbContext.SaveChangesAsync() > 0)
            {
                return company;
            }

            return null;
        }

        public async Task<List<Companies>> Read()
        {
            return await _companiesDbContext.Companies.Include(s => s.Stores).ToListAsync();
        }

        public async Task<Companies> Read(Guid id)
        {
            Companies company = await _companiesDbContext.Companies.Include(s => s.Stores).SingleOrDefaultAsync(s => s.Id == id);

            if (company != null)
            {
                return company;
            }

            return null;
        }

        public async Task<Companies> Update(Companies company)
        {
            _companiesDbContext.Companies.Update(company);

            if (await _companiesDbContext.SaveChangesAsync() > 0)
            {
                return company;
            }

            return null;
        }

        public async Task<bool> Delete(Companies company)
        {
            _companiesDbContext.Companies.Remove(company);

            if (await _companiesDbContext.SaveChangesAsync() > 0)
            {
                return true;
            }

            return false;
        }
    }
}
