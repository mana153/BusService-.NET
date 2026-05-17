using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace Bus_Service
{
    public partial class StudentDashboard : Form
    {
        private int _userID;
        private DatabaseHelper _dbHelper;
        private string _connectionString = AppSettings.SqlConnectionString;

        public StudentDashboard()
        {
            InitializeComponent();
        }

        public StudentDashboard(int userID)
        {
            InitializeComponent();
            _userID = userID;
            _dbHelper = new DatabaseHelper(_connectionString);
        }

        private void StudentDashboard_Load(object sender, EventArgs e)
        {
            // Apply styling
            this.BackColor = Color.White;
            this.Font = new Font("Segoe UI", 10);
            LoadStudentInfo();
            LoadUpcomingTravels();
        }

        private void LoadStudentInfo()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(_connectionString))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand(
                        "SELECT Username, Department FROM Users WHERE UserID = @UserID", con);
                    cmd.Parameters.AddWithValue("@UserID", _userID);

                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        lblName.Text = "Name: " + dr["Username"].ToString();
                        lblDept.Text = "Department: " + dr["Department"].ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading student info: " + ex.Message);
            }
        }

        private void LoadUpcomingTravels()
        {
            try
            {
                DataTable travels = _dbHelper.GetUpcomingTravels();
                dataGridViewUpcomingTravels.DataSource = travels;
                dataGridViewUpcomingTravels.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading travels: " + ex.Message);
            }
        }

        private void LoadStudentBookings()
        {
            try
            {
                DataTable bookings = _dbHelper.GetStudentBookings(_userID);
                dataGridViewMyBookings.DataSource = bookings;
                dataGridViewMyBookings.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading bookings: " + ex.Message);
            }
        }

        private void btnBookTravel_Click(object sender, EventArgs e)
        {
            StudentBookingForm bookingForm = new StudentBookingForm(_userID);
            bookingForm.ShowDialog();
            LoadStudentBookings();
        }

        private void btnCancelBooking_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridViewMyBookings.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Please select a booking to cancel");
                    return;
                }

                int bookingId = (int)dataGridViewMyBookings.SelectedRows[0].Cells["BookingID"].Value;
                int travelId = (int)dataGridViewMyBookings.SelectedRows[0].Cells["TravelID"].Value;

                DialogResult result = MessageBox.Show("Are you sure you want to cancel this booking?", "Confirm", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    if (_dbHelper.CancelStudentBooking(bookingId, travelId))
                    {
                        MessageBox.Show("Booking cancelled successfully");
                        LoadStudentBookings();
                        LoadUpcomingTravels();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login login = new Login();
            login.Show();
        }

        private void StudentDashboard_FormClosing(object sender, FormClosingEventArgs e)
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

        private void groupBox1_Enter(object sender, EventArgs e)
        {
        }
    }
}
