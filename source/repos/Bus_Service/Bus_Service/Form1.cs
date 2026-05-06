using System.Collections;
using System.Data;
using Microsoft.Data.SqlClient;

namespace Bus_Service
{
    public partial class Form1 : Form
    {
        private int generatedOTP;

        public Form1()
        {
            InitializeComponent();

            // 🔹 Default state
            comboBox2.Enabled = false;
            button1.Enabled = false;
            textBox3.Enabled = false;

            textBox2.PasswordChar = '*';
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Title_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        { 
            string role = comboBox1.Text;

            if (role == "Student")
            {
                comboBox2.Enabled = true;   // Department
                button1.Enabled = false;    // OTP
                textBox3.Enabled = false;
            }
            else if (role == "Volunteer")
            {
                comboBox2.Enabled = false;
                button1.Enabled = true;
                textBox3.Enabled = true;
            }
            else // Admin
            {
                comboBox2.Enabled = false;
                button1.Enabled = false;
                textBox3.Enabled = false;
            }
        }
        

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
          
            if (textBox1.Text == "")
            {
                MessageBox.Show("Enter Register Number first");
                return;
            }

            using (Microsoft.Data.SqlClient.SqlConnection con = new Microsoft.Data.SqlClient.SqlConnection(
              @"Data Source=(LocalDB)\MSSQLLocalDB;
  AttachDbFilename=C:\Users\Mana\source\repos\Bus_Service\Bus_Service\Database1.mdf;
  Integrated Security=True"))
            {
                con.Open();

                SqlCommand cmd = new SqlCommand(
                    "SELECT COUNT(*) FROM AllowedVolunteers WHERE RegNo=@u", con);

                cmd.Parameters.AddWithValue("@u", textBox1.Text);

                int count = (int)cmd.ExecuteScalar();

                if (count == 0)
                {
                    MessageBox.Show("Not an authorized volunteer");
                    return;
                }

                // ✅ GENERATE OTP AFTER VALIDATION
                Random r = new Random();
                generatedOTP = r.Next(1000, 9999);

                MessageBox.Show("Your OTP is: " + generatedOTP);
            }
        }
        

        private void button2_Click(object sender, EventArgs e)
        {
            string role = comboBox1.Text;
            string username = textBox1.Text;
            string password = textBox2.Text;
            string department = comboBox2.Text;


            // 🔴 Basic validation
            if (username == "" || password == "" || role == "")
            {
                MessageBox.Show("Please fill all required fields");
                return;
            }

            if (role == "Admin")
            {
                MessageBox.Show("Admin cannot register. Contact system administrator.");
                return;
            }

            // 🎓 Student validation
            if (role == "Student" && department == "")
            {
                MessageBox.Show("Department is required for students");
                return;
            }

            // 🔒 Ensure volunteer generated OTP first
            if (role == "Volunteer" && generatedOTP == 0)
            {
                MessageBox.Show("Please generate OTP first");
                return;
            }

            // 🔐 OTP validation
            if (role == "Volunteer")
            {
                if (textBox3.Text == "" || Convert.ToInt32(textBox3.Text) != generatedOTP)
                {
                    MessageBox.Show("Invalid OTP");
                    return;
                }
            }
            try
            {
                using (Microsoft.Data.SqlClient.SqlConnection con = new Microsoft.Data.SqlClient.SqlConnection(
             @"Data Source=(LocalDB)\MSSQLLocalDB;
  AttachDbFilename=C:\Users\Mana\source\repos\Bus_Service\Bus_Service\Database1.mdf;
  Integrated Security=True"))
                {
                    con.Open();

                    // 🔍 CHECK IF USER EXISTS (ADD HERE)
                    string checkQuery = "SELECT COUNT(*) FROM Users WHERE Username=@u";

                    using (Microsoft.Data.SqlClient.SqlCommand checkCmd =
                           new Microsoft.Data.SqlClient.SqlCommand(checkQuery, con))
                    {
                        checkCmd.Parameters.AddWithValue("@u", username);

                        int exists = (int)checkCmd.ExecuteScalar();

                        if (exists > 0)
                        {
                            MessageBox.Show("User already exists");
                            return;
                        }
                    }

                    // INSERT USER
                    string query = "INSERT INTO Users (Username, Password, Role, Department) VALUES (@u, @p, @r, @d)";

                    using (Microsoft.Data.SqlClient.SqlCommand cmd = new Microsoft.Data.SqlClient.SqlCommand(query, con))
                    {
                        
                        cmd.Parameters.AddWithValue("@u", username);
                        cmd.Parameters.AddWithValue("@p", password);
                        cmd.Parameters.AddWithValue("@r", role);

                        if (role == "Student")
                            cmd.Parameters.AddWithValue("@d", department);
                        else
                            cmd.Parameters.AddWithValue("@d", DBNull.Value);

                        con.Open();
                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Registration Successful!");

                generatedOTP = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
    }
}
