using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mashrok.Domain
{
    public class ApplicationUser : IdentityUser
    {
        [MaxLength(50)]
        public string Name { get; set; }

        [Required, MaxLength(50), Phone]
        public string PhoneNumber { get; set; }
 
    }
}
