using System;
using System.Collections.Generic;

namespace ConsidSite.Models.ViewModels
{
    public class StoreIndexViewModel
    {
        public List<Stores> StoreList { get; set; }

        public StoreIndexViewModel()
        {
            StoreList = new List<Stores>();
        }
    }
}
