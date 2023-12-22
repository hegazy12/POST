using Mashrok.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mashrok.Domain
{
    public interface IGeneralPost
    {

        public Guid ID { get; set; }

        public ApplicationUser Owner { get; set; }

        public int partner_type { get; set; }

        public int city_id { get; set; }

        public int investment_cost { get; set; }
        public string description { get; set; }

        public int partners_count { get; set; }
    }
}
