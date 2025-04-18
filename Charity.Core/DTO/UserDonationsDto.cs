using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Charity.Core.DTO
{
    public class UserDonationsDto
    {
        public decimal Amount { get; set; }
        public string Charityname { get; set; } = null!;
        public DateTime? Donationdate { get; set; }
    }
}
