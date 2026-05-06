namespace HorizonAcademy
{
    partial class Cashier
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.cboxStudentNo = new System.Windows.Forms.ComboBox();
            this.dataGridViewPaymentHistory = new System.Windows.Forms.DataGridView();
            this.btnClearForm = new System.Windows.Forms.Button();
            this.btnSubmitPayment = new System.Windows.Forms.Button();
            this.cboxPaymentAmount = new System.Windows.Forms.ComboBox();
            this.dtpPaymentDate = new System.Windows.Forms.DateTimePicker();
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtYearandProgram = new System.Windows.Forms.TextBox();
            this.btnRefreshList = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPaymentHistory)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // cboxStudentNo
            // 
            this.cboxStudentNo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboxStudentNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.cboxStudentNo.FormattingEnabled = true;
            this.cboxStudentNo.Location = new System.Drawing.Point(70, 252);
            this.cboxStudentNo.Name = "cboxStudentNo";
            this.cboxStudentNo.Size = new System.Drawing.Size(234, 39);
            this.cboxStudentNo.TabIndex = 13;
            this.cboxStudentNo.SelectedIndexChanged += new System.EventHandler(this.cboxStudentNo_SelectedIndexChanged);
            // 
            // dataGridViewPaymentHistory
            // 
            this.dataGridViewPaymentHistory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewPaymentHistory.Location = new System.Drawing.Point(70, 388);
            this.dataGridViewPaymentHistory.Name = "dataGridViewPaymentHistory";
            this.dataGridViewPaymentHistory.ReadOnly = true;
            this.dataGridViewPaymentHistory.Size = new System.Drawing.Size(878, 248);
            this.dataGridViewPaymentHistory.TabIndex = 14;
            // 
            // btnClearForm
            // 
            this.btnClearForm.BackColor = System.Drawing.Color.Brown;
            this.btnClearForm.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnClearForm.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.btnClearForm.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnClearForm.Location = new System.Drawing.Point(272, 647);
            this.btnClearForm.Name = "btnClearForm";
            this.btnClearForm.Size = new System.Drawing.Size(153, 63);
            this.btnClearForm.TabIndex = 15;
            this.btnClearForm.Text = "Clear Form";
            this.btnClearForm.UseVisualStyleBackColor = false;
            this.btnClearForm.Click += new System.EventHandler(this.btnClearForm_Click);
            // 
            // btnSubmitPayment
            // 
            this.btnSubmitPayment.BackColor = System.Drawing.Color.Brown;
            this.btnSubmitPayment.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSubmitPayment.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.btnSubmitPayment.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnSubmitPayment.Location = new System.Drawing.Point(598, 647);
            this.btnSubmitPayment.Name = "btnSubmitPayment";
            this.btnSubmitPayment.Size = new System.Drawing.Size(153, 63);
            this.btnSubmitPayment.TabIndex = 16;
            this.btnSubmitPayment.Text = "Submit Payment";
            this.btnSubmitPayment.UseVisualStyleBackColor = false;
            this.btnSubmitPayment.Click += new System.EventHandler(this.btnSubmitPayment_Click);
            // 
            // cboxPaymentAmount
            // 
            this.cboxPaymentAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.cboxPaymentAmount.FormattingEnabled = true;
            this.cboxPaymentAmount.Items.AddRange(new object[] {
            "BS in Information Technology",
            "BS in Computer Engineering",
            "BS in Tourism Management",
            "BS in Accountancy"});
            this.cboxPaymentAmount.Location = new System.Drawing.Point(70, 333);
            this.cboxPaymentAmount.Name = "cboxPaymentAmount";
            this.cboxPaymentAmount.Size = new System.Drawing.Size(234, 39);
            this.cboxPaymentAmount.TabIndex = 17;
            this.cboxPaymentAmount.SelectedIndexChanged += new System.EventHandler(this.cboxPaymentAmount_SelectedIndexChanged);
            // 
            // dtpPaymentDate
            // 
            this.dtpPaymentDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.dtpPaymentDate.Location = new System.Drawing.Point(310, 333);
            this.dtpPaymentDate.Name = "dtpPaymentDate";
            this.dtpPaymentDate.Size = new System.Drawing.Size(433, 38);
            this.dtpPaymentDate.TabIndex = 19;
            // 
            // txtName
            // 
            this.txtName.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.txtName.Location = new System.Drawing.Point(310, 252);
            this.txtName.Name = "txtName";
            this.txtName.ReadOnly = true;
            this.txtName.Size = new System.Drawing.Size(433, 38);
            this.txtName.TabIndex = 20;
            // 
            // txtYearandProgram
            // 
            this.txtYearandProgram.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.txtYearandProgram.Location = new System.Drawing.Point(749, 252);
            this.txtYearandProgram.Name = "txtYearandProgram";
            this.txtYearandProgram.ReadOnly = true;
            this.txtYearandProgram.Size = new System.Drawing.Size(199, 38);
            this.txtYearandProgram.TabIndex = 21;
            // 
            // btnRefreshList
            // 
            this.btnRefreshList.BackColor = System.Drawing.Color.Brown;
            this.btnRefreshList.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnRefreshList.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.btnRefreshList.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnRefreshList.Location = new System.Drawing.Point(70, 647);
            this.btnRefreshList.Name = "btnRefreshList";
            this.btnRefreshList.Size = new System.Drawing.Size(153, 63);
            this.btnRefreshList.TabIndex = 22;
            this.btnRefreshList.Text = "Refresh Student List";
            this.btnRefreshList.UseVisualStyleBackColor = false;
            this.btnRefreshList.Click += new System.EventHandler(this.btnRefreshList_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::HorizonAcademy.Properties.Resources.Copy_of_Student_Registration;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1024, 768);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // Cashier
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1024, 768);
            this.Controls.Add(this.btnRefreshList);
            this.Controls.Add(this.txtYearandProgram);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.dtpPaymentDate);
            this.Controls.Add(this.cboxPaymentAmount);
            this.Controls.Add(this.btnSubmitPayment);
            this.Controls.Add(this.btnClearForm);
            this.Controls.Add(this.dataGridViewPaymentHistory);
            this.Controls.Add(this.cboxStudentNo);
            this.Controls.Add(this.pictureBox1);
            this.Name = "Cashier";
            this.Text = "Cashier";
            this.Load += new System.EventHandler(this.Cashier_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPaymentHistory)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ComboBox cboxStudentNo;
        private System.Windows.Forms.DataGridView dataGridViewPaymentHistory;
        private System.Windows.Forms.Button btnClearForm;
        private System.Windows.Forms.Button btnSubmitPayment;
        private System.Windows.Forms.ComboBox cboxPaymentAmount;
        private System.Windows.Forms.DateTimePicker dtpPaymentDate;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtYearandProgram;
        private System.Windows.Forms.Button btnRefreshList;
    }
}