============================================================
QUICK START GUIDE - BUS SERVICE MANAGEMENT SYSTEM
============================================================

## 🚀 FASTEST WAY TO GET STARTED (2 MINUTES)

### Step 1: Build the Project
- Open Bus_Service.sln in Visual Studio
- Press Ctrl+Shift+B (Build Solution)
- Wait for "Build successful" message ✓

### Step 2: Run the Application
- Press F5 (Start Debug)
- Application window opens
- Database initializes automatically
- You see Login form ✓

### Step 3: Login & Test
- Username: admin1
- Password: admin123
- Click Login ✓
- See AdminDashboard ✓

### Step 4: Test Features
- Click "Manage Travels"
- Try Add Travel, Update, Delete
- Go Back to Dashboard
- Click Logout
- Return to Login ✓

DONE! System is working.

============================================================
SETUP WITH SAMPLE DATA (OPTIONAL - 5 MINUTES)
============================================================

If you want pre-populated data with many records:

### Option A: Visual Studio Server Explorer
1. View > Server Explorer (Ctrl+Alt+S)
2. Right-click Data Connections > Add Connection
3. Server: (LocalDB)\MSSQLLocalDB
4. Database: Bus_Service (or select Database1)
5. Right-click Database1 > New Query
6. Copy-paste from: Bus_Service\SQL_Scripts\002_SampleData.sql
7. Execute (Ctrl+Shift+E)

### Option B: SQL Server Management Studio
1. Open SQL Server Management Studio
2. Connect to: (LocalDB)\MSSQLLocalDB
3. Right-click Database1 > New Query
4. Copy-paste from: Bus_Service\SQL_Scripts\002_SampleData.sql
5. Execute (F5)

After this, you'll have:
- 6 sample users (Admin, HOD, 3 Students, 1 Volunteer)
- 3 sample travels
- 2 sample volunteers
- Ready for immediate testing

============================================================
TEST SCENARIOS (5-10 MINUTES)
============================================================

### Scenario 1: Admin Workflow
1. Login: admin1 / admin123
2. Click "Manage Travels" or similar button
3. Try these:
   - [ ] Add new travel (future date, any bus number, route)
   - [ ] Select a travel in grid
   - [ ] Update its details
   - [ ] Delete it
   - [ ] Confirm it's gone
4. Click "Back" to return to dashboard
5. Click "Logout" or close window
6. Confirm dialog appears
7. Click "Yes" to logout
8. Return to Login form ✓

### Scenario 2: Student Workflow
1. Login: student1 / student123
2. See StudentForm or StudentDashboard
3. Try these:
   - [ ] Click "Book Seat" or similar button
   - [ ] See available travels
   - [ ] Select one and book
   - [ ] Confirm booking success
   - [ ] See booking in "My Bookings"
   - [ ] Cancel the booking
   - [ ] Confirm cancellation
4. Logout and return to Login ✓

### Scenario 3: Multi-User
1. Login as admin1
2. Open travel management
3. Add a travel
4. Logout
5. Login as student1
6. Book the travel you just added
7. Logout
8. Login as admin1
9. See the booking exists
10. Confirm data is shared ✓

============================================================
TROUBLESHOOTING
============================================================

### Problem: Build Failed
Solution:
- Close any running instances of Bus_Service.exe
- Try: dotnet clean
- Then: dotnet build
- Check for errors in Output window

### Problem: "Can't connect to LocalDB"
Solution:
- Open Command Prompt as Administrator
- Run: sqllocaldb start MSSQLLocalDB
- Try running application again

### Problem: Login doesn't work
Solution:
- Verify you're using exactly: admin1 / admin123
- No spaces before/after
- Check that Database1.mdf exists in project folder
- Try running 002_SampleData.sql to add users

### Problem: No travels shown
Solution:
- Run 002_SampleData.sql to populate sample data
- Or add a travel manually as admin
- Future dates only (travels in past don't show)

### Problem: DataGridView is empty
Solution:
- Try clicking "Refresh" button if available
- Close and reopen the form
- Verify data exists in database
- Check for SQL errors in Application Output

### Problem: Form freezes or hangs
Solution:
- Press Ctrl+Alt+Delete > Task Manager
- Kill Bus_Service.exe process
- Try again
- If persists, verify database connection:
  - Open Server Explorer
  - Right-click Database1
  - Check for connection errors

============================================================
DATABASE VERIFICATION
============================================================

To verify database is set up correctly:

### Using Visual Studio Server Explorer:
1. View > Server Explorer (Ctrl+Alt+S)
2. Expand Data Connections
3. Expand Database1 (or attach if not visible)
4. Expand Tables folder
5. You should see 9 tables:
   - Attendance
   - AllowedVolunteers
   - BusSchedule
   - Cancellations
   - Notifications
   - OneWayRequests
   - StudentBooking
   - TravelDetails
   - Users

If any tables are missing:
- Run 001_CreateTables.sql from SQL_Scripts folder
- Use option from SETUP_GUIDE.md

============================================================
QUICK REFERENCE: LOGIN CREDENTIALS
============================================================

Admin:
- Username: admin1
- Password: admin123
- Can: Manage travels, approve requests

HOD:
- Username: hod1
- Password: hod123
- Can: Approve one-way requests

Student:
- Username: student1 (or student2, student3)
- Password: student123
- Can: Book travels, submit requests

Volunteer:
- Username: volunteer1
- Password: vol123
- Can: Mark attendance

============================================================
QUICK REFERENCE: DATABASE LOCATION
============================================================

Database File: Database1.mdf
Location: Bus_Service\Database1.mdf
Size: ~8 MB
Type: SQL Server LocalDB
Instance: (LocalDB)\MSSQLLocalDB

Connection String:
Data Source=(LocalDB)\MSSQLLocalDB;
AttachDbFilename=[AppDirectory]\Database1.mdf;
Integrated Security=True;

Note: Uses Windows Authentication (no password needed)

============================================================
FEATURES YOU CAN TEST
============================================================

✓ User Authentication (Login/Logout)
✓ Role-Based Access (Admin/Student/HOD/Volunteer)
✓ Travel Management (Add/Update/Delete)
✓ Seat Booking (Reserve seats, cancel)
✓ Attendance Marking (Volunteers)
✓ One-Way Requests (Student requests, HOD/Admin approves)
✓ Data Persistence (Data survives logout/login)
✓ Error Handling (User-friendly error messages)
✓ Form Navigation (Smooth transitions)

============================================================
COMMON QUESTIONS
============================================================

Q: Do I need to run SQL scripts?
A: No! DatabaseInitializer automatically creates tables.
   But you can manually run 002_SampleData.sql for more data.

Q: Can I run multiple instances?
A: Yes! Open two VS windows and run both.
   Login as different users to test multi-user.

Q: Where are passwords stored?
A: In Database1.mdf Users table (plain text, development only).
   For production, implement password hashing.

Q: Can I change database name?
A: The system looks for Database1.mdf by default.
   To change, modify AppSettings.cs connection string.

Q: How do I backup data?
A: Backup Database1.mdf file regularly.
   Also recommended: Use SQL Server backup utilities.

Q: Can I run without SQL Server installed?
A: SQL Server LocalDB must be installed (lightweight version).
   It's included with Visual Studio.

Q: What if I delete Database1.mdf?
A: Run application, it will recreate schema automatically.
   Sample data will be lost (run 002_SampleData.sql again).

============================================================
NEXT STEPS
============================================================

After confirming everything works:

1. Read: PROJECT_COMPLETION_REPORT.md
2. Read: TEST_PLAN.md (for comprehensive testing)
3. Read: SETUP_GUIDE.md (for detailed setup)
4. Run: TEST_PLAN.md test cases systematically
5. Verify: All features work as expected
6. Deploy: Share with team/users

============================================================
GETTING HELP
============================================================

If something doesn't work:

1. Check Error Message
   - Read what it says carefully
   - Search for exact error text

2. Check Database
   - Is Database1.mdf in project folder?
   - Is SQL Server LocalDB running?
   - Do all tables exist?

3. Check Code
   - Are you using correct login credentials?
   - Any typos in username/password?
   - Is date in the future for travels?

4. Check Documentation
   - SETUP_GUIDE.md - Detailed setup
   - TEST_PLAN.md - How to test everything
   - PROJECT_COMPLETION_REPORT.md - What was fixed
   - SQL_Scripts/README.md - SQL setup options

5. Restart Everything
   - Close application
   - Close Visual Studio
   - Restart computer
   - Try again

============================================================
SUCCESS INDICATORS
============================================================

You'll know it's working when:

✓ Application starts without errors
✓ Login form appears
✓ Login with admin1/admin123 works
✓ AdminDashboard shows
✓ DataGridView displays travels
✓ Can add/update/delete travels
✓ Logout returns to Login form
✓ No application crashes
✓ Forms respond to button clicks
✓ Messages display for all operations

============================================================

🎉 CONGRATULATIONS!

If you see all success indicators above, the system is ready.

Start with admin1/admin123 and explore!

============================================================
