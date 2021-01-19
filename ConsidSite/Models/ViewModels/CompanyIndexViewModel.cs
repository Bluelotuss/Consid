using System;
using System.Collections.Generic;

namespace ConsidSite.Models.ViewModels
{
    public class CompanyIndexViewModel
    {
        public List<Companies> CompanyList { get; set; }

        public CompanyIndexViewModel()
        {
            CompanyList = new List<Companies>();
        }
    }
}
