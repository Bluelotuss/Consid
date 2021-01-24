using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ConsidSite.Models.Data
{
    public interface IStoresRepo
    {
        Task<Stores> Create(Guid companyId, string name, string address, string city, string zip, string country, string longitude, string latitude);
        Task<List<Stores>> Read();
        Task<Stores> Read(Guid id);
        Task<Stores> Update(Stores store);
        Task<bool> Delete(Stores store);
    }
}
