using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JiraThing.Models
{
    public class TicketHistory
    {
        public string Key;
        public string Description;
        public float StoryPoints;
        public Transition[] Transitions;
    }

    public class TicketStatus
    {
        public string Key;
        public string CurrentStatus;
        public string NextStatus;
        public float ProgressInStatus;
        public bool ExistedAtTime;
    }
}
