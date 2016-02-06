using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JiraThing.Models
{
    public class TicketScore
    {
        public string Key { get; set; }
        public string[] TeamMembers { get; set; }
        public float Score { get; set; }
    }
}
