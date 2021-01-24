using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ConsidSite.Models.ViewModels;

namespace ConsidSite.Models.Services
{
    public interface IStoresService
    {
        public Task<Stores> Add(CreateStoreViewModel createStoreViewModel);
        public Task<List<Stores>> All();
        public Task<Stores> FindBy(Guid id);
        public Task<Stores> Edit(Guid id, CreateStoreViewModel store);
        public Task<bool> Remove(Guid id);
    }
}
