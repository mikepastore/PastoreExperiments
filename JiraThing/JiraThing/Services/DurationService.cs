using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JiraThing.Services
{
    public class DurationService
    {

        public TimeSpan GetAdjustedDuration(DateTime start, DateTime end)
        {
            return GetDurationWithoutWeekends(start, end);
        }

        private TimeSpan GetDurationWithoutWeekends(DateTime start, DateTime end)
        {           
            var totalDuration = TimeSpan.Zero;

            var time = start;

            while (time < end)
            {
                var nextDate = time.AddDays(1).GetMorningTime();

                if (nextDate > end)
                    nextDate = end;

                if (time.DayOfWeek != DayOfWeek.Saturday && time.DayOfWeek != DayOfWeek.Sunday)
                {
                    var dayDuration = nextDate - time;
                    totalDuration = totalDuration.Add(dayDuration);
                }

                time = nextDate;
            }

            return totalDuration;

        }

    }
}
