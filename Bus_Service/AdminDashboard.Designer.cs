namespace Bus_Service
{
    partial class AdminDashboard
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            label1 = new Label();
            btnTravelDetails = new Button();
            buttonOneWayRequests = new Button();
            buttonNotifications = new Button();
            labelNotificationCount = new Label();
            dataGridViewUpcomingTravels = new DataGridView();
            labelUpcomingTravels = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridViewUpcomingTravels).BeginInit();
            SuspendLayout();

            // label1
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            label1.ForeColor = System.Drawing.Color.FromArgb(0, 102, 204);
            label1.Location = new Point(250, 20);
            label1.Name = "label1";
            label1.Size = new Size(250, 41);
            label1.TabIndex = 0;
            label1.Text = "Admin Dashboard";

            // labelUpcomingTravels
            labelUpcomingTravels.AutoSize = true;
            labelUpcomingTravels.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            labelUpcomingTravels.ForeColor = System.Drawing.Color.FromArgb(0, 102, 204);
            labelUpcomingTravels.Location = new Point(20, 80);
            labelUpcomingTravels.Name = "labelUpcomingTravels";
            labelUpcomingTravels.Size = new Size(150, 21);
            labelUpcomingTravels.TabIndex = 5;
            labelUpcomingTravels.Text = "Upcoming Travels:";

            // dataGridViewUpcomingTravels
            dataGridViewUpcomingTravels.AllowUserToAddRows = false;
            dataGridViewUpcomingTravels.AllowUserToDeleteRows = false;
            dataGridViewUpcomingTravels.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewUpcomingTravels.Location = new Point(20, 110);
            dataGridViewUpcomingTravels.Name = "dataGridViewUpcomingTravels";
            dataGridViewUpcomingTravels.ReadOnly = true;
            dataGridViewUpcomingTravels.RowHeadersWidth = 51;
            dataGridViewUpcomingTravels.Size = new Size(660, 150);
            dataGridViewUpcomingTravels.TabIndex = 6;

            // btnTravelDetails
            btnTravelDetails.BackColor = System.Drawing.Color.FromArgb(0, 102, 204);
            btnTravelDetails.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnTravelDetails.ForeColor = System.Drawing.Color.White;
            btnTravelDetails.Location = new Point(50, 290);
            btnTravelDetails.Name = "btnTravelDetails";
            btnTravelDetails.Size = new Size(180, 50);
            btnTravelDetails.TabIndex = 1;
            btnTravelDetails.Text = "Travel Details";
            btnTravelDetails.UseVisualStyleBackColor = false;
            btnTravelDetails.Click += btnTravelDetails_Click;

            // buttonOneWayRequests
            buttonOneWayRequests.BackColor = System.Drawing.Color.FromArgb(0, 102, 204);
            buttonOneWayRequests.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            buttonOneWayRequests.ForeColor = System.Drawing.Color.White;
            buttonOneWayRequests.Location = new Point(270, 290);
            buttonOneWayRequests.Name = "buttonOneWayRequests";
            buttonOneWayRequests.Size = new Size(180, 50);
            buttonOneWayRequests.TabIndex = 2;
            buttonOneWayRequests.Text = "One-Way Requests";
            buttonOneWayRequests.UseVisualStyleBackColor = false;
            buttonOneWayRequests.Click += buttonOneWayRequests_Click;

            // buttonNotifications
            buttonNotifications.BackColor = System.Drawing.Color.FromArgb(0, 102, 204);
            buttonNotifications.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            buttonNotifications.ForeColor = System.Drawing.Color.White;
            buttonNotifications.Location = new Point(500, 290);
            buttonNotifications.Name = "buttonNotifications";
            buttonNotifications.Size = new Size(180, 50);
            buttonNotifications.TabIndex = 3;
            buttonNotifications.Text = "Notifications";
            buttonNotifications.UseVisualStyleBackColor = false;
            buttonNotifications.Click += buttonNotifications_Click;

            // labelNotificationCount
            labelNotificationCount.AutoSize = true;
            labelNotificationCount.BackColor = System.Drawing.Color.Red;
            labelNotificationCount.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            labelNotificationCount.ForeColor = System.Drawing.Color.White;
            labelNotificationCount.Location = new Point(670, 295);
            labelNotificationCount.Name = "labelNotificationCount";
            labelNotificationCount.Size = new Size(18, 19);
            labelNotificationCount.TabIndex = 4;
            labelNotificationCount.Text = "0";
            labelNotificationCount.Visible = false;

            // AdminDashboard
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = System.Drawing.Color.White;
            ClientSize = new Size(700, 420);
            Controls.Add(dataGridViewUpcomingTravels);
            Controls.Add(labelUpcomingTravels);
            Controls.Add(labelNotificationCount);
            Controls.Add(buttonNotifications);
            Controls.Add(buttonOneWayRequests);
            Controls.Add(btnTravelDetails);
            Controls.Add(label1);
            Name = "AdminDashboard";
            Text = "Admin Dashboard";
            FormClosing += AdminDashboard_FormClosing;
            Load += AdminDashboard_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridViewUpcomingTravels).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #region Designer generated code
        #endregion

        private Label label1;
        private Button btnTravelDetails;
        private Button buttonOneWayRequests;
        private Button buttonNotifications;
        private Label labelNotificationCount;
        private DataGridView dataGridViewUpcomingTravels;
        private Label labelUpcomingTravels;
    }
}
