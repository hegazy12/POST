using System.ComponentModel.DataAnnotations.Schema;

namespace Mashrok.Domain
{
    public class Partnership_proposal
    {
        public int Id { get; set; }
        public bool Islocation_suitable { get; set; }
        public bool Ispartnership_amount_appropriate { get; set; }
        public double? Amount { get; set; }
        public string UserId { get; set; }
        [ForeignKey("UserId")]
        public ApplicationUser User { get; set; }
    }
}