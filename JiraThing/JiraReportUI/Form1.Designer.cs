namespace JiraReportUI
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.display = new System.Windows.Forms.Panel();
            this.progressPanel = new System.Windows.Forms.Panel();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.time = new System.Windows.Forms.TrackBar();
            this.options = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.twoWeeks = new System.Windows.Forms.CheckBox();
            this.goButton = new System.Windows.Forms.Button();
            this.endDate = new System.Windows.Forms.DateTimePicker();
            this.startDate = new System.Windows.Forms.DateTimePicker();
            this.jql = new System.Windows.Forms.TextBox();
            this.animate = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.display.SuspendLayout();
            this.progressPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.time)).BeginInit();
            this.options.SuspendLayout();
            this.SuspendLayout();
            // 
            // display
            // 
            this.display.Controls.Add(this.progressPanel);
            this.display.Dock = System.Windows.Forms.DockStyle.Fill;
            this.display.Location = new System.Drawing.Point(0, 103);
            this.display.Name = "display";
            this.display.Size = new System.Drawing.Size(833, 306);
            this.display.TabIndex = 0;
            this.display.Paint += new System.Windows.Forms.PaintEventHandler(this.display_Paint);
            this.display.MouseMove += new System.Windows.Forms.MouseEventHandler(this.display_MouseMove);
            // 
            // progressPanel
            // 
            this.progressPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.progressPanel.BackColor = System.Drawing.Color.DimGray;
            this.progressPanel.Controls.Add(this.progressBar1);
            this.progressPanel.Location = new System.Drawing.Point(75, 88);
            this.progressPanel.Name = "progressPanel";
            this.progressPanel.Size = new System.Drawing.Size(674, 100);
            this.progressPanel.TabIndex = 0;
            this.progressPanel.Visible = false;
            // 
            // progressBar1
            // 
            this.progressBar1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBar1.Location = new System.Drawing.Point(16, 10);
            this.progressBar1.Margin = new System.Windows.Forms.Padding(10);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(640, 80);
            this.progressBar1.TabIndex = 0;
            // 
            // time
            // 
            this.time.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.time.LargeChange = 15;
            this.time.Location = new System.Drawing.Point(0, 409);
            this.time.Maximum = 100;
            this.time.Name = "time";
            this.time.Size = new System.Drawing.Size(833, 45);
            this.time.TabIndex = 0;
            this.time.Scroll += new System.EventHandler(this.time_Scroll);
            // 
            // options
            // 
            this.options.Controls.Add(this.label1);
            this.options.Controls.Add(this.twoWeeks);
            this.options.Controls.Add(this.goButton);
            this.options.Controls.Add(this.endDate);
            this.options.Controls.Add(this.startDate);
            this.options.Controls.Add(this.jql);
            this.options.Dock = System.Windows.Forms.DockStyle.Top;
            this.options.Location = new System.Drawing.Point(0, 0);
            this.options.Name = "options";
            this.options.Size = new System.Drawing.Size(833, 103);
            this.options.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 61);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 13);
            this.label1.TabIndex = 5;
            // 
            // twoWeeks
            // 
            this.twoWeeks.AutoSize = true;
            this.twoWeeks.Checked = true;
            this.twoWeeks.CheckState = System.Windows.Forms.CheckState.Checked;
            this.twoWeeks.Location = new System.Drawing.Point(436, 28);
            this.twoWeeks.Name = "twoWeeks";
            this.twoWeeks.Size = new System.Drawing.Size(84, 17);
            this.twoWeeks.TabIndex = 4;
            this.twoWeeks.Text = "Two Weeks";
            this.twoWeeks.UseVisualStyleBackColor = true;
            // 
            // goButton
            // 
            this.goButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.goButton.Location = new System.Drawing.Point(746, 26);
            this.goButton.Name = "goButton";
            this.goButton.Size = new System.Drawing.Size(75, 23);
            this.goButton.TabIndex = 3;
            this.goButton.Text = "Go";
            this.goButton.UseVisualStyleBackColor = true;
            this.goButton.Click += new System.EventHandler(this.goButton_Click);
            // 
            // endDate
            // 
            this.endDate.Location = new System.Drawing.Point(220, 26);
            this.endDate.Name = "endDate";
            this.endDate.Size = new System.Drawing.Size(200, 20);
            this.endDate.TabIndex = 2;
            // 
            // startDate
            // 
            this.startDate.Location = new System.Drawing.Point(3, 26);
            this.startDate.Name = "startDate";
            this.startDate.Size = new System.Drawing.Size(200, 20);
            this.startDate.TabIndex = 1;
            this.startDate.ValueChanged += new System.EventHandler(this.startDate_ValueChanged);
            // 
            // jql
            // 
            this.jql.Dock = System.Windows.Forms.DockStyle.Top;
            this.jql.Location = new System.Drawing.Point(0, 0);
            this.jql.Name = "jql";
            this.jql.Size = new System.Drawing.Size(833, 20);
            this.jql.TabIndex = 0;
            // 
            // animate
            // 
            this.animate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.animate.Location = new System.Drawing.Point(758, 431);
            this.animate.Name = "animate";
            this.animate.Size = new System.Drawing.Size(75, 23);
            this.animate.TabIndex = 0;
            this.animate.Text = "Animate";
            this.animate.UseVisualStyleBackColor = true;
            this.animate.Click += new System.EventHandler(this.animate_Click);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.WorkerReportsProgress = true;
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker1_ProgressChanged);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(833, 454);
            this.Controls.Add(this.animate);
            this.Controls.Add(this.display);
            this.Controls.Add(this.time);
            this.Controls.Add(this.options);
            this.DoubleBuffered = true;
            this.Name = "Form1";
            this.Text = "Form1";
            this.display.ResumeLayout(false);
            this.progressPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.time)).EndInit();
            this.options.ResumeLayout(false);
            this.options.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel display;
        private System.Windows.Forms.TrackBar time;
        private System.Windows.Forms.Panel options;
        private System.Windows.Forms.DateTimePicker endDate;
        private System.Windows.Forms.DateTimePicker startDate;
        private System.Windows.Forms.TextBox jql;
        private System.Windows.Forms.Button goButton;
        private System.Windows.Forms.CheckBox twoWeeks;
        private System.Windows.Forms.Button animate;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel progressPanel;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
    }
}

