using System;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;
using System.Linq;
using System.Text;
using System.IO;

namespace HorizonAcademy
{
    internal class Methods
    {
        private SqlConnection sqlConnect;
        private SqlCommand sqlCommand;
        private SqlDataAdapter sqlAdapter;
        private SqlDataReader sqlReader;
        public DataTable dataTable;
        public BindingSource bindingSource;
        private string connectionString;

        public Methods()
        {
            connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=HorizonAcademy;Integrated Security=True;Connect Timeout=30;Encrypt=False";
            sqlConnect = new SqlConnection(connectionString);
            dataTable = new DataTable();
            bindingSource = new BindingSource();
        }

        // Method to get the next student number
        public long GetNextStudentNumber()
        {
            long studentNumber = 0;
            string queryCheckEmpty = "SELECT COUNT(*) FROM Students";
            string queryGetLastStudentNumber = "SELECT MAX(StudentNo) FROM Students";

            try
            {
                sqlConnect.Open();

                // Check if the table is empty
                using (SqlCommand cmd = new SqlCommand(queryCheckEmpty, sqlConnect))
                {
                    int count = (int)cmd.ExecuteScalar();
                    if (count == 0)
                    {
                        // Start with the initial number
                        studentNumber = 02000284527;
                    }
                    else
                    {
                        // Get the last student number and increment it
                        using (SqlCommand cmdGetLast = new SqlCommand(queryGetLastStudentNumber, sqlConnect))
                        {
                            object result = cmdGetLast.ExecuteScalar();
                            studentNumber = Convert.ToInt64(result) + 1;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error fetching student number: {ex.Message}");
            }
            finally
            {
                sqlConnect.Close();
            }

            return studentNumber;
        }

        // Method to enroll a student
        public void EnrollStudent(long studentNumber, string lastName, string firstName, string middleName, string gender, string contactNo,
                                  string email, string guardianName, string guardianContactNo, string guardianEmail, string program, string yearLevel, 
                                  string paymentTerm)
        {
            // For int data type yearLevel
            int yearLevelInt = 0;

            // Convert the Year Level string from the combobox into an int
            switch (yearLevel)
            {
                case "First Year":
                    yearLevelInt = 1;
                    break;
                case "Second Year":
                    yearLevelInt = 2;
                    break;
                case "Third Year":
                    yearLevelInt = 3;
                    break;
                case "Fourth Year":
                    yearLevelInt = 4;
                    break;
                default:
                    MessageBox.Show("Invalid year level selected.");
                    return;
            }

            // Condition for not leaving fields blank
            if (string.IsNullOrWhiteSpace(lastName) ||
                string.IsNullOrWhiteSpace(firstName) ||
                string.IsNullOrWhiteSpace(gender) ||
                string.IsNullOrWhiteSpace(contactNo) ||
                string.IsNullOrWhiteSpace(email) ||
                string.IsNullOrWhiteSpace(guardianName) ||
                string.IsNullOrWhiteSpace(program) ||
                string.IsNullOrWhiteSpace(yearLevel) ||
                string.IsNullOrWhiteSpace(paymentTerm))
            {
                MessageBox.Show("Please fill in all the required fields.");
                return;
            }

            // Condition for the names to not have numbers
            if (lastName.Any(c => Char.IsDigit(c)) ||
                firstName.Any(c => Char.IsDigit(c)) ||
                middleName.Any(c => Char.IsDigit(c)) ||
                guardianName.Any(c => Char.IsDigit(c)))
            {
                MessageBox.Show("Names cannot contain numbers.");
                return;
            }

            // Validating the contact numbers
            if (contactNo.Any(c => !Char.IsDigit(c)) ||
                guardianContactNo.Any(c => !Char.IsDigit(c)))
            {
                MessageBox.Show("Contact numbers must contain only digits.");
                return;
            }

            // Philippine number format for student contact number
            try
            {
                string contactNumberPattern = @"^09\d{9}$";
                if (!System.Text.RegularExpressions.Regex.IsMatch(contactNo, contactNumberPattern))
                {
                    MessageBox.Show("Invalid student contact number format. It should start with '09' and have 11 digits.");
                    return;
                }

                // Philippine number format for guardian contact number
                if (!System.Text.RegularExpressions.Regex.IsMatch(guardianContactNo, contactNumberPattern))
                {
                    MessageBox.Show("Invalid guardian contact number format. It should start with '09' and have 11 digits.");
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error validating contact number: {ex.Message}");
                return;
            }
            if (!(email.EndsWith("@gmail.com") || email.EndsWith("@yahoo.com") || email.EndsWith("@outlook.com")) ||!(guardianEmail.EndsWith("@gmail.com") || guardianEmail.EndsWith("@yahoo.com") || guardianEmail.EndsWith("@outlook.com")))
            {
                MessageBox.Show("Email must be in the format of @gmail.com, @yahoo.com, or @outlook.com.");
                return;
            }

            // SQL query to check if the student is already registered
            string queryCheckStudent = @"SELECT COUNT(*) FROM Students 
                                 WHERE LastName = @LastName 
                                 AND FirstName = @FirstName 
                                 AND MiddleName = @MiddleName";

            try
            {
                sqlConnect.Open();

                // Check if the student already exists
                using (SqlCommand cmdCheck = new SqlCommand(queryCheckStudent, sqlConnect))
                {
                    cmdCheck.Parameters.AddWithValue("@LastName", lastName);
                    cmdCheck.Parameters.AddWithValue("@FirstName", firstName);
                    cmdCheck.Parameters.AddWithValue("@MiddleName", middleName ?? (object)DBNull.Value);

                    int existingStudentCount = (int)cmdCheck.ExecuteScalar();
                    if (existingStudentCount > 0)
                    {
                        MessageBox.Show("This student is already registered.");
                        return;
                    }
                }

                // SQL query to insert a new student into the Students table
                string queryInsert = @"INSERT INTO Students 
                              (StudentNo, LastName, FirstName, MiddleName, Gender, ContactNumber, EmailAddress, GuardianName, GuardianContactNumber, GuardianEmail, ProgramID, YearLevel, PaymentTerm)
                               VALUES 
                              (@StudentNo, @LastName, @FirstName, @MiddleName, @Gender, @ContactNumber, @EmailAddress, @GuardianName, @GuardianContactNumber, @GuardianEmail, @ProgramID, @YearLevel, @PaymentTerm)";

                using (SqlCommand cmd = new SqlCommand(queryInsert, sqlConnect))
                {
                    cmd.Parameters.AddWithValue("@StudentNo", studentNumber);
                    cmd.Parameters.AddWithValue("@LastName", lastName);
                    cmd.Parameters.AddWithValue("@FirstName", firstName);
                    cmd.Parameters.AddWithValue("@MiddleName", middleName ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@Gender", gender);
                    cmd.Parameters.AddWithValue("@ContactNumber", contactNo);
                    cmd.Parameters.AddWithValue("@EmailAddress", email);
                    cmd.Parameters.AddWithValue("@GuardianName", guardianName);
                    cmd.Parameters.AddWithValue("@GuardianContactNumber", guardianContactNo ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@GuardianEmail", guardianEmail ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@ProgramID", program);  // Ensure ProgramID matches the comboBox selection (ProgramID)
                    cmd.Parameters.AddWithValue("@YearLevel", yearLevelInt);  // Use the mapped integer value for year level
                    cmd.Parameters.AddWithValue("@PaymentTerm", paymentTerm);

                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show($"Enrollment successful! Student Number: {studentNumber}");
            }
            catch (SqlException sqlEx)
            {
                MessageBox.Show($"SQL Error: {sqlEx.Message}");
            }
            catch (FormatException formatEx)
            {
                MessageBox.Show($"Format Error: {formatEx.Message}");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error enrolling student: {ex.Message}");
            }
            finally
            {
                sqlConnect.Close();
            }
        }

        //For putting the initial values in the combobox of cashier  and registrar form
        public void LoadStudentNumbers(ComboBox cboxStudentNumber)
        {
            cboxStudentNumber.Items.Clear();
            string query = "SELECT StudentNo FROM Students WHERE PaymentTerm IS NOT NULL AND YearLevel IS NOT NULL AND ProgramID IS NOT NULL";

            try
            {
                sqlConnect.Open();
                SqlCommand cmd = new SqlCommand(query, sqlConnect);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    cboxStudentNumber.Items.Add(reader["StudentNo"].ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading student numbers: " + ex.Message);
            }
            finally
            {
                sqlConnect.Close();
            }
        }
        public void UpdatePaymentAmountAndHistory(ComboBox cboxPaymentAmount, DataGridView dataGridViewPaymentHistory, string studentNo, TextBox txtName, TextBox txtYearandProgram)
        {
            cboxPaymentAmount.SelectedIndex = -1;
            cboxPaymentAmount.Items.Clear();

            string program = "";
            string yearLevel = "";
            string lastName = "";
            string firstName = "";
            string middleInitial = "";

            // Get program, year level, and student details (name) based on the selected student
            string query = @"SELECT LastName, FirstName, MiddleName, ProgramID, YearLevel 
                           FROM Students 
                           WHERE StudentNo = @StudentNo";

            using (SqlCommand cmd = new SqlCommand(query, sqlConnect))
            {
                cmd.Parameters.AddWithValue("@StudentNo", studentNo);
                sqlConnect.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    lastName = reader["LastName"].ToString();
                    firstName = reader["FirstName"].ToString();
                    middleInitial = !string.IsNullOrEmpty(reader["MiddleName"].ToString()) ? reader["MiddleName"].ToString()[0] + "." : ""; // Get middle initial and put a .
                    program = reader["ProgramID"].ToString();
                    yearLevel = reader["YearLevel"].ToString();
                }
                sqlConnect.Close();
            }

            // Set the student name and year/program in the respective textboxes
            txtName.Text = $"{lastName}, {firstName} {middleInitial}";
            txtYearandProgram.Text = $"{program} - {yearLevel}";

            // Get fees based on ProgramID and YearLevel
            string feeQuery = @" SELECT DownPayment, MonthlyPayment, FullPaymentFee
                                 FROM ProgramFees 
                                 WHERE ProgramID = @ProgramID AND YearLevel = @YearLevel";

            decimal downPayment = 0, monthlyPayment = 0, fullPaymentFee = 0;
            using (SqlCommand cmd = new SqlCommand(feeQuery, sqlConnect))
            {
                cmd.Parameters.AddWithValue("@ProgramID", program);
                cmd.Parameters.AddWithValue("@YearLevel", yearLevel);
                sqlConnect.Open();
                SqlDataReader feeReader = cmd.ExecuteReader();
                if (feeReader.Read())
                {
                    downPayment = feeReader["DownPayment"] != DBNull.Value ? (decimal)feeReader["DownPayment"] : 0;
                    monthlyPayment = feeReader["MonthlyPayment"] != DBNull.Value ? (decimal)feeReader["MonthlyPayment"] : 0;
                    fullPaymentFee = feeReader["FullPaymentFee"] != DBNull.Value ? (decimal)feeReader["FullPaymentFee"] : 0;
                }
                sqlConnect.Close();
            }

            // Populate payment options based on payment term
            string paymentTerm = GetPaymentTerm(studentNo); //call another method
            if (paymentTerm == "Full payment" && fullPaymentFee > 0)
            {
                cboxPaymentAmount.Items.Add(fullPaymentFee.ToString()); //if payment term is full payment, the combo box only has the Full payment amount option
            }
            else if (paymentTerm == "DP + Monthly Installment")
            {
                if (HasPaidDownPayment(studentNo))
                {
                    cboxPaymentAmount.Items.Add(monthlyPayment.ToString()); //if payment term is dp + installments and if DP has been paid, show only the monthly payment amount option
                }
                else
                {
                    cboxPaymentAmount.Items.Add(downPayment.ToString()); //if payment term is dp + installments and if DP has not been paid, show only the dp payment option
                }
            }

            // Populate the payment history for the selected student
            string historyQuery = "SELECT PaymentAmount, PaymentDate FROM Payments WHERE StudentNo = @StudentNo";
            using (SqlCommand cmd = new SqlCommand(historyQuery, sqlConnect))
            {
                cmd.Parameters.AddWithValue("@StudentNo", studentNo);
                sqlConnect.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(reader);
                dataGridViewPaymentHistory.DataSource = dt;
                sqlConnect.Close();
            }
        }
        private string GetPaymentTerm(string studentNo)
        {
            string query = "SELECT PaymentTerm FROM Students WHERE StudentNo = @StudentNo";
            using (SqlCommand cmd = new SqlCommand(query, sqlConnect))
            {
                cmd.Parameters.AddWithValue("@StudentNo", studentNo);
                sqlConnect.Open();
                string paymentTerm = cmd.ExecuteScalar()?.ToString();
                sqlConnect.Close();
                return paymentTerm;
            }
        }

        //method to check whether the downpayment has been paid (since the dp is the first required payment, its easier to just use the amount of payments of the student as condition)
        private bool HasPaidDownPayment(string studentNo)
        {
            string query = "SELECT COUNT(*) FROM Payments WHERE StudentNo = @StudentNo AND PaymentAmount = (SELECT DownPayment FROM ProgramFees WHERE ProgramID = (SELECT ProgramID FROM Students WHERE StudentNo = @StudentNo) AND YearLevel = (SELECT YearLevel FROM Students WHERE StudentNo = @StudentNo))";
            using (SqlCommand cmd = new SqlCommand(query, sqlConnect))
            {
                cmd.Parameters.AddWithValue("@StudentNo", studentNo);
                sqlConnect.Open();
                int count = (int)cmd.ExecuteScalar();
                sqlConnect.Close();
                return count > 0;
            }
        }

        
        public void SubmitPayment(string studentNo, decimal paymentAmount, DateTime paymentDate)
        {
            // Check if the student is allowed to make the payment
            if (!isFullyPaid(studentNo))
            {
                MessageBox.Show("This student has already made all required payments.");
                return;
            }

            string query = "INSERT INTO Payments (StudentNo, PaymentAmount, PaymentDate) VALUES (@StudentNo, @PaymentAmount, @PaymentDate)";
            using (SqlCommand cmd = new SqlCommand(query, sqlConnect))
            {
                cmd.Parameters.AddWithValue("@StudentNo", studentNo);
                cmd.Parameters.AddWithValue("@PaymentAmount", paymentAmount);
                cmd.Parameters.AddWithValue("@PaymentDate", paymentDate.Date); // Only the date, no time
                sqlConnect.Open();
                cmd.ExecuteNonQuery();
                sqlConnect.Close();
            }
            MessageBox.Show("Payment successfully submitted");
           
        }


        //checking if the student has already paid everything
        private bool isFullyPaid(string studentNo)
        {
            // Check for downpayment records
            string dpQuery = "SELECT COUNT(*) FROM Payments WHERE StudentNo = @StudentNo AND PaymentAmount = (SELECT DownPayment FROM ProgramFees WHERE ProgramID = (SELECT ProgramID FROM Students WHERE StudentNo = @StudentNo) AND YearLevel = (SELECT YearLevel FROM Students WHERE StudentNo = @StudentNo))";

            // Check for full payment records
            string fpQuery = "SELECT COUNT(*) FROM Payments WHERE StudentNo = @StudentNo AND PaymentAmount = (SELECT FullPaymentFee FROM ProgramFees WHERE ProgramID = (SELECT ProgramID FROM Students WHERE StudentNo = @StudentNo) AND YearLevel = (SELECT YearLevel FROM Students WHERE StudentNo = @StudentNo))";

            // Check for monthly installment records
            string mpQuery = "SELECT COUNT(*) FROM Payments WHERE StudentNo = @StudentNo AND PaymentAmount = (SELECT MonthlyPayment FROM ProgramFees WHERE ProgramID = (SELECT ProgramID FROM Students WHERE StudentNo = @StudentNo) AND YearLevel = (SELECT YearLevel FROM Students WHERE StudentNo = @StudentNo))";

            int dpCount = 0, fpCount = 0, mpCount = 0;

            // Execute the queries to get the counts for downpayment, full payment, and monthly payments
            using (SqlCommand cmd = new SqlCommand(dpQuery, sqlConnect))
            {
                cmd.Parameters.AddWithValue("@StudentNo", studentNo);
                sqlConnect.Open();
                dpCount = (int)cmd.ExecuteScalar();
                sqlConnect.Close();
            }

            using (SqlCommand cmd = new SqlCommand(fpQuery, sqlConnect))
            {
                cmd.Parameters.AddWithValue("@StudentNo", studentNo);
                sqlConnect.Open();
                fpCount = (int)cmd.ExecuteScalar();
                sqlConnect.Close();
            }

            using (SqlCommand cmd = new SqlCommand(mpQuery, sqlConnect))
            {
                cmd.Parameters.AddWithValue("@StudentNo", studentNo);
                sqlConnect.Open();
                mpCount = (int)cmd.ExecuteScalar();
                sqlConnect.Close();
            }

            // Check if the student has already paid downpayment, full payment, or the maximum number of monthly installments
            if (fpCount >= 1 || mpCount >= 4 && dpCount >=1)
            {
                return false;
            }
            return true;
        }

        // method for getting the info for the registrar form
        public void FetchStudentInfo(string studentNo, TextBox txtFullName, TextBox txtProgram, TextBox txtTotalPayments, TextBox txtTotalFees, TextBox txtTotalBalance)
        {
            // Query to get basic student info, including program, year level, and middle name
            string studentQuery = @"SELECT 
                                    S.FirstName, S.LastName, S.MiddleName, S.ProgramID, S.YearLevel, S.PaymentTerm, 
                                    PF.FullPaymentFee
                                  FROM Students S
                                  LEFT JOIN ProgramFees PF ON PF.ProgramID = S.ProgramID AND PF.YearLevel = S.YearLevel
                                  WHERE S.StudentNo = @StudentNo";

            // Query to get total payments made by the student
            string paymentQuery = "SELECT PaymentAmount FROM Payments WHERE StudentNo = @StudentNo";

            if (sqlConnect.State == System.Data.ConnectionState.Closed)
            {
                sqlConnect.Open();
            }

            try
            {
                // First, execute query to get student details
                using (SqlCommand cmd = new SqlCommand(studentQuery, sqlConnect))
                {
                    cmd.Parameters.AddWithValue("@StudentNo", studentNo);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            // Populate student details
                            txtFullName.Text = reader["FirstName"].ToString() + " " + reader["LastName"].ToString() +
                                (reader["MiddleName"] != DBNull.Value && !string.IsNullOrEmpty(reader["MiddleName"].ToString())
                                 ? " " + reader["MiddleName"].ToString()[0].ToString() + "."
                                 : "");

                            txtProgram.Text = reader["ProgramID"].ToString() + "-" + reader["YearLevel"].ToString();

                            decimal fullPaymentFee = Convert.ToDecimal(reader["FullPaymentFee"]);
                            txtTotalFees.Text = fullPaymentFee.ToString("C");

                            
                            reader.Close();

                            //get the total payments for the selected student by summing them up
                            decimal totalPayments = 0;
                            using (SqlCommand paymentCmd = new SqlCommand(paymentQuery, sqlConnect))
                            {
                                paymentCmd.Parameters.AddWithValue("@StudentNo", studentNo);

                                using (SqlDataReader paymentReader = paymentCmd.ExecuteReader())
                                {
                                    while (paymentReader.Read())
                                    {
                                        totalPayments += Convert.ToDecimal(paymentReader["PaymentAmount"]);
                                    }
                                }
                            }

                            // Populate the total payments
                            txtTotalPayments.Text = totalPayments.ToString("C");

                            // Calculate the total balance
                            decimal totalBalance = fullPaymentFee - totalPayments;
                            txtTotalBalance.Text = totalBalance.ToString("C");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
            finally
            {
                if (sqlConnect.State == System.Data.ConnectionState.Open)
                {
                    sqlConnect.Close();
                }
            }
        }

        // registrar form method for getting the courses of a student based on their program and year
        public void FetchEnrolledCourses(string studentNo, RichTextBox richTextBoxEnrolledCourses)
        {
            // Query to get ProgramID and YearLevel of the student
            string studentQuery = @"SELECT ProgramID, YearLevel 
                                    FROM Students 
                                    WHERE StudentNo = @StudentNo";

            // Query to get course names based on ProgramID and YearLevel
            string coursesQuery = @"SELECT CourseName 
                                    FROM Courses 
                                    WHERE ProgramID = @ProgramID AND YearLevel = @YearLevel";

            if (sqlConnect.State == System.Data.ConnectionState.Closed)
            {
                sqlConnect.Open();
            }

            try
            {
                //get the student's ProgramID and YearLevel
                string programID = "";
                int yearLevel = 0;

                using (SqlCommand cmd = new SqlCommand(studentQuery, sqlConnect))
                {
                    cmd.Parameters.AddWithValue("@StudentNo", studentNo);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            programID = reader["ProgramID"].ToString();
                            yearLevel = Convert.ToInt32(reader["YearLevel"]);
                        }
                    }
                }

                //get the course names based on ProgramID and YearLevel
                using (SqlCommand coursesCmd = new SqlCommand(coursesQuery, sqlConnect))
                {
                    coursesCmd.Parameters.AddWithValue("@ProgramID", programID);
                    coursesCmd.Parameters.AddWithValue("@YearLevel", yearLevel);

                    using (SqlDataReader coursesReader = coursesCmd.ExecuteReader())
                    {
                        // Clear previous courses in the richTextBox
                        richTextBoxEnrolledCourses.Clear();

                        // Add courses to the richTextBox
                        while (coursesReader.Read())
                        {
                            richTextBoxEnrolledCourses.AppendText(coursesReader["CourseName"].ToString() + "\n");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
            finally
            {
                if (sqlConnect.State == System.Data.ConnectionState.Open)
                {
                    sqlConnect.Close();
                }
            }
        }

        //registrar form method for getting the payment schedule
        public void GeneratePaymentSchedule(string studentNo, RichTextBox richTextBoxPaymentSchedule)
        {
            // Query to get the ProgramID, YearLevel, and PaymentTerm of the student
            string studentQuery = @"SELECT ProgramID, YearLevel, PaymentTerm
                                    FROM Students
                                    WHERE StudentNo = @StudentNo";

            // Query to get the ProgramFees based on ProgramID and YearLevel
            string feesQuery = @"SELECT FullPaymentFee, DownPayment, MonthlyPayment
                                 FROM ProgramFees
                                 WHERE ProgramID = @ProgramID AND YearLevel = @YearLevel";

            // Query to count the number of payments already made by the student
            string paymentCountQuery = @"SELECT COUNT(*) FROM Payments
                                        WHERE StudentNo = @StudentNo";

            if (sqlConnect.State == System.Data.ConnectionState.Closed)
            {
                sqlConnect.Open();
            }

            try
            {
                //get the student's ProgramID, YearLevel, and PaymentTerm
                string programID = string.Empty;
                int yearLevel = 0;
                string paymentTerm = string.Empty;

                using (SqlCommand cmd = new SqlCommand(studentQuery, sqlConnect))
                {
                    cmd.Parameters.AddWithValue("@StudentNo", studentNo);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            programID = reader["ProgramID"].ToString();
                            yearLevel = Convert.ToInt32(reader["YearLevel"]);
                            paymentTerm = reader["PaymentTerm"].ToString();
                        }
                    }
                }

                //get the ProgramFees for the student based on ProgramID and YearLevel
                decimal fullPaymentFee = 0;
                decimal downPayment = 0;
                decimal monthlyPayment = 0;

                using (SqlCommand cmdFees = new SqlCommand(feesQuery, sqlConnect))
                {
                    cmdFees.Parameters.AddWithValue("@ProgramID", programID);
                    cmdFees.Parameters.AddWithValue("@YearLevel", yearLevel);

                    using (SqlDataReader readerFees = cmdFees.ExecuteReader())
                    {
                        if (readerFees.Read())
                        {
                            fullPaymentFee = Convert.ToDecimal(readerFees["FullPaymentFee"]);
                            downPayment = Convert.ToDecimal(readerFees["DownPayment"]);
                            monthlyPayment = Convert.ToDecimal(readerFees["MonthlyPayment"]);
                        }
                    }
                }

                // Get the count of payments already made by the student
                int paymentCount = 0;
                using (SqlCommand cmdPaymentCount = new SqlCommand(paymentCountQuery, sqlConnect))
                {
                    cmdPaymentCount.Parameters.AddWithValue("@StudentNo", studentNo);
                    paymentCount = Convert.ToInt32(cmdPaymentCount.ExecuteScalar());
                }

                // Build the payment schedule based on the conditions
                StringBuilder paymentSchedule = new StringBuilder();

                if (paymentTerm == "Full payment" && paymentCount == 1)
                {
                    paymentSchedule.AppendLine("December 10, 2024 - Php 0");
                    paymentSchedule.AppendLine("January 13, 2025 - Php 0");
                    paymentSchedule.AppendLine("February 14, 2025 - Php 0");
                    paymentSchedule.AppendLine("March 16, 2025 - Php 0");
                    paymentSchedule.AppendLine("April 20, 2025 - Php 0");
                }
                else if (paymentTerm == "Full payment" && paymentCount != 1)
                {
                    paymentSchedule.AppendLine($"December 10, 2024 - Php {fullPaymentFee}");
                    paymentSchedule.AppendLine("January 13, 2025 - Php 0");
                    paymentSchedule.AppendLine("February 14, 2025 - Php 0");
                    paymentSchedule.AppendLine("March 16, 2025 - Php 0");
                    paymentSchedule.AppendLine("April 20, 2025 - Php 0");
                }
                else if (paymentTerm == "DP + Monthly Installment")
                {
                    // Handle payments based on number of records in the Payments table
                    if (paymentCount == 0)
                    {
                        paymentSchedule.AppendLine($"December 10, 2024 - Php {downPayment}");
                        paymentSchedule.AppendLine($"January 13, 2025 - Php {monthlyPayment}");
                        paymentSchedule.AppendLine($"February 14, 2025 - Php {monthlyPayment}");
                        paymentSchedule.AppendLine($"March 16, 2025 - Php {monthlyPayment}");
                        paymentSchedule.AppendLine($"April 20, 2025 - Php {monthlyPayment}");
                    }
                    else if (paymentCount == 1)
                    {
                        paymentSchedule.AppendLine("December 10, 2024 - Php 0");
                        paymentSchedule.AppendLine($"January 13, 2025 - Php {monthlyPayment}");
                        paymentSchedule.AppendLine($"February 14, 2025 - Php {monthlyPayment}");
                        paymentSchedule.AppendLine($"March 16, 2025 - Php {monthlyPayment}");
                        paymentSchedule.AppendLine($"April 20, 2025 - Php {monthlyPayment}");
                    }
                    else if (paymentCount == 2)
                    {
                        paymentSchedule.AppendLine("December 10, 2024 - Php 0");
                        paymentSchedule.AppendLine("January 13, 2025 - Php 0");
                        paymentSchedule.AppendLine($"February 14, 2025 - Php {monthlyPayment}");
                        paymentSchedule.AppendLine($"March 16, 2025 - Php {monthlyPayment}");
                        paymentSchedule.AppendLine($"April 20, 2025 - Php {monthlyPayment}");
                    }
                    else if (paymentCount == 3)
                    {
                        paymentSchedule.AppendLine("December 10, 2024 - Php 0");
                        paymentSchedule.AppendLine("January 13, 2025 - Php 0");
                        paymentSchedule.AppendLine("February 14, 2025 - Php 0");
                        paymentSchedule.AppendLine($"March 16, 2025 - Php {monthlyPayment}");
                        paymentSchedule.AppendLine($"April 20, 2025 - Php {monthlyPayment}");
                    }
                    else if (paymentCount == 4)
                    {
                        paymentSchedule.AppendLine("December 10, 2024 - Php 0");
                        paymentSchedule.AppendLine("January 13, 2025 - Php 0");
                        paymentSchedule.AppendLine("February 14, 2025 - Php 0");
                        paymentSchedule.AppendLine("March 16, 2025 - Php 0");
                        paymentSchedule.AppendLine($"April 20, 2025 - Php {monthlyPayment}");
                    }
                    else if (paymentCount == 5)
                    {
                        paymentSchedule.AppendLine("December 10, 2024 - Php 0");
                        paymentSchedule.AppendLine("January 13, 2025 - Php 0");
                        paymentSchedule.AppendLine("February 14, 2025 - Php 0");
                        paymentSchedule.AppendLine("March 16, 2025 - Php 0");
                        paymentSchedule.AppendLine("April 20, 2025 - Php 0");
                    }
                }

                // Display the generated payment schedule in the RichTextBox
                richTextBoxPaymentSchedule.Text = paymentSchedule.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
            finally
            {
                if (sqlConnect.State == System.Data.ConnectionState.Open)
                {
                    sqlConnect.Close();
                }
            }
        }

        public void GenerateRAFFile(ComboBox cboxRegistrar, TextBox txtFullName, TextBox txtProgram,
                             TextBox txtTotalFees, TextBox txtTotalPayments, TextBox txtTotalBalance,
                             RichTextBox richTextBoxEnrolledCourses, RichTextBox richTextBoxPaymentSchedule)
        {

            if (string.IsNullOrWhiteSpace(cboxRegistrar.Text) ||
                string.IsNullOrWhiteSpace(txtFullName.Text) ||
                string.IsNullOrWhiteSpace(txtProgram.Text) ||
                string.IsNullOrWhiteSpace(txtTotalFees.Text) ||
                string.IsNullOrWhiteSpace(txtTotalPayments.Text) ||
                string.IsNullOrWhiteSpace(txtTotalBalance.Text) ||
                string.IsNullOrWhiteSpace(richTextBoxEnrolledCourses.Text) ||
                string.IsNullOrWhiteSpace(richTextBoxPaymentSchedule.Text))
            {
                MessageBox.Show("Please fill in all the required fields.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return; // Stop the method if any field is empty
            }
            // Get the student number from the ComboBox
            string studentNumber = cboxRegistrar.Text;

            // Get the file path where the text file will be saved
            string directoryPath = @"D:\fianls\mgaRaf"; // Path where the file will be saved

            // Ensure the directory exists
            if (!Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
            }

            // Set the file name and full path (e.g., "StudentNumber_RAF.txt")
            string filePath = Path.Combine(directoryPath, $"{studentNumber}_RAF.txt");
            int fileIndex = 1;

            // Check for existing files and increment the file name
            while (File.Exists(filePath))
            {
                filePath = Path.Combine(directoryPath, $"{studentNumber}({fileIndex})_RAF.txt");
                fileIndex++;
            }
            try
            {
                // Create or overwrite the text file
                using (StreamWriter writer = new StreamWriter(filePath))
                {
                    // Write the header for Student Information
                    writer.WriteLine("_____________________________________________________");
                    writer.WriteLine("\t\tSTUDENT INFORMATION");
                    writer.WriteLine($"Student Number: {studentNumber}");
                    writer.WriteLine($"Student's Full Name: {txtFullName.Text}");
                    writer.WriteLine($"Year and Program: {txtProgram.Text}");
                    writer.WriteLine("_____________________________________________________");

                    // Write the Enrolled Courses section
                    writer.WriteLine("\t\tENROLLED COURSES");
                    writer.WriteLine(richTextBoxEnrolledCourses.Text);
                    writer.WriteLine("_____________________________________________________");

                    // Write the Total Payments, Fees, and Balances section
                    writer.WriteLine("\tTOTAL PAYMENTS, FEES, AND BALANCES");
                    writer.WriteLine($"Total Fees: {txtTotalFees.Text}");
                    writer.WriteLine($"Total Payments Made: {txtTotalPayments.Text}");
                    writer.WriteLine($"Remaining Balance: {txtTotalBalance.Text}");
                    writer.WriteLine("_____________________________________________________");

                    // Write the Payment Schedule section
                    writer.WriteLine("\t\tPAYMENT SCHEDULE");
                    writer.WriteLine(richTextBoxPaymentSchedule.Text);
                    if (richTextBoxPaymentSchedule.Text.Contains("December 10, 2024 - Php") && !richTextBoxPaymentSchedule.Text.Contains("December 10, 2024 - Php 0"))
                    {
                        // Add a message if the balance for December 10, 2024 is not fully paid
                        writer.WriteLine("\n**You are still not fully enrolled! Please settle your balance for December 10, 2024, before that date to be fully enrolled.**");
                    }
                }

                // Notify user that the file has been created successfully
                MessageBox.Show("RAF file generated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                // Handle any errors that occur during the file creation
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }




        public void ClearForm(Control form)
        {
            foreach (Control control in form.Controls)
            {
                if (control is TextBox textBox)
                {
                    textBox.Clear();
                }
                else if (control is ComboBox comboBox)
                {
                    comboBox.SelectedIndex = -1; 
                }
                else if (control is RichTextBox richTextBox)
                {
                    richTextBox.Clear();
                }
                else if (control is DataGridView dataGridView)
                {
                    dataGridView.DataSource = null;
                    dataGridView.Rows.Clear();
                }
                else if (control.HasChildren)
                {
                    ClearForm(control);
                }
            }
        }

        public void ClearFormCashier(ComboBox cboxStudentNo, ComboBox cboxPaymentAmount, DateTimePicker dtpPaymentDate, DataGridView dataGridViewPaymentHistory, TextBox txtName, TextBox txtYearAndProgram)
        {
            // Clear ComboBox selections and items
            cboxStudentNo.SelectedIndex = -1;
            cboxPaymentAmount.SelectedIndex = -1;
            cboxPaymentAmount.Items.Clear();

            // Reset DateTimePicker to the current date
            dtpPaymentDate.Value = DateTime.Now;

            // Clear DataGridView
            dataGridViewPaymentHistory.DataSource = null;

            // Clear TextBox fields for name and year/program
            txtName.Text = string.Empty;
            txtYearAndProgram.Text = string.Empty;
        }

        public void ClearFormRegistrar(ComboBox cboxRegistrar, TextBox txtFullName, TextBox txtProgram,
                      TextBox txtTotalPayments, TextBox txtTotalFees, TextBox txtTotalBalance,
                      RichTextBox richTextBoxEnrolledCourses, RichTextBox richTextBoxPaymentSchedule)
        {
            // Clear the ComboBox
            cboxRegistrar.SelectedIndex = -1;

            // Clear the TextBoxes
            txtFullName.Clear();
            txtProgram.Clear();
            txtTotalPayments.Clear();
            txtTotalFees.Clear();
            txtTotalBalance.Clear();

            // Clear the RichTextBoxes
            richTextBoxEnrolledCourses.Clear();
            richTextBoxPaymentSchedule.Clear();
        }



    }
}
