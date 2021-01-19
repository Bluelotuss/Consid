using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsidSite.Models.Data
{
    public class DatabaseStoresRepo : IStoresRepo
    {
        private readonly ConsidDBContext _storesDbContext;

        public DatabaseStoresRepo(ConsidDBContext storesDbContext)
        {
            _storesDbContext = storesDbContext;
        }

        public Stores Create(Guid companyId, string name, string address, string city, string zip, string country, string longitude, string latitude)
        {
            Stores store = new Stores(companyId, name, address, city, zip, country, longitude, latitude);

            _storesDbContext.Stores.Add(store);

            if (_storesDbContext.SaveChanges() > 0)
            {
                return store;
            }

            return null;
        }

        public List<Stores> Read()
        {
            return _storesDbContext.Stores.ToList();
        }

        public Stores Read(Guid id)
        {
            Stores store = _storesDbContext.Stores.Find(id);

            if (store != null)
            {
                return store;
            }

            return null;
        }

        public Stores Update(Stores store)
        {
            _storesDbContext.Stores.Update(store);

            if (_storesDbContext.SaveChanges() > 0)
            {
                return store;
            }

            return null;
        }

        public bool Delete(Stores store)
        {
            _storesDbContext.Stores.Remove(store);

            if (_storesDbContext.SaveChanges() > 0)
            {
                return true;
            }

            return false;
        }
    }
}
