using JiraThing.Models;
using JiraThing.Services;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JiraReportUI
{

    class ReportSnapshotImageInfo
    {
        public int PixelsPerTicket;
        public int ImageHeight;
        public Dictionary<Phase, float> PhasePositions = new Dictionary<Phase, float>();
        public Dictionary<Phase, Color> PhaseColors = new Dictionary<Phase, Color>();

        public Color ForwardColor;
        public Color BackwardColor;
        public Color StillColor;
    }

    class ReportSnapshot
    {
        public DateTime Date;
        public TicketStatus[] Tickets;
        public Bitmap Image;

        private ReportSnapshot() { }

        public static ReportSnapshot Create(TicketHistory[] history, DateTime time, ReportSnapshotImageInfo imageInfo)
        {
            var ret = new ReportSnapshot();
            ret.Date = time;

            ret.Tickets = history.Select(ret.GetTicketSnapshot).ToArray(); 
            ret.Image = ret.CreateImage(imageInfo);
            return ret;
        }

        private TicketStatus GetTicketSnapshot(TicketHistory history)
        {
            var statusBefore = history.Transitions.LastOrDefault(p => p.Date < this.Date)
                ?? history.Transitions.First();

            var statusAfter = history.Transitions.FirstOrDefault(p => p.Date > this.Date)
                ?? history.Transitions.Last();
            
            var timespan = statusAfter.Date - statusBefore.Date;
            var snapshotTime = this.Date - statusBefore.Date;
            float progress = (float)snapshotTime.TotalSeconds / (float)timespan.TotalSeconds;
            if (float.IsInfinity(progress) || float.IsNaN(progress))
                progress = 1f;

            return new TicketStatus
            {
                ExistedAtTime = history.Transitions[0].Date <= this.Date,
                Key = history.Key,
                CurrentStatus = statusBefore.NewStatus,
                NextStatus = statusAfter.NewStatus,
                ProgressInStatus = progress
            };




        }

        private Bitmap CreateImage(ReportSnapshotImageInfo imageInfo)
        {
            var image = new Bitmap(this.Tickets.Length * imageInfo.PixelsPerTicket, imageInfo.ImageHeight);

            var forwardBrush = new SolidBrush(imageInfo.ForwardColor);
            var backwardBrush = new SolidBrush(imageInfo.BackwardColor);
            var stillBrush = new SolidBrush(imageInfo.StillColor);

            using(var g = Graphics.FromImage(image))
            {
                DrawImageBackground(g, image, imageInfo);
                int index = 0;
                foreach(var ticket in Tickets)
                {
                    if (!ticket.ExistedAtTime)
                        continue;

                    float overallProgress = 0;

                    var currentStatusPosition = imageInfo.PhasePositions[StatusService.GetPhaseFromStatus(ticket.CurrentStatus)];
                    var nextStatusPosition = imageInfo.PhasePositions[StatusService.GetPhaseFromStatus(ticket.NextStatus)];
                    overallProgress = currentStatusPosition + ((nextStatusPosition - currentStatusPosition) * ticket.ProgressInStatus);

                    int x = index * imageInfo.PixelsPerTicket;
                    int y = image.Height - (int)(image.Height * overallProgress);

                    Brush brush;
                    if (currentStatusPosition < nextStatusPosition)
                        brush = forwardBrush;
                    else if (currentStatusPosition > nextStatusPosition)
                        brush = backwardBrush;
                    else
                        brush = stillBrush;

                    g.FillRectangle(brush, new Rectangle(x,y,imageInfo.PixelsPerTicket,imageInfo.PixelsPerTicket));
                    index++;
                }    
            }

            forwardBrush.Dispose();
            backwardBrush.Dispose();
            stillBrush.Dispose();
            return image;
        }

        private void DrawImageBackground(Graphics g, Bitmap image, ReportSnapshotImageInfo imageInfo)
        {
            var brushes = imageInfo.PhaseColors.ToDictionary(p => p.Key, p => new SolidBrush(p.Value));

            Rectangle area = new Rectangle(0, image.Height, image.Width, 0);

            foreach(var phase in brushes.Keys)
            {
                var bottom = area.Y;
                area.Y = image.Height - (int)(imageInfo.PhasePositions[phase] * image.Height);
                area.Height = bottom - area.Y;
                g.FillRectangle(brushes[phase], area);
            }

            foreach (var brush in brushes)
                brush.Value.Dispose();

        }
      
    }
}
