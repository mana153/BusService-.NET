using System;
using System.Data;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace Bus_Service
{
    public partial class AdminForm : Form
    {
        private int _adminId;

        public AdminForm(int adminId = 0)
        {
            InitializeComponent();
            _adminId = adminId;
        }

        private void AdminForm_Load(object sender, EventArgs e)
        {
            RefreshTravels();
        }

        private void RefreshTravels()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(AppSettings.SqlConnectionString))
                {
                    con.Open();
                    string query = "SELECT TravelID, TravelDate, BusNumber, Route, SeatCapacity, SeatsAvailable FROM TravelDetails ORDER BY TravelDate DESC";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, con);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    dataGridViewTravels.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading travels: " + ex.Message);
            }
        }

        private void btnAddTravel_Click(object sender, EventArgs e)
        {
            try
            {
                if (dtpTravelDate.Value < DateTime.Now)
                {
                    MessageBox.Show("Travel date must be in the future");
                    return;
                }

                if (string.IsNullOrEmpty(cbBusNumber.Text) || string.IsNullOrEmpty(txtRoute.Text) || nudSeatCapacity.Value <= 0)
                {
                    MessageBox.Show("Please fill all fields correctly");
                    return;
                }

                DateTime travelDate = dtpTravelDate.Value;
                string busNumber = cbBusNumber.Text;
                string route = txtRoute.Text;
                int seatCapacity = (int)nudSeatCapacity.Value;

                using (SqlConnection con = new SqlConnection(AppSettings.SqlConnectionString))
                {
                    con.Open();
                    string query = "INSERT INTO TravelDetails (TravelDate, BusNumber, Route, SeatCapacity, SeatsAvailable, TravelType, CreatedDate, UpdatedDate) " +
                                   "VALUES (@TravelDate, @BusNumber, @Route, @SeatCapacity, @SeatCapacity, 'TwoWay', GETDATE(), GETDATE())";

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@TravelDate", travelDate);
                        cmd.Parameters.AddWithValue("@BusNumber", busNumber);
                        cmd.Parameters.AddWithValue("@Route", route);
                        cmd.Parameters.AddWithValue("@SeatCapacity", seatCapacity);

                        int result = cmd.ExecuteNonQuery();
                        if (result > 0)
                        {
                            MessageBox.Show("Travel added successfully!");
                            ClearFields();
                            RefreshTravels();
                        }
                        else
                        {
                            MessageBox.Show("Failed to add travel");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void btnUpdateTravel_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridViewTravels.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Please select a travel to update");
                    return;
                }

                int travelId = (int)dataGridViewTravels.SelectedRows[0].Cells["TravelID"].Value;

                if (string.IsNullOrEmpty(cbBusNumber.Text) || string.IsNullOrEmpty(txtRoute.Text))
                {
                    MessageBox.Show("Please fill all fields");
                    return;
                }

                DateTime travelDate = dtpTravelDate.Value;
                string busNumber = cbBusNumber.Text;
                string route = txtRoute.Text;
                int seatCapacity = (int)nudSeatCapacity.Value;

                using (SqlConnection con = new SqlConnection(AppSettings.SqlConnectionString))
                {
                    con.Open();
                    string query = "UPDATE TravelDetails SET TravelDate = @TravelDate, BusNumber = @BusNumber, Route = @Route, " +
                                   "SeatCapacity = @SeatCapacity, UpdatedDate = GETDATE() WHERE TravelID = @TravelID";

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@TravelID", travelId);
                        cmd.Parameters.AddWithValue("@TravelDate", travelDate);
                        cmd.Parameters.AddWithValue("@BusNumber", busNumber);
                        cmd.Parameters.AddWithValue("@Route", route);
                        cmd.Parameters.AddWithValue("@SeatCapacity", seatCapacity);

                        int result = cmd.ExecuteNonQuery();
                        if (result > 0)
                        {
                            MessageBox.Show("Travel updated successfully!");
                            ClearFields();
                            RefreshTravels();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void btnDeleteTravel_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridViewTravels.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Please select a travel to delete");
                    return;
                }

                int travelId = (int)dataGridViewTravels.SelectedRows[0].Cells["TravelID"].Value;

                if (MessageBox.Show("Are you sure?", "Delete Travel", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    using (SqlConnection con = new SqlConnection(AppSettings.SqlConnectionString))
                    {
                        con.Open();
                        string query = "DELETE FROM TravelDetails WHERE TravelID = @TravelID";

                        using (SqlCommand cmd = new SqlCommand(query, con))
                        {
                            cmd.Parameters.AddWithValue("@TravelID", travelId);
                            int result = cmd.ExecuteNonQuery();

                            if (result > 0)
                            {
                                MessageBox.Show("Travel deleted successfully!");
                                ClearFields();
                                RefreshTravels();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearFields();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            AdminDashboard dashboard = new AdminDashboard(_adminId);
            dashboard.Show();
        }

        private void ClearFields()
        {
            dtpTravelDate.Value = DateTime.Now.AddDays(1);
            cbBusNumber.SelectedIndex = -1;
            txtRoute.Clear();
            nudSeatCapacity.Value = 0;
            dataGridViewTravels.ClearSelection();
        }

        private void dataGridViewTravels_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    DataGridViewRow row = dataGridViewTravels.Rows[e.RowIndex];
                    dtpTravelDate.Value = (DateTime)row.Cells["TravelDate"].Value;
                    cbBusNumber.Text = row.Cells["BusNumber"].Value.ToString();
                    txtRoute.Text = row.Cells["Route"].Value.ToString();
                    nudSeatCapacity.Value = (int)row.Cells["SeatCapacity"].Value;
                }
            }
            catch { }
        }

        private void AdminForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Close this form and return to dashboard
            this.Hide();
            AdminDashboard dashboard = new AdminDashboard(_adminId);
            dashboard.Show();
            e.Cancel = true;
        }
    }
}
