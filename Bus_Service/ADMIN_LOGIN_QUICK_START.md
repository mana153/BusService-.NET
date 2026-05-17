# 🎯 QUICK ADMIN LOGIN & SIGNUP GUIDE

## 🔴 **IMMEDIATE ACTION REQUIRED**

### Step 1: Run the Application
Start the Bus Service application by pressing F5 or clicking Run in Visual Studio.

### Step 2: Login Screen
You'll see the Login form with two buttons:
- **"Login"** button (left)
- **"Sign Up"** button (right)

---

## ✅ EASIEST METHOD: LOGIN WITH TEST ADMIN

### Login Credentials:
```
Username: admin1
Password: admin123
```

### Login Steps:
1. In the Login form, enter:
   - **Username field:** `admin1`
   - **Password field:** `admin123`
2. Click **"Login"** button
3. ✅ You'll be taken to **AdminDashboard**

---

## 📝 ALTERNATIVE METHOD: SIGNUP AS NEW ADMIN

### If You Want to Create a New Admin Account:

**Step 1: Open Sign Up Form**
- Click **"Sign Up"** button from Login screen

**Step 2: Fill Registration Form**
```
Role:       Select "Admin" from dropdown
Username:   (Enter any username, e.g., "myadmin")
Password:   (Enter a password)
Department: Select "Administration" (or leave blank)
```

**Step 3: Register**
- Click **"Register"** button
- See success message: "Registration Successful!"

**Step 4: Login**
- You'll return to Login screen
- Enter your new admin credentials
- Click **"Login"**
- ✅ Access AdminDashboard

---

## 🎛️ WHAT YOU CAN DO AS ADMIN

Once logged in to AdminDashboard:

| Feature | Action |
|---------|--------|
| 👥 **Users** | View/Manage all users (Students, HOD, Volunteers) |
| 🚌 **Travels** | Add/Edit/Delete bus travels |
| 📋 **Requests** | Approve/Reject one-way requests from students |
| 📊 **Reports** | View attendance and system statistics |
| ⚙️ **Settings** | Configure system parameters |

---

## ⚠️ IF SOMETHING GOES WRONG

### Error: "Invalid username or password"
```
Solution:
1. Make sure database file exists (Database1.mdf)
2. Check spelling of username/password
3. Run SQL_Scripts\002_SampleData.sql to add admin1 user
```

### Error: Database Connection Error
```
Solution:
1. Go to AppSettings.cs
2. Check SqlConnectionString is correct
3. Default: Data Source=.\\SQLEXPRESS;Initial Catalog=Database1;Integrated Security=true;
```

### Error: Can't see Admin in dropdown
```
Solution:
1. Look for "Admin" option in Role dropdown
2. It's between "Student" and "Volunteer"
3. If not visible, restart application
```

---

## 📊 TEST ACCOUNTS AVAILABLE

| Account | Username | Password | Steps |
|---------|----------|----------|-------|
| **Admin** | `admin1` | `admin123` | Click Login → Enter credentials → Click Login ✅ |
| **Student** | `student1` | `student123` | Click Login → Enter credentials → Click Login ✅ |
| **HOD** | `hod1` | `hod123` | Click Login → Enter credentials → Click Login ✅ |
| **Volunteer** | `volunteer1` | `vol123` | Click Login → Enter credentials → Click Login ✅ |

---

## 🔒 SECURITY REMINDER

⚠️ These are test credentials for development/testing only.
- For production: Use strong passwords
- Enable password hashing
- Implement encryption
- Add two-factor authentication

---

## ✨ YOU'RE ALL SET!

**Ready to login?** 
→ Use `admin1` / `admin123` 
→ Click Login 
→ Manage your bus service system! 🚌

