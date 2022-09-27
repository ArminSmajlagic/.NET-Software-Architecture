using orders.domain.common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace user.domain.entities
{
    public class User : BaseEntity
    {
        public int wallet_id { get; set; }
        public string username { get; set; } = "";
        public string password { get; set; } = "";
        public string first_name { get; set; } = "";
        public string last_name { get; set; } = "";
        public string country { get; set; } = "";
        public string zip_code { get; set; } = "";
    }
}
