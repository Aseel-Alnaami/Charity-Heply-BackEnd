using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Charity.Core.DTOs.Testimonial
{
    public class TestimonialWithUserDto
    {
        public decimal Testimonialid { get; set; }
        public string Fullname { get; set; } = null!;
        public string Username { get; set; } = null!;
        public string? Profilepicture { get; set; }
        public string Content { get; set; } = null!;
        public decimal? Rating { get; set; }
        public DateTime? Submitteddate { get; set; }
    }
}
