using Jira;
using JiraThing.Models;
using JiraThing.Services.Jira;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JiraThing.Services
{
    public class SearchService
    {
        private IJiraAPIClient mAPIClient;
        private CustomFieldService mCustomFieldService;

        public SearchService(IJiraAPIClient apiClient, CustomFieldService customFieldService)
        {
            mAPIClient = apiClient;
            mCustomFieldService = customFieldService; 
        }

        public AccelaJiraTicket[] Search(string jql)
        {
            var issues = GetIssues(new string[] { "summary", "status", "Story Points", "worklog","created"}, jql);

            return issues.Select(issue =>
                new AccelaJiraTicket
                {
                    Key = issue.Key,
                    Created = DateTime.Parse(issue.ReadField("created",mCustomFieldService)),
                    Status = issue.ReadField<JiraStatus>("status", mCustomFieldService).Name,
                    StoryPoints = issue.ReadFieldFloat("Story Points", mCustomFieldService),
                    Summary = issue.ReadField("summary", mCustomFieldService),
                    WorkLog = issue.ReadField<WorkLogCollection>("worklog",mCustomFieldService).WorkLogs      
                }).ToArray();
        }


        private Issue[] GetIssues(string[] fields, string jql)
        {
            fields = mCustomFieldService.NamesToKeys(fields);
            int perBatch = 1000;
            int cursor = 0;

            List<Issue> issues = new List<Issue>();

            while (true)
            {
                var batch = mAPIClient.Search(fields, cursor, perBatch, jql);
                issues.AddRange(batch.Issues);
                cursor += batch.Issues.Length;

                if (!batch.Issues.Any())
                    break;
            }

            return issues.ToArray();
        }
    }
}
