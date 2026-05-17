namespace Bus_Service
{
    partial class VolunteerForm
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
            label2 = new Label();
            dtpSelectDate = new DateTimePicker();
            btnLoadAttendance = new Button();
            btnRefresh = new Button();
            dataGridViewAttendance = new DataGridView();
            groupBox1 = new GroupBox();
            ((System.ComponentModel.ISupportInitialize)dataGridViewAttendance).BeginInit();
            groupBox1.SuspendLayout();
            SuspendLayout();

            // label1
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            label1.Location = new Point(20, 20);
            label1.Name = "label1";
            label1.Size = new Size(170, 32);
            label1.TabIndex = 0;
            label1.Text = "Mark Attendance";

            // label2
            label2.AutoSize = true;
            label2.Location = new Point(20, 70);
            label2.Name = "label2";
            label2.Size = new Size(89, 20);
            label2.TabIndex = 1;
            label2.Text = "Select Date:";

            // dtpSelectDate
            dtpSelectDate.Location = new Point(120, 70);
            dtpSelectDate.Name = "dtpSelectDate";
            dtpSelectDate.Size = new Size(200, 27);
            dtpSelectDate.TabIndex = 2;

            // btnLoadAttendance
            btnLoadAttendance.Location = new Point(340, 70);
            btnLoadAttendance.Name = "btnLoadAttendance";
            btnLoadAttendance.Size = new Size(100, 35);
            btnLoadAttendance.TabIndex = 3;
            btnLoadAttendance.Text = "Load";
            btnLoadAttendance.UseVisualStyleBackColor = true;
            btnLoadAttendance.Click += btnLoadAttendance_Click;

            // btnRefresh
            btnRefresh.Location = new Point(450, 70);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(100, 35);
            btnRefresh.TabIndex = 4;
            btnRefresh.Text = "Refresh";
            btnRefresh.UseVisualStyleBackColor = true;
            btnRefresh.Click += btnRefresh_Click;

            // dataGridViewAttendance
            dataGridViewAttendance.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewAttendance.Dock = DockStyle.Bottom;
            dataGridViewAttendance.Location = new Point(0, 140);
            dataGridViewAttendance.Name = "dataGridViewAttendance";
            dataGridViewAttendance.RowHeadersWidth = 51;
            dataGridViewAttendance.Size = new Size(800, 310);
            dataGridViewAttendance.TabIndex = 5;
            dataGridViewAttendance.CellEndEdit += dataGridViewAttendance_CellEndEdit;

            // groupBox1
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(dtpSelectDate);
            groupBox1.Controls.Add(btnLoadAttendance);
            groupBox1.Controls.Add(btnRefresh);
            groupBox1.Dock = DockStyle.Top;
            groupBox1.Location = new Point(0, 0);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(10);
            groupBox1.Size = new Size(800, 140);
            groupBox1.TabIndex = 6;
            groupBox1.TabStop = false;

            // VolunteerForm
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(dataGridViewAttendance);
            Controls.Add(groupBox1);
            Name = "VolunteerForm";
            Text = "Volunteer - Mark Attendance";
            Load += VolunteerForm_Load;
            FormClosing += VolunteerForm_FormClosing;
            ((System.ComponentModel.ISupportInitialize)dataGridViewAttendance).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
        }

        #region Designer generated code
        #endregion

        private Label label1;
        private Label label2;
        private DateTimePicker dtpSelectDate;
        private Button btnLoadAttendance;
        private Button btnRefresh;
        private DataGridView dataGridViewAttendance;
        private GroupBox groupBox1;
    }
}
