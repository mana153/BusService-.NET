using System;
using System.IO;
using System.Data;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace Bus_Service
{
    /// <summary>
    /// Database initialization and setup utility
    /// Automatically creates tables and schema on first run
    /// </summary>
    public static class DatabaseInitializer
    {
        /// <summary>
        /// Initialize database schema on application startup
        /// </summary>
        public static void Initialize()
        {
            try
            {
                string connectionString = AppSettings.SqlConnectionString;

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Check if Users table exists
                    if (!TableExists(connection, "Users"))
                    {
                        CreateAllTables(connection);
                    }
                    else
                    {
                        // Verify all required tables exist
                        VerifyAndCreateMissingTables(connection);
                    }
                }
            }
            catch (Exception ex)
            {
                string errorMsg = "Database initialization error: " + ex.Message;
                if (ex.InnerException != null)
                {
                    errorMsg += "\n\nDetails: " + ex.InnerException.Message;
                }
                MessageBox.Show(errorMsg, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Check if a table exists in the database
        /// </summary>
        private static bool TableExists(SqlConnection connection, string tableName)
        {
            try
            {
                string query = @"SELECT COUNT(*) FROM INFORMATION_SCHEMA.TABLES 
                               WHERE TABLE_NAME = @TableName";
                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@TableName", tableName);
                    int result = (int)cmd.ExecuteScalar();
                    return result > 0;
                }
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Create all required tables if they don't exist
        /// </summary>
        private static void CreateAllTables(SqlConnection connection)
        {
            string script = GetCreateTablesScript();
            ExecuteSqlScript(connection, script);
        }

        /// <summary>
        /// Verify all required tables exist and create missing ones
        /// </summary>
        private static void VerifyAndCreateMissingTables(SqlConnection connection)
        {
            string[] requiredTables = new string[]
            {
                "Users", "TravelDetails", "StudentBooking", "Attendance",
                "OneWayRequests", "BusSchedule", "Cancellations",
                "AllowedVolunteers", "Notifications"
            };

            foreach (var table in requiredTables)
            {
                if (!TableExists(connection, table))
                {
                    CreateMissingTable(connection, table);
                }
            }
        }

        /// <summary>
        /// Create a specific missing table based on its name
        /// </summary>
        private static void CreateMissingTable(SqlConnection connection, string tableName)
        {
            string createScript = GetTableCreationScript(tableName);
            if (!string.IsNullOrEmpty(createScript))
            {
                ExecuteSqlScript(connection, createScript);
            }
        }

        /// <summary>
        /// Get SQL script for creating a specific table
        /// </summary>
        private static string GetTableCreationScript(string tableName)
        {
            return tableName switch
            {
                "Users" => @"
                    CREATE TABLE [dbo].[Users]
                    (
                        [UserID] INT PRIMARY KEY IDENTITY(1,1),
                        [Username] NVARCHAR(100) NOT NULL UNIQUE,
                        [Password] NVARCHAR(255) NOT NULL,
                        [Role] NVARCHAR(50) NOT NULL,
                        [Department] NVARCHAR(100),
                        [CreatedDate] DATETIME DEFAULT GETDATE(),
                        [UpdatedDate] DATETIME DEFAULT GETDATE()
                    );",

                "TravelDetails" => @"
                    CREATE TABLE [dbo].[TravelDetails]
                    (
                        [TravelID] INT PRIMARY KEY IDENTITY(1,1),
                        [TravelDate] DATETIME NOT NULL,
                        [BusNumber] NVARCHAR(50) NOT NULL,
                        [Route] NVARCHAR(255) NOT NULL,
                        [SeatCapacity] INT NOT NULL,
                        [SeatsAvailable] INT NOT NULL,
                        [TravelType] NVARCHAR(50) DEFAULT 'TwoWay',
                        [CreatedDate] DATETIME DEFAULT GETDATE(),
                        [UpdatedDate] DATETIME DEFAULT GETDATE()
                    );",

                "StudentBooking" => @"
                    CREATE TABLE [dbo].[StudentBooking]
                    (
                        [BookingID] INT PRIMARY KEY IDENTITY(1,1),
                        [StudentID] INT NOT NULL,
                        [TravelID] INT NOT NULL,
                        [BookingType] NVARCHAR(50) NOT NULL,
                        [BookingStatus] NVARCHAR(50) DEFAULT 'Booked',
                        [BookingDate] DATETIME DEFAULT GETDATE(),
                        [CreatedDate] DATETIME DEFAULT GETDATE(),
                        [UpdatedDate] DATETIME DEFAULT GETDATE(),
                        FOREIGN KEY ([StudentID]) REFERENCES [Users]([UserID]) ON DELETE CASCADE,
                        FOREIGN KEY ([TravelID]) REFERENCES [TravelDetails]([TravelID]) ON DELETE CASCADE
                    );",

                "Attendance" => @"
                    CREATE TABLE [dbo].[Attendance]
                    (
                        [AttendanceID] INT PRIMARY KEY IDENTITY(1,1),
                        [StudentID] INT NOT NULL,
                        [TravelDate] DATETIME NOT NULL,
                        [Status] NVARCHAR(50) NOT NULL,
                        [CreatedDate] DATETIME DEFAULT GETDATE(),
                        [UpdatedDate] DATETIME DEFAULT GETDATE(),
                        FOREIGN KEY ([StudentID]) REFERENCES [Users]([UserID]) ON DELETE CASCADE,
                        UNIQUE([StudentID], [TravelDate])
                    );",

                "OneWayRequests" => @"
                    CREATE TABLE [dbo].[OneWayRequests]
                    (
                        [RequestId] INT PRIMARY KEY IDENTITY(1,1),
                        [StudentId] INT NOT NULL,
                        [Reason] NVARCHAR(MAX) NOT NULL,
                        [Route] NVARCHAR(255) NOT NULL,
                        [RequestDate] DATETIME NOT NULL,
                        [HODStatus] NVARCHAR(50) DEFAULT 'Pending',
                        [AdminStatus] NVARCHAR(50) DEFAULT 'Pending',
                        [FinalStatus] NVARCHAR(50) DEFAULT 'Pending',
                        [CreatedDate] DATETIME DEFAULT GETDATE(),
                        [UpdatedDate] DATETIME DEFAULT GETDATE(),
                        FOREIGN KEY ([StudentId]) REFERENCES [Users]([UserID]) ON DELETE CASCADE
                    );",

                "BusSchedule" => @"
                    CREATE TABLE [dbo].[BusSchedule]
                    (
                        [ScheduleID] INT PRIMARY KEY IDENTITY(1,1),
                        [BusNumber] NVARCHAR(50) NOT NULL,
                        [Route] NVARCHAR(255) NOT NULL,
                        [DayOfWeek] NVARCHAR(50),
                        [DepartureTime] TIME,
                        [ArrivalTime] TIME,
                        [Capacity] INT NOT NULL,
                        [CreatedDate] DATETIME DEFAULT GETDATE(),
                        [UpdatedDate] DATETIME DEFAULT GETDATE()
                    );",

                "Cancellations" => @"
                    CREATE TABLE [dbo].[Cancellations]
                    (
                        [CancellationID] INT PRIMARY KEY IDENTITY(1,1),
                        [BookingID] INT NOT NULL,
                        [StudentID] INT NOT NULL,
                        [TravelID] INT NOT NULL,
                        [Reason] NVARCHAR(MAX),
                        [CancellationDate] DATETIME DEFAULT GETDATE(),
                        [CreatedDate] DATETIME DEFAULT GETDATE(),
                        FOREIGN KEY ([StudentID]) REFERENCES [Users]([UserID]) ON DELETE CASCADE,
                        FOREIGN KEY ([TravelID]) REFERENCES [TravelDetails]([TravelID]) ON DELETE CASCADE
                    );",

                "AllowedVolunteers" => @"
                    CREATE TABLE [dbo].[AllowedVolunteers]
                    (
                        [VolunteerID] INT PRIMARY KEY IDENTITY(1,1),
                        [RegNo] NVARCHAR(100) NOT NULL UNIQUE,
                        [Name] NVARCHAR(100),
                        [Department] NVARCHAR(100),
                        [IsActive] BIT DEFAULT 1,
                        [CreatedDate] DATETIME DEFAULT GETDATE(),
                        [UpdatedDate] DATETIME DEFAULT GETDATE()
                    );",

                "Notifications" => @"
                    CREATE TABLE [dbo].[Notifications]
                    (
                        [NotificationId] INT PRIMARY KEY IDENTITY(1,1),
                        [UserId] INT NOT NULL,
                        [UserType] NVARCHAR(50),
                        [Message] NVARCHAR(MAX) NOT NULL,
                        [RelatedRequestId] INT,
                        [IsRead] BIT DEFAULT 0,
                        [CreatedDate] DATETIME DEFAULT GETDATE(),
                        FOREIGN KEY ([UserId]) REFERENCES [Users]([UserID]) ON DELETE CASCADE
                    );",

                _ => null
            };
        }

        /// <summary>
        /// Get the complete database creation script
        /// </summary>
        private static string GetCreateTablesScript()
        {
            return @"
                -- Users Table
                IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Users]') AND type in (N'U'))
                    CREATE TABLE [dbo].[Users]
                    (
                        [UserID] INT PRIMARY KEY IDENTITY(1,1),
                        [Username] NVARCHAR(100) NOT NULL UNIQUE,
                        [Password] NVARCHAR(255) NOT NULL,
                        [Role] NVARCHAR(50) NOT NULL,
                        [Department] NVARCHAR(100),
                        [CreatedDate] DATETIME DEFAULT GETDATE(),
                        [UpdatedDate] DATETIME DEFAULT GETDATE()
                    );

                -- TravelDetails Table
                IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TravelDetails]') AND type in (N'U'))
                    CREATE TABLE [dbo].[TravelDetails]
                    (
                        [TravelID] INT PRIMARY KEY IDENTITY(1,1),
                        [TravelDate] DATETIME NOT NULL,
                        [BusNumber] NVARCHAR(50) NOT NULL,
                        [Route] NVARCHAR(255) NOT NULL,
                        [SeatCapacity] INT NOT NULL,
                        [SeatsAvailable] INT NOT NULL,
                        [TravelType] NVARCHAR(50) DEFAULT 'TwoWay',
                        [CreatedDate] DATETIME DEFAULT GETDATE(),
                        [UpdatedDate] DATETIME DEFAULT GETDATE()
                    );

                -- StudentBooking Table
                IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[StudentBooking]') AND type in (N'U'))
                    CREATE TABLE [dbo].[StudentBooking]
                    (
                        [BookingID] INT PRIMARY KEY IDENTITY(1,1),
                        [StudentID] INT NOT NULL,
                        [TravelID] INT NOT NULL,
                        [BookingType] NVARCHAR(50) NOT NULL,
                        [BookingStatus] NVARCHAR(50) DEFAULT 'Booked',
                        [BookingDate] DATETIME DEFAULT GETDATE(),
                        [CreatedDate] DATETIME DEFAULT GETDATE(),
                        [UpdatedDate] DATETIME DEFAULT GETDATE(),
                        FOREIGN KEY ([StudentID]) REFERENCES [Users]([UserID]) ON DELETE CASCADE,
                        FOREIGN KEY ([TravelID]) REFERENCES [TravelDetails]([TravelID]) ON DELETE CASCADE
                    );

                -- Attendance Table
                IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Attendance]') AND type in (N'U'))
                    CREATE TABLE [dbo].[Attendance]
                    (
                        [AttendanceID] INT PRIMARY KEY IDENTITY(1,1),
                        [StudentID] INT NOT NULL,
                        [TravelDate] DATETIME NOT NULL,
                        [Status] NVARCHAR(50) NOT NULL,
                        [CreatedDate] DATETIME DEFAULT GETDATE(),
                        [UpdatedDate] DATETIME DEFAULT GETDATE(),
                        FOREIGN KEY ([StudentID]) REFERENCES [Users]([UserID]) ON DELETE CASCADE,
                        UNIQUE([StudentID], [TravelDate])
                    );

                -- OneWayRequests Table
                IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[OneWayRequests]') AND type in (N'U'))
                    CREATE TABLE [dbo].[OneWayRequests]
                    (
                        [RequestId] INT PRIMARY KEY IDENTITY(1,1),
                        [StudentId] INT NOT NULL,
                        [Reason] NVARCHAR(MAX) NOT NULL,
                        [Route] NVARCHAR(255) NOT NULL,
                        [RequestDate] DATETIME NOT NULL,
                        [HODStatus] NVARCHAR(50) DEFAULT 'Pending',
                        [AdminStatus] NVARCHAR(50) DEFAULT 'Pending',
                        [FinalStatus] NVARCHAR(50) DEFAULT 'Pending',
                        [CreatedDate] DATETIME DEFAULT GETDATE(),
                        [UpdatedDate] DATETIME DEFAULT GETDATE(),
                        FOREIGN KEY ([StudentId]) REFERENCES [Users]([UserID]) ON DELETE CASCADE
                    );

                -- BusSchedule Table
                IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[BusSchedule]') AND type in (N'U'))
                    CREATE TABLE [dbo].[BusSchedule]
                    (
                        [ScheduleID] INT PRIMARY KEY IDENTITY(1,1),
                        [BusNumber] NVARCHAR(50) NOT NULL,
                        [Route] NVARCHAR(255) NOT NULL,
                        [DayOfWeek] NVARCHAR(50),
                        [DepartureTime] TIME,
                        [ArrivalTime] TIME,
                        [Capacity] INT NOT NULL,
                        [CreatedDate] DATETIME DEFAULT GETDATE(),
                        [UpdatedDate] DATETIME DEFAULT GETDATE()
                    );

                -- Cancellations Table
                IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Cancellations]') AND type in (N'U'))
                    CREATE TABLE [dbo].[Cancellations]
                    (
                        [CancellationID] INT PRIMARY KEY IDENTITY(1,1),
                        [BookingID] INT NOT NULL,
                        [StudentID] INT NOT NULL,
                        [TravelID] INT NOT NULL,
                        [Reason] NVARCHAR(MAX),
                        [CancellationDate] DATETIME DEFAULT GETDATE(),
                        [CreatedDate] DATETIME DEFAULT GETDATE(),
                        FOREIGN KEY ([StudentID]) REFERENCES [Users]([UserID]) ON DELETE CASCADE,
                        FOREIGN KEY ([TravelID]) REFERENCES [TravelDetails]([TravelID]) ON DELETE CASCADE
                    );

                -- AllowedVolunteers Table
                IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[AllowedVolunteers]') AND type in (N'U'))
                    CREATE TABLE [dbo].[AllowedVolunteers]
                    (
                        [VolunteerID] INT PRIMARY KEY IDENTITY(1,1),
                        [RegNo] NVARCHAR(100) NOT NULL UNIQUE,
                        [Name] NVARCHAR(100),
                        [Department] NVARCHAR(100),
                        [IsActive] BIT DEFAULT 1,
                        [CreatedDate] DATETIME DEFAULT GETDATE(),
                        [UpdatedDate] DATETIME DEFAULT GETDATE()
                    );

                -- Notifications Table
                IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Notifications]') AND type in (N'U'))
                    CREATE TABLE [dbo].[Notifications]
                    (
                        [NotificationId] INT PRIMARY KEY IDENTITY(1,1),
                        [UserId] INT NOT NULL,
                        [UserType] NVARCHAR(50),
                        [Message] NVARCHAR(MAX) NOT NULL,
                        [RelatedRequestId] INT,
                        [IsRead] BIT DEFAULT 0,
                        [CreatedDate] DATETIME DEFAULT GETDATE(),
                        FOREIGN KEY ([UserId]) REFERENCES [Users]([UserID]) ON DELETE CASCADE
                    );
            ";
        }

        /// <summary>
        /// Execute SQL script against the database
        /// </summary>
        private static void ExecuteSqlScript(SqlConnection connection, string script)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand(script, connection))
                {
                    cmd.CommandTimeout = 300; // 5 minutes
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("SQL Script Error: " + ex.Message);
            }
        }
    }
}
    