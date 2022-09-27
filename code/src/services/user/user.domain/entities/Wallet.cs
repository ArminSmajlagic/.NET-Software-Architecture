using orders.domain.common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace user.domain.entities
{
    public class Wallet : BaseEntity
    {
        public string card_name { get; set; }
        public string card_number { get; set; }
        public string cvv { get; set; }
        public string expiration { get; set; }
    }
}
