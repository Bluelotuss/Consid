using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ConsidSite.Models.Data
{
    public class DatabaseStoresRepo : IStoresRepo
    {
        private readonly ConsidDBContext _storesDbContext;

        public DatabaseStoresRepo(ConsidDBContext storesDbContext)
        {
            _storesDbContext = storesDbContext;
        }

        public async Task<Stores> Create(Guid companyId, string name, string address, string city, string zip, string country, string longitude, string latitude)
        {
            Stores store = new Stores(companyId, name, address, city, zip, country, longitude, latitude);

            _storesDbContext.Stores.Add(store);

            if (await _storesDbContext.SaveChangesAsync() > 0)
            {
                return store;
            }

            return null;
        }

        public async Task<List<Stores>> Read()
        {
            return await _storesDbContext.Stores.Include(c => c.Company).ToListAsync();
        }

        public async Task<Stores> Read(Guid id)
        {
            Stores store = await _storesDbContext.Stores.Include(c => c.Company).SingleOrDefaultAsync(s => s.Id == id);

            if (store != null)
            {
                return store;
            }

            return null;
        }

        public async Task<Stores> Update(Stores store)
        {
            _storesDbContext.Stores.Update(store);

            if (await _storesDbContext.SaveChangesAsync() > 0)
            {
                return store;
            }

            return null;
        }

        public async Task<bool> Delete(Stores store)
        {
            _storesDbContext.Stores.Remove(store);

            if (await _storesDbContext.SaveChangesAsync() > 0)
            {
                return true;
            }

            return false;
        }
    }
}
