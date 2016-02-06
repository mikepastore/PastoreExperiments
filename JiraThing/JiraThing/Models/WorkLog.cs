using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JiraThing.Models
{
    public class StoryPointsVsTimeSpent
    {
        public string Key { get; set; }
        public float StoryPoints { get; set; }
        public TimeSpan EstimatedTime { get; set; }
        public TimeSpan TotalTimeLogged { get; set; }

        public override string ToString()
        {
            return String.Concat(Key, ",", StoryPoints, ",", EstimatedTime.TotalHours.ToString("0.0"), ",", TotalTimeLogged.TotalHours.ToString("0.0"));
        }
    }

    public class DeveloperPerDay
    {
        public string Developer { get; set; }
        public DateTime Day { get;set;}
        public TimeSpan TotalTimeLogged { get; set; }

        public override string ToString()
        {
            return String.Concat(Developer, ",", Day.ToString("yyyy/M/d"), ",", TotalTimeLogged.TotalHours.ToString("0.0"));
        }
    }

    public class DeveloperAveragePerDay
    {
        public string Developer { get; set; }
        public TimeSpan AverageTimeLogged { get; set; }

        public override string ToString()
        {
            return String.Concat(Developer, ",", AverageTimeLogged.TotalHours.ToString("0.0"));
        }
    }

    public class StandupReport
    {
        public List<StandupUserReport> UserReports { get; set; }
    }

    public class StandupUserReport
    {
        public string Developer {get;set;}
        public List<StandupItem> Items { get; set; }
    }

    public class StandupItem
    {
        public string Ticket { get; set; }
        public string TicketSummary { get; set; }
        public string Comment { get; set; }
        public TimeSpan TimeLogged { get; set; }
    }
}
