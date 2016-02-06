using JiraThing.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JiraThing.Services
{
    class WorkLogAnalyzer
    {
        public IEnumerable<StoryPointsVsTimeSpent> CalculateStoryPointsVsTimeSpent(WorkLogView[] logs)
        {
            foreach (var group in logs.GroupBy(p => p.Key))
            {

                yield return new StoryPointsVsTimeSpent
                {
                    Key = group.Key,
                    StoryPoints = group.First().StoryPoints,
                    EstimatedTime = TimeSpan.FromHours(group.First().StoryPoints * 8),
                    TotalTimeLogged = TimeSpan.FromSeconds(group.Sum(p => p.TimeSpent.TotalSeconds))
                };                
            }
        }

        public IEnumerable<DeveloperPerDay> CalculateDeveloperTimePerDay(WorkLogView[] logs)
        {

            foreach (var developerGroup in logs.GroupBy(p => p.Author))
            {
                string developer = developerGroup.Key;

                foreach(var daySum in developerGroup.GroupBy(p=>p.Started.GetMorningTime()))
                {
                    yield return new DeveloperPerDay
                    {
                        Developer = developer,
                        Day = daySum.Key,
                        TotalTimeLogged = TimeSpan.FromHours(daySum.Sum(p => p.TimeSpent.TotalHours))
                    };
                }

            }
        }

        public IEnumerable<DeveloperAveragePerDay> CalculateDeveloperAveragePerDay(WorkLogView[] logs)
        {
            var devPerDay = CalculateDeveloperTimePerDay(logs).ToArray();

            return devPerDay.GroupBy(p=>p.Developer).Select(p=>
                new DeveloperAveragePerDay { Developer = p.Key, 
                                            AverageTimeLogged= TimeSpan.FromHours((double)p.Average(q=>q.TotalTimeLogged.TotalHours)) });
        }
    }
}
