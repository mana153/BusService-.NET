using System;
using System.Data;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace Bus_Service
{
    public partial class AdminDashboard : Form
    {
        private int _adminId;

        public AdminDashboard(int adminId = 0)
        {
            InitializeComponent();
            _adminId = adminId;
        }

        private void AdminDashboard_Load(object sender, EventArgs e)
        {
            LoadUpcomingTravels();
        }

        private void LoadUpcomingTravels()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(AppSettings.SqlConnectionString))
                {
                    con.Open();
                    string query = "SELECT TOP 10 TravelID, TravelDate, BusNumber, Route, SeatCapacity, SeatsAvailable FROM TravelDetails " +
                                   "WHERE TravelDate >= GETDATE() ORDER BY TravelDate ASC";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, con);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    dataGridViewUpcomingTravels.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading travels: " + ex.Message);
            }
        }

        private void btnTravelDetails_Click(object sender, EventArgs e)
        {
            AdminForm form = new AdminForm(_adminId);
            form.Show();
        }

        private void buttonOneWayRequests_Click(object sender, EventArgs e)
        {
            MessageBox.Show("One-Way Request Management");
        }

        private void buttonNotifications_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Notifications");
        }

        private void AdminDashboard_FormClosing(object sender, FormClosingEventArgs e)
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
