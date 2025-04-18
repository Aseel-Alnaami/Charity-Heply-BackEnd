using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Charity.Core.DTO
{
    public class MakePaymentDto
    {
        public string CardNumber { get; set; } = string.Empty;
        public string CvvNumber { get; set; } = string.Empty;
        public decimal Amount { get; set; }
    }
}
