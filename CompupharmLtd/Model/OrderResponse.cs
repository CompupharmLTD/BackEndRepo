using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CompupharmLtd.Model
{
    public class OrderResponse
    {
        public string status { get; set; }
        public int statusCode { get; set; }
        public Order order { get; set; }
    }

    public class OrderListResponse
    {
        public string status { get; set; }
        public int statusCode { get; set; }
        public IEnumerable<Order> product { get; set; }
    }

}
