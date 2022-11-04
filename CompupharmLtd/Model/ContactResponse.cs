using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CompupharmLtd.Model
{
    public class ContactResponse
    {
        public string status { get; set; }
        public int statusCode { get; set; }
        public Contact contact { get; set; }
    }

    public class ContactListResponse
    {
        public string status { get; set; }
        public int statusCode { get; set; }
        public IEnumerable<Contact> contact { get; set; }
    }

}
