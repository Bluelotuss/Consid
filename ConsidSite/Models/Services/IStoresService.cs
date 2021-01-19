using System;
using System.Collections.Generic;
using ConsidSite.Models.ViewModels;

namespace ConsidSite.Models.Services
{
    public interface IStoresService
    {
        public Stores Add(CreateStoreViewModel createStoreViewModel);
        public List<Stores> All();
        public Stores FindBy(Guid id);
        public Stores Edit(Guid id, CreateStoreViewModel store);
        public bool Remove(Guid id);
    }
}
