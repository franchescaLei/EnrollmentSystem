using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HorizonAcademy
{
    public partial class frmStudentRegistration : Form
    {
        Methods methods = new Methods();
        public frmStudentRegistration()
        {
            InitializeComponent();
            btnRegister.BackColor = ColorTranslator.FromHtml("#285430");
            btnClear.BackColor = ColorTranslator.FromHtml("#285430");
        }

        private void frmStudentRegistration_Load(object sender, EventArgs e)
        {

        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            try
            {
                long studentNumber = methods.GetNextStudentNumber();

                // Collect input data
                string lastName = txtLastName.Text;
                string firstName = txtFirstName.Text;
                string middleName = txtMiddleName.Text;
                string gender = cboxGender.SelectedItem?.ToString() ?? string.Empty; // Use null-coalescing operator
                string contactNo = txtContactNo.Text;
                string email = txtEmailAddress.Text;
                string guardianName = txtGuardianName.Text;
                string guardianContactNo = txtGuardianContactNo.Text;
                string guardianEmail = txtGuardianEmail.Text;
                string program = cboxProgram.SelectedItem?.ToString() ?? string.Empty;
                string yearLevel = cboxYearLevel.SelectedItem?.ToString() ?? string.Empty;
                string paymentTerm = cboxPaymentTerm.SelectedItem?.ToString() ?? string.Empty;

                // Validate mandatory fields
                if (string.IsNullOrWhiteSpace(lastName) || string.IsNullOrWhiteSpace(firstName) ||
                    string.IsNullOrWhiteSpace(gender) || string.IsNullOrWhiteSpace(program) ||
                    string.IsNullOrWhiteSpace(yearLevel) || string.IsNullOrWhiteSpace(paymentTerm))
                {
                    MessageBox.Show("Please complete all required fields.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Enroll the student
                methods.EnrollStudent(studentNumber, lastName, firstName, middleName, gender, contactNo, email, guardianName, guardianContactNo, guardianEmail, program, yearLevel, paymentTerm);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            methods.ClearForm(this);
            MessageBox.Show("Student Registration form has been cleared!");
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
