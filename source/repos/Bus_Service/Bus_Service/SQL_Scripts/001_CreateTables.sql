-- =====================================================
-- Bus Service Management System Database Setup
-- Database: Database1.mdf (Service-Based)
-- =====================================================

-- =====================================================
-- 1. USERS TABLE - Core user management
-- =====================================================
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Users]') AND type in (N'U'))
BEGIN
    CREATE TABLE [dbo].[Users]
    (
        [UserID] INT PRIMARY KEY IDENTITY(1,1),
        [Username] NVARCHAR(100) NOT NULL UNIQUE,
        [Password] NVARCHAR(255) NOT NULL,
        [Role] NVARCHAR(50) NOT NULL, -- Admin, Student, HOD, Volunteer
        [Department] NVARCHAR(100),
        [CreatedDate] DATETIME DEFAULT GETDATE(),
        [UpdatedDate] DATETIME DEFAULT GETDATE()
    );
    PRINT 'Users table created';
END
ELSE
    PRINT 'Users table already exists';

-- =====================================================
-- 2. TRAVEL DETAILS TABLE - Bus travels/routes
-- =====================================================
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TravelDetails]') AND type in (N'U'))
BEGIN
    CREATE TABLE [dbo].[TravelDetails]
    (
        [TravelID] INT PRIMARY KEY IDENTITY(1,1),
        [TravelDate] DATETIME NOT NULL,
        [BusNumber] NVARCHAR(50) NOT NULL,
        [Route] NVARCHAR(255) NOT NULL,
        [SeatCapacity] INT NOT NULL,
        [SeatsAvailable] INT NOT NULL,
        [TravelType] NVARCHAR(50) DEFAULT 'TwoWay', -- TwoWay, OneWay
        [CreatedDate] DATETIME DEFAULT GETDATE(),
        [UpdatedDate] DATETIME DEFAULT GETDATE()
    );
    PRINT 'TravelDetails table created';
END
ELSE
    PRINT 'TravelDetails table already exists';

-- =====================================================
-- 3. STUDENT BOOKING TABLE - Student seat bookings
-- =====================================================
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[StudentBooking]') AND type in (N'U'))
BEGIN
    CREATE TABLE [dbo].[StudentBooking]
    (
        [BookingID] INT PRIMARY KEY IDENTITY(1,1),
        [StudentID] INT NOT NULL,
        [TravelID] INT NOT NULL,
        [BookingType] NVARCHAR(50) NOT NULL, -- TwoWay, OneWay
        [BookingStatus] NVARCHAR(50) DEFAULT 'Booked', -- Booked, Cancelled
        [BookingDate] DATETIME DEFAULT GETDATE(),
        [CreatedDate] DATETIME DEFAULT GETDATE(),
        [UpdatedDate] DATETIME DEFAULT GETDATE(),
        FOREIGN KEY ([StudentID]) REFERENCES [Users]([UserID]) ON DELETE CASCADE,
        FOREIGN KEY ([TravelID]) REFERENCES [TravelDetails]([TravelID]) ON DELETE CASCADE
    );
    PRINT 'StudentBooking table created';
END
ELSE
    PRINT 'StudentBooking table already exists';

-- =====================================================
-- 4. ATTENDANCE TABLE - Student attendance records
-- =====================================================
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Attendance]') AND type in (N'U'))
BEGIN
    CREATE TABLE [dbo].[Attendance]
    (
        [AttendanceID] INT PRIMARY KEY IDENTITY(1,1),
        [StudentID] INT NOT NULL,
        [TravelDate] DATETIME NOT NULL,
        [Status] NVARCHAR(50) NOT NULL, -- Present, Absent
        [CreatedDate] DATETIME DEFAULT GETDATE(),
        [UpdatedDate] DATETIME DEFAULT GETDATE(),
        FOREIGN KEY ([StudentID]) REFERENCES [Users]([UserID]) ON DELETE CASCADE,
        UNIQUE([StudentID], [TravelDate])
    );
    PRINT 'Attendance table created';
END
ELSE
    PRINT 'Attendance table already exists';

-- =====================================================
-- 5. ONE WAY REQUESTS TABLE - One-way request management
-- =====================================================
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[OneWayRequests]') AND type in (N'U'))
BEGIN
    CREATE TABLE [dbo].[OneWayRequests]
    (
        [RequestId] INT PRIMARY KEY IDENTITY(1,1),
        [StudentId] INT NOT NULL,
        [Reason] NVARCHAR(MAX) NOT NULL,
        [Route] NVARCHAR(255) NOT NULL,
        [RequestDate] DATETIME NOT NULL,
        [HODStatus] NVARCHAR(50) DEFAULT 'Pending', -- Pending, Approved, Rejected
        [AdminStatus] NVARCHAR(50) DEFAULT 'Pending', -- Pending, Approved, Rejected
        [FinalStatus] NVARCHAR(50) DEFAULT 'Pending', -- Pending, Approved, Rejected
        [CreatedDate] DATETIME DEFAULT GETDATE(),
        [UpdatedDate] DATETIME DEFAULT GETDATE(),
        FOREIGN KEY ([StudentId]) REFERENCES [Users]([UserID]) ON DELETE CASCADE
    );
    PRINT 'OneWayRequests table created';
END
ELSE
    PRINT 'OneWayRequests table already exists';

-- =====================================================
-- 6. BUS SCHEDULE TABLE - Regular bus schedules
-- =====================================================
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[BusSchedule]') AND type in (N'U'))
BEGIN
    CREATE TABLE [dbo].[BusSchedule]
    (
        [ScheduleID] INT PRIMARY KEY IDENTITY(1,1),
        [BusNumber] NVARCHAR(50) NOT NULL,
        [Route] NVARCHAR(255) NOT NULL,
        [DayOfWeek] NVARCHAR(50), -- Monday, Tuesday, etc.
        [DepartureTime] TIME,
        [ArrivalTime] TIME,
        [Capacity] INT NOT NULL,
        [CreatedDate] DATETIME DEFAULT GETDATE(),
        [UpdatedDate] DATETIME DEFAULT GETDATE()
    );
    PRINT 'BusSchedule table created';
END
ELSE
    PRINT 'BusSchedule table already exists';

-- =====================================================
-- 7. CANCELLATIONS TABLE - Booking cancellations
-- =====================================================
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Cancellations]') AND type in (N'U'))
BEGIN
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
    PRINT 'Cancellations table created';
END
ELSE
    PRINT 'Cancellations table already exists';

-- =====================================================
-- 8. ALLOWED VOLUNTEERS TABLE - Volunteer management
-- =====================================================
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[AllowedVolunteers]') AND type in (N'U'))
BEGIN
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
    PRINT 'AllowedVolunteers table created';
END
ELSE
    PRINT 'AllowedVolunteers table already exists';

-- =====================================================
-- 9. NOTIFICATIONS TABLE - User notifications
-- =====================================================
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Notifications]') AND type in (N'U'))
BEGIN
    CREATE TABLE [dbo].[Notifications]
    (
        [NotificationId] INT PRIMARY KEY IDENTITY(1,1),
        [UserId] INT NOT NULL,
        [UserType] NVARCHAR(50), -- Admin, Student, HOD, Volunteer
        [Message] NVARCHAR(MAX) NOT NULL,
        [RelatedRequestId] INT,
        [IsRead] BIT DEFAULT 0,
        [CreatedDate] DATETIME DEFAULT GETDATE(),
        FOREIGN KEY ([UserId]) REFERENCES [Users]([UserID]) ON DELETE CASCADE
    );
    PRINT 'Notifications table created';
END
ELSE
    PRINT 'Notifications table already exists';

-- =====================================================
-- Create Indexes for Performance
-- =====================================================
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[Users]') AND name = N'IX_Users_Username')
    CREATE INDEX [IX_Users_Username] ON [dbo].[Users]([Username]);

IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[TravelDetails]') AND name = N'IX_TravelDetails_TravelDate')
    CREATE INDEX [IX_TravelDetails_TravelDate] ON [dbo].[TravelDetails]([TravelDate]);

IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[StudentBooking]') AND name = N'IX_StudentBooking_StudentID')
    CREATE INDEX [IX_StudentBooking_StudentID] ON [dbo].[StudentBooking]([StudentID]);

IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[Attendance]') AND name = N'IX_Attendance_StudentID')
    CREATE INDEX [IX_Attendance_StudentID] ON [dbo].[Attendance]([StudentID]);

IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[OneWayRequests]') AND name = N'IX_OneWayRequests_StudentId')
    CREATE INDEX [IX_OneWayRequests_StudentId] ON [dbo].[OneWayRequests]([StudentId]);

PRINT '================================================';
PRINT 'Database setup completed successfully';
PRINT '================================================';
