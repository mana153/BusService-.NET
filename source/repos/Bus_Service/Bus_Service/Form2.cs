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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            string username = textBox1.Text;
            string password = textBox2.Text;

            if (username == "" || password == "")
            {
                MessageBox.Show("Enter username and password");
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

                    string query = "SELECT UserID, Role FROM Users WHERE Username=@u AND Password=@p";

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@u", username);
                        cmd.Parameters.AddWithValue("@p", password);

                        SqlDataReader reader = cmd.ExecuteReader();

                        if (!reader.Read())
                        {
                            MessageBox.Show("Invalid credentials");
                            return;
                        }

                        int userId = Convert.ToInt32(reader["UserID"]);
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
                        string role = reader["Role"].ToString();
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.

                        MessageBox.Show("Login Successful! Role: " + role);

                        if (role == "Admin")
                        {
                            Admin admin = new Admin();
                            admin.Show();
                        }
                        else if (role == "Student")
                        {
                            StudentForm student = new StudentForm(userId);
                            student.Show();
                        }
                        else if (role == "Volunteer")
                        {
                            VolunteerForm volunteer = new VolunteerForm();
                            volunteer.Show();
                        }

                        this.Hide();
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
