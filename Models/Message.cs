using System.ComponentModel.DataAnnotations.Schema;
using TestApiJWT.Models;

namespace ProjectEweis.Models
{
    public class Message
    {
        public int Id { get; set; }
        public string ReceiverId { get; set; }
        public string SenderId { get; set; }
        public string Text { get; set; }
        public DateTime When { get; set; } = DateTime.Now;
        public bool Deleted { get; set; }
        public string RequestId { get; set; }
       
    }
}
