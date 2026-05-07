using Microsoft.Data.SqlClient;
using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Bus_Service
{
    public partial class StudentForm : Form
    {
        int userID;
        // 🔹 Connection String
        string connectionString =
            @"Data Source=(LocalDB)\MSSQLLocalDB;
AttachDbFilename=C:\Users\Mana\source\repos\Bus_Service\Bus_Service\Database1.mdf;
Integrated Security=True";

        public StudentForm(int UserID)
        {
            InitializeComponent();

            userID = UserID;
        }


        private void StudentForm_Load(object sender, EventArgs e)
        {
            LoadTravelDetails();
            CheckExistingBooking();
        }

        private void LoadTravelDetails()
        {
            try
            {
                using (Microsoft.Data.SqlClient.SqlConnection con = new Microsoft.Data.SqlClient.SqlConnection(
             @"Data Source=(LocalDB)\MSSQLLocalDB;
  AttachDbFilename=C:\Users\Mana\source\repos\Bus_Service\Bus_Service\Database1.mdf;
  Integrated Security=True"))
                {
                    con.Open();

                    string query =
                        "SELECT TOP 1 ScheduleID, TravelDate, TotalSeats FROM BusSchedule ORDER BY ScheduleID DESC";

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        SqlDataReader reader = cmd.ExecuteReader();

                        if (reader.Read())
                        {
                            DateTime travelDate = Convert.ToDateTime(reader["TravelDate"]);
                            int totalSeats = Convert.ToInt32(reader["TotalSeats"]);

                            label5.Text = travelDate.ToString("dddd, dd MMM yyyy");

                            reader.Close();

                            string seatQuery =
                                "SELECT COUNT(*) FROM Bookings WHERE Status='Confirmed'";

                            using (SqlCommand seatCmd = new SqlCommand(seatQuery, con))
                            {
                                int bookedSeats = (int)seatCmd.ExecuteScalar();
                                int availableSeats = totalSeats - bookedSeats;

                                label6.Text = availableSeats.ToString();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        // 🔹 CHECK IF STUDENT ALREADY BOOKED
        private void CheckExistingBooking()
        {
            try
            {
                using (Microsoft.Data.SqlClient.SqlConnection con = new Microsoft.Data.SqlClient.SqlConnection(
             @"Data Source=(LocalDB)\MSSQLLocalDB;
  AttachDbFilename=C:\Users\Mana\source\repos\Bus_Service\Bus_Service\Database1.mdf;
  Integrated Security=True"))
                {
                    con.Open();

                    string query =
                        "SELECT COUNT(*) FROM Bookings WHERE UserID=@u AND Status!='Cancelled'";

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@u", userID);

                        int count = (int)cmd.ExecuteScalar();

                        if (count > 0)
                        {
                            MessageBox.Show("You have already booked.");

                            StudentDashboard dash = new StudentDashboard(userID);
                            dash.Show();
                            this.Hide();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

           private void button1_Click(object sender, EventArgs e)
        {

            string name = textBox1.Text;
            string department = comboBox1.Text;

            string bookingType = "";

            if (radioButton1.Checked)
                bookingType = "OneWay";
            else if (radioButton2.Checked)
                bookingType = "TwoWay";

            if (name == "" || department == "" || bookingType == "")
            {
                MessageBox.Show("Please fill all details");
                return;
            }

            if (!checkBox1.Checked)
            {
                MessageBox.Show("Please confirm travel details");
                return;
            }

            try
            {
                using (Microsoft.Data.SqlClient.SqlConnection con = new Microsoft.Data.SqlClient.SqlConnection(
              @"Data Source=(LocalDB)\MSSQLLocalDB;
  AttachDbFilename=C:\Users\Mana\source\repos\Bus_Service\Bus_Service\Database1.mdf;
  Integrated Security=True"))
                {
                    con.Open();

                    // 🔹 Total seats
                    string totalSeatQuery =
                        "SELECT TOP 1 TotalSeats FROM BusSchedule ORDER BY ScheduleID DESC";

                    int totalSeats = (int)new SqlCommand(totalSeatQuery, con).ExecuteScalar();

                    // 🔹 Booked seats
                    string bookedQuery =
                        "SELECT COUNT(*) FROM Bookings WHERE Status='Confirmed'";

                    int bookedSeats = (int)new SqlCommand(bookedQuery, con).ExecuteScalar();

                    int availableSeats = totalSeats - bookedSeats;

                    if (availableSeats <= 0)
                    {
                        MessageBox.Show("No seats available");
                        return;
                    }

                    string status = (bookingType == "OneWay") ? "Pending" : "Confirmed";
                    int seatNumber = bookedSeats + 1;

                    string insertQuery =
                        @"INSERT INTO Bookings 
                        (UserID, BookingType, Status, SeatNumber, BookingTime) 
                        VALUES (@u, @t, @s, @seat, GETDATE())";

                    using (SqlCommand cmd = new SqlCommand(insertQuery, con))
                    {
                        cmd.Parameters.AddWithValue("@u", userID);
                        cmd.Parameters.AddWithValue("@t", bookingType);
                        cmd.Parameters.AddWithValue("@s", status);
                        cmd.Parameters.AddWithValue("@seat", seatNumber);

                        cmd.ExecuteNonQuery();
                    }

                    MessageBox.Show("Seat Booked Successfully!");

                    StudentDashboard dashboard = new StudentDashboard(userID);
                    dashboard.Show();
                    this.Hide();

                    label6.Text = (availableSeats - 1).ToString();

                    radioButton1.Enabled = false;
                    radioButton2.Enabled = false;
                    textBox1.Enabled = false;
                    comboBox1.Enabled = false;
                    checkBox1.Enabled = false;
                    button1.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


    }
}