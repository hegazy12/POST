using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mashrok.Domain
{
    public interface Icommercial
    {
        public int project_status { get; set; }
        public int user_contribution { get; set; }
        public int other_contribution { get; set; }
    }
}
