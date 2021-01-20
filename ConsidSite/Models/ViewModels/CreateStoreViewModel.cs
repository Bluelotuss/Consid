using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ConsidSite.Models.ViewModels
{
    public class CreateStoreViewModel
    {
        public Guid CompanyId { get; set; }

        [Required(ErrorMessage = "Store name is required")]
        [Display(Name = "Store name")]
        [StringLength(100, ErrorMessage = "Can not contain more than 100 characters")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Address is required")]
        [Display(Name = "Address")]
        [StringLength(512, ErrorMessage = "Can not contain more than 512 characters")]
        public string Address { get; set; }

        [Required(ErrorMessage = "City is required")]
        [Display(Name = "City")]
        [StringLength(512, ErrorMessage = "Can not contain more than 512 characters")]
        public string City { get; set; }

        [Required(ErrorMessage = "Zip is required")]
        [Display(Name = "Zip")]
        [StringLength(16, ErrorMessage = "Can not contain more than 16 characters")]
        public string Zip { get; set; }

        [Required(ErrorMessage = "Country is required")]
        [Display(Name = "Country")]
        [StringLength(50, ErrorMessage = "Can not contain more than 50 characters")]
        public string Country { get; set; }

        [Display(Name = "Longitude")]
        [StringLength(15, ErrorMessage = "Can not contain more than 15 characters")]
        public string Longitude { get; set; }

        [Display(Name = "Latitude")]
        [StringLength(15, ErrorMessage = "Can not contain more than 15 characters")]
        public string Latitude { get; set; }

        [Required]
        public Companies Company { get; set; }

        public List<Companies> CompanyList { get; set; }

        public CreateStoreViewModel() { }

        public CreateStoreViewModel(Guid companyId, string name, string address, string city, string zip, string country, string longitude, string latitude)
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

        public CreateStoreViewModel(Stores store)
        {
            CompanyId = store.CompanyId;
            Name = store.Name;
            Address = store.Address;
            City = store.City;
            Zip = store.Zip;
            Country = store.Country;
            Longitude = store.Longitude;
            Latitude = store.Latitude;
        }
    }
}
