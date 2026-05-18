-- Insert Sample Users into Users Table
-- Run this script in SQL Server Management Studio

-- Insert Admin User
INSERT INTO Users (Username, Password, Role, Department, IsActive) 
VALUES ('admin', 'admin123', 'Admin', 'Administration', 1);

-- Insert HOD User
INSERT INTO Users (Username, Password, Role, Department, IsActive) 
VALUES ('hod1', 'hod123', 'HOD', 'Computer Science', 1);

-- Insert Student User
INSERT INTO Users (Username, Password, Role, Department, IsActive) 
VALUES ('student1', 'student123', 'Student', 'Computer Science', 1);

-- Insert Volunteer User
INSERT INTO Users (Username, Password, Role, Department, IsActive) 
VALUES ('volunteer1', 'vol123', 'Volunteer', 'Volunteer Team', 1);

-- Insert Sample Travels
INSERT INTO TravelDetails (TravelDate, BusNumber, Route, SeatCapacity, SeatsAvailable, TravelType) 
VALUES 
(DATEADD(day, 1, GETDATE()), 'BUS001', 'Route A - City Center', 50, 50, 'TwoWay'),
(DATEADD(day, 1, GETDATE()), 'BUS002', 'Route B - Downtown', 45, 45, 'TwoWay'),
(DATEADD(day, 2, GETDATE()), 'BUS003', 'Route C - Campus', 40, 40, 'OneWay');

-- Verify Data Was Inserted
SELECT 'Users Table:' as TableName;
SELECT UserID, Username, Role, Department FROM Users;

SELECT 'TravelDetails Table:' as TableName;
SELECT TravelID, TravelDate, Route, SeatCapacity FROM TravelDetails;
