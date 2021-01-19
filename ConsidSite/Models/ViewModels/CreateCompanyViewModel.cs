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
        [Range(1, int.MaxValue)]        //Värdet kan ju överstiga 2147483647, hur gör man om man är född 99 och har enskild firma?
        public int OrganizationNumber { get; set; }

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
