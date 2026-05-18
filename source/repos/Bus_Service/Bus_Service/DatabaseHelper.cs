using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace Bus_Service
{
    public class DatabaseHelper
    {
        private readonly string _connectionString;

        public DatabaseHelper()
        {
            _connectionString = AppSettings.SqlConnectionString;
        }

        public DatabaseHelper(string connectionString)
        {
            _connectionString = connectionString;
        }

        // Add Travel
        public bool AddTravel(DateTime travelDate, string busNumber, string route, int seatCapacity)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                    string query = "INSERT INTO TravelDetails (TravelDate, BusNumber, Route, SeatCapacity, SeatsAvailable) " +
                                   "VALUES (@TravelDate, @BusNumber, @Route, @SeatCapacity, @SeatsAvailable)";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@TravelDate", travelDate);
                        command.Parameters.AddWithValue("@BusNumber", busNumber);
                        command.Parameters.AddWithValue("@Route", route);
                        command.Parameters.AddWithValue("@SeatCapacity", seatCapacity);
                        command.Parameters.AddWithValue("@SeatsAvailable", seatCapacity);

                        command.ExecuteNonQuery();
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error adding travel: " + ex.Message);
                return false;
            }
        }

        // Update Travel
        public bool UpdateTravel(int travelId, DateTime travelDate, string busNumber, string route, int seatCapacity)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                    string query = "UPDATE TravelDetails SET TravelDate = @TravelDate, BusNumber = @BusNumber, " +
                                   "Route = @Route, SeatCapacity = @SeatCapacity WHERE TravelID = @TravelID";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@TravelID", travelId);
                        command.Parameters.AddWithValue("@TravelDate", travelDate);
                        command.Parameters.AddWithValue("@BusNumber", busNumber);
                        command.Parameters.AddWithValue("@Route", route);
                        command.Parameters.AddWithValue("@SeatCapacity", seatCapacity);

                        command.ExecuteNonQuery();
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating travel: " + ex.Message);
                return false;
            }
        }

        // Delete Travel
        public bool DeleteTravel(int travelId)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                    string query = "DELETE FROM TravelDetails WHERE TravelID = @TravelID";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@TravelID", travelId);
                        command.ExecuteNonQuery();
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error deleting travel: " + ex.Message);
                return false;
            }
        }

        // Get All Travels
        public DataTable GetAllTravels()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    string query = "SELECT TravelID, TravelDate, BusNumber, Route, SeatCapacity, SeatsAvailable FROM TravelDetails";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);
                    return dataTable;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error retrieving travels: " + ex.Message);
                return new DataTable();
            }
        }

        // Book Seat - Decrement SeatsAvailable
        public bool BookSeat(int travelId)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                    string query = "UPDATE TravelDetails SET SeatsAvailable = SeatsAvailable - 1 WHERE TravelID = @TravelID AND SeatsAvailable > 0";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@TravelID", travelId);
                        int rowsAffected = command.ExecuteNonQuery();
                        return rowsAffected > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error booking seat: " + ex.Message);
                return false;
            }
        }

        // Cancel Booking - Increment SeatsAvailable
        public bool CancelBooking(int travelId)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                    string query = "UPDATE TravelDetails SET SeatsAvailable = SeatsAvailable + 1 WHERE TravelID = @TravelID";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@TravelID", travelId);
                        command.ExecuteNonQuery();
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error cancelling booking: " + ex.Message);
                return false;
            }
        }

        // Mark Attendance
        public bool MarkAttendance(int studentId, DateTime travelDate, string status)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                    string query = "INSERT INTO Attendance (StudentID, TravelDate, Status) VALUES (@StudentID, @TravelDate, @Status)";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@StudentID", studentId);
                        command.Parameters.AddWithValue("@TravelDate", travelDate);
                        command.Parameters.AddWithValue("@Status", status);

                        command.ExecuteNonQuery();
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error marking attendance: " + ex.Message);
                return false;
            }
        }

        // Update Attendance
        public bool UpdateAttendance(int studentId, DateTime travelDate, string status)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                    string query = "UPDATE Attendance SET Status = @Status WHERE StudentID = @StudentID AND TravelDate = @TravelDate";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@StudentID", studentId);
                        command.Parameters.AddWithValue("@TravelDate", travelDate);
                        command.Parameters.AddWithValue("@Status", status);

                        command.ExecuteNonQuery();
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating attendance: " + ex.Message);
                return false;
            }
        }

        // Get Attendance by Travel Date
        public DataTable GetAttendanceByDate(DateTime travelDate)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    string query = "SELECT StudentID, TravelDate, Status FROM Attendance WHERE TravelDate = @TravelDate";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                    adapter.SelectCommand.Parameters.AddWithValue("@TravelDate", travelDate);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);
                    return dataTable;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error retrieving attendance: " + ex.Message);
                return new DataTable();
            }
        }

        // Check if seat is available
        public bool IsSeatAvailable(int travelId)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                    string query = "SELECT SeatsAvailable FROM TravelDetails WHERE TravelID = @TravelID";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@TravelID", travelId);
                        object result = command.ExecuteScalar();

                        if (result != null && int.TryParse(result.ToString(), out int seatsAvailable))
                        {
                            return seatsAvailable > 0;
                        }
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error checking seat availability: " + ex.Message);
                return false;
            }
        }

        // Book a seat with booking type
        public bool BookSeatWithType(int studentId, int travelId, string bookingType)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    connection.Open();

                    // Insert booking record
                    string insertQuery = "INSERT INTO StudentBooking (StudentID, TravelID, BookingType, BookingStatus) " +
                                       "VALUES (@StudentID, @TravelID, @BookingType, 'Booked')";

                    using (SqlCommand command = new SqlCommand(insertQuery, connection))
                    {
                        command.Parameters.AddWithValue("@StudentID", studentId);
                        command.Parameters.AddWithValue("@TravelID", travelId);
                        command.Parameters.AddWithValue("@BookingType", bookingType);
                        command.ExecuteNonQuery();
                    }

                    // Update seats available
                    string updateQuery = "UPDATE TravelDetails SET SeatsAvailable = SeatsAvailable - 1 " +
                                       "WHERE TravelID = @TravelID AND SeatsAvailable > 0";

                    using (SqlCommand command = new SqlCommand(updateQuery, connection))
                    {
                        command.Parameters.AddWithValue("@TravelID", travelId);
                        int rowsAffected = command.ExecuteNonQuery();
                        return rowsAffected > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error booking seat: " + ex.Message);
                return false;
            }
        }

        // Get student bookings
        public DataTable GetStudentBookings(int studentId)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    string query = @"SELECT 
                                    sb.BookingID, 
                                    sb.BookingType, 
                                    sb.BookingStatus,
                                    td.TravelID, 
                                    td.TravelDate, 
                                    td.BusNumber, 
                                    td.Route, 
                                    td.SeatCapacity,
                                    sb.BookingDate
                                FROM StudentBooking sb
                                INNER JOIN TravelDetails td ON sb.TravelID = td.TravelID
                                WHERE sb.StudentID = @StudentID
                                ORDER BY td.TravelDate DESC";

                    SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                    adapter.SelectCommand.Parameters.AddWithValue("@StudentID", studentId);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);
                    return dataTable;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error retrieving bookings: " + ex.Message);
                return new DataTable();
            }
        }

        // Cancel booking for student
        public bool CancelStudentBooking(int bookingId, int travelId)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    connection.Open();

                    // Update booking status
                    string updateBookingQuery = "UPDATE StudentBooking SET BookingStatus = 'Cancelled' WHERE BookingID = @BookingID";
                    using (SqlCommand command = new SqlCommand(updateBookingQuery, connection))
                    {
                        command.Parameters.AddWithValue("@BookingID", bookingId);
                        command.ExecuteNonQuery();
                    }

                    // Increment seats available
                    string updateSeatsQuery = "UPDATE TravelDetails SET SeatsAvailable = SeatsAvailable + 1 WHERE TravelID = @TravelID";
                    using (SqlCommand command = new SqlCommand(updateSeatsQuery, connection))
                    {
                        command.Parameters.AddWithValue("@TravelID", travelId);
                        command.ExecuteNonQuery();
                    }

                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error cancelling booking: " + ex.Message);
                return false;
            }
        }

        // Get upcoming travels
        public DataTable GetUpcomingTravels()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    string query = @"SELECT TOP 10 
                                    TravelID, 
                                    TravelDate, 
                                    BusNumber, 
                                    Route, 
                                    SeatCapacity, 
                                    SeatsAvailable,
                                    TravelType
                                FROM TravelDetails 
                                WHERE TravelDate >= GETDATE()
                                ORDER BY TravelDate ASC";

                    SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);
                    return dataTable;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error retrieving upcoming travels: " + ex.Message);
                return new DataTable();
            }
        }
    }
}
