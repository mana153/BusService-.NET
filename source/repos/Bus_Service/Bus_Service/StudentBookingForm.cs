using System;
using System.Data;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace Bus_Service
{
    public partial class StudentBookingForm : Form
    {
        private int _studentId;

        public StudentBookingForm(int studentId)
        {
            InitializeComponent();
            _studentId = studentId;
        }

        private void StudentBookingForm_Load(object sender, EventArgs e)
        {
            LoadAvailableTravels();
            LoadMyBookings();
            lblStudentId.Text = "Student ID: " + _studentId.ToString();
        }

        private void LoadAvailableTravels()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(AppSettings.SqlConnectionString))
                {
                    con.Open();
                    string query = "SELECT TravelID, TravelDate, BusNumber, Route, SeatCapacity, SeatsAvailable FROM TravelDetails " +
                                   "WHERE TravelDate >= GETDATE() AND SeatsAvailable > 0 ORDER BY TravelDate ASC";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, con);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    dataGridViewAvailableTravels.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading travels: " + ex.Message);
            }
        }

        private void LoadMyBookings()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(AppSettings.SqlConnectionString))
                {
                    con.Open();
                    string query = "SELECT sb.BookingID, sb.TravelID, td.TravelDate, td.Route, sb.BookingType, sb.BookingStatus " +
                                   "FROM StudentBooking sb " +
                                   "INNER JOIN TravelDetails td ON sb.TravelID = td.TravelID " +
                                   "WHERE sb.StudentID = @id ORDER BY td.TravelDate DESC";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, con);
                    adapter.SelectCommand.Parameters.AddWithValue("@id", _studentId);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    dataGridViewMyBookings.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading bookings: " + ex.Message);
            }
        }

        private void btnBookTravel_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridViewAvailableTravels.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Please select a travel to book");
                    return;
                }

                int travelId = (int)dataGridViewAvailableTravels.SelectedRows[0].Cells["TravelID"].Value;
                string bookingType = "TwoWay";

                using (SqlConnection con = new SqlConnection(AppSettings.SqlConnectionString))
                {
                    con.Open();

                    // Check if already booked
                    string checkQuery = "SELECT COUNT(*) FROM StudentBooking WHERE StudentID = @sid AND TravelID = @tid AND BookingStatus = 'Booked'";
                    using (SqlCommand checkCmd = new SqlCommand(checkQuery, con))
                    {
                        checkCmd.Parameters.AddWithValue("@sid", _studentId);
                        checkCmd.Parameters.AddWithValue("@tid", travelId);
                        int count = (int)checkCmd.ExecuteScalar();
                        if (count > 0)
                        {
                            MessageBox.Show("You already have a booking for this travel");
                            return;
                        }
                    }

                    // Insert booking
                    string insertQuery = "INSERT INTO StudentBooking (StudentID, TravelID, BookingType, BookingStatus, BookingDate) " +
                                       "VALUES (@sid, @tid, @type, 'Booked', GETDATE())";
                    using (SqlCommand insertCmd = new SqlCommand(insertQuery, con))
                    {
                        insertCmd.Parameters.AddWithValue("@sid", _studentId);
                        insertCmd.Parameters.AddWithValue("@tid", travelId);
                        insertCmd.Parameters.AddWithValue("@type", bookingType);
                        int result = insertCmd.ExecuteNonQuery();

                        if (result > 0)
                        {
                            // Update available seats
                            string updateQuery = "UPDATE TravelDetails SET SeatsAvailable = SeatsAvailable - 1 WHERE TravelID = @tid";
                            using (SqlCommand updateCmd = new SqlCommand(updateQuery, con))
                            {
                                updateCmd.Parameters.AddWithValue("@tid", travelId);
                                updateCmd.ExecuteNonQuery();
                            }

                            MessageBox.Show("Seat booked successfully!");
                            LoadAvailableTravels();
                            LoadMyBookings();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
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

                if (MessageBox.Show("Cancel this booking?", "Confirm", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    using (SqlConnection con = new SqlConnection(AppSettings.SqlConnectionString))
                    {
                        con.Open();

                        // Update booking status
                        string updateQuery = "UPDATE StudentBooking SET BookingStatus = 'Cancelled' WHERE BookingID = @bid";
                        using (SqlCommand updateCmd = new SqlCommand(updateQuery, con))
                        {
                            updateCmd.Parameters.AddWithValue("@bid", bookingId);
                            updateCmd.ExecuteNonQuery();
                        }

                        // Restore seat
                        string restoreQuery = "UPDATE TravelDetails SET SeatsAvailable = SeatsAvailable + 1 WHERE TravelID = @tid";
                        using (SqlCommand restoreCmd = new SqlCommand(restoreQuery, con))
                        {
                            restoreCmd.Parameters.AddWithValue("@tid", travelId);
                            restoreCmd.ExecuteNonQuery();
                        }

                        MessageBox.Show("Booking cancelled!");
                        LoadAvailableTravels();
                        LoadMyBookings();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
    }
}

