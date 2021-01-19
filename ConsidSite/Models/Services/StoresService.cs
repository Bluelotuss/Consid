using System;
using System.Collections.Generic;
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

        public Stores Add(CreateStoreViewModel createStoreViewModel)
        {
            Stores store = _storesRepo.Create(createStoreViewModel.CompanyId, createStoreViewModel.Name, createStoreViewModel.Address, createStoreViewModel.City, createStoreViewModel.Zip, createStoreViewModel.Country, createStoreViewModel.Longitude, createStoreViewModel.Latitude);

            return store;
        }

        public List<Stores> All()
        {
            List<Stores> stores = _storesRepo.Read();

            return stores;
        }

        public Stores FindBy(Guid id)
        {
            Stores store = _storesRepo.Read(id);

            return store;
        }

        public Stores Edit(Guid id, CreateStoreViewModel store)
        {
            Stores editedStore = new Stores() { Id = id, CompanyId = store.CompanyId, Name = store.Name, Address = store.Address, City = store.City, Zip = store.Zip, Country = store.Country, Longitude = store.Longitude, Latitude = store.Latitude };

            _storesRepo.Update(editedStore);

            return editedStore;
        }

        public bool Remove(Guid id)
        {
            bool removedStore = _storesRepo.Delete(FindBy(id));

            return removedStore;
        }

    }
}
