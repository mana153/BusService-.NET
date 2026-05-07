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

        int userID;

        public StudentDashboard()
        {
            InitializeComponent();
        }

        public StudentDashboard(int UserID)
        {
            InitializeComponent();
            userID = UserID;
        }


        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (Microsoft.Data.SqlClient.SqlConnection con = new Microsoft.Data.SqlClient.SqlConnection(
  @"Data Source=(LocalDB)\MSSQLLocalDB;
AttachDbFilename=C:\Users\Mana\source\repos\Bus_Service\Bus_Service\Database1.mdf;
Integrated Security=True"))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(
                    "SELECT u.Name, u.Department, b.BookingType, b.SeatNumber, b.Status " +
                    "FROM Bookings b INNER JOIN Users u ON b.UserID = u.UserID " +
                    "WHERE b.UserID = @UserID", con);

                cmd.Parameters.AddWithValue("@UserID", userID);

                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    lblName.Text = dr["Name"].ToString();
                    lblDept.Text = dr["Department"].ToString();
                    lblType.Text = dr["BookingType"].ToString();
                    lblSeat.Text = dr["SeatNumber"].ToString();
                    lblStatus.Text = dr["Status"].ToString();
                }
                else
                {
                    MessageBox.Show("No booking found.");
                }
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            using (Microsoft.Data.SqlClient.SqlConnection con = new Microsoft.Data.SqlClient.SqlConnection(
  @"Data Source=(LocalDB)\MSSQLLocalDB;
AttachDbFilename=C:\Users\Mana\source\repos\Bus_Service\Bus_Service\Database1.mdf;
Integrated Security=True"))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(
                    "UPDATE Bookings SET Status = 'Cancelled' WHERE UserID = @UserID", con);

                cmd.Parameters.AddWithValue("@UserID", userID);

                int rows = cmd.ExecuteNonQuery();
                if (rows > 0)
                {
                    lblStatus.Text = "Cancelled";
                    MessageBox.Show("Booking cancelled successfully.");
                }
                else
                {
                    MessageBox.Show("No booking to cancel.");
                }
            }
        }

            private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login login = new Login();
            login.Show();
             }
    }
}
