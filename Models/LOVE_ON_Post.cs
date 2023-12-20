using System.ComponentModel.DataAnnotations;
using TestApiJWT.Models;

namespace ProjectEweis.Models
{
    public class LOVE_ON_Post
    {

        
            [Key]
            public Guid ID { get; set; }
            public ApplicationUser Reactor { get; set; }
            public DateTime DateCreated { get; set; } = DateTime.Now;
            public int Deleted { get; set; } = 0;
            public commercial commercial { get; set; }
            public real_estate_yes real_estate_yes { get; set; }
            public real_estate_no real_estate_no { get; set; }
        
    }
}
