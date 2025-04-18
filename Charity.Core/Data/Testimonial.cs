﻿using System;
using System.Collections.Generic;

namespace Charity.Core.Data
{
    public partial class Testimonial
    {
        public decimal Testimonialid { get; set; }
        public decimal Userid { get; set; }
        public string? Content { get; set; } 
        public decimal? Rating { get; set; }
        public string? Status { get; set; }
        public DateTime? Submitteddate { get; set; }

        public virtual Userinfo? User { get; set; }
    }
}
