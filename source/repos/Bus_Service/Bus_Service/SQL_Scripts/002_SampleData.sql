-- =====================================================
-- Bus Service Management System - Sample Data
-- Database: Database1.mdf
-- =====================================================

-- =====================================================
-- 1. INSERT SAMPLE USERS
-- =====================================================

-- Admin User
IF NOT EXISTS (SELECT * FROM Users WHERE Username = 'admin1')
    INSERT INTO Users (Username, Password, Role, Department)
    VALUES ('admin1', 'admin123', 'Admin', 'Administration');

-- HOD Users
IF NOT EXISTS (SELECT * FROM Users WHERE Username = 'hod1')
    INSERT INTO Users (Username, Password, Role, Department)
    VALUES ('hod1', 'hod123', 'HOD', 'Academics');

-- Student Users
IF NOT EXISTS (SELECT * FROM Users WHERE Username = 'student1')
    INSERT INTO Users (Username, Password, Role, Department)
    VALUES ('student1', 'student123', 'Student', 'Computer Science');

IF NOT EXISTS (SELECT * FROM Users WHERE Username = 'student2')
    INSERT INTO Users (Username, Password, Role, Department)
    VALUES ('student2', 'student123', 'Student', 'Mechanical Engineering');

IF NOT EXISTS (SELECT * FROM Users WHERE Username = 'student3')
    INSERT INTO Users (Username, Password, Role, Department)
    VALUES ('student3', 'student123', 'Student', 'Electrical Engineering');

-- Volunteer User
IF NOT EXISTS (SELECT * FROM Users WHERE Username = 'volunteer1')
    INSERT INTO Users (Username, Password, Role, Department)
    VALUES ('volunteer1', 'vol123', 'Volunteer', 'Volunteer');

PRINT 'Sample users inserted';

-- =====================================================
-- 2. INSERT SAMPLE TRAVELS
-- =====================================================

DECLARE @FutureDate DATETIME = DATEADD(DAY, 1, CAST(GETDATE() AS DATE));
DECLARE @TravelID INT;

IF NOT EXISTS (SELECT * FROM TravelDetails WHERE BusNumber = 'BUS-001')
BEGIN
    INSERT INTO TravelDetails (TravelDate, BusNumber, Route, SeatCapacity, SeatsAvailable, TravelType)
    VALUES (@FutureDate, 'BUS-001', 'City Center to Campus', 50, 50, 'TwoWay');
    SET @TravelID = SCOPE_IDENTITY();
END

IF NOT EXISTS (SELECT * FROM TravelDetails WHERE BusNumber = 'BUS-002')
BEGIN
    INSERT INTO TravelDetails (TravelDate, BusNumber, Route, SeatCapacity, SeatsAvailable, TravelType)
    VALUES (@FutureDate, 'BUS-002', 'Station to Campus', 45, 45, 'TwoWay');
END

IF NOT EXISTS (SELECT * FROM TravelDetails WHERE BusNumber = 'BUS-003')
BEGIN
    INSERT INTO TravelDetails (TravelDate, BusNumber, Route, SeatCapacity, SeatsAvailable, TravelType)
    VALUES (DATEADD(DAY, 2, @FutureDate), 'BUS-003', 'Main Gate to Campus', 60, 60, 'TwoWay');
END

PRINT 'Sample travels inserted';

-- =====================================================
-- 3. INSERT SAMPLE BUS SCHEDULES
-- =====================================================

IF NOT EXISTS (SELECT * FROM BusSchedule WHERE BusNumber = 'BUS-001')
BEGIN
    INSERT INTO BusSchedule (BusNumber, Route, DayOfWeek, DepartureTime, ArrivalTime, Capacity)
    VALUES 
    ('BUS-001', 'City Center to Campus', 'Monday', '06:00:00', '07:00:00', 50),
    ('BUS-001', 'City Center to Campus', 'Tuesday', '06:00:00', '07:00:00', 50),
    ('BUS-001', 'City Center to Campus', 'Wednesday', '06:00:00', '07:00:00', 50),
    ('BUS-001', 'City Center to Campus', 'Thursday', '06:00:00', '07:00:00', 50),
    ('BUS-001', 'City Center to Campus', 'Friday', '06:00:00', '07:00:00', 50);
END

PRINT 'Sample schedules inserted';

-- =====================================================
-- 4. INSERT SAMPLE VOLUNTEERS
-- =====================================================

IF NOT EXISTS (SELECT * FROM AllowedVolunteers WHERE RegNo = 'VOL-001')
BEGIN
    INSERT INTO AllowedVolunteers (RegNo, Name, Department, IsActive)
    VALUES 
    ('VOL-001', 'volunteer1', 'Volunteer', 1),
    ('VOL-002', 'John Volunteer', 'Volunteer', 1);
END

PRINT 'Sample volunteers inserted';

-- =====================================================
-- VERIFICATION
-- =====================================================
PRINT '================================================';
PRINT 'Sample data setup completed';
PRINT '================================================';
PRINT 'Users Count: ' + CAST((SELECT COUNT(*) FROM Users) AS NVARCHAR(10));
PRINT 'Travels Count: ' + CAST((SELECT COUNT(*) FROM TravelDetails) AS NVARCHAR(10));
PRINT '================================================';
