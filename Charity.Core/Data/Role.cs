using System;
using System.Collections.Generic;

namespace Charity.Core.Data
{
    public partial class Role
    {
        public Role()
        {
            Userinfos = new HashSet<Userinfo>();
        }

        public decimal Roleid { get; set; }
        public string Rolename { get; set; } = null!;

        public virtual ICollection<Userinfo> Userinfos { get; set; }
    }
}
