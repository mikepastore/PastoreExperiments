using Jira;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JiraThing.Models
{
    public class AccelaJiraTicket
    {
        public string Key { get; set; }
        public string Summary { get; set; }
        public string Status { get; set; }
        public float StoryPoints { get; set; }
        public DateTime Created { get; set; }

        public WorkLog[] WorkLog { get; set; }
    }
}
