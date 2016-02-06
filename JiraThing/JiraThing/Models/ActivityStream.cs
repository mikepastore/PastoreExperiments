using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JiraThing.Models
{
    public class ActivityEntry
    {
        public string Author { get; set; }
        public DateTime Date { get; set; }
        public string Description;

        public override string ToString()
        {
            return Date.ToString("yyyy/M/d") + " " + Description;
        }
    }

    public class Transition
    {
        public string Key { get; set; }
        public string Author { get; set; }
        public string NewStatus { get; set; }
        public DateTime Date { get; set; }

        public override string ToString()
        {
            return Key + " " + Date.ToString("yyyy/M/d") + " " + NewStatus;
        }
    }

    public class History
    {
        public string Key { get; set; }
        public Transition[] Transitions { get; set; }

        public DateTime? Created { get; set; }
        public DateTime? FirstInProgress { get; set; }
        public DateTime? ReadyForDeployment { get; set; }
        public DateTime? Closed { get; set; }
    }

    public class HistoryStats
    {
        public string Key { get; set; }
        public TimeSpan? CreatedToInProgess { get; set; }
        public TimeSpan? InProgressToReadyForDeployment { get; set; }
        public TimeSpan? ReadyForDeploymentToClosed { get; set; }
        public TimeSpan? CreatedToClosed { get; set; }
    }
}
