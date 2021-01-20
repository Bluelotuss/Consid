using System;
using System.Collections.Generic;
using System.Linq;
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

        public Companies Create(string name, long organizationNumber, string notes)
        {
            Companies company = new Companies(name, organizationNumber, notes);

            _companiesDbContext.Companies.Add(company);

            if (_companiesDbContext.SaveChanges() > 0)
            {
                return company;
            }

            return null;
        }

        public List<Companies> Read()
        {
            return _companiesDbContext.Companies.Include(s => s.Stores).ToList();
        }

        public Companies Read(Guid id)
        {
            Companies company = _companiesDbContext.Companies.Include(s => s.Stores).SingleOrDefault(s => s.Id == id);

            if (company != null)
            {
                return company;
            }

            return null;
        }

        public Companies Update(Companies company)
        {
            _companiesDbContext.Companies.Update(company);

            if (_companiesDbContext.SaveChanges() > 0)
            {
                return company;
            }

            return null;
        }

        public bool Delete(Companies company)
        {
            _companiesDbContext.Companies.Remove(company);

            if (_companiesDbContext.SaveChanges() > 0)
            {
                return true;
            }

            return false;
        }
    }
}
