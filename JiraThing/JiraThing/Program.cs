using JiraThing.Models;
using JiraThing.Services;
using JiraThing.Services.Jira;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace JiraThing
{
    public static class Main
    {
        public static ReportService ConnectService()
        {
            var user = ConfigurationManager.AppSettings["jiraUser"];
            var pwd = ConfigurationManager.AppSettings["jiraPassword"];

            var apiClient = new JIRAAPIClient(user, pwd);
            var activityFeedReader = new CachedActivityFeedService(new LocalCacheService("ActivityFeeds"), new JiraActivityFeedService(user, pwd));
            var activityFeedService = new ActivityFeedService(activityFeedReader);
            var statusService = new StatusService();
            var durationService = new DurationService();
            var customFieldService = new CustomFieldService(apiClient);

            var searchService = new SearchService(apiClient, customFieldService);

            var reportService = new ReportService(searchService, activityFeedService, statusService, durationService);

            return reportService;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var user = ConfigurationManager.AppSettings["jiraUser"];
            var pwd = ConfigurationManager.AppSettings["jiraPassword"];

            var apiClient = new JIRAAPIClient(user, pwd);
            var activityFeedReader = new CachedActivityFeedService(new LocalCacheService("ActivityFeeds"), new JiraActivityFeedService(user, pwd));
            var activityFeedService = new ActivityFeedService(activityFeedReader);
            var statusService = new StatusService();
            var durationService = new DurationService();
            var customFieldService = new CustomFieldService(apiClient);

            var searchService = new SearchService(apiClient, customFieldService);
            var reportService = new ReportService(searchService, activityFeedService, statusService, durationService);
               
            DateTime reportDate;
            if (DateTime.Now.DayOfWeek == DayOfWeek.Monday)
                reportDate = DateTime.Now.AddDays(-3);
            else
                reportDate = DateTime.Now.AddDays(-1);

            var report = reportService.GetStandupReport(reportDate);
            var sb = new StringBuilder();            
            foreach(var standupUser in report.UserReports)
            {
                sb.Append("Standup Report for ").Append(standupUser.Developer).AppendLine() ;
                sb.Append("Total hours = ").Append(standupUser.Items.Sum(p => p.TimeLogged.TotalHours).ToString("0.0")).AppendLine();
                
                foreach (var item in standupUser.Items)
                {
                    sb.AppendFormat("{0}h ", item.TimeLogged.TotalHours.ToString("0.0"));
                    sb.Append(" ").Append(item.TicketSummary);
                    sb.Append(" - ").Append(item.Comment.Replace(Environment.NewLine,""));
                    sb.AppendLine();
                }

                sb.AppendLine("-----");
            }

            Console.WriteLine();
            Console.Write(sb.ToString());
            Console.WriteLine("Press any key to exit");
            Console.ReadKey();
        }

        static void Maina(string[] args)
        {         
            bool enableConsole = true;
            while (true)
            {
                string options;
                if (enableConsole)
                {
                    Console.WriteLine("Usage:");
                    Console.WriteLine("d (yyyy/M/d) - get report for a different day");
                    Console.WriteLine("y - gets report from yesterday, or last friday if today is monday");
                    Console.WriteLine("v (fix version) - generate ticket score report");
                    Console.WriteLine("t - include time");
                    Console.WriteLine("s - include ticket summary");
                    Console.WriteLine("c - include comments");
                    Console.WriteLine("q - quit");


                    Console.Write(">");
                    options = Console.ReadLine();
                    if (options.Contains("q"))
                        break;

                    Console.WriteLine("Loading...");
                }
                else
                {
                    options = String.Join(" ", args);
                    if (options.StartsWith("?"))
                    {
                        Console.WriteLine("Usage:");
                        Console.WriteLine("d (yyyy/M/d) - get report for a different day");
                        Console.WriteLine("y - gets report from yesterday, or last friday if today is monday");
                        Console.WriteLine("v (fix version) - generate ticket score report");
                  
                        Console.WriteLine("t - include time");
                        Console.WriteLine("s - include ticket summary");
                        Console.WriteLine("c - include comments");
                        break;
                    }
                    
                }
                var user = ConfigurationManager.AppSettings["jiraUser"];
                var pwd = ConfigurationManager.AppSettings["jiraPassword"];

                var apiClient = new JIRAAPIClient(user, pwd);
                var activityFeedReader = new CachedActivityFeedService(new LocalCacheService("ActivityFeeds"), new JiraActivityFeedService(user, pwd));
                var activityFeedService = new ActivityFeedService(activityFeedReader);
                var statusService = new StatusService();
                var durationService = new DurationService();
                var customFieldService = new CustomFieldService(apiClient);

                var searchService = new SearchService(apiClient, customFieldService);
                var reportService = new ReportService(searchService, activityFeedService, statusService, durationService);
                


                var reportDate = DateTime.Now;
                if (options.Contains("d"))
                    reportDate = DateTime.ParseExact(options.Substring(options.IndexOf("d")+2), "yyyy/M/d",null);
                
                if(options.Contains("y"))
                {
                    if (DateTime.Now.DayOfWeek == DayOfWeek.Monday)
                        reportDate = DateTime.Now.AddDays(-3);
                    else
                        reportDate = DateTime.Now.AddDays(-1);
                }

                if(options.Contains("v"))
                {
                    var sb = new StringBuilder();
                    var rpt = reportService.GetSprintScore(options.Substring(2));

                    foreach (var item in rpt)
                        sb.AppendFormat("{0} - {1}% ({2})", item.Key, (item.Score * 100).ToString("0"),
                            String.Join(",", item.TeamMembers)).AppendLine();
                            
                    Console.WriteLine(sb.ToString());
                }
                else if(options.Contains("a"))
                {
                    var sb = new StringBuilder();
                    var rpt = reportService.GetStoryPointAccuracy(options.Substring(2));

                    foreach (var item in rpt)
                        sb.AppendFormat("{0}    {1} {2} {3}", item.Key, item.StoryPoints * 8.0, item.TotalWorkLogged.TotalHours, item.TotalTimeInProgress.TotalHours).AppendLine();

                    Console.WriteLine(sb.ToString());
                }
                else
                { 
                    var report = reportService.GetStandupReport(reportDate);


                    var sb = new StringBuilder();
                    foreach(var standupUser in report.UserReports)
                    {
                        sb.Append("Standup Report for ").Append(standupUser.Developer).AppendLine() ;
                        foreach (var item in standupUser.Items)
                        {
                            if(options.Contains("t"))
                                    sb.AppendFormat("{0}h ", item.TimeLogged.TotalHours.ToString("0.0"));

                            if(!options.Contains("c"))  
                                sb.Append(item.Ticket);

                            if (options.Contains("s"))
                                sb.Append(" ").Append(item.TicketSummary);

                            if (options.Contains("c"))
                                sb.Append(" - ").Append(item.Comment.Replace(Environment.NewLine,""));
                            sb.AppendLine();
                        }

                        sb.AppendLine("-----");
                    }

                Console.Write(sb.ToString());
            }
                if (!enableConsole)
                    break;
            }
        }

        private static void Test()
        {

            //var service = new JiraService(client);


            //var transitionService = new JiraTransitionService();
            //var activity = feedReader.GetActivityForProject("LMAM");
            //var transitions = transitionService.ParseTransitions(activity);
            //var history = transitionService.ExtractHistory(transitions);
            //var stats = transitionService.GetHistoryStats(history.ToArray());

            //var fields = client.GetCustomFields();
            //fields = fields.Where(p => p.Name.Contains("Story")).ToArray();

            ////var jql ="fixVersion=8.8.36";
            ////   var jql = "status in (Closed, \"Ready for Deployment\") AND fixVersion in (8.8.31.0, 8.8.31.1, 8.8.32.0, 8.8.33.0, 8.8.34.0, 8.8.35.0, 8.8.36) ORDER BY cf[10004] ASC";
            //var jql = "project in (LMAM, LMDB, LMDEVOPS, LMEE, LMESIGS, LMBC, LMCSG2, LMCSG3, LM, LMTS, LMWP, LMWGA) AND status in (Closed, \"Ready for Deployment\") AND updated >= -30w ORDER BY cf[10004] ASC";
            //var work = service.GetWorkLog(jql);

            //var logCruncher = new WorkLogAnalyzer();
            //var results = logCruncher.CalculateStoryPointsVsTimeSpent(work).ToArray();

            //var csv = "Key,Story Points,Estimated Hours,Logged Hours" + Environment.NewLine +
            //    results.Select(p => p.ToString()).StringJoin(Environment.NewLine);


            //var results2 = logCruncher.CalculateDeveloperTimePerDay(work).ToArray();
            //var csv2 = "Developer,Day,Logged Hours" + Environment.NewLine +
            //    results2.Select(p => p.ToString()).StringJoin(Environment.NewLine);

            //var results3 = logCruncher.CalculateDeveloperAveragePerDay(work).ToArray();
            //var csv3 = "Developer,Average Logged Per Day" + Environment.NewLine +
            //    results3.Select(p => p.ToString()).StringJoin(Environment.NewLine);


        }

        
    }

  
   

    

   


}
