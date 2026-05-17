// ==========================================
// QUICK START GUIDE - ONE-WAY REQUEST SYSTEM
// ==========================================

/* 

🚀 QUICK SETUP (5 MINUTES)

1. DATABASE SETUP
   ================

   Step 1: Open SQL Server Management Studio
   Step 2: Connect to: (LocalDB)\MSSQLLocalDB
   Step 3: Open file: SQL_Scripts/CreateOneWayRequestsAndNotifications.sql
   Step 4: Execute the script (Ctrl+E or F5)

   ✅ Tables created:
      - OneWayRequests
      - Notifications

   Step 5: Add HOD user:

   INSERT INTO Users (Username, Password, Role, Name, Department)
   VALUES ('hod1', 'password', 'HOD', 'Dr. Smith', 'Science');

   INSERT INTO Users (Username, Password, Role, Name, Department)
   VALUES ('hod2', 'password', 'HOD', 'Dr. Johnson', 'Commerce');

2. BUILD & TEST
   =============

   Step 1: Open Bus_Service.sln in Visual Studio
   Step 2: Rebuild Solution (Ctrl+Alt+B)
   Step 3: Run project (F5)

3. TEST WORKFLOW
   ==============

   TEST CASE 1: Student Submits Request
   ✓ Login as Student (userid=1)
   ✓ Click "One-Way Request" button
   ✓ Fill form:
     - Reason: "Need to visit home"
     - Route: Select from dropdown
     - Date: Tomorrow
   ✓ Click "Submit"
   ✓ Message: "One-Way Request submitted successfully!"

   TEST CASE 2: HOD Reviews Request
   ✓ Login as HOD (hod1)
   ✓ HOD Dashboard opens automatically
   ✓ See "Pending Requests: 1"
   ✓ Click on request in DataGridView
   ✓ See request details
   ✓ Click "Approve"
   ✓ Message: "Request approved successfully!"

   TEST CASE 3: Admin Final Review
   ✓ Login as Admin
   ✓ Click "One-Way Requests" button
   ✓ See HOD-approved requests
   ✓ Click on request
   ✓ Click "Final Approve"
   ✓ Message: "Request APPROVED successfully!"

   TEST CASE 4: Student Gets Notification
   ✓ Login as Student
   ✓ See notification about approval

   TEST CASE 5: Check Notifications
   ✓ Click "Notifications" button
   ✓ See all notifications
   ✓ Mark as read

4. FILES TO REVIEW
   ================

   Core Files:
   - OneWayRequestHelper.cs (Main business logic)
   - OneWayRequestForm.cs (Student form)
   - HODDashboardForm.cs (HOD approvals)
   - AdminOneWayRequestForm.cs (Admin approvals)
   - NotificationForm.cs (Notifications)

   Modified Files:
   - StudentForm.cs (Added One-Way Request button)
   - AdminDashboard.cs (Added One-Way Request & Notification buttons)
   - Login.cs (Added HOD role support)

   SQL:
   - SQL_Scripts/CreateOneWayRequestsAndNotifications.sql

5. STATUS INDICATORS
   =================

   OneWayRequests Table:
   - RequestId: Unique request identifier
   - StudentId: Who submitted
   - HODStatus: Pending/Approved/Rejected
   - AdminStatus: Pending/Approved/Rejected
   - FinalStatus: Pending/Approved/Rejected (Final decision)

   Notifications Table:
   - UserId: Who receives notification
   - UserType: Admin/HOD/Student
   - IsRead: 0 (unread) or 1 (read)

6. KEY FEATURES
   =============

   ✅ Multi-Level Approval (HOD → Admin)
   ✅ Automatic Notifications
   ✅ Real-time Status Updates
   ✅ Request History Tracking
   ✅ Role-Based Access Control
   ✅ Data Validation

7. TROUBLESHOOTING
   ================

   Q: HOD Dashboard not appearing?
   A: Make sure you created a user with Role='HOD'
      Login with that user

   Q: No notifications appearing?
   A: Check:
      - Notifications table exists
      - Users have correct Role
      - Database connection string is correct

   Q: "One-Way Request" button not visible?
   A: Rebuild project (Ctrl+Alt+B)
      Verify StudentForm.Designer.cs has buttonOneWayRequest

   Q: Can't submit request as student?
   A: Check:
      - OneWayRequests table exists
      - BusSchedule table has routes
      - Connection string matches your DB path

8. DATABASE QUERIES FOR VERIFICATION
   ===================================

   Check OneWayRequests:
   SELECT * FROM OneWayRequests;

   Check Notifications:
   SELECT * FROM Notifications;

   Check pending HOD requests:
   SELECT * FROM OneWayRequests WHERE HODStatus = 'Pending';

   Check unread notifications:
   SELECT * FROM Notifications WHERE IsRead = 0;

9. WHAT HAPPENS NEXT
   ===================

   Student Submit Request (OneWayRequestForm)
   ↓
   → Request saved with HODStatus = 'Pending'
   → HODs notified via Notifications table
   ↓
   HOD Approves (HODDashboardForm)
   ↓
   → HODStatus changed to 'Approved'
   → Admins notified via Notifications table
   ↓
   Admin Final Review (AdminOneWayRequestForm)
   ↓
   → AdminStatus changed to 'Approved'/'Rejected'
   → FinalStatus set accordingly
   → Student notified via Notifications table
   ↓
   Student Views Status (OneWayRequestForm)
   ↓
   → Sees final status in request list

10. TIPS & TRICKS
    ==============

    • Each role has different views (role-based access)
    • Requests are auto-removed from pending lists after approval/rejection
    • Notifications can't be deleted, only marked as read
    • Date picker prevents selecting past dates for requests
    • All timestamps are recorded for audit trail

*/

// CONNECTION STRING (Update if needed)
// Current: LocalDB with Database1.mdf file
// Future: Consider centralizing in AppSettings.cs

// ROLES & ACCESS
// Student: Submit requests, view own requests, receive notifications
// HOD: Approve/reject requests from students, receive notifications
// Admin: Final approval/rejection, receive notifications
// Volunteer: (Existing - no changes)

// DATABASE TABLES CREATED
// 1. OneWayRequests (RequestId, StudentId, Reason, Route, RequestDate, HODStatus, AdminStatus, FinalStatus, CreatedDate, UpdatedDate)
// 2. Notifications (NotificationId, UserId, UserType, Message, RelatedRequestId, IsRead, CreatedDate)

// FILES SUMMARY
// ✅ OneWayRequestForm.cs - Student one-way request submission & tracking
// ✅ OneWayRequestForm.Designer.cs - UI controls
// ✅ HODDashboardForm.cs - HOD approval interface
// ✅ HODDashboardForm.Designer.cs - UI controls
// ✅ AdminOneWayRequestForm.cs - Admin final approval interface
// ✅ AdminOneWayRequestForm.Designer.cs - UI controls
// ✅ NotificationForm.cs - Notification viewer for all roles
// ✅ NotificationForm.Designer.cs - UI controls
// ✅ OneWayRequestHelper.cs - Business logic & database operations
// ✅ StudentForm.cs - Updated with One-Way Request button
// ✅ AdminDashboard.cs - Updated with One-Way Request & Notification buttons
// ✅ Login.cs - Updated to support HOD role

// STATUS FLOW DIAGRAM
/*
                    PENDING HOD APPROVAL
                    (Initial Status)
                            ↓
            ┌───────────────┴───────────────┐
            ↓                               ↓
      [HOD APPROVES]                 [HOD REJECTS]
            ↓                               ↓
     APPROVED BY HOD                  REJECTED
            ↓
   PENDING ADMIN APPROVAL
            ↓
      ┌─────┴─────┐
      ↓           ↓
[ADMIN APPROVES] [ADMIN REJECTS]
      ↓           ↓
   APPROVED    REJECTED
    (FINAL)     (FINAL)
*/

// NEXT STEPS AFTER IMPLEMENTATION
// 1. ✅ Execute SQL script
// 2. ✅ Add HOD users to database
// 3. ✅ Rebuild project
// 4. ✅ Test complete workflow
// 5. ✅ Verify notifications work
// 6. ✅ Check database data
// 7. ✅ Deploy to production

// VERSION: 1.0
// STATUS: READY FOR USE
// LAST UPDATED: [Current Session]
