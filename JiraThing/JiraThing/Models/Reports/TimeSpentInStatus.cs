using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JiraThing.Models.Reports
{
    /// <summary>
    /// The time, counting only working hours, that a ticket spent in each status.
    /// </summary>
    public class TicketTimeReport
    {
        public string Key { get; set; }
        public string Summary { get; set; }
        public float StoryPoints { get; set; }

        public TimeSpan WorkLogged { get; set; }
        public int TimesRejected { get; set; }
        public int TimesRejectedFromReady { get; set; }

        public DateTime? Started { get; set; }
        public DateTime? Finished { get; set; }        
        public TimeSpan? StartToFinish { get; set; }

        public TimeSpan BeforeWorkStarted { get; set; }
        public TimeSpan InProgress { get; set; }
        public TimeSpan InReview { get; set; }
        public TimeSpan Idle { get; set; }
        public TimeSpan InQA { get; set; }
        public TimeSpan ReadyForDeployment { get; set; }
    }
}
