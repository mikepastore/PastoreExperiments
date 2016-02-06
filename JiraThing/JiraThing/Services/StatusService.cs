using JiraThing.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JiraThing.Services
{
    public class StatusService
    {
        
        public Transition[] GetTransitionsFromActivity(IEnumerable<ActivityEntry> activity)
        {
            return activity.Select(TryParseTransition).RemoveEmpty().OrderBy(p=>p.Date).ToArray();
        }

        public static Phase GetPhaseFromStatus(string status)
        {
            switch (status)
            {
                case Status.Backlog:
                case Status.SelectedForDevelopment:
                case Status.Assigned:
                case Status.Reopened:
                case Status.OnDeck:
                case Status.ToDo:
                case Status.OnHold:
                    return Phase.Idle;
                case Status.InProgress:
                    return Phase.InProgress;
                case Status.NeedsReview:
                case Status.InReview:
                case Status.Followup:
                case Status.InternalReviewNeeded:
                case Status.AnalysisinProgress:
                case Status.SupportFollowUp:
                    return Phase.InReview;
                case Status.ReadyForQA:
                    return Phase.ReadyForQA;
                case Status.QAInProgress:
                case Status.InQA:
                    return Phase.InQA;
                case Status.ReadyForDeployment:
                    return Phase.ReadyToRelease;
                case Status.Closed:
                case Status.Done:
                case Status.Released:
                    return Phase.Closed;
                default:
                    return Phase.Unknown;

            }
        }

        private Transition TryParseTransition(ActivityEntry activity)
        {
            if (activity.Description.Contains("LMAM-217"))
                Console.WriteLine("X");

            if (activity.Description.Contains("created a link"))
                return null;

            var actionAndKey = SplitActionAndKey(activity.Description, "created");
            if (actionAndKey.Length == 2)
                return new Transition
                {
                    Author = activity.Author,
                    Date = activity.Date,
                    Key = actionAndKey[1],
                    NewStatus = "Backlog"
                };


            actionAndKey = SplitActionAndKey(activity.Description, "started progress on");
            if (actionAndKey.Length == 2)
                return new Transition
                {
                    Author = activity.Author,
                    Date = activity.Date,
                    Key = actionAndKey[1],
                    NewStatus = "In Progress"
                };

            actionAndKey = SplitActionAndKey(activity.Description, "changed the status to","on");
            if (actionAndKey.Length == 2)
                return new Transition
                {
                    Author = activity.Author,
                    Date = activity.Date,
                    Key = actionAndKey[1],
                    NewStatus = actionAndKey[0]
                };

            actionAndKey = SplitActionAndKey(activity.Description, "reopened");
            if (actionAndKey.Length == 2)
                return new Transition
                {
                    Author = activity.Author,
                    Date = activity.Date,
                    Key = actionAndKey[1],
                    NewStatus = Status.Reopened 
                };

            actionAndKey = SplitActionAndKey(activity.Description, "closed");
            if (actionAndKey.Length == 2)
                return new Transition
                {
                    Author = activity.Author,
                    Date = activity.Date,
                    Key = actionAndKey[1],
                    NewStatus = "Closed"
                };

            return null;

        }

        private string[] SplitActionAndKey(string description, string actionText, string splitWord=null)
        {
            if (!description.Contains(actionText))
                return new string[] { };
           
            if (!description.Contains(" - "))
                return new string[] { };

            description = description.Substring(0, description.IndexOf(" - "));
            description = description.Substring(description.IndexOf(actionText) + actionText.Length).Trim();

            if (splitWord == null)
                return new string[] { "", description };
            else 
                return description.Split(new string[]{" " + splitWord + " "}, StringSplitOptions.RemoveEmptyEntries);

        }

       
    }
}
