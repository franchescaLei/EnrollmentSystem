# 🎓 Horizon Academy — Student Enrollment & Management System

> A desktop-based academic management system built with **C# Windows Forms** and **MS SQL Server**, designed to streamline student enrollment, payment processing, and academic record management for Horizon Academy.

---

## 📌 Overview

Horizon Academy is a multi-form desktop application that provides three dedicated role-based interfaces — for **Registration staff**, the **Cashier**, and the **Registrar** — each handling a distinct part of the student lifecycle, from initial enrollment to payment tracking and official record generation.

---

## 🏗️ System Architecture

```
HorizonAcademy/
├── Program.cs                  # Application entry point — launches all three forms
├── Methods.cs                  # Centralized business logic & database operations
├── Form1.cs / Form1.Designer.cs        # Student Registration Form
├── Cashier.cs / Cashier.Designer.cs    # Cashier Payment Form
├── Registrar.cs / Registrar.Designer.cs# Registrar Records Form
└── App.config                          # .NET 4.7.2 runtime configuration
```

**Tech Stack:**
- **Language:** C# (.NET Framework 4.7.2)
- **UI Framework:** Windows Forms (WinForms)
- **Database:** Microsoft SQL Server (LocalDB)
- **Data Access:** ADO.NET (`SqlConnection`, `SqlCommand`, `SqlDataReader`)

---

## 🖥️ Features by Module

### 📝 Student Registration (`Form1`)
The entry point for new student enrollment. Staff can input complete student details and submit them to the database.

- Collects personal information: Last Name, First Name, Middle Name, Gender, Contact Number, Email Address
- Collects guardian information: Name, Contact Number, Email
- Selects academic details: Program, Year Level, and Payment Term
- **Validations include:**
  - Names cannot contain numeric characters
  - Philippine mobile number format enforced (`09XXXXXXXXX`)
  - Email must end with `@gmail.com`, `@yahoo.com`, or `@outlook.com`
  - Duplicate student detection by full name
  - All required fields must be completed before submission
- Auto-generates a sequential **Student Number** upon successful registration

**Supported Programs:**
| Code | Program |
|------|---------|
| BSIT | BS in Information Technology |
| BSCpE | BS in Computer Engineering |
| BSTM | BS in Tourism Management |
| BSA | BS in Accountancy |

**Payment Terms:**
- `Full Payment` — One-time settlement of total fees
- `DP + Monthly Installment` — Down payment followed by monthly payments

---

### 💰 Cashier (`Cashier`)
Handles student payment submission and real-time payment history viewing.

- Selects a student from a populated dropdown of enrolled students
- Auto-fills student **Name** and **Year & Program** upon selection
- Dynamically loads the correct **payment amount** based on:
  - The student's payment term (`Full Payment` or `DP + Monthly Installment`)
  - Whether the down payment has already been settled
- Selects a payment date via a date picker
- Submits payments to the database and immediately refreshes payment history
- Displays full **Payment History** in a data grid (amount + date)
- Prevents overpayment — blocks submission if the student has completed all required payments
- Refresh button to reload the student list

---

### 📋 Registrar (`Registrar`)
Provides a read-only academic overview of any enrolled student and generates their official Registration Acknowledgment Form (RAF).

- Selects a student by student number
- Displays:
  - **Full Name** and **Year & Program**
  - **Total Fees**, **Total Payments Made**, and **Remaining Balance**
  - **Enrolled Courses** based on program and year level
  - **Payment Schedule** dynamically generated based on payment term and number of payments made
- **Generate RAF** — Exports a formatted `.txt` file to disk containing:
  - Student Information
  - Enrolled Courses
  - Financial Summary (fees, payments, balance)
  - Payment Schedule with outstanding balance warnings

---

## 🗄️ Database Schema (Inferred)

| Table | Key Columns |
|-------|-------------|
| `Students` | `StudentNo`, `LastName`, `FirstName`, `MiddleName`, `Gender`, `ContactNumber`, `EmailAddress`, `GuardianName`, `GuardianContactNumber`, `GuardianEmail`, `ProgramID`, `YearLevel`, `PaymentTerm` |
| `ProgramFees` | `ProgramID`, `YearLevel`, `DownPayment`, `MonthlyPayment`, `FullPaymentFee` |
| `Payments` | `StudentNo`, `PaymentAmount`, `PaymentDate` |
| `Courses` | `CourseName`, `ProgramID`, `YearLevel` |

---

## ⚙️ Setup & Installation

### Prerequisites
- Windows OS
- [Visual Studio 2019+](https://visualstudio.microsoft.com/)
- .NET Framework 4.7.2
- SQL Server LocalDB (included with Visual Studio)

### Steps

1. **Clone the repository**
   ```bash
   git clone https://github.com/your-username/HorizonAcademy.git
   cd HorizonAcademy
   ```

2. **Set up the database**
   - Open SQL Server Management Studio or Visual Studio's SQL Server Object Explorer
   - Create a new database named `HorizonAcademy`
   - Run the schema scripts to create the `Students`, `ProgramFees`, `Payments`, and `Courses` tables
   - Populate `ProgramFees` and `Courses` with appropriate seed data

3. **Configure the connection string** *(if needed)*

   The connection string is defined in `Methods.cs`:
   ```csharp
   connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=HorizonAcademy;Integrated Security=True;";
   ```
   Modify this if your SQL Server instance differs.

4. **Build and Run**
   - Open `HorizonAcademy.sln` in Visual Studio
   - Build the solution (`Ctrl+Shift+B`)
   - Run with `F5`

All three forms (Registration, Cashier, Registrar) launch simultaneously on startup.

---

## 🔄 Application Flow

```
Student Arrives
      │
      ▼
[Registration Form] ──► Student enrolled, Student No. generated
      │
      ▼
[Cashier Form] ──► Payment submitted (DP or Full or Monthly)
      │
      ▼
[Registrar Form] ──► Records viewed, RAF file generated & saved
```

---

## 🛡️ Validation & Business Rules

- A student **cannot be registered twice** (checked by full name match)
- Contact numbers must follow Philippine format (`09XXXXXXXXX`, 11 digits)
- Email validation enforces common providers only
- Cashier **dynamically adjusts** payment options based on prior payment history
- A student on **DP + Monthly Installment** must pay the down payment before monthly options appear
- A student with **Full Payment** term only sees the full fee amount
- Payments are **blocked** once a student has completed all required payments (1 full payment, or 1 DP + 4 monthly installments)

---

## 📁 RAF File Output

Generated RAF files are saved to `D:\fianls\mgaRaf\` in the format:

```
{StudentNumber}_RAF.txt
```

If a file already exists, it is saved as `{StudentNumber}(1)_RAF.txt`, and so on — preventing overwrite.

---

## 👨‍💻 Author

Developed as an academic project demonstrating role-based desktop application development with C# WinForms and SQL Server.

---

> *Horizon Academy — Empowering students, one enrollment at a time.*
