using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HorizonAcademy
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Create instances of your forms
            frmStudentRegistration studentRegistrationForm = new frmStudentRegistration();  // Main form
            Cashier cashierForm = new Cashier();  // Cashier form
            Registrar registrarForm = new Registrar();  // Registrar form

            // Show the forms
            studentRegistrationForm.Show();  // Show the StudentRegistration form
            cashierForm.Show();  // Show the Cashier form
            registrarForm.Show();  // Show the Registrar form

            // Run the application (starts the message loop for all forms)
            Application.Run(studentRegistrationForm);
        }
    }
}
