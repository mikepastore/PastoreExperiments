using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JiraThing.Models
{
    public class Fields
    {
        public const string StoryPoints = "Story Points";
    }

    public class Status
    {
        public const string Backlog = "Backlog";
        public const string Assigned = "Assigned";
        public const string OnDeck = "On Deck";
        public const string ToDo = "To Do";
        public const string OnHold = "On Hold";

        public const string SelectedForDevelopment = "Selected for Development";
        public const string InProgress = "In Progress";
        public const string Reopened = "Reopened";

        public const string InReview = "In Review";
        public const string NeedsReview = "Needs Review";
        public const string InternalReviewNeeded = "Internal review needed";
        public const string AnalysisinProgress = "Analysis in Progress";
        public const string SupportFollowUp = "Support Follow Up";
      
        public const string ReadyForQA = "Ready for QA";
        public const string QAInProgress = "QA In Progress";
        public const string InQA = "In QA";

        public const string ReadyForDeployment = "Ready for Deployment";
        
        public const string Closed = "Closed";
        public const string Released = "Released";
        public const string Done = "Done";

        public const string Followup = "Follow Up";
    }

    public enum Phase
    {
        Idle,
        InProgress,
        InReview,
        ReadyForQA,
        InQA,
        ReadyToRelease,
        Closed,
        Unknown
    }
}
