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
            string username = textBox1.Text.Trim();
            string password = textBox2.Text.Trim();

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Please enter both username and password");
                return;
            }

            try
            {
                using (SqlConnection con = new SqlConnection(AppSettings.SqlConnectionString))
                {
                    con.Open();
                    string query = "SELECT UserID, Role, Department FROM Users WHERE Username=@username AND Password=@password";

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@username", username);
                        cmd.Parameters.AddWithValue("@password", password);

                        SqlDataReader reader = cmd.ExecuteReader();

                        if (!reader.Read())
                        {
                            MessageBox.Show("Invalid username or password");
                            textBox2.Clear();
                            return;
                        }

                        int userId = Convert.ToInt32(reader["UserID"]);
                        string role = reader["Role"]?.ToString() ?? "";
                        string department = reader["Department"]?.ToString() ?? "";

                        reader.Close();

                        bool formOpened = false;

                        if (role == "Admin")
                        {
                            AdminDashboard admin = new AdminDashboard(userId);
                            admin.Show();
                            formOpened = true;
                        }
                        else if (role == "Student")
                        {
                            StudentForm student = new StudentForm(userId);
                            student.Show();
                            formOpened = true;
                        }
                        else if (role == "HOD")
                        {
                            HODDashboardForm hod = new HODDashboardForm();
                            hod.Show();
                            formOpened = true;
                        }
                        else if (role == "Volunteer")
                        {
                            VolunteerForm volunteer = new VolunteerForm();
                            volunteer.Show();
                            formOpened = true;
                        }

                        if (formOpened)
                        {
                            this.Hide();
                        }
                        else
                        {
                            MessageBox.Show("Unknown role type: " + role);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Login Error: " + ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Register signupForm = new Register();
            signupForm.ShowDialog();
        }
    }
}
