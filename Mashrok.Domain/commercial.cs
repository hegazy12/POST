
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mashrok.Domain
{
    public class commercial : IGeneralPost, Icommercial
    {
        [Key]
        public Guid ID { get; set; }

        public ApplicationUser Owner { get; set; }

        public int partner_type { get; set; }

        public int city_id { get; set; }

        public int investment_cost { get; set; }
        public string description { get; set; }

        public int partners_count { get; set; }

        public int project_status { get; set; }

        public int user_contribution { get; set; }

        public int other_contribution { get; set; }

        public DateTime DateCreated { get; set; } = DateTime.Now;


        public int Deleted { get; set; } = 0;

        public List<UserRequest> requests { get; set; }
    }
}
