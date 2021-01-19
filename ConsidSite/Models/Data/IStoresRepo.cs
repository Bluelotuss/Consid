using System;
using System.Collections.Generic;

namespace ConsidSite.Models.Data
{
    public interface IStoresRepo
    {
        Stores Create(Guid companyId, string name, string address, string city, string zip, string country, string longitude, string latitude);
        List<Stores> Read();
        Stores Read(Guid id);
        Stores Update(Stores store);
        bool Delete(Stores store);
    }
}
