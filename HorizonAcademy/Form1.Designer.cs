namespace HorizonAcademy
{
    partial class frmStudentRegistration
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
            this.txtLastName = new System.Windows.Forms.TextBox();
            this.txtFirstName = new System.Windows.Forms.TextBox();
            this.txtMiddleName = new System.Windows.Forms.TextBox();
            this.txtContactNo = new System.Windows.Forms.TextBox();
            this.txtEmailAddress = new System.Windows.Forms.TextBox();
            this.txtGuardianName = new System.Windows.Forms.TextBox();
            this.txtGuardianContactNo = new System.Windows.Forms.TextBox();
            this.txtGuardianEmail = new System.Windows.Forms.TextBox();
            this.btnRegister = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.cboxProgram = new System.Windows.Forms.ComboBox();
            this.cboxGender = new System.Windows.Forms.ComboBox();
            this.cboxPaymentTerm = new System.Windows.Forms.ComboBox();
            this.cboxYearLevel = new System.Windows.Forms.ComboBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // txtLastName
            // 
            this.txtLastName.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.txtLastName.Location = new System.Drawing.Point(70, 250);
            this.txtLastName.Name = "txtLastName";
            this.txtLastName.Size = new System.Drawing.Size(264, 38);
            this.txtLastName.TabIndex = 1;
            // 
            // txtFirstName
            // 
            this.txtFirstName.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.txtFirstName.Location = new System.Drawing.Point(344, 250);
            this.txtFirstName.Name = "txtFirstName";
            this.txtFirstName.Size = new System.Drawing.Size(264, 38);
            this.txtFirstName.TabIndex = 2;
            // 
            // txtMiddleName
            // 
            this.txtMiddleName.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.txtMiddleName.Location = new System.Drawing.Point(620, 250);
            this.txtMiddleName.Name = "txtMiddleName";
            this.txtMiddleName.Size = new System.Drawing.Size(264, 38);
            this.txtMiddleName.TabIndex = 3;
            // 
            // txtContactNo
            // 
            this.txtContactNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.txtContactNo.Location = new System.Drawing.Point(344, 328);
            this.txtContactNo.Name = "txtContactNo";
            this.txtContactNo.Size = new System.Drawing.Size(264, 38);
            this.txtContactNo.TabIndex = 4;
            // 
            // txtEmailAddress
            // 
            this.txtEmailAddress.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.txtEmailAddress.Location = new System.Drawing.Point(620, 328);
            this.txtEmailAddress.Name = "txtEmailAddress";
            this.txtEmailAddress.Size = new System.Drawing.Size(327, 38);
            this.txtEmailAddress.TabIndex = 5;
            // 
            // txtGuardianName
            // 
            this.txtGuardianName.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.txtGuardianName.Location = new System.Drawing.Point(70, 460);
            this.txtGuardianName.Name = "txtGuardianName";
            this.txtGuardianName.Size = new System.Drawing.Size(264, 38);
            this.txtGuardianName.TabIndex = 6;
            // 
            // txtGuardianContactNo
            // 
            this.txtGuardianContactNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.txtGuardianContactNo.Location = new System.Drawing.Point(345, 461);
            this.txtGuardianContactNo.Name = "txtGuardianContactNo";
            this.txtGuardianContactNo.Size = new System.Drawing.Size(264, 38);
            this.txtGuardianContactNo.TabIndex = 7;
            // 
            // txtGuardianEmail
            // 
            this.txtGuardianEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.txtGuardianEmail.Location = new System.Drawing.Point(620, 461);
            this.txtGuardianEmail.Name = "txtGuardianEmail";
            this.txtGuardianEmail.Size = new System.Drawing.Size(327, 38);
            this.txtGuardianEmail.TabIndex = 8;
            // 
            // btnRegister
            // 
            this.btnRegister.BackColor = System.Drawing.Color.Brown;
            this.btnRegister.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnRegister.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.btnRegister.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnRegister.Location = new System.Drawing.Point(328, 655);
            this.btnRegister.Name = "btnRegister";
            this.btnRegister.Size = new System.Drawing.Size(135, 52);
            this.btnRegister.TabIndex = 10;
            this.btnRegister.Text = "Register";
            this.btnRegister.UseVisualStyleBackColor = false;
            this.btnRegister.Click += new System.EventHandler(this.btnRegister_Click);
            // 
            // btnClear
            // 
            this.btnClear.BackColor = System.Drawing.Color.Brown;
            this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnClear.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.btnClear.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnClear.Location = new System.Drawing.Point(566, 655);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(135, 52);
            this.btnClear.TabIndex = 11;
            this.btnClear.Text = "Clear Form";
            this.btnClear.UseVisualStyleBackColor = false;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // cboxProgram
            // 
            this.cboxProgram.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.cboxProgram.FormattingEnabled = true;
            this.cboxProgram.Items.AddRange(new object[] {
            "BSIT",
            "BSTM",
            "BSCpE",
            "BSA"});
            this.cboxProgram.Location = new System.Drawing.Point(70, 600);
            this.cboxProgram.Name = "cboxProgram";
            this.cboxProgram.Size = new System.Drawing.Size(264, 39);
            this.cboxProgram.TabIndex = 12;
            // 
            // cboxGender
            // 
            this.cboxGender.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.cboxGender.FormattingEnabled = true;
            this.cboxGender.Items.AddRange(new object[] {
            "Male",
            "Female"});
            this.cboxGender.Location = new System.Drawing.Point(70, 327);
            this.cboxGender.Name = "cboxGender";
            this.cboxGender.Size = new System.Drawing.Size(264, 39);
            this.cboxGender.TabIndex = 13;
            // 
            // cboxPaymentTerm
            // 
            this.cboxPaymentTerm.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.cboxPaymentTerm.FormattingEnabled = true;
            this.cboxPaymentTerm.Items.AddRange(new object[] {
            "DP + Monthly Installment",
            "Full payment"});
            this.cboxPaymentTerm.Location = new System.Drawing.Point(620, 599);
            this.cboxPaymentTerm.Name = "cboxPaymentTerm";
            this.cboxPaymentTerm.Size = new System.Drawing.Size(264, 39);
            this.cboxPaymentTerm.TabIndex = 14;
            // 
            // cboxYearLevel
            // 
            this.cboxYearLevel.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.cboxYearLevel.FormattingEnabled = true;
            this.cboxYearLevel.Items.AddRange(new object[] {
            "First Year",
            "Second Year",
            "Third Year",
            "Fourth Year"});
            this.cboxYearLevel.Location = new System.Drawing.Point(345, 599);
            this.cboxYearLevel.Name = "cboxYearLevel";
            this.cboxYearLevel.Size = new System.Drawing.Size(264, 39);
            this.cboxYearLevel.TabIndex = 15;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::HorizonAcademy.Properties.Resources._2;
            this.pictureBox1.Location = new System.Drawing.Point(0, -2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1024, 768);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // frmStudentRegistration
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1023, 765);
            this.Controls.Add(this.cboxYearLevel);
            this.Controls.Add(this.cboxPaymentTerm);
            this.Controls.Add(this.cboxGender);
            this.Controls.Add(this.cboxProgram);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnRegister);
            this.Controls.Add(this.txtGuardianEmail);
            this.Controls.Add(this.txtGuardianContactNo);
            this.Controls.Add(this.txtGuardianName);
            this.Controls.Add(this.txtEmailAddress);
            this.Controls.Add(this.txtContactNo);
            this.Controls.Add(this.txtMiddleName);
            this.Controls.Add(this.txtFirstName);
            this.Controls.Add(this.txtLastName);
            this.Controls.Add(this.pictureBox1);
            this.Name = "frmStudentRegistration";
            this.Text = "Student Registration";
            this.Load += new System.EventHandler(this.frmStudentRegistration_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox txtLastName;
        private System.Windows.Forms.TextBox txtFirstName;
        private System.Windows.Forms.TextBox txtMiddleName;
        private System.Windows.Forms.TextBox txtContactNo;
        private System.Windows.Forms.TextBox txtEmailAddress;
        private System.Windows.Forms.TextBox txtGuardianName;
        private System.Windows.Forms.TextBox txtGuardianContactNo;
        private System.Windows.Forms.TextBox txtGuardianEmail;
        private System.Windows.Forms.Button btnRegister;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.ComboBox cboxProgram;
        private System.Windows.Forms.ComboBox cboxGender;
        private System.Windows.Forms.ComboBox cboxPaymentTerm;
        private System.Windows.Forms.ComboBox cboxYearLevel;
    }
}

