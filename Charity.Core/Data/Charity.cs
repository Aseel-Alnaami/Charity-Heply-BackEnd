using System;
using System.Collections.Generic;

namespace Charity.Core.Data
{
    public partial class Charity
    {
        public Charity()
        {
            Donations = new HashSet<Donation>();
            Invoices = new HashSet<Invoice>();
        }

        public decimal Charityid { get; set; }
        public string Charityname { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string Charityimg { get; set; } = null!;
        public string Goals { get; set; } = null!;
        public string Location { get; set; } = null!;
        public string? Status { get; set; }
        public decimal Target { get; set; }
        public decimal Userid { get; set; }
        public decimal Categoryid { get; set; }
        public DateTime? Createddate { get; set; }
        public decimal? Latitude { get; set; }
        public decimal? Longitude { get; set; }
        public decimal? Currentdonation { get; set; }

        public virtual Category? Category { get; set; } 
        public virtual Userinfo? User { get; set; } 
        public virtual ICollection<Donation> Donations { get; set; }
        public virtual ICollection<Invoice> Invoices { get; set; }
    }
}
