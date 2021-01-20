using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace ConsidSite
{
    public partial class Companies
    {
        public Companies()
        {
            Stores = new HashSet<Stores>();
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public long OrganizationNumber { get; set; }
        public string Notes { get; set; }

        public virtual ICollection<Stores> Stores { get; set; }

        public Companies(string name, long organizationNumber, string notes)
        {
            Name = name;
            OrganizationNumber = organizationNumber;
            Notes = notes;
        }
    }
}
