using JiraThing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jira
{
    public class Field
    {
        public string id { get; set; }
        public string Name { get; set; }
        public bool Custom { get; set; }
    }

    public class SearchResults : IResultCollection
    {
        public int StartAt { get; set; }
        public int MaxResults { get; set; }
        public int Total { get; set; }

        public Issue[] Issues { get; set; }
    }

    public class User
    {
        public string name { get; set; }
        public string key { get; set; }
        public string displayName { get; set; }
    }

    public class Issue
    {
        public string Key { get; set; }
        public Dictionary<string, object> Fields { get; set; }
    }

    public class JiraStatus
    {
        public string Name { get; set; }
    }

    public class WorkLogCollection
    {
        public int StartAt { get; set; }
        public int MaxResults { get; set; }
        public int Total { get; set; }

        public WorkLog[] WorkLogs { get; set; }
    }

    public class WorkLog
    {
        public User author { get; set; }
        public string Comment { get; set; }
        public DateTime Started { get; set; }
        public int timeSpentSeconds { get; set; }
    }
}
