using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace orders.appliaction.models.OrderVM
{
    public class OrdersVM
    {
        public string username { get; set; }
        public decimal total_price { get; set; }
        public int user_id { get; set; }
        public int payment_id { get; set; }
    }
}
