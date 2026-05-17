namespace Bus_Service
{
    partial class AttendanceForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.dtpSelectDate = new System.Windows.Forms.DateTimePicker();
            this.btnLoadAttendance = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.dataGridViewAttendance = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAttendance)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();

            // label1
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Select Date:";

            // dtpSelectDate
            this.dtpSelectDate.Location = new System.Drawing.Point(100, 20);
            this.dtpSelectDate.Name = "dtpSelectDate";
            this.dtpSelectDate.Size = new System.Drawing.Size(150, 23);
            this.dtpSelectDate.TabIndex = 1;

            // btnLoadAttendance
            this.btnLoadAttendance.Location = new System.Drawing.Point(260, 20);
            this.btnLoadAttendance.Name = "btnLoadAttendance";
            this.btnLoadAttendance.Size = new System.Drawing.Size(120, 23);
            this.btnLoadAttendance.TabIndex = 2;
            this.btnLoadAttendance.Text = "Load Attendance";
            this.btnLoadAttendance.UseVisualStyleBackColor = true;
            this.btnLoadAttendance.Click += new System.EventHandler(this.btnLoadAttendance_Click);

            // btnRefresh
            this.btnRefresh.Location = new System.Drawing.Point(390, 20);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(80, 23);
            this.btnRefresh.TabIndex = 3;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);

            // groupBox1 - Date Selection
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.dtpSelectDate);
            this.groupBox1.Controls.Add(this.btnLoadAttendance);
            this.groupBox1.Controls.Add(this.btnRefresh);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(5);
            this.groupBox1.Size = new System.Drawing.Size(800, 70);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Select Travel Date";

            // groupBox2 - Attendance Data
            this.groupBox2.Controls.Add(this.dataGridViewAttendance);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 70);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(5);
            this.groupBox2.Size = new System.Drawing.Size(800, 380);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Attendance Records";

            // dataGridViewAttendance
            this.dataGridViewAttendance.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewAttendance.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewAttendance.Location = new System.Drawing.Point(5, 25);
            this.dataGridViewAttendance.Name = "dataGridViewAttendance";
            this.dataGridViewAttendance.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewAttendance.Size = new System.Drawing.Size(790, 350);
            this.dataGridViewAttendance.TabIndex = 4;
            this.dataGridViewAttendance.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewAttendance_CellEndEdit);

            // AttendanceForm
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "AttendanceForm";
            this.Text = "Attendance Management";
            this.Load += new System.EventHandler(this.AttendanceForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAttendance)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpSelectDate;
        private System.Windows.Forms.Button btnLoadAttendance;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.DataGridView dataGridViewAttendance;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
    }
}
