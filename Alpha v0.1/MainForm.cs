using System;
using System.IO;
using System.Text.Json;
using System.Windows.Forms;

namespace Project_KTMH
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            this.txtName.Text = "name";
            this.txtName.ReadOnly = true;
            this.txtEmail.Text = "email";
            this.txtEmail.ReadOnly = true;
            this.txtPhone.Text = "phonenumber";
            this.txtPhone.ReadOnly = true;
            this.txtEmployeeID.Text = "eID";
            this.txtEmployeeID.ReadOnly = true;
            this.txtRoleID.Text = "rID";
            this.txtRoleID.ReadOnly = true;
            this.txtDepartmentID.Text = "dID";
            this.txtDepartmentID.ReadOnly = true;
            this.txtRoleName.Text = "role";
            this.txtRoleName.ReadOnly = true;
        }

        private string employeeFilePath = "employee.json";

        public Employee LoadEmployeeFromFile(string filePath)
        {
            if (!File.Exists(filePath))
                return null;

            string json = File.ReadAllText(filePath);
            return JsonSerializer.Deserialize<Employee>(json);
        }

        public MainForm(Employee employee)
        {
            InitializeComponent();
            this.txtName.Text = employee.Name;
            this.txtName.ReadOnly = true;
            this.txtEmail.Text = employee.Email;
            this.txtEmail.ReadOnly = true;
            this.txtPhone.Text = employee.Phone_num;
            this.txtPhone.ReadOnly = true;
            this.txtEmployeeID.Text = employee.EmployeeID1;
            this.txtEmployeeID.ReadOnly = true;
            this.txtRoleID.Text = employee.RoleID1;
            this.txtRoleID.ReadOnly = true;
            this.txtDepartmentID.Text = employee.DepartmentID1;
            this.txtDepartmentID.ReadOnly = true;
            this.txtRoleName.Text = employee.RoleName;
            this.txtRoleName.ReadOnly = true;
        }

        private void InitializeComponent()
        {
            this.avatar = new System.Windows.Forms.PictureBox();
            this.lblName = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.lblEmail = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
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
            this.btnEditInfo = new System.Windows.Forms.Button();
            this.btnAttendance = new System.Windows.Forms.Button();
            this.btnCheckPayroll = new System.Windows.Forms.Button();
            this.btnLogout = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.avatar)).BeginInit();
            this.SuspendLayout();
            // 
            // avatar
            // 
            this.avatar.Location = new System.Drawing.Point(28, 27);
            this.avatar.Name = "avatar";
            this.avatar.Size = new System.Drawing.Size(142, 167);
            this.avatar.TabIndex = 16;
            this.avatar.TabStop = false;
            // 
            // lblName
            // 
            this.lblName.Location = new System.Drawing.Point(240, 31);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(100, 23);
            this.lblName.TabIndex = 0;
            this.lblName.Text = "Họ và tên:";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(398, 28);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(238, 22);
            this.txtName.TabIndex = 1;
            // 
            // lblEmail
            // 
            this.lblEmail.Location = new System.Drawing.Point(240, 116);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(100, 23);
            this.lblEmail.TabIndex = 4;
            this.lblEmail.Text = "Email:";
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(398, 113);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(238, 22);
            this.txtEmail.TabIndex = 5;
            // 
            // lblPhone
            // 
            this.lblPhone.Location = new System.Drawing.Point(240, 72);
            this.lblPhone.Name = "lblPhone";
            this.lblPhone.Size = new System.Drawing.Size(100, 23);
            this.lblPhone.TabIndex = 8;
            this.lblPhone.Text = "Số điện thoại:";
            // 
            // txtPhone
            // 
            this.txtPhone.Location = new System.Drawing.Point(398, 69);
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.Size = new System.Drawing.Size(238, 22);
            this.txtPhone.TabIndex = 9;
            // 
            // lblEmployeeID
            // 
            this.lblEmployeeID.Location = new System.Drawing.Point(240, 157);
            this.lblEmployeeID.Name = "lblEmployeeID";
            this.lblEmployeeID.Size = new System.Drawing.Size(100, 23);
            this.lblEmployeeID.TabIndex = 10;
            this.lblEmployeeID.Text = "Mã Nhân viên:";
            // 
            // txtEmployeeID
            // 
            this.txtEmployeeID.Location = new System.Drawing.Point(398, 154);
            this.txtEmployeeID.Name = "txtEmployeeID";
            this.txtEmployeeID.Size = new System.Drawing.Size(238, 22);
            this.txtEmployeeID.TabIndex = 11;
            // 
            // lblRoleID
            // 
            this.lblRoleID.Location = new System.Drawing.Point(240, 279);
            this.lblRoleID.Name = "lblRoleID";
            this.lblRoleID.Size = new System.Drawing.Size(100, 23);
            this.lblRoleID.TabIndex = 12;
            this.lblRoleID.Text = "Mã Chức vụ:";
            // 
            // txtRoleID
            // 
            this.txtRoleID.Location = new System.Drawing.Point(398, 280);
            this.txtRoleID.Name = "txtRoleID";
            this.txtRoleID.Size = new System.Drawing.Size(238, 22);
            this.txtRoleID.TabIndex = 13;
            // 
            // lblDepartmentID
            // 
            this.lblDepartmentID.Location = new System.Drawing.Point(240, 196);
            this.lblDepartmentID.Name = "lblDepartmentID";
            this.lblDepartmentID.Size = new System.Drawing.Size(100, 23);
            this.lblDepartmentID.TabIndex = 14;
            this.lblDepartmentID.Text = "Mã Phòng ban:";
            // 
            // txtDepartmentID
            // 
            this.txtDepartmentID.Location = new System.Drawing.Point(398, 193);
            this.txtDepartmentID.Name = "txtDepartmentID";
            this.txtDepartmentID.Size = new System.Drawing.Size(238, 22);
            this.txtDepartmentID.TabIndex = 15;
            // 
            // lblRoleName
            // 
            this.lblRoleName.Location = new System.Drawing.Point(240, 237);
            this.lblRoleName.Name = "lblRoleName";
            this.lblRoleName.Size = new System.Drawing.Size(100, 23);
            this.lblRoleName.TabIndex = 0;
            this.lblRoleName.Text = "Chức vụ:";
            // 
            // txtRoleName
            // 
            this.txtRoleName.Location = new System.Drawing.Point(398, 237);
            this.txtRoleName.Name = "txtRoleName";
            this.txtRoleName.Size = new System.Drawing.Size(238, 22);
            this.txtRoleName.TabIndex = 0;
            // 
            // btnEditInfo
            // 
            this.btnEditInfo.Location = new System.Drawing.Point(28, 238);
            this.btnEditInfo.Name = "btnEditInfo";
            this.btnEditInfo.Size = new System.Drawing.Size(142, 64);
            this.btnEditInfo.TabIndex = 17;
            this.btnEditInfo.Text = "Sửa thông tin";
            this.btnEditInfo.UseVisualStyleBackColor = true;
            this.btnEditInfo.Click += new System.EventHandler(this.btn_EditInfo_Click);
            // 
            // btnAttendance
            // 
            this.btnAttendance.Location = new System.Drawing.Point(28, 342);
            this.btnAttendance.Name = "btnAttendance";
            this.btnAttendance.Size = new System.Drawing.Size(142, 63);
            this.btnAttendance.TabIndex = 18;
            this.btnAttendance.Text = "Chấm công";
            this.btnAttendance.UseVisualStyleBackColor = true;
            this.btnAttendance.Click += new System.EventHandler(this.btn_Attendance_Click);
            // 
            // btnCheckPayroll
            // 
            this.btnCheckPayroll.Location = new System.Drawing.Point(259, 341);
            this.btnCheckPayroll.Name = "btnCheckPayroll";
            this.btnCheckPayroll.Size = new System.Drawing.Size(151, 63);
            this.btnCheckPayroll.TabIndex = 19;
            this.btnCheckPayroll.Text = "Xem lương";
            this.btnCheckPayroll.UseVisualStyleBackColor = true;
            this.btnCheckPayroll.Click += new System.EventHandler(this.btn_CheckPayroll_Click);
            // 
            // btnLogout
            // 
            this.btnLogout.Location = new System.Drawing.Point(490, 342);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(146, 62);
            this.btnLogout.TabIndex = 20;
            this.btnLogout.Text = "Đăng xuất";
            this.btnLogout.UseVisualStyleBackColor = true;
            this.btnLogout.Click += new System.EventHandler(this.btn_LogOut_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(666, 443);
            this.Controls.Add(this.btnLogout);
            this.Controls.Add(this.btnCheckPayroll);
            this.Controls.Add(this.btnAttendance);
            this.Controls.Add(this.btnEditInfo);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.lblEmail);
            this.Controls.Add(this.txtEmail);
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
            this.Controls.Add(this.avatar);
            this.Name = "MainForm";
            this.Text = "Main Form";
            ((System.ComponentModel.ISupportInitialize)(this.avatar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void btn_LogOut_Click(object sender, EventArgs e)
        {
            UserForm userForm = new UserForm();
            userForm.Show();

            this.Close();
        }

        private void btn_CheckPayroll_Click(object sender, EventArgs e)
        {
            PayrollForm payrollFrom = new PayrollForm();
            payrollFrom.Show();

            this.Close();
        }

        private void btn_Attendance_Click(object sender, EventArgs e)
        {
            //AttendanceForm attForm = new AttendanceForm();
            //attForm.Show();

            //this.Close();
        }

        private void btn_EditInfo_Click(object sender, EventArgs e)
        {
            //EmployeeForm empForm = new EmployeeForm();
            //empForm.Show();

            //this.Close();
        }
    }
}
