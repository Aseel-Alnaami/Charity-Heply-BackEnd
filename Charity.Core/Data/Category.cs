using System;
using System.Collections.Generic;

namespace Charity.Core.Data
{
    public partial class Category
    {
        public Category()
        {
            Charities = new HashSet<Charity>();
        }

        public decimal Categoryid { get; set; }
        public string Categoryname { get; set; } = null!;
        public decimal Profit { get; set; }

        public virtual ICollection<Charity> Charities { get; set; }
    }
}
