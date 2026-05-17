namespace Bus_Service
{
    partial class StudentBookingForm
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
            this.lblStudentId = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dataGridViewAvailableTravels = new System.Windows.Forms.DataGridView();
            this.btnBookTravel = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dataGridViewMyBookings = new System.Windows.Forms.DataGridView();
            this.btnCancelBooking = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAvailableTravels)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewMyBookings)).BeginInit();
            this.SuspendLayout();

            // lblStudentId
            this.lblStudentId.AutoSize = true;
            this.lblStudentId.Location = new System.Drawing.Point(10, 10);
            this.lblStudentId.Name = "lblStudentId";
            this.lblStudentId.Size = new System.Drawing.Size(79, 15);
            this.lblStudentId.TabIndex = 0;
            this.lblStudentId.Text = "Student ID: 0";

            // groupBox1
            this.groupBox1.Controls.Add(this.dataGridViewAvailableTravels);
            this.groupBox1.Controls.Add(this.btnBookTravel);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 30);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(600, 250);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Available Travels";

            // dataGridViewAvailableTravels
            this.dataGridViewAvailableTravels.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewAvailableTravels.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewAvailableTravels.Location = new System.Drawing.Point(3, 19);
            this.dataGridViewAvailableTravels.Name = "dataGridViewAvailableTravels";
            this.dataGridViewAvailableTravels.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewAvailableTravels.Size = new System.Drawing.Size(594, 212);
            this.dataGridViewAvailableTravels.TabIndex = 0;

            // btnBookTravel
            this.btnBookTravel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnBookTravel.Location = new System.Drawing.Point(3, 222);
            this.btnBookTravel.Name = "btnBookTravel";
            this.btnBookTravel.Size = new System.Drawing.Size(594, 25);
            this.btnBookTravel.TabIndex = 1;
            this.btnBookTravel.Text = "Book Travel";
            this.btnBookTravel.UseVisualStyleBackColor = true;
            this.btnBookTravel.Click += new System.EventHandler(this.btnBookTravel_Click);

            // groupBox2
            this.groupBox2.Controls.Add(this.dataGridViewMyBookings);
            this.groupBox2.Controls.Add(this.btnCancelBooking);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 280);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(600, 220);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "My Bookings";

            // dataGridViewMyBookings
            this.dataGridViewMyBookings.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewMyBookings.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            new System.Windows.Forms.DataGridViewTextBoxColumn() { Name = "TravelID", HeaderText = "Travel ID", ReadOnly = true },
            new System.Windows.Forms.DataGridViewTextBoxColumn() { Name = "TravelDate", HeaderText = "Travel Date", ReadOnly = true }});
            this.dataGridViewMyBookings.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewMyBookings.Location = new System.Drawing.Point(3, 19);
            this.dataGridViewMyBookings.Name = "dataGridViewMyBookings";
            this.dataGridViewMyBookings.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewMyBookings.Size = new System.Drawing.Size(594, 173);
            this.dataGridViewMyBookings.TabIndex = 0;

            // btnCancelBooking
            this.btnCancelBooking.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnCancelBooking.Location = new System.Drawing.Point(3, 192);
            this.btnCancelBooking.Name = "btnCancelBooking";
            this.btnCancelBooking.Size = new System.Drawing.Size(594, 25);
            this.btnCancelBooking.TabIndex = 1;
            this.btnCancelBooking.Text = "Cancel Booking";
            this.btnCancelBooking.UseVisualStyleBackColor = true;
            this.btnCancelBooking.Click += new System.EventHandler(this.btnCancelBooking_Click);

            // StudentBookingForm
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 500);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lblStudentId);
            this.Name = "StudentBookingForm";
            this.Text = "Student - Travel Booking";
            this.Load += new System.EventHandler(this.StudentBookingForm_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAvailableTravels)).EndInit();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewMyBookings)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Label lblStudentId;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dataGridViewAvailableTravels;
        private System.Windows.Forms.Button btnBookTravel;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dataGridViewMyBookings;
        private System.Windows.Forms.Button btnCancelBooking;
    }
}
