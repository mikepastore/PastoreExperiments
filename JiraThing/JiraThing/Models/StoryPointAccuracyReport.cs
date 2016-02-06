using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JiraThing.Models
{
    public class StoryPointAccuracyReport
    {
        public string Key { get; set; }
        public string Description { get; set; }
        public float StoryPoints { get; set; }
        public TimeSpan TotalWorkLogged { get; set; }
        public TimeSpan TotalTimeInProgress { get; set; }
        public bool Finished { get; set; }
    }
}
