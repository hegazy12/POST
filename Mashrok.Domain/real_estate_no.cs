using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mashrok.Domain
{
    public class real_estate_no : IGeneralPost, Ireal_estate
    {
        [Key]
        public Guid ID { get; set; }

        public ApplicationUser Owner { get; set; }

        public int purpose { get; set; }

        public int property_type { get; set; }

        public int property_area { get; set; }

        public string? directions { get; set; }

        public int street_width { get; set; }

        public int negotiable { get; set; }

        public string? Neighborhood { get; set; }

        public int needs_money { get; set; }


        public int partner_type { get; set; }

        public int city_id { get; set; }

        public int investment_cost { get; set; }

        public string? description { get; set; }


        public int partners_count { get; set; }
        public string? partnerNeighborhoods { get; set; }

        public DateTime DateCreated { get; set; } = DateTime.Now;


        public int Deleted { get; set; } = 0;

        public List<UserRequest> requests { get; set; }
    }
}
