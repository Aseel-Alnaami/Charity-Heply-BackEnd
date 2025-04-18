using System;
using System.Collections.Generic;

namespace Charity.Core.Data
{
    public partial class Invoice
    {
        public decimal Invoiceid { get; set; }
        public decimal Userid { get; set; }
        public decimal Charityid { get; set; }
        public decimal Amount { get; set; }
        public string? Type { get; set; }
        public DateTime? Invoicedate { get; set; }

        public virtual Charity? Charity { get; set; } 
        public virtual Userinfo? User { get; set; } 
    }
}
