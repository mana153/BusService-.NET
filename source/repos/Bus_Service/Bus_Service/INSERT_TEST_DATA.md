# 🔧 FIX: Insert Test Users into Database

## Problem
Users table is empty - no test data for login testing

## Solution

### Method 1: Run InsertTestData.sql (Recommended)

1. **Open SQL Server Management Studio (SSMS)**
2. **Click File → Open → File**
3. **Select:** `Bus_Service\InsertTestData.sql`
4. **Click Execute** (F5)
5. ✅ Users will be inserted

### Method 2: Run SQL Queries Directly

1. **Open SSMS Query Window**
2. **Run these commands:**

```sql
-- Insert Admin
INSERT INTO Users (Username, Password, Role, Department, IsActive) 
VALUES ('admin', 'admin123', 'Admin', 'Administration', 1);

-- Insert HOD
INSERT INTO Users (Username, Password, Role, Department, IsActive) 
VALUES ('hod1', 'hod123', 'HOD', 'Computer Science', 1);

-- Insert Student
INSERT INTO Users (Username, Password, Role, Department, IsActive) 
VALUES ('student1', 'student123', 'Student', 'Computer Science', 1);

-- Insert Volunteer
INSERT INTO Users (Username, Password, Role, Department, IsActive) 
VALUES ('volunteer1', 'vol123', 'Volunteer', 'Volunteer Team', 1);
```

3. **Execute (F5)**
4. ✅ Users inserted

### Method 3: Verify Data Was Inserted

```sql
SELECT UserID, Username, Role, Department FROM Users;
```

Should show 4 rows:
- UserID 1: admin
- UserID 2: hod1
- UserID 3: student1
- UserID 4: volunteer1

---

## ✅ After Inserting Users

### Run Application and Test Login:

**Username:** admin  
**Password:** admin123  

Expected: Admin Dashboard opens successfully ✅

---

## 📝 Test Credentials Now Available

| Username | Password | Role | Department |
|----------|----------|------|-----------|
| admin | admin123 | Admin | Administration |
| hod1 | hod123 | HOD | Computer Science |
| student1 | student123 | Student | Computer Science |
| volunteer1 | vol123 | Volunteer | Volunteer Team |

---

## 🚀 Next Steps

1. ✅ Insert test data (pick Method 1 or 2)
2. ✅ Run Application (F5)
3. ✅ Login with admin / admin123
4. ✅ Test all features

**System is ready after data insertion!**
