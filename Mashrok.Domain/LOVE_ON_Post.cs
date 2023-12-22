using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mashrok.Domain
{
    public class LOVE_ON_Post
    {


        [Key]
        public Guid ID { get; set; }
        [Required]
        public ApplicationUser Reactor { get; set; }
        public DateTime DateCreated { get; set; } = DateTime.Now;
        public int Deleted { get; set; } = 0;
        [AllowNull]
        public string commercialID { get; set; }
        [AllowNull]
        public string real_estate_yesID { get; set; }
        [AllowNull]
        public string real_estate_noID { get; set; }

    }
}
