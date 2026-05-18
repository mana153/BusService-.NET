using System;
using System.Data;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace Bus_Service
{
    public partial class StudentForm : Form
    {
        private int _studentId;

        public StudentForm(int studentId)
        {
            InitializeComponent();
            _studentId = studentId;
        }

        private void StudentForm_Load(object sender, EventArgs e)
        {
            LoadStudentInfo();
        }

        private void LoadStudentInfo()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(AppSettings.SqlConnectionString))
                {
                    con.Open();
                    string query = "SELECT Username, Department FROM Users WHERE UserID = @id";
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@id", _studentId);
                        SqlDataReader reader = cmd.ExecuteReader();
                        if (reader.Read())
                        {
                            label5.Text = reader["Username"].ToString();
                            comboBox1.Text = reader["Department"].ToString();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading info: " + ex.Message);
            }
        }

        private void btnBookSeat_Click(object sender, EventArgs e)
        {
            StudentBookingForm form = new StudentBookingForm(_studentId);
            form.ShowDialog();
        }

        private void StudentForm_FormClosing(object sender, FormClosingEventArgs e)
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
