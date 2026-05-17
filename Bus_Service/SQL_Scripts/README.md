============================================================
DATABASE SETUP - STEP BY STEP INSTRUCTIONS
============================================================

## IMPORTANT: Choose ONE of the three methods below

============================================================
METHOD 1: VISUAL STUDIO SERVER EXPLORER (EASIEST)
============================================================

STEP 1: Open Visual Studio Server Explorer
   - Go to Menu: View > Server Explorer
   - Or press: Ctrl + Alt + S

STEP 2: Connect to LocalDB
   - In Server Explorer, you should see "Data Connections"
   - Look for Database1 connection
   - If not visible, right-click Data Connections > Add Connection
   - Server Name: (LocalDB)\MSSQLLocalDB
   - Select: Bus_Service Database1

STEP 3: Open New Query
   - Right-click on Database1
   - Select: New Query

STEP 4: Create Tables
   - Open file: Bus_Service\SQL_Scripts\001_CreateTables.sql
   - Copy all content
   - Paste into Query window
   - Click Execute (or Ctrl+Shift+E)
   - Wait for completion message

STEP 5: Insert Sample Data
   - Open file: Bus_Service\SQL_Scripts\002_SampleData.sql
   - Copy all content
   - Paste into NEW Query window
   - Click Execute
   - Wait for completion message

STEP 6: Verify
   - In Server Explorer, expand Database1 > Tables
   - You should see all 9 tables created:
     ✓ Users
     ✓ TravelDetails
     ✓ StudentBooking
     ✓ Attendance
     ✓ OneWayRequests
     ✓ BusSchedule
     ✓ Cancellations
     ✓ AllowedVolunteers
     ✓ Notifications

============================================================
METHOD 2: SQL SERVER MANAGEMENT STUDIO
============================================================

STEP 1: Launch SQL Server Management Studio
   - Search for "SQL Server Management Studio" in Windows Start
   - Open the application

STEP 2: Connect to LocalDB
   - Server name: (LocalDB)\MSSQLLocalDB
   - Authentication: Windows Authentication
   - Click Connect

STEP 3: Open Database1
   - In Object Explorer (left panel)
   - Expand Databases
   - Find or expand Database1

STEP 4: Create Tables
   - Right-click on Database1
   - Select: New Query
   - Copy entire content from: Bus_Service\SQL_Scripts\001_CreateTables.sql
   - Paste into query editor
   - Click Execute (or F5)
   - Check Results tab for success message

STEP 5: Insert Sample Data
   - In the same query window, clear previous query
   - Copy entire content from: Bus_Service\SQL_Scripts\002_SampleData.sql
   - Paste into query editor
   - Click Execute (or F5)
   - Check Results tab for success message

STEP 6: Verify Tables
   - In Object Explorer, right-click Database1
   - Select: Refresh
   - Expand Tables folder
   - Confirm all 9 tables are present

============================================================
METHOD 3: COMMAND LINE (SQLCMD)
============================================================

STEP 1: Open Command Prompt or PowerShell
   - Press Windows+R
   - Type: cmd
   - Press Enter
   OR
   - Type: powershell
   - Press Enter

STEP 2: Navigate to SQL Scripts folder
   PowerShell:
   - cd "C:\Users\Mana\source\repos\Bus_Service\Bus_Service\SQL_Scripts"

STEP 3: Run Create Tables Script
   - sqlcmd -S "(LocalDB)\MSSQLLocalDB" -d Database1 -i 001_CreateTables.sql
   - Wait for success message

STEP 4: Run Sample Data Script
   - sqlcmd -S "(LocalDB)\MSSQLLocalDB" -d Database1 -i 002_SampleData.sql
   - Wait for success message

STEP 5: Verify (Using Server Explorer or SSMS)
   - Use Visual Studio Server Explorer or SSMS
   - Expand Database1 > Tables
   - Confirm all 9 tables exist

============================================================
METHOD 4: AUTOMATIC ON APPLICATION FIRST RUN
============================================================

NOTE: The application has DatabaseInitializer class that
      automatically creates tables on first run if they don't exist.

STEP 1: Build the project
   - Open solution in Visual Studio
   - Build > Build Solution
   - Or press Ctrl+Shift+B

STEP 2: Run the application
   - Press F5 or click Start Debugging
   - Application automatically initializes database
   - May take a few seconds

STEP 3: Add Sample Data Manually
   - Login with placeholder credentials
   - Use application UI to add test data
   OR
   - Still run 002_SampleData.sql using one of methods above

============================================================
TROUBLESHOOTING
============================================================

ISSUE 1: "Cannot connect to (LocalDB)\MSSQLLocalDB"
SOLUTION:
   - Open Command Prompt as Administrator
   - Run: sqllocaldb start MSSQLLocalDB
   - If not found, install SQL Server LocalDB from Windows Features

ISSUE 2: "Database file 'Database1.mdf' cannot be attached"
SOLUTION:
   - Verify Database1.mdf exists in project folder
   - Right-click Database1.mdf > Properties > check file permissions
   - Ensure current user has read/write permissions

ISSUE 3: "Login failed for user 'DOMAIN\USER'"
SOLUTION:
   - Application uses Windows Authentication (Integrated Security)
   - No username/password needed
   - Ensure running as current Windows user

ISSUE 4: "Tables already exist" or duplicate key error
SOLUTION:
   - SQL Scripts check if tables exist before creating
   - Safe to run multiple times
   - If issues persist, drop tables and rerun:
     DROP TABLE [Notifications];
     DROP TABLE [OneWayRequests];
     DROP TABLE [Cancellations];
     DROP TABLE [AllowedVolunteers];
     DROP TABLE [StudentBooking];
     DROP TABLE [Attendance];
     DROP TABLE [BusSchedule];
     DROP TABLE [TravelDetails];
     DROP TABLE [Users];
   - Then run 001_CreateTables.sql again

ISSUE 5: "Query execution timeout"
SOLUTION:
   - In SQL Server Management Studio:
     - Tools > Options > Query Execution > Execution Time-out
     - Set to 300 seconds (default)
   - Try executing each table creation separately

============================================================
SAMPLE DATA DETAILS
============================================================

After running 002_SampleData.sql, you'll have:

USERS:
  - admin1 (password: admin123) - Admin role
  - hod1 (password: hod123) - HOD role
  - student1 (password: student123) - Student, CS dept
  - student2 (password: student123) - Student, ME dept
  - student3 (password: student123) - Student, EE dept
  - volunteer1 (password: vol123) - Volunteer

TRAVELS:
  - BUS-001: City Center to Campus
  - BUS-002: Station to Campus
  - BUS-003: Main Gate to Campus

SCHEDULES:
  - Daily schedules for BUS-001 (Mon-Fri)

VOLUNTEERS:
  - VOL-001: volunteer1
  - VOL-002: John Volunteer

============================================================
VERIFICATION CHECKLIST
============================================================

After setup, verify:

[ ] Database1.mdf exists in project directory
[ ] All 9 tables created in Database1
[ ] Users table contains at least 1 user
[ ] TravelDetails table contains at least 1 travel
[ ] Foreign key relationships exist
[ ] Indexes created for performance
[ ] Application starts without DB errors
[ ] Login works with admin1/admin123
[ ] Can navigate to Admin Dashboard
[ ] Can view travel details
[ ] DataGridViews display data correctly

============================================================
NEXT STEPS
============================================================

1. Run application (F5 in Visual Studio)
2. Login with admin1 / admin123
3. Test all features:
   - Add a travel
   - Update travel details
   - Delete a travel
4. Login as student1 / student123
5. Book a travel
6. Test other features
7. Report any issues

============================================================
For detailed information, see SETUP_GUIDE.md
============================================================
