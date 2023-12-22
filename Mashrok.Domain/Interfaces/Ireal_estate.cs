using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mashrok.Domain
{
    public interface Ireal_estate
    {
        public int purpose { get; set; }
        public int property_type { get; set; }
        public int property_area { get; set; }
        public string directions { get; set; }
        public int street_width { get; set; }
        public int negotiable { get; set; }
        public string partnerNeighborhoods { get; set; }
        public int needs_money { get; set; }
    }
}
