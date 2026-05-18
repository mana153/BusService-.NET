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
    public partial class OneWayRequestForm : Form
    {
        private int _studentId;
        private string _connectionString = AppSettings.SqlConnectionString;
        private OneWayRequestHelper _helper;

        public OneWayRequestForm(int studentId)
        {
            InitializeComponent();
            _studentId = studentId;
            _helper = new OneWayRequestHelper(_connectionString);
        }

        private void OneWayRequestForm_Load(object sender, EventArgs e)
        {
            LoadRoutes();
            LoadStudentRequests();
            dateTimePickerRequestDate.MinDate = DateTime.Today;
        }

        /// <summary>
        /// Load available routes into ComboBox
        /// </summary>
        private void LoadRoutes()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                    string query = "SELECT DISTINCT Route FROM BusSchedule ORDER BY Route";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        SqlDataReader reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            comboBoxRoute.Items.Add(reader["Route"].ToString());
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading routes: " + ex.Message);
            }
        }

        /// <summary>
        /// Load student's previous one-way requests
        /// </summary>
        private void LoadStudentRequests()
        {
            try
            {
                DataTable requests = _helper.GetStudentOneWayRequests(_studentId);
                dataGridViewRequests.DataSource = requests;

                // Format columns
                if (dataGridViewRequests.Columns.Count > 0)
                {
                    dataGridViewRequests.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading requests: " + ex.Message);
            }
        }

        /// <summary>
        /// Submit One-Way Request
        /// </summary>
        private void buttonSubmitRequest_Click(object sender, EventArgs e)
        {
            // Validation
            if (string.IsNullOrWhiteSpace(textBoxReason.Text))
            {
                MessageBox.Show("Please enter a reason for your one-way request.");
                return;
            }

            if (comboBoxRoute.SelectedItem == null)
            {
                MessageBox.Show("Please select a route.");
                return;
            }

            string reason = textBoxReason.Text;
            string route = comboBoxRoute.SelectedItem.ToString();
            DateTime requestDate = dateTimePickerRequestDate.Value;

            // Submit request
            if (_helper.SubmitOneWayRequest(_studentId, reason, route, requestDate))
            {
                MessageBox.Show("One-Way Request submitted successfully!\nAwaiting HOD Approval.", "Success");
                textBoxReason.Clear();
                comboBoxRoute.SelectedIndex = -1;
                dateTimePickerRequestDate.Value = DateTime.Today;
                LoadStudentRequests();
            }
            else
            {
                MessageBox.Show("Failed to submit request. Please try again.");
            }
        }

        /// <summary>
        /// Refresh the request list
        /// </summary>
        private void buttonRefresh_Click(object sender, EventArgs e)
        {
            LoadStudentRequests();
        }

        /// <summary>
        /// Close the form
        /// </summary>
        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
