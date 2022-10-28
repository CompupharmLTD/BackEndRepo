using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CompupharmLtd.Model
{
    public class Product
    {
        public string ProductName { get; set; }
        public int ProductID { get; set; }
        public string ProductRestriction { get; set; }
        public string ProductImage { get; set; }
        public string ProductfullDescription { get;  set; }
        public string ProductShortDescription { get;  set; }  
        public string ProductStatus { get;  set; }  
        public int ProductPrice { get;  set; }
        public DateTime ProductCreatedDate { get;  set; }
        public int ProductQuantity { get;  set; }
    }
}
