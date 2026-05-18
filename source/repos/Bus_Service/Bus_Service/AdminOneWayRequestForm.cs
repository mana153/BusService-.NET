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
    public partial class AdminOneWayRequestForm : Form
    {
        private string _connectionString = AppSettings.SqlConnectionString;
        private OneWayRequestHelper _helper;
        private int _selectedRequestId = -1;

        public AdminOneWayRequestForm()
        {
            InitializeComponent();
            _helper = new OneWayRequestHelper(_connectionString);
        }

        private void AdminOneWayRequestForm_Load(object sender, EventArgs e)
        {
            LoadPendingAdminRequests();
        }

        /// <summary>
        /// Load all HOD-approved requests pending admin approval
        /// </summary>
        private void LoadPendingAdminRequests()
        {
            try
            {
                DataTable requests = _helper.GetPendingAdminRequests();
                dataGridViewAdminRequests.DataSource = requests;

                // Format columns
                if (dataGridViewAdminRequests.Columns.Count > 0)
                {
                    dataGridViewAdminRequests.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
                }

                // Update status label
                labelPendingCount.Text = $"Pending Admin Approval: {requests.Rows.Count}";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading pending requests: " + ex.Message);
            }
        }

        /// <summary>
        /// Handle row selection in DataGridView
        /// </summary>
        private void dataGridViewAdminRequests_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridViewAdminRequests.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dataGridViewAdminRequests.SelectedRows[0];
                _selectedRequestId = Convert.ToInt32(selectedRow.Cells["RequestId"].Value);

                // Display request details
                textBoxRequestDetails.Clear();
                textBoxRequestDetails.AppendText($"Request ID: {selectedRow.Cells["RequestId"].Value}\n");
                textBoxRequestDetails.AppendText($"Student: {selectedRow.Cells["StudentName"].Value}\n");
                textBoxRequestDetails.AppendText($"Department: {selectedRow.Cells["Department"].Value}\n");
                textBoxRequestDetails.AppendText($"Route: {selectedRow.Cells["Route"].Value}\n");
                textBoxRequestDetails.AppendText($"Request Date: {selectedRow.Cells["RequestDate"].Value}\n");
                textBoxRequestDetails.AppendText($"HOD Status: {selectedRow.Cells["HODStatus"].Value}\n");
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
        /// Final approve the selected request
        /// </summary>
        private void buttonApprove_Click(object sender, EventArgs e)
        {
            if (_selectedRequestId < 0)
            {
                MessageBox.Show("Please select a request first.");
                return;
            }

            if (MessageBox.Show("Are you sure you want to FINALLY APPROVE this request?\nThe student will be notified.", "Confirm", MessageBoxButtons.YesNo) == DialogResult.No)
                return;

            if (_helper.UpdateAdminApproval(_selectedRequestId, "Approved"))
            {
                MessageBox.Show("Request APPROVED successfully!\nStudent has been notified.");
                LoadPendingAdminRequests();
                textBoxRequestDetails.Clear();
                _selectedRequestId = -1;
            }
            else
            {
                MessageBox.Show("Failed to approve request.");
            }
        }

        /// <summary>
        /// Reject the selected request
        /// </summary>
        private void buttonReject_Click(object sender, EventArgs e)
        {
            if (_selectedRequestId < 0)
            {
                MessageBox.Show("Please select a request first.");
                return;
            }

            if (MessageBox.Show("Are you sure you want to REJECT this request?\nThe student will be notified.", "Confirm", MessageBoxButtons.YesNo) == DialogResult.No)
                return;

            if (_helper.UpdateAdminApproval(_selectedRequestId, "Rejected"))
            {
                MessageBox.Show("Request REJECTED successfully!\nStudent has been notified.");
                LoadPendingAdminRequests();
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
            LoadPendingAdminRequests();
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
    }
}
