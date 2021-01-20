using System;
using System.ComponentModel.DataAnnotations;

namespace ConsidSite.Models.ViewModels
{
    public class CreateCompanyViewModel
    {
        [Required(ErrorMessage = "Company name is required")]
        [Display(Name = "Company name")]
        [StringLength(255, ErrorMessage = "Can not contain more than 255 characters")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Organization number is required")]
        [Display(Name = "Organization number")]
        [Range(1000000000, 999999999999999, ErrorMessage = "Organization number cannot be less than 10 or more than 15 numbers")]
        public long OrganizationNumber { get; set; }

        [Display(Name = "Notes")]
        public string Notes { get; set; }

        public CreateCompanyViewModel() { }

        public CreateCompanyViewModel(Companies company)
        {
            Name = company.Name;
            OrganizationNumber = company.OrganizationNumber;
            Notes = company.Notes;
        }
    }
}
