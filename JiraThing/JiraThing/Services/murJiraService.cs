using Jira;
using JiraThing.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JiraThing.Services
{
    interface IJiraService
    {
        Issue[] SearchAll(string[] fields, string jql);
        WorkLogView[] GetWorkLog(string jql);
        string[] GetKeys(string jql);
    }

    class JiraService : IJiraService
    {
          public JiraService(IJiraClient client)
        {
            mClient = client;
            mCustomFieldMapper = new CustomFieldMapper(mClient);
        }

        public Issue[] SearchAll(string[] fields, string jql)
        {
            int perBatch = 1000;
            int cursor = 0;

            List<Issue> issues = new List<Issue>();

            while (true)
            {
                var batch = mClient.Search(fields, cursor, perBatch, jql);
                issues.AddRange(batch.Issues);
                cursor += batch.Issues.Length;

                if (!batch.Issues.Any())
                    break;
            }

            return issues.ToArray();
        }
                                                                                                                 
        public WorkLogView[] GetWorkLog(string jql)
        {
            var workLogSearch = SearchAll(mCustomFieldMapper.NamesToKeys("Story Points,worklog"), jql);

            var workLogs = workLogSearch.Select(
                issue => new { Key = issue.Key, 
                               StoryPoints = issue.ReadField<float>("Story Points", mCustomFieldMapper),
                               Items = issue.ReadField<WorkLogCollection>("worklog", mCustomFieldMapper) });

            return workLogs.SelectMany(logs => logs.Items.WorkLogs.Select(log =>
                new WorkLogView
                {
                    Key = logs.Key,
                    StoryPoints = logs.StoryPoints,
                    Author = log.author.displayName,
                    Started = log.Started,
                    TimeSpent = TimeSpan.FromSeconds(log.timeSpentSeconds)
                })).ToArray();
        }

        public string[] GetKeys(string jql)
        {
            var search = mClient.Search(new string[] { },0,1000, jql);
            return search.Issues.Select(p => p.Key).ToArray();
        }



    }
}
 public IEnumerable<History> ExtractHistory(Transition[] transitions)
        {
            foreach (var keyGroup in transitions.GroupBy(p => p.Key))
            {
                var itemHistory = keyGroup.ToArray();
                if (keyGroup.Key == "LMAM-217")
                    Console.WriteLine("X");

                yield return new History
                {
                    Key = keyGroup.Key,
                    Transitions = itemHistory,
                    Created = FindFirstTransitionDate(itemHistory, "Backlog"),
                    FirstInProgress = FindFirstTransitionDate(itemHistory,"In Progress"),
                    ReadyForDeployment = FindLastTransitionDate(itemHistory,"Ready for Deployment"),
                    Closed = FindLastTransitionDate(itemHistory,"Closed")
                };
            }
        }

        private DateTime? FindFirstTransitionDate(Transition[] transitions, string status)
        {
            var t = transitions.FirstOrDefault(p => p.NewStatus == status);
            if (t == null)
                return null;
            else
                return t.Date;
        }

        private DateTime? FindLastTransitionDate(Transition[] transitions, string status)
        {
            var t = transitions.FirstOrDefault(p => p.NewStatus == status);
            if (t == null)
                return null;
            else
                return t.Date;
        }

        private TimeSpan? CalcDuration(DateTime? start, DateTime? end)
        {
            if(!start.HasValue || !end.HasValue)
                return null;
            return end-start;
        }

        public HistoryStats[] GetHistoryStats(History[] history)
        {
            var stats = history.Select(p=>
                new HistoryStats { Key = p.Key,
                    CreatedToClosed = CalcDuration(p.Created,p.Closed),
                    CreatedToInProgess = CalcDuration(p.Created,p.FirstInProgress),
                    InProgressToReadyForDeployment = CalcDuration(p.FirstInProgress,p.ReadyForDeployment),
                    ReadyForDeploymentToClosed = CalcDuration(p.ReadyForDeployment,p.Closed)}).ToArray();

            stats = stats.Where(p => p.CreatedToClosed.HasValue).ToArray();
            var ret = new List<HistoryStats>();

            //total lmam
            ret.Add(GetAverageStats(stats, "LMAM Total", s => s.Key.StartsWith("LMAM")));
            ret.AddRange(stats);

            return ret.ToArray();

        }

        private HistoryStats GetAverageStats(HistoryStats[] stats, string aggregateName, Predicate<HistoryStats> filter)
        {
            var ret = new HistoryStats { Key = aggregateName };
            
            ret.CreatedToClosed = GetAverage(stats, s=>s.CreatedToClosed);
            ret.CreatedToInProgess = GetAverage(stats, s => s.CreatedToInProgess);
            ret.InProgressToReadyForDeployment = GetAverage(stats, s => s.InProgressToReadyForDeployment);
            ret.ReadyForDeploymentToClosed = GetAverage(stats, s => s.ReadyForDeploymentToClosed);

            return ret;
        }

        private TimeSpan? GetAverage(HistoryStats[] stats, Func<HistoryStats,TimeSpan?> select)
        {
            var times = stats.Select(select).Where(p => p.HasValue).ToArray();

            if (!times.Any())
                return null;

            return TimeSpan.FromSeconds(times.Average(p => p.Value.TotalSeconds));
        }