using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CompupharmLtd.Model
{
    public class ProductResponse
    {
        public string status { get; set; }
        public int statusCode { get; set; }
        public Product product { get; set; }
    }


    public class ProductListResponse
    {
        public string status { get; set; }
        public int statusCode { get; set; }
        public IEnumerable<Product> product { get; set; }
    }
}
