using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mashrok.Domain
{
    public class UserRequest
    {
        [Key]
        public Guid Id { get; set; }
        public ApplicationUser Requester { get; set; }
        public int ISpecificationsOK { get; set; }
        public int ISAmountofMoneyOK { get; set; }
        public int SuggestedAmount { get; set; }
        public commercial commercial { get; set; }
        public real_estate_yes real_estate_yes { get; set; }
        public real_estate_no real_estate_no { get; set; }

        public DateTime DateCreated { get; set; } = DateTime.Now;

        public int Deleted { get; set; } = 0;
    }
}
