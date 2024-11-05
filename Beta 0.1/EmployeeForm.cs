using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Project_KTMH
{
    public partial class EmployeeForm : Form
    {
        private EmployeeList employeeList;

        private TextBox txtName;
        private TextBox txtAddress;
        private TextBox txtEmail;
        private DateTimePicker dtpDOB;
        private TextBox txtPhone;
        private TextBox txtEmployeeID;
        private TextBox txtRoleID;
        private TextBox txtDepartmentID;
        private TextBox txtRoleName;

        public EmployeeForm(EmployeeList employeeList)
        {
            InitializeComponent();
            this.employeeList = employeeList;
        }

        private void InitializeComponent()
        {
            this.lblName = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.lblAddress = new System.Windows.Forms.Label();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.lblEmail = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.lblDOB = new System.Windows.Forms.Label();
            this.dtpDOB = new System.Windows.Forms.DateTimePicker();
            this.lblPhone = new System.Windows.Forms.Label();
            this.txtPhone = new System.Windows.Forms.TextBox();
            this.lblEmployeeID = new System.Windows.Forms.Label();
            this.txtEmployeeID = new System.Windows.Forms.TextBox();
            this.lblRoleID = new System.Windows.Forms.Label();
            this.txtRoleID = new System.Windows.Forms.TextBox();
            this.lblDepartmentID = new System.Windows.Forms.Label();
            this.txtDepartmentID = new System.Windows.Forms.TextBox();
            this.lblRoleName = new System.Windows.Forms.Label();
            this.txtRoleName = new System.Windows.Forms.TextBox();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblName
            // 
            this.lblName.Location = new System.Drawing.Point(40, 66);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(100, 23);
            this.lblName.TabIndex = 0;
            this.lblName.Text = "Họ và tên:";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(198, 67);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(238, 22);
            this.txtName.TabIndex = 1;
            this.txtName.Text = "name";
            // 
            // lblAddress
            // 
            this.lblAddress.Location = new System.Drawing.Point(40, 104);
            this.lblAddress.Name = "lblAddress";
            this.lblAddress.Size = new System.Drawing.Size(100, 23);
            this.lblAddress.TabIndex = 2;
            this.lblAddress.Text = "Địa chỉ:";
            // 
            // txtAddress
            // 
            this.txtAddress.Location = new System.Drawing.Point(198, 105);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(238, 22);
            this.txtAddress.TabIndex = 3;
            this.txtAddress.Text = "address";
            // 
            // lblEmail
            // 
            this.lblEmail.Location = new System.Drawing.Point(40, 192);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(100, 23);
            this.lblEmail.TabIndex = 4;
            this.lblEmail.Text = "Email:";
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(198, 189);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(238, 22);
            this.txtEmail.TabIndex = 5;
            // 
            // lblDOB
            // 
            this.lblDOB.Location = new System.Drawing.Point(40, 30);
            this.lblDOB.Name = "lblDOB";
            this.lblDOB.Size = new System.Drawing.Size(138, 23);
            this.lblDOB.TabIndex = 6;
            this.lblDOB.Text = "Sinh nhật:";
            // 
            // dtpDOB
            // 
            this.dtpDOB.Location = new System.Drawing.Point(198, 31);
            this.dtpDOB.Name = "dtpDOB";
            this.dtpDOB.Size = new System.Drawing.Size(238, 22);
            this.dtpDOB.TabIndex = 7;
            // 
            // lblPhone
            // 
            this.lblPhone.Location = new System.Drawing.Point(40, 148);
            this.lblPhone.Name = "lblPhone";
            this.lblPhone.Size = new System.Drawing.Size(100, 23);
            this.lblPhone.TabIndex = 8;
            this.lblPhone.Text = "Số điện thoại:";
            // 
            // txtPhone
            // 
            this.txtPhone.Location = new System.Drawing.Point(198, 145);
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.Size = new System.Drawing.Size(238, 22);
            this.txtPhone.TabIndex = 9;
            this.txtPhone.Text = "phone";
            // 
            // lblEmployeeID
            // 
            this.lblEmployeeID.Location = new System.Drawing.Point(40, 233);
            this.lblEmployeeID.Name = "lblEmployeeID";
            this.lblEmployeeID.Size = new System.Drawing.Size(100, 23);
            this.lblEmployeeID.TabIndex = 10;
            this.lblEmployeeID.Text = "Mã Nhân viên:";
            // 
            // txtEmployeeID
            // 
            this.txtEmployeeID.Location = new System.Drawing.Point(198, 230);
            this.txtEmployeeID.Name = "txtEmployeeID";
            this.txtEmployeeID.Size = new System.Drawing.Size(238, 22);
            this.txtEmployeeID.TabIndex = 11;
            this.txtEmployeeID.Text = "eid";
            // 
            // lblRoleID
            // 
            this.lblRoleID.Location = new System.Drawing.Point(40, 350);
            this.lblRoleID.Name = "lblRoleID";
            this.lblRoleID.Size = new System.Drawing.Size(100, 23);
            this.lblRoleID.TabIndex = 12;
            this.lblRoleID.Text = "Mã Chức vụ:";
            // 
            // txtRoleID
            // 
            this.txtRoleID.Location = new System.Drawing.Point(198, 351);
            this.txtRoleID.Name = "txtRoleID";
            this.txtRoleID.Size = new System.Drawing.Size(238, 22);
            this.txtRoleID.TabIndex = 13;
            this.txtRoleID.Text = "rid";
            // 
            // lblDepartmentID
            // 
            this.lblDepartmentID.Location = new System.Drawing.Point(40, 272);
            this.lblDepartmentID.Name = "lblDepartmentID";
            this.lblDepartmentID.Size = new System.Drawing.Size(100, 23);
            this.lblDepartmentID.TabIndex = 14;
            this.lblDepartmentID.Text = "Mã Phòng ban:";
            // 
            // txtDepartmentID
            // 
            this.txtDepartmentID.Location = new System.Drawing.Point(198, 269);
            this.txtDepartmentID.Name = "txtDepartmentID";
            this.txtDepartmentID.Size = new System.Drawing.Size(238, 22);
            this.txtDepartmentID.TabIndex = 15;
            this.txtDepartmentID.Text = "Mã Phòng ban";
            // 
            // lblRoleName
            // 
            this.lblRoleName.Location = new System.Drawing.Point(40, 312);
            this.lblRoleName.Name = "lblRoleName";
            this.lblRoleName.Size = new System.Drawing.Size(100, 23);
            this.lblRoleName.TabIndex = 0;
            this.lblRoleName.Text = "Chức vụ:";
            // 
            // txtRoleName
            // 
            this.txtRoleName.Location = new System.Drawing.Point(198, 312);
            this.txtRoleName.Name = "txtRoleName";
            this.txtRoleName.Size = new System.Drawing.Size(238, 22);
            this.txtRoleName.TabIndex = 0;
            this.txtRoleName.Text = "chức vụ";
            // 
            // btnSubmit
            // 
            this.btnSubmit.Location = new System.Drawing.Point(43, 391);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(109, 38);
            this.btnSubmit.TabIndex = 16;
            this.btnSubmit.Text = "ADD";
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // EmployeeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(488, 450);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.lblAddress);
            this.Controls.Add(this.txtAddress);
            this.Controls.Add(this.lblEmail);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.lblDOB);
            this.Controls.Add(this.dtpDOB);
            this.Controls.Add(this.lblPhone);
            this.Controls.Add(this.txtPhone);
            this.Controls.Add(this.lblEmployeeID);
            this.Controls.Add(this.txtEmployeeID);
            this.Controls.Add(this.lblRoleID);
            this.Controls.Add(this.txtRoleID);
            this.Controls.Add(this.lblRoleName);
            this.Controls.Add(this.txtRoleName);
            this.Controls.Add(this.lblDepartmentID);
            this.Controls.Add(this.txtDepartmentID);
            this.Controls.Add(this.btnSubmit);
            this.Name = "EmployeeForm";
            this.Text = "EmployeeForm";
            this.Load += new System.EventHandler(this.EmployeeForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            Payroll payroll = new Payroll(txtEmployeeID.Text, txtDepartmentID.Text, txtEmployeeID.Text, txtName.Text, 1, 1, 1, 1, 0);
            AddEmployee(txtName.Text,
                txtAddress.Text,
                txtEmail.Text,
                dtpDOB.Value,
                txtPhone.Text,
                txtEmployeeID.Text,
                txtRoleID.Text,
                txtDepartmentID.Text,
                txtRoleName.Text,
                payroll
                );
        }

        private void AddEmployee(string name, string address, string email, DateTime dob, string phone, string employeeID, string roleID, string departmentID, string roleName, Payroll payroll)
        {
            // Create a new Employee and add it to the list
            Employee newEmployee = new Employee(name, email, dob, phone, address, employeeID, roleID, departmentID, roleName);
            employeeList.AddEmployee(newEmployee, payroll);

            MessageBox.Show("Employee added successfully!");

            // Optionally clear the form inputs
            ClearForm();
        }

        private void UpdateEmployee(string employeeID, string name, string address, string email, DateTime dateofbirth, string phone, string roleID, string departmentID, string roleName)
        {
            foreach ((Employee, Payroll) e in EmployeeList.emp)
                if (e.Item1.EmployeeID1 == employeeID)
                {
                    e.Item1.UpdateEmployee(name, email, dateofbirth, phone, address, roleID, departmentID, roleName);
                    MessageBox.Show("Employee updated successfully!");
                }
                else
                {
                    MessageBox.Show("Employee not found.");
                }


            ClearForm();
        }

        private void RemoveEmployee(string employeeID)
        {
            bool removed = employeeList.RemoveEmployee(employeeID); // Adjust this method in EmployeeList class

            if (removed)
            {
                MessageBox.Show("Employee removed successfully!");
            }
            else
            {
                MessageBox.Show("Employee not found.");
            }

            ClearForm();
        }

        private void ClearForm()
        {
            foreach (Control control in this.Controls)
            {
                if (control is TextBox)
                    control.Text = "";
            }
        }

        private void EmployeeForm_Load(object sender, EventArgs e)
        {

        }

        private void EmployeeForm_Load_1(object sender, EventArgs e)
        {

        }
    }
}