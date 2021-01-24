using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ConsidSite.Models.Data;
using ConsidSite.Models.ViewModels;

namespace ConsidSite.Models.Services
{
    public class StoresService : IStoresService
    {
        private readonly IStoresRepo _storesRepo;

        public StoresService(IStoresRepo storesRepo)
        {
            _storesRepo = storesRepo;
        }

        public async Task<Stores> Add(CreateStoreViewModel createStoreViewModel)
        {
            Stores store = await _storesRepo.Create(createStoreViewModel.CompanyId, createStoreViewModel.Name, createStoreViewModel.Address, createStoreViewModel.City, createStoreViewModel.Zip, createStoreViewModel.Country, createStoreViewModel.Longitude, createStoreViewModel.Latitude);

            return store;
        }

        public async Task<List<Stores>> All()
        {
            List<Stores> stores = await _storesRepo.Read();

            return stores;
        }

        public async Task<Stores> FindBy(Guid id)
        {
            Stores store = await _storesRepo.Read(id);

            return store;
        }

        public async Task<Stores> Edit(Guid id, CreateStoreViewModel store)
        {
            Stores editedStore = await FindBy(id);

            editedStore.CompanyId = store.CompanyId;
            editedStore.Name = store.Name;
            editedStore.Address = store.Address;
            editedStore.City = store.City;
            editedStore.Zip = store.Zip;
            editedStore.Country = store.Country;
            editedStore.Longitude = store.Longitude;
            editedStore.Latitude = store.Latitude;

            await _storesRepo.Update(editedStore);

            return editedStore;
        }

        public async Task<bool> Remove(Guid id)
        {
            bool removedStore = await _storesRepo.Delete(await FindBy(id));

            return removedStore;
        }

    }
}
