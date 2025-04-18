using System;
using System.Collections.Generic;

namespace Charity.Core.Data
{
    public partial class Donation
    {
        public decimal Donationid { get; set; }
        public decimal Amount { get; set; }
        public decimal Userid { get; set; }
        public decimal Charityid { get; set; }
        public DateTime? Donationdate { get; set; }

        public virtual Charity? Charity { get; set; } 
        public virtual Userinfo? User { get; set; } 
    }
}
