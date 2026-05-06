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

namespace HorizonAcademy
{
    public partial class Cashier : Form
    {

        private Methods methods;
        public Cashier()
        {
            InitializeComponent();
            Methods methods = new Methods();
            methods.LoadStudentNumbers(cboxStudentNo);
            btnClearForm.BackColor = ColorTranslator.FromHtml("#285430");
            btnSubmitPayment.BackColor = ColorTranslator.FromHtml("#285430");
            btnRefreshList.BackColor = ColorTranslator.FromHtml("#285430");
            cboxPaymentAmount.Items.Clear();
        }

        private void Cashier_Load(object sender, EventArgs e)
        {

        }

        private void cboxStudentNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            cboxPaymentAmount.SelectedIndex = -1;
            Methods methods = new Methods();
            if (cboxStudentNo.SelectedIndex != -1)
            {
                string studentNo = cboxStudentNo.SelectedItem.ToString();
                methods.UpdatePaymentAmountAndHistory(cboxPaymentAmount, dataGridViewPaymentHistory, studentNo, txtName, txtYearandProgram);
            }
            
        }

        private void btnClearForm_Click(object sender, EventArgs e)
        {
            Methods methods = new Methods();
            methods.ClearFormCashier(cboxStudentNo, cboxPaymentAmount, dtpPaymentDate, dataGridViewPaymentHistory, txtName, txtYearandProgram);
        }

        private void btnSubmitPayment_Click(object sender, EventArgs e)
        {
            Methods methods = new Methods();
            if (cboxStudentNo.SelectedIndex != -1 && cboxPaymentAmount.SelectedIndex != -1)
            {
                string studentNo = cboxStudentNo.SelectedItem.ToString();
                decimal paymentAmount = Convert.ToDecimal(cboxPaymentAmount.SelectedItem.ToString());
                DateTime paymentDate = dtpPaymentDate.Value;

                methods.SubmitPayment(studentNo, paymentAmount, paymentDate);

                // Update the payment history
                methods.UpdatePaymentAmountAndHistory(cboxPaymentAmount, dataGridViewPaymentHistory, studentNo,txtName,txtYearandProgram);

            }
            else
            {
                MessageBox.Show("Please input the necessary details");
            }
           
        }

        private void cboxPaymentAmount_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void btnRefreshList_Click(object sender, EventArgs e)
        {
            Methods methods = new Methods();
            methods.LoadStudentNumbers(cboxStudentNo);
        }
    }
}
