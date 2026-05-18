============================================================
SIGNUP GUIDE - BUS SERVICE MANAGEMENT SYSTEM
============================================================

## 📝 SIGNUP FEATURE OVERVIEW

The signup page allows new users to register for the Bus Service system. Users can register as either **Student** or **Volunteer**. 

**Important:** Admin and HOD accounts can only be created by system administrators.

============================================================
HOW TO ACCESS SIGNUP
============================================================

1. Run the application
2. Login form appears
3. Click the **"Sign Up"** button (below Login button)
4. Signup form opens

============================================================
SIGNUP FOR STUDENTS
============================================================

### Steps:
1. Enter **Username** - Unique identifier (e.g., student1, john_doe)
2. Select **Role** - Choose "Student" from dropdown
3. Enter **Password** - Your login password
4. Select **Department** - Choose from the list:
   - Computer Science
   - Mechanical Engineering
   - Electrical Engineering
   - Civil Engineering
   - Any other department
5. Click **"Register"** button

### Validation:
✓ Username must be unique (not already registered)
✓ Password is required
✓ Department must be selected for students
✓ All fields are mandatory

### After Registration:
- Success message displays
- Automatically redirected to Login form
- Use your username and password to login

### Student Capabilities After Registration:
- Book seats on available travels
- View booking history
- Submit one-way requests
- Cancel bookings
- View notifications

============================================================
SIGNUP FOR VOLUNTEERS
============================================================

### Steps:
1. Enter **Register Number** - Your unique identification number (e.g., VOL-001)
2. Select **Role** - Choose "Volunteer" from dropdown
3. Enter **Password** - Your login password
4. Click **"Generate OTP"** button
5. A dialog shows a random 4-digit OTP (e.g., "Your OTP is: 5682")
6. Enter the OTP in the **"OTP"** field
7. Click **"Register"** button

### Validation:
✓ Register Number must be unique
✓ Password is required
✓ OTP must be generated first (button click required)
✓ OTP must match exactly what was generated
✓ All fields are mandatory for volunteers

### After Registration:
- Success message displays
- Volunteer entry created in AllowedVolunteers table
- Automatically redirected to Login form
- Use your register number and password to login

### Volunteer Capabilities After Registration:
- Mark attendance for travels
- View travel reports
- Manage volunteer assignments

============================================================
BACK TO LOGIN
============================================================

If you want to return to the login form without registering:
- Click **"Back to Login"** button on signup form
- You'll be returned to the Login form

============================================================
TROUBLESHOOTING
============================================================

### Problem: "User already exists"
**Solution:**
- The username you entered is already taken
- Try a different username
- Or use login if you already have an account

### Problem: "Please fill all required fields"
**Solution:**
- Make sure all fields are filled:
  - Username (required)
  - Password (required)
  - Role (required)
  - Department (required for students)
  - OTP (required for volunteers)

### Problem: "Department is required for students"
**Solution:**
- Select "Student" as role
- Then select a department from the dropdown
- Department field only enables for Student role

### Problem: "Please generate OTP first"
**Solution:**
- You selected "Volunteer" role
- Click the **"Generate OTP"** button first
- Button only appears for volunteers

### Problem: "Invalid OTP"
**Solution:**
- Make sure you entered the exact OTP shown in the dialog
- OTPs are case-sensitive and must match exactly
- If you forgot it, click "Generate OTP" again for a new one

### Problem: "Error: [database error message]"
**Solution:**
- Check database connection
- Verify Database1 exists in LocalDB
- Make sure MSSQLLocalDB instance is running
- Try again or contact administrator

### Problem: Registration form won't open from login
**Solution:**
- Make sure you clicked "Sign Up" button (not "Login")
- If form doesn't appear, check:
  - Application error log
  - Database connection
  - Try restarting the application

============================================================
SUCCESSFUL REGISTRATION INDICATORS
============================================================

✓ Username accepted (no "already exists" message)
✓ All validations passed (no error messages)
✓ "Registration Successful!" message appears
✓ Automatically redirected to Login form
✓ Can login with new username and password

============================================================
QUICK REFERENCE: REGISTRATION CRITERIA
============================================================

**Student Registration:**
- Username: Any unique name
- Password: Any password
- Role: Must select "Student"
- Department: Must select from dropdown

**Volunteer Registration:**
- Register Number: Unique ID (for volunteers)
- Password: Any password
- Role: Must select "Volunteer"
- OTP: Generate first, then enter exactly as shown

============================================================
NEXT STEPS AFTER SIGNUP
============================================================

1. Click "Sign Up" from login
2. Fill in your details
3. Click "Register"
4. See success message
5. Login with your new credentials
6. Start using the system!

============================================================
