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
    public partial class HODDashboardForm : Form
    {
        private string _connectionString = AppSettings.SqlConnectionString;
        private OneWayRequestHelper _helper;
        private int _selectedRequestId = -1;

        public HODDashboardForm()
        {
            InitializeComponent();
            _helper = new OneWayRequestHelper(_connectionString);
        }

        private void HODDashboardForm_Load(object sender, EventArgs e)
        {
            LoadPendingRequests();
        }

        /// <summary>
        /// Load all pending HOD requests
        /// </summary>
        private void LoadPendingRequests()
        {
            try
            {
                DataTable requests = _helper.GetPendingHODRequests();
                dataGridViewPendingRequests.DataSource = requests;

                // Format columns
                if (dataGridViewPendingRequests.Columns.Count > 0)
                {
                    dataGridViewPendingRequests.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
                }

                // Update status label
                labelPendingCount.Text = $"Pending Requests: {requests.Rows.Count}";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading pending requests: " + ex.Message);
            }
        }

        /// <summary>
        /// Handle row selection in DataGridView
        /// </summary>
        private void dataGridViewPendingRequests_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridViewPendingRequests.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dataGridViewPendingRequests.SelectedRows[0];
                _selectedRequestId = Convert.ToInt32(selectedRow.Cells["RequestId"].Value);

                // Display request details
                textBoxRequestDetails.Clear();
                textBoxRequestDetails.AppendText($"Request ID: {selectedRow.Cells["RequestId"].Value}\n");
                textBoxRequestDetails.AppendText($"Student: {selectedRow.Cells["StudentName"].Value}\n");
                textBoxRequestDetails.AppendText($"Department: {selectedRow.Cells["Department"].Value}\n");
                textBoxRequestDetails.AppendText($"Route: {selectedRow.Cells["Route"].Value}\n");
                textBoxRequestDetails.AppendText($"Request Date: {selectedRow.Cells["RequestDate"].Value}\n");
                textBoxRequestDetails.AppendText($"Reason:\n{selectedRow.Cells["Reason"].Value}");

                // Enable approve/reject buttons
                buttonApprove.Enabled = true;
                buttonReject.Enabled = true;
            }
            else
            {
                textBoxRequestDetails.Clear();
                buttonApprove.Enabled = false;
                buttonReject.Enabled = false;
                _selectedRequestId = -1;
            }
        }

        /// <summary>
        /// Approve selected request
        /// </summary>
        private void buttonApprove_Click(object sender, EventArgs e)
        {
            if (_selectedRequestId < 0)
            {
                MessageBox.Show("Please select a request first.");
                return;
            }

            if (MessageBox.Show("Are you sure you want to approve this request?", "Confirm", MessageBoxButtons.YesNo) == DialogResult.No)
                return;

            if (_helper.UpdateHODApproval(_selectedRequestId, "Approved"))
            {
                MessageBox.Show("Request approved successfully!\nNotification sent to Admin.");
                LoadPendingRequests();
                textBoxRequestDetails.Clear();
                _selectedRequestId = -1;
            }
            else
            {
                MessageBox.Show("Failed to approve request.");
            }
        }

        /// <summary>
        /// Reject selected request
        /// </summary>
        private void buttonReject_Click(object sender, EventArgs e)
        {
            if (_selectedRequestId < 0)
            {
                MessageBox.Show("Please select a request first.");
                return;
            }

            if (MessageBox.Show("Are you sure you want to reject this request?", "Confirm", MessageBoxButtons.YesNo) == DialogResult.No)
                return;

            if (_helper.UpdateHODApproval(_selectedRequestId, "Rejected"))
            {
                MessageBox.Show("Request rejected successfully!");
                LoadPendingRequests();
                textBoxRequestDetails.Clear();
                _selectedRequestId = -1;
            }
            else
            {
                MessageBox.Show("Failed to reject request.");
            }
        }

        /// <summary>
        /// Refresh the request list
        /// </summary>
        private void buttonRefresh_Click(object sender, EventArgs e)
        {
            LoadPendingRequests();
            textBoxRequestDetails.Clear();
            _selectedRequestId = -1;
            buttonApprove.Enabled = false;
            buttonReject.Enabled = false;
        }

        /// <summary>
        /// Close the form
        /// </summary>
        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void HODDashboardForm_FormClosing(object sender, FormClosingEventArgs e)
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
