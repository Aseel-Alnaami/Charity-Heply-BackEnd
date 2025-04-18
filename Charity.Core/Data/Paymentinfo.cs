using System;
using System.Collections.Generic;

namespace Charity.Core.Data
{
    public partial class Paymentinfo
    {
        public decimal Cardid { get; set; }

        public string Cardnumber { get; set; } = null!;
        public string Cvvnumber { get; set; } = null!;
        public decimal Balance { get; set; }
        public DateTime? Createddate { get; set; }
    }
}
