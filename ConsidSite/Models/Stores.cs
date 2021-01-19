using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace ConsidSite
{
    public partial class Stores
    {
        public Guid Id { get; set; }
        public Guid CompanyId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Zip { get; set; }
        public string Country { get; set; }
        public string Longitude { get; set; }
        public string Latitude { get; set; }

        public virtual Companies Company { get; set; }

        public Stores() { }

        public Stores(Guid companyId, string name, string address, string city, string zip, string country, string longitude, string latitude)
        {
            CompanyId = companyId;
            Name = name;
            Address = address;
            City = city;
            Zip = zip;
            Country = country;
            Longitude = longitude;
            Latitude = latitude;
        }
    }
}
