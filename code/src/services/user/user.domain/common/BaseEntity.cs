using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace orders.domain.common
{
    public class BaseEntity
    {
        public int id { get; set; }
        public string created_by { get; set; } = String.Empty;
        public DateTime created { get; set; }
        public string? modified_by { get; set; }
        public DateTime? modifed { get; set; }
    }
}
