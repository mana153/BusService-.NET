using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Bus_Service
{
    public partial class AttendanceForm : Form
    {
        private DatabaseHelper _dbHelper;
        private string _connectionString = AppSettings.SqlConnectionString;

        public AttendanceForm()
        {
            InitializeComponent();
            _dbHelper = new DatabaseHelper(_connectionString);
        }

        private void AttendanceForm_Load(object sender, EventArgs e)
        {
            LoadTravelDates();
        }

        private void LoadTravelDates()
        {
            try
            {
                DataTable travels = _dbHelper.GetAllTravels();
                dtpSelectDate.Value = DateTime.Now;

                foreach (DataRow row in travels.Rows)
                {
                    DateTime travelDate = (DateTime)row["TravelDate"];
                    if (!dtpSelectDate.Value.Date.Equals(travelDate.Date))
                    {
                        // We'll use DateTimePicker to select date
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading travel dates: " + ex.Message);
            }
        }

        private void btnLoadAttendance_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime selectedDate = dtpSelectDate.Value;
                DataTable attendanceData = _dbHelper.GetAttendanceByDate(selectedDate);
                dataGridViewAttendance.DataSource = attendanceData;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading attendance: " + ex.Message);
            }
        }

        private void dataGridViewAttendance_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == dataGridViewAttendance.Columns["Status"].Index)
                {
                    DataGridViewRow row = dataGridViewAttendance.Rows[e.RowIndex];
                    int studentId = (int)row.Cells["StudentID"].Value;
                    DateTime travelDate = (DateTime)row.Cells["TravelDate"].Value;
                    string status = row.Cells["Status"].Value.ToString();

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
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            btnLoadAttendance_Click(null, null);
        }
    }
}
