using System;
using System.Collections.Generic;

namespace Charity.Core.Data
{
    public partial class Userinfo
    {
        public Userinfo()
        {
            Charities = new HashSet<Charity>();
            Donations = new HashSet<Donation>();
            Invoices = new HashSet<Invoice>();
            Paymentinfos = new HashSet<Paymentinfo>();
            Problems = new HashSet<Problem>();
            Testimonials = new HashSet<Testimonial>();
        }

        public decimal Userid { get; set; }
        public string Fullname { get; set; } = null!;
        public string Username { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string? Phone { get; set; }
        public DateTime? Dateofbirth { get; set; }
        public string? Profilepicture { get; set; }
        public string Password { get; set; } = null!;
        public decimal Roleid { get; set; }
        public DateTime? Dateadded { get; set; }

        public virtual Role? Role { get; set; } 
        public virtual ICollection<Charity> Charities { get; set; }
        public virtual ICollection<Donation> Donations { get; set; }
        public virtual ICollection<Invoice> Invoices { get; set; }
        public virtual ICollection<Paymentinfo> Paymentinfos { get; set; }
        public virtual ICollection<Problem> Problems { get; set; }
        public virtual ICollection<Testimonial> Testimonials { get; set; }
    }
}
