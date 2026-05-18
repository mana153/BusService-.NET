using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace Bus_Service
{
    public partial class VolunteerForm : Form
    {
        private DatabaseHelper _dbHelper;
        private string _connectionString = AppSettings.SqlConnectionString;

        public VolunteerForm()
        {
            InitializeComponent();
            _dbHelper = new DatabaseHelper(_connectionString);
        }

        private void VolunteerForm_Load(object sender, EventArgs e)
        {
            dtpSelectDate.Value = DateTime.Now;
            LoadAttendance();
        }

        private void LoadAttendance()
        {
            try
            {
                DateTime selectedDate = dtpSelectDate.Value;
                DataTable attendanceData = _dbHelper.GetAttendanceByDate(selectedDate);
                dataGridViewAttendance.DataSource = attendanceData;

                if (dataGridViewAttendance.Columns.Count > 0)
                {
                    dataGridViewAttendance.AutoResizeColumns();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading attendance: " + ex.Message);
            }
        }

        private void btnLoadAttendance_Click(object sender, EventArgs e)
        {
            LoadAttendance();
        }

        private void dataGridViewAttendance_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex >= 0 && e.RowIndex >= 0)
                {
                    DataGridViewRow row = dataGridViewAttendance.Rows[e.RowIndex];

                    if (row.Cells.Count > 2 && row.Cells[0].Value != null && row.Cells[2].Value != null)
                    {
                        int studentId = Convert.ToInt32(row.Cells[0].Value);
                        DateTime travelDate = Convert.ToDateTime(row.Cells[1].Value);
                        string status = row.Cells[2].Value.ToString();

                        if (status == "Present" || status == "Absent")
                        {
                            if (_dbHelper.UpdateAttendance(studentId, travelDate, status))
                            {
                                MessageBox.Show("Attendance updated successfully");
                            }
                            else
                            {
                                MessageBox.Show("Failed to update attendance");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Invalid status. Please enter 'Present' or 'Absent'");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadAttendance();
        }

        private void VolunteerForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Return to login instead of exiting application
            DialogResult result = MessageBox.Show("Are you sure you want to logout?", "Confirm Logout", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                this.Hide();
                Login login = new Login();
                login.Show();
            }
            else
            {
                e.Cancel = true;
            }
        }
    }
}
