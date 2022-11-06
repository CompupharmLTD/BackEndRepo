using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CompupharmLtd.Model
{
    public class ExecutiveResponse
    {
         public string status { get; set; }
            public int statusCode { get; set; }
            public Executive executive { get; set; }
        }

        public class ExecutiveListResponse
    {
            public string status { get; set; }
            public int statusCode { get; set; }
            public IEnumerable<Executive> executives { get; set; }
        }
    
}
