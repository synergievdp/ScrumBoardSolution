using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScrumBoard.Models
{
    public class Contact
    {
        public int Id { get; set; }
        public ContactType ContactType { get; set; }
        public string Person { get; set; }
        public string Note { get; set; }
    }
}
