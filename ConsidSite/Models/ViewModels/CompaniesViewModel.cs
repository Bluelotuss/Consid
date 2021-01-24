using System;
using System.Collections.Generic;

namespace ConsidSite.Models.ViewModels
{
    public class CompaniesViewModel
    {
        public List<Companies> CompaniesList { get; set; }

        public CompaniesViewModel()
        {
            CompaniesList = new List<Companies>();
        }
    }
}
