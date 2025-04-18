using System;
using System.Collections.Generic;

namespace Charity.Core.Data
{
    public partial class Contactu
    {
        public decimal Contactid { get; set; }
        public string Name { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Message { get; set; } = null!;
        public DateTime? Contactdate { get; set; }
        public string? Status { get; set; }
    }
}
