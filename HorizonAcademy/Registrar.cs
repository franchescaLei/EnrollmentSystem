using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace HorizonAcademy
{
    public partial class Registrar : Form
    {
 
        public Registrar()
        {
            InitializeComponent();
            btnClearForm.BackColor = ColorTranslator.FromHtml("#285430");
            btnGenerateRAF.BackColor = ColorTranslator.FromHtml("#285430");
            btnRefreshList.BackColor = ColorTranslator.FromHtml("#285430");
            Methods methods = new Methods();
            methods.LoadStudentNumbers(cboxRegistrar);
        }

        private void Registrar_Load(object sender, EventArgs e)
        {

        }
        private void cboxRegistrar_SelectedIndexChanged(object sender, EventArgs e)
        {
            Methods methods = new Methods();
            if (cboxRegistrar.SelectedItem != null)
            {
                // Get the selected student number from the ComboBox (assuming it stores the studentNo)
                string studentNo = cboxRegistrar.SelectedItem.ToString();

                // Call FetchStudentInfo method with the selected studentNo and the textboxes to populate
                methods.FetchStudentInfo(studentNo, txtFullName, txtProgram, txtTotalPayments, txtTotalFees, txtTotalBalance);
                methods.FetchEnrolledCourses(studentNo, richTextBoxEnrolledCourses);
                methods.GeneratePaymentSchedule(studentNo, richTextBoxPaymentSchedule);
            }
        }

        private void btnRefreshList_Click(object sender, EventArgs e)
        {
            Methods methods = new Methods();
            methods.LoadStudentNumbers(cboxRegistrar);
        }

        private void btnClearForm_Click(object sender, EventArgs e)
        {
            Methods methodObj = new Methods();
            methodObj.ClearFormRegistrar(cboxRegistrar, txtFullName, txtProgram,
                        txtTotalPayments, txtTotalFees, txtTotalBalance,
                        richTextBoxEnrolledCourses, richTextBoxPaymentSchedule);
        }

        private void btnGenerateRAF_Click(object sender, EventArgs e)
        {
            Methods methodObj = new Methods();

            // Call GenerateRAFFile method and pass the necessary controls
            methodObj.GenerateRAFFile(cboxRegistrar, txtFullName, txtProgram,
                                       txtTotalFees, txtTotalPayments, txtTotalBalance,
                                       richTextBoxEnrolledCourses, richTextBoxPaymentSchedule);
        }
    }
}
