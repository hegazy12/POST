using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mashrok.Domain
{
    public class Notifacation
    {
        public int Id { get; set; }
        public string NotifyType { get; set; }
        public string NotifyText { get; set; }
        public string Notifyobject { get; set; }
        public string Usr_Id { get; set; }
        public string Post_Id { get; set; }
        public string Request_Id { get; set; }
        public int sent { get; set; }
    }
}
