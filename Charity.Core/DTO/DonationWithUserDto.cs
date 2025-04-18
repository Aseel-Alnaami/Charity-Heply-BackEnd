using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Charity.Core.DTO
{
    public class DonationWithUserDto
    {
        
            public decimal Donationid { get; set; }
            public string Fullname { get; set; } = null!;
            public string Username { get; set; } = null!;
            public decimal Amount { get; set; }
            public string Charityname { get; set; } = null!;
            public DateTime? Donationdate { get; set; }
        }
    }
