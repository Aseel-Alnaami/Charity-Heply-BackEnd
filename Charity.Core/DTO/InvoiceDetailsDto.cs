using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Charity.Core.DTO
{
    public class InvoiceDetailsDto
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public string CharityName { get; set; }
        public DateTime InvoiceDate { get; set; }
        public string Type { get; set; }
        public decimal Amount { get; set; }
    }
}
