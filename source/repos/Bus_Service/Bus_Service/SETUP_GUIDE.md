============================================================
BUS SERVICE MANAGEMENT SYSTEM - COMPLETE SETUP GUIDE
============================================================

## PROJECT OVERVIEW
This is a comprehensive Bus Service Management System built in C# WinForms
with SQL Server LocalDB. The system manages bus routes, student bookings,
attendance, and one-way travel requests.

## TECHNOLOGY STACK
- Language: C# (.NET 10)
- UI Framework: Windows Forms (WinForms)
- Database: SQL Server LocalDB (service-based Database1.mdf)
- Connection: Microsoft.Data.SqlClient

## DATABASE SETUP

### Method 1: Manual Setup (SQL Server Management Studio)
1. Open SQL Server Management Studio
2. Connect to: (LocalDB)\MSSQLLocalDB
3. In Object Explorer, expand Databases
4. Right-click on Database1 (or create it if not exists)
5. Open New Query window
6. Run the SQL scripts in this order:
   - Bus_Service\SQL_Scripts\001_CreateTables.sql
   - Bus_Service\SQL_Scripts\002_SampleData.sql

### Method 2: Visual Studio Server Explorer
1. Open Visual Studio
2. Go to View > Server Explorer (or Ctrl+Alt+S)
3. Expand Data Connections
4. Right-click Database1.mdf > New Query
5. Copy-paste SQL scripts from the SQL_Scripts folder

### Method 3: Automatic (Application Initialization)
The application is configured to automatically create tables on first run
if they don't exist. Connection string uses AttachDbFilename to auto-attach.

## DATABASE SCHEMA

### Users Table
- UserID (PK)
- Username (UNIQUE)
- Password
- Role (Admin, Student, HOD, Volunteer)
- Department
- CreatedDate, UpdatedDate

### TravelDetails Table
- TravelID (PK)
- TravelDate
- BusNumber
- Route
- SeatCapacity
- SeatsAvailable
- TravelType (TwoWay, OneWay)
- CreatedDate, UpdatedDate

### StudentBooking Table
- BookingID (PK)
- StudentID (FK)
- TravelID (FK)
- BookingType (TwoWay, OneWay)
- BookingStatus (Booked, Cancelled)
- BookingDate
- CreatedDate, UpdatedDate

### Attendance Table
- AttendanceID (PK)
- StudentID (FK)
- TravelDate
- Status (Present, Absent)
- CreatedDate, UpdatedDate

### OneWayRequests Table
- RequestId (PK)
- StudentId (FK)
- Reason
- Route
- RequestDate
- HODStatus (Pending, Approved, Rejected)
- AdminStatus (Pending, Approved, Rejected)
- FinalStatus (Pending, Approved, Rejected)
- CreatedDate, UpdatedDate

### BusSchedule Table
- ScheduleID (PK)
- BusNumber
- Route
- DayOfWeek
- DepartureTime
- ArrivalTime
- Capacity
- CreatedDate, UpdatedDate

### AllowedVolunteers Table
- VolunteerID (PK)
- RegNo (UNIQUE)
- Name
- Department
- IsActive
- CreatedDate, UpdatedDate

### Notifications Table
- NotificationId (PK)
- UserId (FK)
- UserType
- Message
- RelatedRequestId
- IsRead
- CreatedDate

### Cancellations Table
- CancellationID (PK)
- BookingID
- StudentID (FK)
- TravelID (FK)
- Reason
- CancellationDate
- CreatedDate

## APPLICATION USAGE

### Default Login Credentials
**Admin:**
- Username: admin1
- Password: admin123

**HOD:**
- Username: hod1
- Password: hod123

**Student:**
- Username: student1
- Password: student123

**Volunteer:**
- Username: volunteer1
- Password: vol123

### Application Flow

1. **Login Screen**
   - User enters username and password
   - System validates credentials
   - Routes to appropriate dashboard based on role

2. **Admin Dashboard**
   - View upcoming travels
   - Manage travel schedules (Add/Update/Delete)
   - View one-way requests awaiting approval
   - Approve/Reject one-way requests

3. **Student Dashboard**
   - View profile information
   - View upcoming travels
   - Book seats for travels
   - View my bookings
   - Cancel bookings
   - Submit one-way requests

4. **HOD Dashboard**
   - View pending one-way requests
   - View request details
   - Approve/Reject one-way requests

5. **Volunteer Dashboard**
   - Select date
   - Mark attendance for students
   - View attendance records

## KEY FEATURES

### 1. Login & Authentication
- Role-based access control (Admin, Student, HOD, Volunteer)
- Secure username/password validation
- Session management

### 2. Travel Management
- Create, update, delete bus travels
- Track seat availability
- View travel schedules
- Two-way and one-way route support

### 3. Booking System
- Book seats for travels
- Cancel bookings
- Check seat availability
- Automatic seat count management

### 4. One-Way Requests
- Submit one-way travel requests
- Two-level approval (HOD → Admin)
- Notification system
- Request tracking

### 5. Attendance Management
- Mark student attendance
- Track attendance by date
- View attendance records

### 6. Volunteer Management
- Volunteer registration
- Attendance marking by volunteers
- Volunteer status tracking

## FILE STRUCTURE

Bus_Service/
├── Program.cs                    # Entry point
├── AppSettings.cs                # Configuration
├── DatabaseHelper.cs             # Database operations
├── OneWayRequestHelper.cs         # One-way request logic
│
├── Forms:
├── Login.cs                       # Login form
├── Sign Up.cs                     # Registration form
├── AdminDashboard.cs              # Admin main dashboard
├── AdminForm.cs                   # Admin travel management
├── AdminOneWayRequestForm.cs       # Admin request approval
├── StudentForm.cs                 # Student main form
├── StudentDashboard.cs            # Student dashboard
├── StudentBookingForm.cs           # Student booking interface
├── OneWayRequestForm.cs            # Student one-way request
├── HODDashboardForm.cs            # HOD dashboard
├── VolunteerForm.cs               # Volunteer attendance marking
├── AttendanceForm.cs              # Attendance management
├── NotificationForm.cs            # Notifications
│
├── SQL_Scripts/
├── 001_CreateTables.sql           # Database schema
└── 002_SampleData.sql             # Sample data

## CONNECTION STRING

The application uses a dynamic connection string that automatically
finds the Database1.mdf file:

Data Source=(LocalDB)\MSSQLLocalDB;
AttachDbFilename=[AppDirectory]\Database1.mdf;
Integrated Security=True;
MultipleActiveResultSets=True;

Location: AppSettings.SqlConnectionString property

## TROUBLESHOOTING

### Issue: "Invalid column name 'IsActive'"
**Solution:** Run 001_CreateTables.sql to create proper schema

### Issue: "Cannot attach database"
**Solution:** 
1. Verify Database1.mdf exists in project directory
2. Check SQL Server LocalDB is installed and running
3. Run: sqllocaldb start MSSQLLocalDB

### Issue: "Login failed"
**Solution:** 
1. Verify username/password exist in Users table
2. Run 002_SampleData.sql to populate sample users
3. Check database connection string in AppSettings

### Issue: "Forms not loading/Database connection timeout"
**Solution:**
1. Check if LocalDB instance is running
2. Verify Database1.mdf file permissions
3. Try restarting SQL Server LocalDB

## IMPORTANT NOTES

1. **Database File Location**: Keep Database1.mdf in the project directory
2. **Connection String**: Uses dynamic path, works in any location
3. **Integrated Security**: No username/password needed for DB (Windows Auth)
4. **Parameterized Queries**: All SQL queries use parameters (SQL injection safe)
5. **Foreign Keys**: Database enforces referential integrity
6. **Application Exit**: Only closes when login form is closed

## DEVELOPMENT NOTES

### Adding New Features
1. Create new table in SQL script
2. Add corresponding methods in DatabaseHelper or helper classes
3. Create UI form for feature
4. Link form to dashboard buttons
5. Test with sample data

### Security Best Practices
- All queries use parameterized statements
- No hardcoded credentials in code
- Connection string stored in centralized location
- Input validation on all forms

## DEPLOYMENT

### Build Process
1. Open solution in Visual Studio
2. Build > Build Solution (or Ctrl+Shift+B)
3. Ensure no compilation errors
4. Run tests

### Distribution
1. Publish application as single-file executable
2. Include Database1.mdf with deployment
3. Ensure SQL Server LocalDB installed on target machine
4. Run setup script on first launch

## SUPPORT & MAINTENANCE

### Regular Tasks
- Backup Database1.mdf regularly
- Monitor database growth
- Archive old travel/attendance records
- Review and optimize slow queries

### Backup Strategy
Regular backups of Database1.mdf ensure data safety:
- Daily: Database1.mdf
- Weekly: Full backup to external storage
- Monthly: Archive old records

============================================================
For questions or issues, refer to SQL_Scripts folder for
database setup instructions.
============================================================
