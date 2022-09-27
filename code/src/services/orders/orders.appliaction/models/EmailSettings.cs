using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace orders.appliaction.models
{
    public class EmailSettings
    {
        public string api_key { get; set; }
        public string from_address { get; set; }
        public string from_name { get; set; }
    }
}
