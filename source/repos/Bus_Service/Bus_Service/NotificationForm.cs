using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Bus_Service
{
    public partial class NotificationForm : Form
    {
        private int _userId;
        private string _connectionString = AppSettings.SqlConnectionString;
        private OneWayRequestHelper _helper;

        public NotificationForm(int userId)
        {
            InitializeComponent();
            _userId = userId;
            _helper = new OneWayRequestHelper(_connectionString);
        }

        private void NotificationForm_Load(object sender, EventArgs e)
        {
            LoadNotifications();
        }

        /// <summary>
        /// Load all notifications for the user
        /// </summary>
        private void LoadNotifications()
        {
            try
            {
                DataTable notifications = _helper.GetAllNotifications(_userId);
                dataGridViewNotifications.DataSource = notifications;

                // Format columns
                if (dataGridViewNotifications.Columns.Count > 0)
                {
                    dataGridViewNotifications.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
                }

                // Update unread count
                int unreadCount = _helper.GetUnreadNotificationCount(_userId);
                labelUnreadCount.Text = $"Unread: {unreadCount}";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading notifications: " + ex.Message);
            }
        }

        /// <summary>
        /// Mark selected notification as read
        /// </summary>
        private void buttonMarkAsRead_Click(object sender, EventArgs e)
        {
            if (dataGridViewNotifications.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a notification first.");
                return;
            }

            DataGridViewRow selectedRow = dataGridViewNotifications.SelectedRows[0];
            int notificationId = Convert.ToInt32(selectedRow.Cells["NotificationId"].Value);

            if (_helper.MarkNotificationAsRead(notificationId))
            {
                MessageBox.Show("Notification marked as read.");
                LoadNotifications();
            }
        }

        /// <summary>
        /// Mark all notifications as read
        /// </summary>
        private void buttonMarkAllAsRead_Click(object sender, EventArgs e)
        {
            if (dataGridViewNotifications.Rows.Count == 0)
            {
                MessageBox.Show("No notifications to mark as read.");
                return;
            }

            foreach (DataGridViewRow row in dataGridViewNotifications.Rows)
            {
                if (row.Cells["IsRead"].Value != null)
                {
                    bool isRead = Convert.ToBoolean(row.Cells["IsRead"].Value);
                    if (!isRead)
                    {
                        int notificationId = Convert.ToInt32(row.Cells["NotificationId"].Value);
                        _helper.MarkNotificationAsRead(notificationId);
                    }
                }
            }

            MessageBox.Show("All notifications marked as read.");
            LoadNotifications();
        }

        /// <summary>
        /// Refresh notifications
        /// </summary>
        private void buttonRefresh_Click(object sender, EventArgs e)
        {
            LoadNotifications();
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
