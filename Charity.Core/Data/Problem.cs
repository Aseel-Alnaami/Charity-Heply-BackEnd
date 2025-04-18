using System;
using System.Collections.Generic;

namespace Charity.Core.Data
{
    public partial class Problem
    {
        public decimal Problemid { get; set; }
        public decimal Userid { get; set; }
        public string Problemtext { get; set; } 
        public DateTime? Reportdate { get; set; }
        public string? Status { get; set; }

        public virtual Userinfo? User { get; set; } 
    }
}
