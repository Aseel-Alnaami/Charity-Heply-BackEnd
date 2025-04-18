using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Charity.Core.Data
{
    public partial class ContactPage
    {
        public int Id { get; set; }
        public string Title1 { get; set; }
        public string Title2 { get; set; }
        public string Location { get; set; }
        public string Phonenumber { get; set; }
        public string Email { get; set; }
        public string Heroimg { get; set; }
    }

}
