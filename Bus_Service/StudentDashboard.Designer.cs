namespace Bus_Service
{
    partial class StudentDashboard
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
            groupBox1 = new GroupBox();
            lblDept = new Label();
            lblName = new Label();
            label2 = new Label();
            label1 = new Label();
            label5 = new Label();
            btnBookTravel = new Button();
            btnCancelBooking = new Button();
            btnLogout = new Button();
            btnOneWayRequest = new Button();
            dataGridViewUpcomingTravels = new DataGridView();
            labelUpcomingTravels = new Label();
            labelMyBookings = new Label();
            dataGridViewMyBookings = new DataGridView();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewUpcomingTravels).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridViewMyBookings).BeginInit();
            SuspendLayout();

            // groupBox1
            groupBox1.BackColor = System.Drawing.Color.FromArgb(240, 240, 240);
            groupBox1.Controls.Add(lblDept);
            groupBox1.Controls.Add(lblName);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(label1);
            groupBox1.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            groupBox1.ForeColor = System.Drawing.Color.FromArgb(0, 102, 204);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(776, 80);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Student Information";
            groupBox1.Enter += groupBox1_Enter;

            // lblDept
            lblDept.AutoSize = true;
            lblDept.ForeColor = System.Drawing.Color.Black;
            lblDept.Location = new Point(420, 35);
            lblDept.Name = "lblDept";
            lblDept.Size = new Size(0, 19);
            lblDept.TabIndex = 5;

            // lblName
            lblName.AutoSize = true;
            lblName.ForeColor = System.Drawing.Color.Black;
            lblName.Location = new Point(120, 35);
            lblName.Name = "lblName";
            lblName.Size = new Size(0, 19);
            lblName.TabIndex = 4;

            // label2
            label2.AutoSize = true;
            label2.Location = new Point(320, 35);
            label2.Name = "label2";
            label2.Size = new Size(100, 19);
            label2.TabIndex = 1;
            label2.Text = "Department:";

            // label1
            label1.AutoSize = true;
            label1.Location = new Point(20, 35);
            label1.Name = "label1";
            label1.Size = new Size(60, 19);
            label1.TabIndex = 0;
            label1.Text = "Name:";

            // label5
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label5.ForeColor = System.Drawing.Color.FromArgb(0, 102, 204);
            label5.Location = new Point(12, 110);
            label5.Name = "label5";
            label5.Size = new Size(150, 21);
            label5.TabIndex = 4;
            label5.Text = "Upcoming Travels:";

            // labelUpcomingTravels
            labelUpcomingTravels.AutoSize = true;
            labelUpcomingTravels.Location = new Point(12, 110);
            labelUpcomingTravels.Name = "labelUpcomingTravels";
            labelUpcomingTravels.Size = new Size(0, 15);
            labelUpcomingTravels.TabIndex = 11;
            labelUpcomingTravels.Visible = false;

            // dataGridViewUpcomingTravels
            dataGridViewUpcomingTravels.AllowUserToAddRows = false;
            dataGridViewUpcomingTravels.AllowUserToDeleteRows = false;
            dataGridViewUpcomingTravels.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewUpcomingTravels.Location = new Point(12, 135);
            dataGridViewUpcomingTravels.Name = "dataGridViewUpcomingTravels";
            dataGridViewUpcomingTravels.ReadOnly = true;
            dataGridViewUpcomingTravels.RowHeadersWidth = 51;
            dataGridViewUpcomingTravels.Size = new Size(776, 120);
            dataGridViewUpcomingTravels.TabIndex = 6;

            // labelMyBookings
            labelMyBookings.AutoSize = true;
            labelMyBookings.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            labelMyBookings.ForeColor = System.Drawing.Color.FromArgb(0, 102, 204);
            labelMyBookings.Location = new Point(12, 270);
            labelMyBookings.Name = "labelMyBookings";
            labelMyBookings.Size = new Size(120, 21);
            labelMyBookings.TabIndex = 7;
            labelMyBookings.Text = "My Bookings:";

            // dataGridViewMyBookings
            dataGridViewMyBookings.AllowUserToAddRows = false;
            dataGridViewMyBookings.AllowUserToDeleteRows = false;
            dataGridViewMyBookings.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewMyBookings.Location = new Point(12, 295);
            dataGridViewMyBookings.Name = "dataGridViewMyBookings";
            dataGridViewMyBookings.ReadOnly = true;
            dataGridViewMyBookings.RowHeadersWidth = 51;
            dataGridViewMyBookings.Size = new Size(776, 120);
            dataGridViewMyBookings.TabIndex = 8;

            // btnBookTravel
            btnBookTravel.BackColor = System.Drawing.Color.FromArgb(0, 102, 204);
            btnBookTravel.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnBookTravel.ForeColor = System.Drawing.Color.White;
            btnBookTravel.Location = new Point(50, 430);
            btnBookTravel.Name = "btnBookTravel";
            btnBookTravel.Size = new Size(120, 35);
            btnBookTravel.TabIndex = 5;
            btnBookTravel.Text = "Book Travel";
            btnBookTravel.UseVisualStyleBackColor = false;
            btnBookTravel.Click += btnBookTravel_Click;

            // btnCancelBooking
            btnCancelBooking.BackColor = System.Drawing.Color.FromArgb(204, 0, 0);
            btnCancelBooking.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnCancelBooking.ForeColor = System.Drawing.Color.White;
            btnCancelBooking.Location = new Point(200, 430);
            btnCancelBooking.Name = "btnCancelBooking";
            btnCancelBooking.Size = new Size(120, 35);
            btnCancelBooking.TabIndex = 9;
            btnCancelBooking.Text = "Cancel Booking";
            btnCancelBooking.UseVisualStyleBackColor = false;
            btnCancelBooking.Click += btnCancelBooking_Click;

            // btnOneWayRequest
            btnOneWayRequest.BackColor = System.Drawing.Color.FromArgb(0, 153, 76);
            btnOneWayRequest.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnOneWayRequest.ForeColor = System.Drawing.Color.White;
            btnOneWayRequest.Location = new Point(350, 430);
            btnOneWayRequest.Name = "btnOneWayRequest";
            btnOneWayRequest.Size = new Size(120, 35);
            btnOneWayRequest.TabIndex = 10;
            btnOneWayRequest.Text = "One-Way Request";
            btnOneWayRequest.UseVisualStyleBackColor = false;

            // btnLogout
            btnLogout.BackColor = System.Drawing.Color.FromArgb(100, 100, 100);
            btnLogout.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnLogout.ForeColor = System.Drawing.Color.White;
            btnLogout.Location = new Point(650, 430);
            btnLogout.Name = "btnLogout";
            btnLogout.Size = new Size(120, 35);
            btnLogout.TabIndex = 11;
            btnLogout.Text = "Logout";
            btnLogout.UseVisualStyleBackColor = false;
            btnLogout.Click += btnLogout_Click;

            // StudentDashboard
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = System.Drawing.Color.White;
            ClientSize = new Size(800, 480);
            Controls.Add(btnLogout);
            Controls.Add(btnOneWayRequest);
            Controls.Add(btnCancelBooking);
            Controls.Add(btnBookTravel);
            Controls.Add(dataGridViewMyBookings);
            Controls.Add(labelMyBookings);
            Controls.Add(dataGridViewUpcomingTravels);
            Controls.Add(label5);
            Controls.Add(groupBox1);
            Name = "StudentDashboard";
            Text = "Student Dashboard";
            Load += StudentDashboard_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewUpcomingTravels).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridViewMyBookings).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private GroupBox groupBox1;
        private Label label2;
        private Label label1;
        private Label label5;
        private Button btnBookTravel;
        private Button btnCancelBooking;
        private Button btnLogout;
        private Label lblDept;
        private Label lblName;
        private Button btnOneWayRequest;
        private DataGridView dataGridViewUpcomingTravels;
        private Label labelUpcomingTravels;
        private Label labelMyBookings;
        private DataGridView dataGridViewMyBookings;
    }
}