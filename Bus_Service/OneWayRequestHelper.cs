using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace Bus_Service
{
    /// <summary>
    /// Helper class for managing One-Way Requests and Notifications
    /// </summary>
    public class OneWayRequestHelper
    {
        private readonly string _connectionString;

        public OneWayRequestHelper()
        {
            _connectionString = AppSettings.SqlConnectionString;
        }

        public OneWayRequestHelper(string connectionString)
        {
            _connectionString = connectionString;
        }

        // ==========================================
        // ONE-WAY REQUESTS METHODS
        // ==========================================

        /// <summary>
        /// Submit a new one-way request
        /// </summary>
        public bool SubmitOneWayRequest(int studentId, string reason, string route, DateTime requestDate)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                    string query = @"INSERT INTO OneWayRequests (StudentId, Reason, Route, RequestDate, HODStatus, AdminStatus, FinalStatus, CreatedDate, UpdatedDate) 
                                   VALUES (@StudentId, @Reason, @Route, @RequestDate, 'Pending', 'Pending', 'Pending', GETDATE(), GETDATE())";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@StudentId", studentId);
                        command.Parameters.AddWithValue("@Reason", reason);
                        command.Parameters.AddWithValue("@Route", route);
                        command.Parameters.AddWithValue("@RequestDate", requestDate);

                        command.ExecuteNonQuery();

                        // Notify all HOD users
                        NotifyAllHODs($"New One-Way Request from Student ID: {studentId}", null);

                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error submitting one-way request: " + ex.Message);
                return false;
            }
        }

        /// <summary>
        /// Get all student's one-way requests
        /// </summary>
        public DataTable GetStudentOneWayRequests(int studentId)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                    string query = @"SELECT RequestId, StudentId, Reason, Route, RequestDate, HODStatus, AdminStatus, FinalStatus, CreatedDate, UpdatedDate
                                   FROM OneWayRequests
                                   WHERE StudentId = @StudentId
                                   ORDER BY CreatedDate DESC";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@StudentId", studentId);

                        SqlDataAdapter adapter = new SqlDataAdapter(command);
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        return dt;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error retrieving one-way requests: " + ex.Message);
                return new DataTable();
            }
        }

        /// <summary>
        /// Get all pending HOD approval requests
        /// </summary>
        public DataTable GetPendingHODRequests()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                    string query = @"SELECT 
                                        r.RequestId,
                                        r.StudentId,
                                        u.Name AS StudentName,
                                        u.Department,
                                        r.Reason,
                                        r.Route,
                                        r.RequestDate,
                                        r.HODStatus,
                                        r.CreatedDate
                                    FROM OneWayRequests r
                                    INNER JOIN Users u ON r.StudentId = u.UserID
                                    WHERE r.HODStatus = 'Pending'
                                    ORDER BY r.CreatedDate DESC";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        SqlDataAdapter adapter = new SqlDataAdapter(command);
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        return dt;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error retrieving pending HOD requests: " + ex.Message);
                return new DataTable();
            }
        }

        /// <summary>
        /// Get all pending Admin approval requests (HOD approved only)
        /// </summary>
        public DataTable GetPendingAdminRequests()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                    string query = @"SELECT 
                                        r.RequestId,
                                        r.StudentId,
                                        u.Name AS StudentName,
                                        u.Department,
                                        r.Reason,
                                        r.Route,
                                        r.RequestDate,
                                        r.HODStatus,
                                        r.AdminStatus,
                                        r.CreatedDate
                                    FROM OneWayRequests r
                                    INNER JOIN Users u ON r.StudentId = u.UserID
                                    WHERE r.HODStatus = 'Approved' AND r.AdminStatus = 'Pending'
                                    ORDER BY r.CreatedDate DESC";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        SqlDataAdapter adapter = new SqlDataAdapter(command);
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        return dt;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error retrieving pending Admin requests: " + ex.Message);
                return new DataTable();
            }
        }

        /// <summary>
        /// Update HOD approval status
        /// </summary>
        public bool UpdateHODApproval(int requestId, string status)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                    string query = @"UPDATE OneWayRequests 
                                   SET HODStatus = @Status, UpdatedDate = GETDATE()
                                   WHERE RequestId = @RequestId";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@RequestId", requestId);
                        command.Parameters.AddWithValue("@Status", status);

                        command.ExecuteNonQuery();

                        // If approved, notify admin
                        if (status == "Approved")
                        {
                            NotifyAllAdmins($"Request ID {requestId} approved by HOD - awaiting admin approval", requestId);
                        }

                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating HOD approval: " + ex.Message);
                return false;
            }
        }

        /// <summary>
        /// Update Admin final approval status
        /// </summary>
        public bool UpdateAdminApproval(int requestId, string status)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    connection.Open();

                    // Get student ID for notification
                    string getStudentQuery = "SELECT StudentId FROM OneWayRequests WHERE RequestId = @RequestId";
                    int studentId = 0;

                    using (SqlCommand getStudentCmd = new SqlCommand(getStudentQuery, connection))
                    {
                        getStudentCmd.Parameters.AddWithValue("@RequestId", requestId);
                        object result = getStudentCmd.ExecuteScalar();
                        if (result != null)
                            studentId = Convert.ToInt32(result);
                    }

                    // Update status
                    string updateQuery = @"UPDATE OneWayRequests 
                                         SET AdminStatus = @Status, FinalStatus = @Status, UpdatedDate = GETDATE()
                                         WHERE RequestId = @RequestId";

                    using (SqlCommand updateCommand = new SqlCommand(updateQuery, connection))
                    {
                        updateCommand.Parameters.AddWithValue("@RequestId", requestId);
                        updateCommand.Parameters.AddWithValue("@Status", status);

                        updateCommand.ExecuteNonQuery();

                        // Notify student
                        if (studentId > 0)
                        {
                            CreateNotification(studentId, "Student", $"Your one-way request has been {status}", requestId);
                        }

                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating admin approval: " + ex.Message);
                return false;
            }
        }

        // ==========================================
        // NOTIFICATION METHODS
        // ==========================================

        /// <summary>
        /// Create a notification
        /// </summary>
        public bool CreateNotification(int userId, string userType, string message, int? relatedRequestId = null)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                    string query = @"INSERT INTO Notifications (UserId, UserType, Message, RelatedRequestId, IsRead, CreatedDate)
                                   VALUES (@UserId, @UserType, @Message, @RelatedRequestId, 0, GETDATE())";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@UserId", userId);
                        command.Parameters.AddWithValue("@UserType", userType);
                        command.Parameters.AddWithValue("@Message", message);
                        command.Parameters.AddWithValue("@RelatedRequestId", relatedRequestId ?? (object)DBNull.Value);

                        command.ExecuteNonQuery();
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error creating notification: " + ex.Message);
                return false;
            }
        }

        /// <summary>
        /// Notify all HOD users
        /// </summary>
        private void NotifyAllHODs(string message, int? requestId)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                    string query = "SELECT UserID FROM Users WHERE Role = 'HOD'";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        SqlDataReader reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            int userId = Convert.ToInt32(reader["UserID"]);
                            CreateNotification(userId, "HOD", message, requestId);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error notifying HODs: " + ex.Message);
            }
        }

        /// <summary>
        /// Notify all Admin users
        /// </summary>
        private void NotifyAllAdmins(string message, int? requestId)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                    string query = "SELECT UserID FROM Users WHERE Role = 'Admin'";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        SqlDataReader reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            int userId = Convert.ToInt32(reader["UserID"]);
                            CreateNotification(userId, "Admin", message, requestId);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error notifying Admins: " + ex.Message);
            }
        }

        /// <summary>
        /// Get all unread notifications for a user
        /// </summary>
        public DataTable GetUnreadNotifications(int userId)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                    string query = @"SELECT NotificationId, Message, RelatedRequestId, CreatedDate
                                   FROM Notifications
                                   WHERE UserId = @UserId AND IsRead = 0
                                   ORDER BY CreatedDate DESC";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@UserId", userId);

                        SqlDataAdapter adapter = new SqlDataAdapter(command);
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        return dt;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error retrieving notifications: " + ex.Message);
                return new DataTable();
            }
        }

        /// <summary>
        /// Get unread notification count
        /// </summary>
        public int GetUnreadNotificationCount(int userId)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                    string query = "SELECT COUNT(*) FROM Notifications WHERE UserId = @UserId AND IsRead = 0";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@UserId", userId);
                        int count = (int)command.ExecuteScalar();
                        return count;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error retrieving notification count: " + ex.Message);
                return 0;
            }
        }

        /// <summary>
        /// Mark notification as read
        /// </summary>
        public bool MarkNotificationAsRead(int notificationId)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                    string query = "UPDATE Notifications SET IsRead = 1 WHERE NotificationId = @NotificationId";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@NotificationId", notificationId);
                        command.ExecuteNonQuery();
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error marking notification as read: " + ex.Message);
                return false;
            }
        }

        /// <summary>
        /// Get all notifications for a user
        /// </summary>
        public DataTable GetAllNotifications(int userId, int limit = 50)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                    string query = @"SELECT TOP @Limit NotificationId, Message, IsRead, CreatedDate, RelatedRequestId
                                   FROM Notifications
                                   WHERE UserId = @UserId
                                   ORDER BY CreatedDate DESC";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@UserId", userId);
                        command.Parameters.AddWithValue("@Limit", limit);

                        SqlDataAdapter adapter = new SqlDataAdapter(command);
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        return dt;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error retrieving all notifications: " + ex.Message);
                return new DataTable();
            }
        }
    }
}
