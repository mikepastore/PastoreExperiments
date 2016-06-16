using JiraThing.Models;
using JiraThing.Models.Reports;
using JiraThing.Services.Jira;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JiraThing.Services
{
    public class ReportService
    {
        private SearchService mSearchService;
        private ActivityFeedService mActivityFeedService;
        private StatusService mStatusService;
        private DurationService mDurationService;
       
        public ReportService(SearchService searchService, ActivityFeedService activityFeedService, StatusService statusService, DurationService durationService)
        {
            mSearchService = searchService;
            mActivityFeedService = activityFeedService;
            mStatusService = statusService;
            mDurationService = durationService;
        }

        public IEnumerable<DeveloperAveragePerDay> GetDailyWorkflowReport(string jql)
        {
            var tickets = mSearchService.Search(jql);

            var workLogs = tickets.SelectMany(p => p.WorkLog).Where(p => p.Started > DateTime.Now.GetMorningTime()).ToArray();

            foreach(var dev in workLogs.GroupBy(p=>p.author.displayName))
            {
                yield return new DeveloperAveragePerDay
                {
                    Developer = dev.Key,
                    AverageTimeLogged = TimeSpan.FromSeconds(dev.Sum(p => p.timeSpentSeconds))
                };
            }

        }

        public TicketHistory[] GetHistory(string jql, Action<int> fnProgress = null)
        {
            var ret = new List<TicketHistory>();

            if (fnProgress == null)
                fnProgress = (pct) => { };

            fnProgress(0);
            var tickets = mSearchService.Search(jql).OrderBy(p => p.Created);
            fnProgress(10);

            int ticketsLoaded=0;
            foreach(var ticket in tickets)
            {
                var history = new TicketHistory { Key = ticket.Key, Description = ticket.Summary, StoryPoints = ticket.StoryPoints };
                var activity = mActivityFeedService.GetActivityForItem(ticket.Key);
                history.Transitions = mStatusService.GetTransitionsFromActivity(activity);
                ret.Add(history);

                ticketsLoaded++;
                var progress = (float)ticketsLoaded / (float)tickets.Count();

                fnProgress(10 + (int)(90 * progress));
            }

            return ret.ToArray();
        }

        public StoryPointAccuracyReport[] GetStoryPointAccuracy(string jql)
        {
          //  var jql = String.Format("fixVersion={0}", fixVersion);
            var times = GetTimeReport(new DateTime(2016,1,18),jql);

           // return times.Where(p=>p.StoryPoints >= 0 && (p.ReadyForDeployment.TotalHours > 0 || p.Finished.HasValue)).Select(p => new StoryPointAccuracyReport
            return times.Select(p => new StoryPointAccuracyReport
           
            {
                Key = p.Key,
                Description = p.Summary,
                StoryPoints = p.StoryPoints,
                TotalWorkLogged = p.WorkLogged,
                TotalTimeInProgress = p.InProgress,
                Finished = p.Finished.HasValue || p.ReadyForDeployment.TotalHours > 0
            }).ToArray();
        }

        public TicketScore[] GetSprintScore(string fixVersion)
        {
            var jql = String.Format("fixVersion = {0}", fixVersion);

            var tickets = mSearchService.Search(jql);

            
            var ticketScores = tickets.Select(CalculateTicketScore)
                .OrderBy(p=>p.Score).ToList();

         
            ticketScores.Insert(0, new TicketScore
            {
                Key = "Total",
                TeamMembers = ticketScores.SelectMany(p => p.TeamMembers).Distinct().ToArray(),
                Score = ticketScores.Average(p => p.Score)
            });

            return ticketScores.ToArray();
        }

        private TicketScore CalculateTicketScore(AccelaJiraTicket ticket)
        {

            var loggedTime = TimeSpan.FromSeconds(ticket.WorkLog.Sum(p => p.timeSpentSeconds));

            var expectedTime = TimeSpan.FromHours(8 * ticket.StoryPoints);

            var score = 0f;

            switch(StatusService.GetPhaseFromStatus(ticket.Status))
            {
                case Phase.Closed:
                case Phase.ReadyToRelease:
                    score = 1;
                    break;
                case Phase.InProgress:
                case Phase.Idle:
                    if (loggedTime < expectedTime)
                        score = .6f * (float)(loggedTime.TotalHours / expectedTime.TotalHours);
                    else
                        score = .6f;
                    break;
                case Phase.InReview:
                    score = .7f;
                    break;
                case Phase.InQA:
                    score = .8f;
                    break;
            }

            return new TicketScore
            {
                Key = ticket.Key,
                TeamMembers = ticket.WorkLog.Select(p => p.author.displayName).Distinct().ToArray(),
                Score = score
            };

        }

        public StandupReport GetStandupReport(DateTime day)
        {
            var jql = string.Format("project = LM AND updated >= {0} AND updated <= {1}",
                day.AddDays(-1).ToString("yyyy-MM-dd"),
                day.AddDays(1).ToString("yyyy-MM-dd"));

            var tickets = mSearchService.Search(jql);

            var report = new StandupReport() { UserReports = new List<StandupUserReport>() };
           
            foreach(var ticket in tickets)
            {
                Console.Write(".");
                var history = mActivityFeedService.GetActivityForItem(ticket.Key);
                var devWorkItems = ticket.WorkLog.Where(p => p.Started > day.GetMorningTime() && p.Started < day.AddDays(1).GetMorningTime())
                    .GroupBy(p => p.author.displayName);

                foreach(var workItems in devWorkItems)
                {
                    var author = workItems.Key;

                    var userHistory = history.Where(p => p.Author == author);
                    var devReport = report.UserReports.FirstOrDefault(p => p.Developer == author);
                    if (devReport == null)
                    {
                        devReport = new StandupUserReport { Developer = author, Items = new List<StandupItem>() };
                        report.UserReports.Add(devReport);
                    }

                    var transitions = mStatusService.GetTransitionsFromActivity(userHistory);

                    var sbLog = new StringBuilder();

                    if (transitions.Any(p => p.NewStatus == Status.Closed))
                        sbLog.Append("Closed ");
                    else if (transitions.Any(p => p.NewStatus == Status.ReadyForDeployment))
                        sbLog.Append("Tested ");
                    else if (transitions.Any(p => p.NewStatus == Status.InQA))
                        sbLog.Append("Started testing ");
                    else if (transitions.Any(p => p.NewStatus == Status.ReadyForQA))
                        sbLog.Append("Reviewed ");
                    else if (transitions.Any(p => p.NewStatus == Status.NeedsReview))
                        sbLog.Append("Worked on ");
                    else if (transitions.Any(p => p.NewStatus == Status.InProgress))
                        sbLog.Append("Started ");
                    else if (transitions.Any(p => p.NewStatus == Status.Reopened))
                        sbLog.Append("Sent back ");
                  
                    sbLog.Append(ticket.Key);
                    sbLog.Append(". ");

                    foreach(var comment in workItems.Select(p=>p.Comment))
                    {
                        if(!String.IsNullOrEmpty(comment.Trim()))
                        {
                            var lf = comment.Trim().IndexOf(Environment.NewLine);
                            if (lf > -1)
                                sbLog.Append(" ").Append(comment.Substring(0, lf));
                            else 
                                sbLog.Append(" ").Append(comment);
                        }
                    }

                    devReport.Items.Add(new StandupItem
                    {
                        Ticket = ticket.Key,
                        TicketSummary = ticket.Summary,
                        Comment = sbLog.ToString(),
                        TimeLogged = TimeSpan.FromSeconds(workItems.Sum(p => p.timeSpentSeconds))
                    });
                }
                
            }

            return report;
        }

        public IEnumerable<TicketTimeReport> GetTimeReport(DateTime workLogBegin, string jql)
        {
            var tickets = mSearchService.Search(jql);
        
            foreach (var ticket in tickets)
            {
                var activity = mActivityFeedService.GetActivityForItem(ticket.Key);
                var transitions = mStatusService.GetTransitionsFromActivity(activity);


                var ret = new TicketTimeReport { Key = ticket.Key, StoryPoints = ticket.StoryPoints };
                ret.Summary = ticket.Summary;
                ret.Idle = TimeSpan.Zero;
                ret.BeforeWorkStarted = TimeSpan.Zero;
                ret.InProgress = TimeSpan.Zero;
                ret.InReview = TimeSpan.Zero;
                ret.InQA = TimeSpan.Zero;
                ret.ReadyForDeployment = TimeSpan.Zero;

                ret.WorkLogged = TimeSpan.FromSeconds(ticket.WorkLog.Where(p=>p.Started > workLogBegin).Sum(p => p.timeSpentSeconds));

                bool foundStart=false;
                var lastPhase = Phase.Idle;
                if (ret.Key == "LMAM-43")
                    Console.Write("X");

                for(int i = 0; i < transitions.Length-1;i++)
                {
                    var duration = mDurationService.GetAdjustedDuration(transitions[i].Date, transitions[i+1].Date);
                    var transition = transitions[i];

                    bool wasInReviewOrFinished = lastPhase == Phase.InReview || lastPhase == Phase.InQA || lastPhase == Phase.ReadyToRelease || lastPhase == Phase.Closed;
                    bool wasReady = lastPhase == Phase.ReadyToRelease || lastPhase == Phase.Closed;

             
                    switch(StatusService.GetPhaseFromStatus(transition.NewStatus))
                    {
                        case Phase.Idle:

                            if(!foundStart)
                                ret.BeforeWorkStarted = ret.BeforeWorkStarted.Add(duration);
                            else
                                ret.Idle = ret.Idle.Add(duration);

                            if (wasInReviewOrFinished)
                                ret.TimesRejected++;
                            if (wasReady)
                                ret.TimesRejectedFromReady++;

                            break;
                        case Phase.InProgress:
                            if (!foundStart)
                                ret.Started = transition.Date;
                            foundStart=true;
                            if(transition.Date >= workLogBegin)
                                ret.InProgress = ret.InProgress.Add(duration);

                            if (wasInReviewOrFinished)
                                ret.TimesRejected++;
                            if (wasReady)
                                ret.TimesRejectedFromReady++;

                            break;
                        case Phase.InReview:
                            ret.InReview = ret.InReview.Add(duration);
                            break;
                        case Phase.InQA:
                            ret.InQA = ret.InQA.Add(duration);
                            break;
                        case Phase.ReadyToRelease:
                            ret.ReadyForDeployment = ret.ReadyForDeployment.Add(duration);
                            break;
                        case Phase.Closed:
                            ret.Finished = transition.Date;
                            break;
                   }

                    lastPhase = StatusService.GetPhaseFromStatus(transition.NewStatus);
                }

                if (ret.Started.HasValue && ret.Finished.HasValue)
                {
                    ret.StartToFinish = mDurationService.GetAdjustedDuration(ret.Started.Value, ret.Finished.Value);
                }

             

                yield return ret;
            }

            
        }
    }
}
