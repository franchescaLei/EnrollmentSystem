namespace HorizonAcademy
{
    partial class Registrar
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
            this.cboxRegistrar = new System.Windows.Forms.ComboBox();
            this.txtFullName = new System.Windows.Forms.TextBox();
            this.txtProgram = new System.Windows.Forms.TextBox();
            this.txtTotalPayments = new System.Windows.Forms.TextBox();
            this.txtTotalFees = new System.Windows.Forms.TextBox();
            this.txtTotalBalance = new System.Windows.Forms.TextBox();
            this.richTextBoxEnrolledCourses = new System.Windows.Forms.RichTextBox();
            this.richTextBoxPaymentSchedule = new System.Windows.Forms.RichTextBox();
            this.btnClearForm = new System.Windows.Forms.Button();
            this.btnGenerateRAF = new System.Windows.Forms.Button();
            this.btnRefreshList = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // cboxRegistrar
            // 
            this.cboxRegistrar.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.cboxRegistrar.FormattingEnabled = true;
            this.cboxRegistrar.Location = new System.Drawing.Point(70, 254);
            this.cboxRegistrar.Name = "cboxRegistrar";
            this.cboxRegistrar.Size = new System.Drawing.Size(213, 39);
            this.cboxRegistrar.TabIndex = 14;
            this.cboxRegistrar.SelectedIndexChanged += new System.EventHandler(this.cboxRegistrar_SelectedIndexChanged);
            // 
            // txtFullName
            // 
            this.txtFullName.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.txtFullName.Location = new System.Drawing.Point(289, 254);
            this.txtFullName.Name = "txtFullName";
            this.txtFullName.ReadOnly = true;
            this.txtFullName.Size = new System.Drawing.Size(472, 38);
            this.txtFullName.TabIndex = 15;
            // 
            // txtProgram
            // 
            this.txtProgram.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.txtProgram.Location = new System.Drawing.Point(767, 254);
            this.txtProgram.Name = "txtProgram";
            this.txtProgram.ReadOnly = true;
            this.txtProgram.Size = new System.Drawing.Size(182, 38);
            this.txtProgram.TabIndex = 16;
            // 
            // txtTotalPayments
            // 
            this.txtTotalPayments.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.txtTotalPayments.Location = new System.Drawing.Point(70, 334);
            this.txtTotalPayments.Name = "txtTotalPayments";
            this.txtTotalPayments.ReadOnly = true;
            this.txtTotalPayments.Size = new System.Drawing.Size(264, 38);
            this.txtTotalPayments.TabIndex = 17;
            // 
            // txtTotalFees
            // 
            this.txtTotalFees.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.txtTotalFees.Location = new System.Drawing.Point(366, 334);
            this.txtTotalFees.Name = "txtTotalFees";
            this.txtTotalFees.ReadOnly = true;
            this.txtTotalFees.Size = new System.Drawing.Size(264, 38);
            this.txtTotalFees.TabIndex = 18;
            // 
            // txtTotalBalance
            // 
            this.txtTotalBalance.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.txtTotalBalance.Location = new System.Drawing.Point(662, 334);
            this.txtTotalBalance.Name = "txtTotalBalance";
            this.txtTotalBalance.ReadOnly = true;
            this.txtTotalBalance.Size = new System.Drawing.Size(264, 38);
            this.txtTotalBalance.TabIndex = 19;
            // 
            // richTextBoxEnrolledCourses
            // 
            this.richTextBoxEnrolledCourses.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.richTextBoxEnrolledCourses.Location = new System.Drawing.Point(70, 436);
            this.richTextBoxEnrolledCourses.Name = "richTextBoxEnrolledCourses";
            this.richTextBoxEnrolledCourses.ReadOnly = true;
            this.richTextBoxEnrolledCourses.Size = new System.Drawing.Size(418, 199);
            this.richTextBoxEnrolledCourses.TabIndex = 21;
            this.richTextBoxEnrolledCourses.Text = "";
            // 
            // richTextBoxPaymentSchedule
            // 
            this.richTextBoxPaymentSchedule.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.richTextBoxPaymentSchedule.Location = new System.Drawing.Point(531, 436);
            this.richTextBoxPaymentSchedule.Name = "richTextBoxPaymentSchedule";
            this.richTextBoxPaymentSchedule.ReadOnly = true;
            this.richTextBoxPaymentSchedule.Size = new System.Drawing.Size(418, 199);
            this.richTextBoxPaymentSchedule.TabIndex = 22;
            this.richTextBoxPaymentSchedule.Text = "";
            // 
            // btnClearForm
            // 
            this.btnClearForm.BackColor = System.Drawing.Color.Brown;
            this.btnClearForm.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnClearForm.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.btnClearForm.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnClearForm.Location = new System.Drawing.Point(70, 645);
            this.btnClearForm.Name = "btnClearForm";
            this.btnClearForm.Size = new System.Drawing.Size(153, 63);
            this.btnClearForm.TabIndex = 23;
            this.btnClearForm.Text = "Clear Form";
            this.btnClearForm.UseVisualStyleBackColor = false;
            this.btnClearForm.Click += new System.EventHandler(this.btnClearForm_Click);
            // 
            // btnGenerateRAF
            // 
            this.btnGenerateRAF.BackColor = System.Drawing.Color.Brown;
            this.btnGenerateRAF.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnGenerateRAF.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.btnGenerateRAF.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnGenerateRAF.Location = new System.Drawing.Point(797, 645);
            this.btnGenerateRAF.Name = "btnGenerateRAF";
            this.btnGenerateRAF.Size = new System.Drawing.Size(153, 63);
            this.btnGenerateRAF.TabIndex = 24;
            this.btnGenerateRAF.Text = "Generate RAF";
            this.btnGenerateRAF.UseVisualStyleBackColor = false;
            this.btnGenerateRAF.Click += new System.EventHandler(this.btnGenerateRAF_Click);
            // 
            // btnRefreshList
            // 
            this.btnRefreshList.BackColor = System.Drawing.Color.Brown;
            this.btnRefreshList.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnRefreshList.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.btnRefreshList.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnRefreshList.Location = new System.Drawing.Point(335, 645);
            this.btnRefreshList.Name = "btnRefreshList";
            this.btnRefreshList.Size = new System.Drawing.Size(153, 63);
            this.btnRefreshList.TabIndex = 25;
            this.btnRefreshList.Text = "Refresh Student List";
            this.btnRefreshList.UseVisualStyleBackColor = false;
            this.btnRefreshList.Click += new System.EventHandler(this.btnRefreshList_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::HorizonAcademy.Properties.Resources._5;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1024, 768);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // Registrar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1024, 768);
            this.Controls.Add(this.btnRefreshList);
            this.Controls.Add(this.btnGenerateRAF);
            this.Controls.Add(this.btnClearForm);
            this.Controls.Add(this.richTextBoxPaymentSchedule);
            this.Controls.Add(this.richTextBoxEnrolledCourses);
            this.Controls.Add(this.txtTotalBalance);
            this.Controls.Add(this.txtTotalFees);
            this.Controls.Add(this.txtTotalPayments);
            this.Controls.Add(this.txtProgram);
            this.Controls.Add(this.txtFullName);
            this.Controls.Add(this.cboxRegistrar);
            this.Controls.Add(this.pictureBox1);
            this.Name = "Registrar";
            this.Text = "Registrar";
            this.Load += new System.EventHandler(this.Registrar_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ComboBox cboxRegistrar;
        private System.Windows.Forms.TextBox txtFullName;
        private System.Windows.Forms.TextBox txtProgram;
        private System.Windows.Forms.TextBox txtTotalPayments;
        private System.Windows.Forms.TextBox txtTotalFees;
        private System.Windows.Forms.TextBox txtTotalBalance;
        private System.Windows.Forms.RichTextBox richTextBoxEnrolledCourses;
        private System.Windows.Forms.RichTextBox richTextBoxPaymentSchedule;
        private System.Windows.Forms.Button btnClearForm;
        private System.Windows.Forms.Button btnGenerateRAF;
        private System.Windows.Forms.Button btnRefreshList;
    }
}