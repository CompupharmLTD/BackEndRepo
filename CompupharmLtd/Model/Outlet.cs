using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CompupharmLtd.Model
{
    public class Outlet
    {
        public int OutletID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string ZipCode { get; set; }
        public DateTime DateAdded { get; set; }
        public DateTime DateUpdated { get; set; }
    }
    public class OutletRequest
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string ZipCode { get; set; }
    }
    public class OutletEditRequest
    {

        public int OutletID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string ZipCode { get; set; }
        public DateTime DateAdded { get; set; }
    }


}
