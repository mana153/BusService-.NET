-- Users Table
IF NOT EXISTS (SELECT 1 FROM sys.tables WHERE name = 'Users')
BEGIN
    CREATE TABLE Users (
        UserID INT IDENTITY(1,1) PRIMARY KEY,
        Username VARCHAR(100) UNIQUE NOT NULL,
        Password VARCHAR(255) NOT NULL,
        Role VARCHAR(50) NOT NULL CHECK (Role IN ('Student', 'Admin', 'HOD', 'Volunteer')),
        Department VARCHAR(100),
        RegDate DATETIME DEFAULT GETDATE(),
        IsActive BIT DEFAULT 1
    );
END
GO

-- TravelDetails Table
IF NOT EXISTS (SELECT 1 FROM sys.tables WHERE name = 'TravelDetails')
BEGIN
    CREATE TABLE TravelDetails (
        TravelID INT IDENTITY(1,1) PRIMARY KEY,
        TravelDate DATETIME NOT NULL,
        BusNumber VARCHAR(50) NOT NULL,
        Route VARCHAR(100) NOT NULL,
        SeatCapacity INT NOT NULL,
        SeatsAvailable INT NOT NULL,
        TravelType VARCHAR(20) DEFAULT 'TwoWay' CHECK (TravelType IN ('OneWay', 'TwoWay')),
        CreatedDate DATETIME DEFAULT GETDATE(),
        UpdatedDate DATETIME DEFAULT GETDATE()
    );
END
GO

-- StudentBooking Table
IF NOT EXISTS (SELECT 1 FROM sys.tables WHERE name = 'StudentBooking')
BEGIN
    CREATE TABLE StudentBooking (
        BookingID INT IDENTITY(1,1) PRIMARY KEY,
        StudentID INT NOT NULL,
        TravelID INT NOT NULL,
        BookingType VARCHAR(20) NOT NULL CHECK (BookingType IN ('OneWay', 'TwoWay')),
        BookingStatus VARCHAR(20) NOT NULL DEFAULT 'Booked' CHECK (BookingStatus IN ('Booked', 'Cancelled', 'Completed')),
        BookingDate DATETIME DEFAULT GETDATE(),
        FOREIGN KEY (StudentID) REFERENCES Users(UserID),
        FOREIGN KEY (TravelID) REFERENCES TravelDetails(TravelID)
    );
END
GO

-- OneWayRequests Table
IF NOT EXISTS (SELECT 1 FROM sys.tables WHERE name = 'OneWayRequests')
BEGIN
    CREATE TABLE OneWayRequests (
        RequestId INT IDENTITY(1,1) PRIMARY KEY,
        StudentId INT NOT NULL,
        Reason NVARCHAR(MAX) NOT NULL,
        Route VARCHAR(100) NOT NULL,
        RequestDate DATETIME NOT NULL,
        HODStatus VARCHAR(50) DEFAULT 'Pending' CHECK (HODStatus IN ('Pending', 'Approved', 'Rejected')),
        AdminStatus VARCHAR(50) DEFAULT 'Pending' CHECK (AdminStatus IN ('Pending', 'Approved', 'Rejected')),
        FinalStatus VARCHAR(50) DEFAULT 'Pending' CHECK (FinalStatus IN ('Pending', 'Approved', 'Rejected', 'Expired')),
        CreatedDate DATETIME DEFAULT GETDATE(),
        UpdatedDate DATETIME DEFAULT GETDATE(),
        FOREIGN KEY (StudentId) REFERENCES Users(UserID)
    );
END
GO

-- Notifications Table
IF NOT EXISTS (SELECT 1 FROM sys.tables WHERE name = 'Notifications')
BEGIN
    CREATE TABLE Notifications (
        NotificationID INT IDENTITY(1,1) PRIMARY KEY,
        UserID INT NOT NULL,
        Title VARCHAR(255) NOT NULL,
        Message NVARCHAR(MAX) NOT NULL,
        Type VARCHAR(50),
        IsRead BIT DEFAULT 0,
        CreatedDate DATETIME DEFAULT GETDATE(),
        FOREIGN KEY (UserID) REFERENCES Users(UserID)
    );
END
GO

-- Attendance Table
IF NOT EXISTS (SELECT 1 FROM sys.tables WHERE name = 'Attendance')
BEGIN
    CREATE TABLE Attendance (
        AttendanceID INT IDENTITY(1,1) PRIMARY KEY,
        StudentID INT NOT NULL,
        TravelID INT NOT NULL,
        Status VARCHAR(20) NOT NULL CHECK (Status IN ('Present', 'Absent')),
        CreatedDate DATETIME DEFAULT GETDATE(),
        FOREIGN KEY (StudentID) REFERENCES Users(UserID),
        FOREIGN KEY (TravelID) REFERENCES TravelDetails(TravelID)
    );
END
GO

-- Create Indexes
IF NOT EXISTS (SELECT 1 FROM sys.indexes WHERE name = 'idx_TravelDetails_TravelDate')
    CREATE INDEX idx_TravelDetails_TravelDate ON TravelDetails(TravelDate);

IF NOT EXISTS (SELECT 1 FROM sys.indexes WHERE name = 'idx_StudentBooking_StudentID')
    CREATE INDEX idx_StudentBooking_StudentID ON StudentBooking(StudentID);

IF NOT EXISTS (SELECT 1 FROM sys.indexes WHERE name = 'idx_OneWayRequests_StudentId')
    CREATE INDEX idx_OneWayRequests_StudentId ON OneWayRequests(StudentId);

GO

-- Insert sample data
INSERT INTO Users (Username, Password, Role, Department, IsActive) 
VALUES ('admin', 'admin123', 'Admin', 'Administration', 1);

INSERT INTO Users (Username, Password, Role, Department, IsActive) 
VALUES ('hod1', 'hod123', 'HOD', 'Computer Science', 1);

INSERT INTO Users (Username, Password, Role, Department, IsActive) 
VALUES ('student1', 'student123', 'Student', 'Computer Science', 1);

INSERT INTO Users (Username, Password, Role, Department, IsActive) 
VALUES ('volunteer1', 'vol123', 'Volunteer', 'Volunteer Team', 1);

INSERT INTO TravelDetails (TravelDate, BusNumber, Route, SeatCapacity, SeatsAvailable, TravelType) 
VALUES 
(DATEADD(day, 1, GETDATE()), 'BUS001', 'Route A - City Center', 50, 50, 'TwoWay'),
(DATEADD(day, 1, GETDATE()), 'BUS002', 'Route B - Downtown', 45, 45, 'TwoWay'),
(DATEADD(day, 2, GETDATE()), 'BUS003', 'Route C - Campus', 40, 40, 'OneWay');

GO
