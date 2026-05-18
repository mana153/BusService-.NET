============================================================
SIGNUP SYSTEM - VISUAL DIAGRAMS & FLOWCHARTS
============================================================

## APPLICATION FLOW

```
┌─────────────────────┐
│   Run Application   │
│    (Press F5)       │
└──────────┬──────────┘
           │
           ▼
    ┌──────────────┐
    │  Login Form  │
    └──────┬───────┘
           │
      ┌────┴────┐
      │          │
      ▼          ▼
  [Login]  [Sign Up] ← NEW BUTTON
      │          │
      │          └──────┐
      │                 │
      │                 ▼
      │         ┌──────────────────┐
      │         │ Registration Form│
      │         └─────┬────────────┘
      │               │
      │          ┌────┴────┐
      │          │          │
      │    [Student]  [Volunteer]
      │          │          │
      │          ▼          ▼
      │    (Normal)    (OTP Check)
      │          │          │
      │          └────┬─────┘
      │               │
      │               ▼
      │        [Register Button]
      │               │
      │               ▼
      │        Success Message
      │               │
      │     Redirect to Login
      │
      └──────────┬────────────┘
                 │
                 ▼
        ┌─────────────────┐
        │ User Dashboard  │
        │  (role-based)   │
        └─────────────────┘
```

## SIGNUP FORM LAYOUT

```
╔════════════════════════════════════════════════════════╗
║            USER REGISTRATION FORM                      ║
╠════════════════════════════════════════════════════════╣
║                                                        ║
║  Role:        [  Student ▼  ]  ← Select one           ║
║                                                        ║
║  Username:    [  john_doe  ]                           ║
║                                                        ║
║  Password:    [  ••••••••••  ]                         ║
║                                                        ║
║  Department:  [  SCIENCE ▼  ]  ← For Student only     ║
║                                                        ║
║  OTP:         [  5682  ]      ← For Volunteer only     ║
║  [Generate OTP Button]        ← For Volunteer only     ║
║                                                        ║
║       [ Register ]  [ Back to Login ]                  ║
║                                                        ║
╚════════════════════════════════════════════════════════╝
```

## STUDENT SIGNUP SEQUENCE

```
START
  │
  ├─→ Open Registration Form
  │
  ├─→ Fill Username: john_cs_2024
  │
  ├─→ Fill Password: MyPass123
  │
  ├─→ Select Role: "Student"
  │   └─→ Department field ENABLED
  │
  ├─→ Select Department: SCIENCE
  │
  ├─→ Click [Register]
  │
  ├─→ System Validates:
  │   ├─ Username not empty? ✓
  │   ├─ Password not empty? ✓
  │   ├─ Role selected? ✓
  │   ├─ Department selected? ✓
  │   └─ Username unique? ✓
  │
  ├─→ Insert into Users table
  │   {
  │     UserID: 5,
  │     Username: john_cs_2024,
  │     Password: MyPass123,
  │     Role: Student,
  │     Department: SCIENCE
  │   }
  │
  ├─→ Show: "Registration Successful!"
  │
  ├─→ Close Form
  │
  └─→ Return to Login Form
      │
      └─→ Can now login with john_cs_2024 / MyPass123
```

## VOLUNTEER SIGNUP SEQUENCE

```
START
  │
  ├─→ Open Registration Form
  │
  ├─→ Fill Register Number: VOL-2024-001
  │
  ├─→ Fill Password: SecurePass456
  │
  ├─→ Select Role: "Volunteer"
  │   └─→ OTP fields ENABLED
  │
  ├─→ Click [Generate OTP]
  │   └─→ System generates random 4-digit: 7392
  │   └─→ Dialog shows: "Your OTP is: 7392"
  │
  ├─→ User writes down OTP (7392)
  │
  ├─→ Enter OTP in field: 7392
  │
  ├─→ Click [Register]
  │
  ├─→ System Validates:
  │   ├─ Username not empty? ✓
  │   ├─ Password not empty? ✓
  │   ├─ Role selected? ✓
  │   ├─ OTP generated? ✓
  │   ├─ OTP correct (7392==7392)? ✓
  │   └─ Username unique? ✓
  │
  ├─→ Insert into Users table
  │   {
  │     UserID: 6,
  │     Username: VOL-2024-001,
  │     Password: SecurePass456,
  │     Role: Volunteer,
  │     Department: N/A
  │   }
  │
  ├─→ Insert into AllowedVolunteers table
  │   {
  │     VolunteerID: 3,
  │     RegNo: VOL-2024-001,
  │     Name: VOL-2024-001,
  │     Department: Volunteer,
  │     IsActive: 1
  │   }
  │
  ├─→ Show: "Registration Successful!"
  │
  ├─→ Close Form
  │
  └─→ Return to Login Form
      │
      └─→ Can now login with VOL-2024-001 / SecurePass456
```

## ERROR HANDLING FLOWCHART

```
┌─────────────────┐
│  Click Register │
└────────┬────────┘
         │
         ▼
    ┌─────────────────────┐
    │ Username Empty?     │
    └────────┬────────────┘
       YES ──┤── NO
             │    │
             │    ▼
             │ ┌──────────────────┐
             │ │ Password Empty?  │
             │ └────────┬─────────┘
             │    YES ──┤── NO
             │          │   │
             │          │   ▼
             │          │ ┌────────────────────┐
             │          │ │ Role Not Selected? │
             │          │ └────────┬───────────┘
             │          │    YES ──┤── NO
             │          │          │   │
             │          │          │   ▼
             │          │          │ ┌─────────────────────┐
             │          │          │ │ Student?            │
             │          │          │ └──────┬──────────────┘
             │          │          │        │
             │          │          │   YES ┌┴─────┐
             │          │          │        │  NO  │
             │          │          │        │      │
             │          │          │        ▼      ▼
             │          │          │   ┌─────┐ ┌────────────┐
             │          │          │   │Dept?│ │Volunteer?  │
             │          │          │   │check│ │ OTP check  │
             │          │          │   └─────┘ └────┬───────┘
             │          │          │        │  YES ─┤─ NO
             │          │          │        │       │
    Error ──┬┴──────────┴┴──────────┴┴───────┘       │
    Message │                                       │
             │                                       ▼
    ┌────────┴────────┐                    ┌──────────────────┐
    │ Show Alert:     │                    │ Username Unique? │
    │ - Fill fields   │                    └────────┬─────────┘
    │ - Select dept   │                       YES ──┤── NO
    │ - Generate OTP  │                            │   │
    │ - Enter OTP     │                            │   ▼
    │ - Fix error     │                            │ ┌────────────┐
    └────────┬────────┘                            │ │ Duplicate! │
             │                                     │ └────────────┘
             │<────────────────────────────────────┤
             │                                     │
             ▼                                     ▼
    ┌─────────────────────────────────────────────────┐
    │     Registration Failed                        │
    │     Return to Form (Keep Data)                 │
    │     Try Again                                  │
    └─────────────────────────────────────────────────┘
```

## DATABASE FLOW

```
┌──────────────────────┐
│   Registration Form  │
└─────────┬────────────┘
          │
          ├─ Role = Student?
          │  ├─ YES ──┐
          │  │        └─→ [Insert into Users]
          │  │           └─→ Success
          │  │
          │  └─ NO (Volunteer)
          │     └─→ [Insert into Users]
          │        └─→ [Insert into AllowedVolunteers]
          │           └─→ Success
          │
          ▼
    ┌─────────────────┐
    │  Users Table    │
    ├─────────────────┤
    │ UserID (PK)     │
    │ Username        │
    │ Password        │
    │ Role            │
    │ Department      │
    │ CreatedDate     │
    │ UpdatedDate     │
    └─────────────────┘
         │
         │ (Volunteer only)
         │
         ▼
    ┌──────────────────────┐
    │ AllowedVolunteers    │
    ├──────────────────────┤
    │ VolunteerID (PK)     │
    │ RegNo (FK to Users)  │
    │ Name                 │
    │ Department           │
    │ IsActive             │
    │ CreatedDate          │
    └──────────────────────┘
```

## LOGIN AFTER SIGNUP FLOW

```
┌─────────────────────────┐
│    Registration Done    │
│  (User in database)     │
└────────┬────────────────┘
         │
         ▼
    ┌─────────────────┐
    │   Login Form    │
    └────────┬────────┘
             │
      ┌──────┴──────┐
      │             │
      ▼             ▼
 [Username]   [Password]
      │             │
      │ (Use from)  │ (Use from)
      │ (Signup)    │ (Signup)
      │             │
      └──────┬──────┘
             │
             ▼
      ┌─────────────┐
      │ Click Login │
      └──────┬──────┘
             │
             ▼
    ┌─────────────────────┐
    │ Check Credentials   │
    │ in Users Table      │
    └──────┬──────────────┘
           │
      ┌────┴────┐
      │          │
      ▼          ▼
   Match    No Match
      │          │
      ▼          ▼
   Success    Error
      │          │
      ▼          ▼
  ┌─────┐   ┌────────┐
  │ Get │   │ Invalid│
  │Role │   │Cred.   │
  └──┬──┘   └────────┘
     │
 ┌───┴───┬────────┬────────┐
 │       │        │        │
 ▼       ▼        ▼        ▼
Admin Student  HOD  Volunteer
 │       │        │        │
 └───┬───┴────────┴────────┘
     │
     ▼
Open Dashboard (Role-based)
     │
     ▼
User Logged In ✓
```

## DECISION TREE

```
Registration Form Opens
│
└─→ Select Role
   │
   ├─→ STUDENT
   │  └─→ Department visible? YES
   │     └─→ Can select any of 6 departments
   │        └─→ Click Register
   │           └─→ Quick registration
   │              └─→ Success (1-2 seconds)
   │
   ├─→ VOLUNTEER
   │  └─→ Generate OTP visible? YES
   │     └─→ Click Generate OTP
   │        └─→ Get random 4-digit code
   │           └─→ Enter OTP in field
   │              └─→ Click Register
   │                 └─→ Dual registration
   │                    └─→ Success (2-3 seconds)
   │
   └─→ ADMIN
      └─→ Error: Cannot self-register
         └─→ Contact administrator
```

## UI STATE TRANSITIONS

```
INITIAL STATE (Form Opens)
├─ Role: [Dropdown - empty]
├─ Username: [TextBox - enabled]
├─ Password: [TextBox - enabled]
├─ Department: [ComboBox - DISABLED] ← Greyed out
├─ Generate OTP: [Button - DISABLED] ← Greyed out
└─ OTP Field: [TextBox - DISABLED] ← Greyed out

↓

STUDENT SELECTED
├─ Role: [Student] ✓
├─ Username: [TextBox - enabled]
├─ Password: [TextBox - enabled]
├─ Department: [ComboBox - ENABLED] ← Brightened
├─ Generate OTP: [Button - DISABLED] ← Still greyed
└─ OTP Field: [TextBox - DISABLED] ← Still greyed

↓

VOLUNTEER SELECTED
├─ Role: [Volunteer] ✓
├─ Username: [TextBox - enabled]
├─ Password: [TextBox - enabled]
├─ Department: [ComboBox - DISABLED] ← Greyed again
├─ Generate OTP: [Button - ENABLED] ← Brightened
└─ OTP Field: [TextBox - ENABLED] ← Brightened

↓

OTP GENERATED
├─ All fields: [Same as before]
├─ OTP Field: [TextBox - ready for input]
└─ Message: "Your OTP is: 5682" ← Dialog

↓

READY TO REGISTER
├─ All validation passed
├─ Register Button: [Enabled - ready]
└─ Click Register → Success
```

## CLASS DIAGRAM (Simplified)

```
┌──────────────────┐
│  LoginForm       │
├──────────────────┤
│ - textBox1       │
│ - textBox2       │
│ - button1 (Login)│
│ - button2 (Sign) │◄── NEW
├──────────────────┤
│ + button1_Click()│
│ + button2_Click()│◄── NEW
└──────────────────┘
      │
      │ Opens
      ▼
┌──────────────────┐
│ Register Form    │
├──────────────────┤
│ - textBox1       │
│ - textBox2       │
│ - textBox3       │
│ - comboBox1      │
│ - comboBox2      │
│ - button1 (OTP)  │
│ - button2 (Reg)  │
│ - button3 (Back) │
├──────────────────┤
│ - generatedOTP   │
├──────────────────┤
│ + button1_Click()│
│ + button2_Click()│
│ + button3_Click()│
│ - Validate()     │
│ - RegisterUser() │
│ - InsertDB()     │
└──────────────────┘
      │
      │ Writes to
      ▼
┌──────────────────┐
│   Users Table    │
├──────────────────┤
│ UserID (PK)      │
│ Username         │
│ Password         │
│ Role             │
│ Department       │
└──────────────────┘
      │
      │ (Volunteer only)
      ▼
┌──────────────────────┐
│AllowedVolunteers Tbl │
├──────────────────────┤
│ VolunteerID (PK)     │
│ RegNo (FK)           │
│ Name                 │
│ Department           │
└──────────────────────┘
```

## TIMELINE DIAGRAM

```
Time: 0 seconds
├─ User launches application

Time: 1 second
├─ Login form appears
├─ User sees [Login] and [Sign Up] buttons

Time: 2 seconds
├─ User clicks [Sign Up]
├─ Registration form opens

Time: 5 seconds
├─ User fills in all details
├─ For Student: Select department (1-2 secs)
├─ For Volunteer: Generate OTP (1 sec), enter OTP (1 sec)

Time: 6-8 seconds
├─ User clicks [Register]
├─ Validation checks run (<100ms)
├─ Database insert (<500ms)
├─ Success message appears

Time: 9 seconds
├─ Form closes automatically
├─ Returns to Login form

Time: 10 seconds
├─ User enters new username/password
├─ Clicks [Login]

Time: 12 seconds
├─ Authenticated
├─ Dashboard opens (role-based)
├─ User is logged in ✓

Total Time: ~12 seconds
```

============================================================

These diagrams show the complete flow of your signup system!
