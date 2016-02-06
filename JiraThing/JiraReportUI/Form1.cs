using JiraThing.Models;
using JiraThing.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JiraReportUI
{
    public partial class Form1 : Form
    {
        private ReportService mService;
        private TicketHistory[] mHistory;
        private List<ReportSnapshot> mSnapshots = new List<ReportSnapshot>();
        private ReportSnapshot mDisplayedSnapshot;
        private ReportSnapshotImageInfo mImageInfo;
        private Rectangle mCurrentImageDisplaySize;

        public Form1()
        {
            InitializeComponent();

            var info = new ReportSnapshotImageInfo();
            info.PixelsPerTicket = 2;
            info.ImageHeight = 100;
            info.PhasePositions.Add(Phase.Unknown, 0f);
            info.PhasePositions.Add(Phase.Idle, .1f);
            info.PhasePositions.Add(Phase.InProgress, .5f);
            info.PhasePositions.Add(Phase.InReview, .55f);
            info.PhasePositions.Add(Phase.ReadyForQA, .6f);
            info.PhasePositions.Add(Phase.InQA, .9f);
            info.PhasePositions.Add(Phase.ReadyToRelease, .95f);
            info.PhasePositions.Add(Phase.Closed, 1f);

            info.PhaseColors.Add(Phase.Idle, Color.LightGray);
            info.PhaseColors.Add(Phase.InProgress, Color.LightYellow);
            info.PhaseColors.Add(Phase.InReview, Color.Orange);
            info.PhaseColors.Add(Phase.ReadyForQA, Color.LightSeaGreen);
            info.PhaseColors.Add(Phase.InQA, Color.LightBlue);
            info.PhaseColors.Add(Phase.ReadyToRelease, Color.LightGreen);

            info.ForwardColor = Color.Green;
            info.BackwardColor = Color.Red;
            info.StillColor = Color.Purple;

            mImageInfo = info;

            mService = JiraThing.Main.ConnectService();
            jql.Text = "Sprint = 628";
            startDate.Value = new DateTime(2016, 1, 18);
            endDate.Value = startDate.Value.AddDays(14);

            RecalculateReport();
        }

        private void RecalculateReport()
        {
            time.Value = 0;
            mSnapshots.Clear();
            mHistory = new TicketHistory[] { };

            progressPanel.Visible = true;
            progressBar1.Value = 0;
            backgroundWorker1.RunWorkerAsync(jql.Text);           
        }

        private void time_Scroll(object sender, EventArgs e)
        {
            UpdateCurrentImage();
        }

        private void UpdateCurrentImage()
        {
            var span = (endDate.Value - startDate.Value).TotalHours;

            var pct = (double)time.Value / (double)time.Maximum;

            var spanPct = span * pct;

            var selectedTime = startDate.Value.AddHours(spanPct);
            
            var report = mSnapshots.FirstOrDefault(p => p.Date.Equals(selectedTime));
            if (report == null)
            {
                report = ReportSnapshot.Create(mHistory, selectedTime, mImageInfo);
                mSnapshots.Add(report);
            }
            mDisplayedSnapshot = report;
            display.Refresh();
        }

        private void display_Paint(object sender, PaintEventArgs e)
        {
            if (mDisplayedSnapshot == null || mDisplayedSnapshot.Image == null)
                return;

            var img = mDisplayedSnapshot.Image;

            Rectangle targetSize;
            
            //targetSize = new Rectangle(0,0,display.Width,(int)(display.Width * ((float)img.Height / (float)img.Width)));

            //if (targetSize.Height > display.Height)
            //    targetSize = new Rectangle(0, 0, (int)(display.Width * ((float)img.Width / (float)img.Height)), display.Height);


            targetSize = new Rectangle(0, 0, display.Width, display.Height);
            mCurrentImageDisplaySize = targetSize;
            var g = e.Graphics;
            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
            g.DrawImage(mDisplayedSnapshot.Image, targetSize);

        }
        private void startDate_ValueChanged(object sender, EventArgs e)
        {
            if (twoWeeks.Checked)
                endDate.Value = startDate.Value.AddDays(14);
        }

        private void goButton_Click(object sender, EventArgs e)
        {
            RecalculateReport();
            time.Value = 0;
        }

        private void animate_Click(object sender, EventArgs e)
        {
            if (timer1.Enabled)
                timer1.Enabled = false;
            else
            {
                time.Value = 0;
                timer1.Enabled = true;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            int step = (int)(time.Maximum / 100f);
            var newValue = time.Value + step;

            if (newValue > time.Maximum)
            {
                newValue = time.Maximum;
                timer1.Enabled = false;
            }

            time.Value = newValue;
            UpdateCurrentImage();
        }

        private void display_MouseMove(object sender, MouseEventArgs e)
        {
            if (mDisplayedSnapshot == null)
                return;

            var xScale = (float)mCurrentImageDisplaySize.Width / (float)mDisplayedSnapshot.Image.Width;
            var yScale = (float)mCurrentImageDisplaySize.Height / (float)mDisplayedSnapshot.Image.Height;

            var imagePoint = new Point((int)(e.X / xScale), (int)(e.Y / yScale));

            var ticketIndex = imagePoint.X / mImageInfo.PixelsPerTicket;
            if (ticketIndex < 0 || ticketIndex >= mHistory.Count())
                label1.Text = "";
            else 
                label1.Text = string.Format("{0} {1} on {2}",
                    mHistory[ticketIndex].Key, mHistory[ticketIndex].Description,startDate.Value.AddHours(time.Value).ToString("MMM d yyyy hh:mm tt"));
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            var jql = (string)e.Argument;

            mHistory = mService.GetHistory(jql, pct => backgroundWorker1.ReportProgress(pct));

        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;

        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            progressPanel.Visible = false;
        }

        
    }
}
