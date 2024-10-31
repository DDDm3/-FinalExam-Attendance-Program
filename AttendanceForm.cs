using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project_KTMH
{
    partial class AttendanceForm : Form
    {
            private System.Windows.Forms.Label lblEmployeeID;
            private System.Windows.Forms.TextBox txtEmployeeID;
            private System.Windows.Forms.Label lblStatus;
            private System.Windows.Forms.Label lblWorkingDays;
            private System.Windows.Forms.ListBox lstAttendanceHistory;
            private System.Windows.Forms.Button btnCheckIn;
            private System.Windows.Forms.Button btnCheckOut;

            private void InitializeComponent()
            {
                this.SuspendLayout();
                // 
                // FormAttendance
                // 
                this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
                this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
                this.ClientSize = new System.Drawing.Size(800, 450);
                this.Name = "FormAttendance";
                this.Text = "FormAttendance";
                this.ResumeLayout(false);

                this.lblEmployeeID = new System.Windows.Forms.Label();
                this.txtEmployeeID = new System.Windows.Forms.TextBox();
                this.lblStatus = new System.Windows.Forms.Label();
                this.lblWorkingDays = new System.Windows.Forms.Label();
                this.lstAttendanceHistory = new System.Windows.Forms.ListBox();
                this.btnCheckIn = new System.Windows.Forms.Button();
                this.btnCheckOut = new System.Windows.Forms.Button();

                // 
                // lblEmployeeID
                // 
                this.lblEmployeeID.AutoSize = true;
                this.lblEmployeeID.Location = new System.Drawing.Point(30, 20);
                this.lblEmployeeID.Name = "lblEmployeeID";
                this.lblEmployeeID.Size = new System.Drawing.Size(80, 15);
                this.lblEmployeeID.Text = "Employee ID:";

                // 
                // txtEmployeeID
                // 
                this.txtEmployeeID.Location = new System.Drawing.Point(120, 17);
                this.txtEmployeeID.Name = "txtEmployeeID";
                this.txtEmployeeID.Size = new System.Drawing.Size(150, 23);

                // 
                // lblStatus
                // 
                this.lblStatus.AutoSize = true;
                this.lblStatus.Location = new System.Drawing.Point(30, 50);
                this.lblStatus.Name = "lblStatus";
                this.lblStatus.Size = new System.Drawing.Size(45, 15);
                this.lblStatus.Text = "Status:";

                // 
                // lblWorkingDays
                // 
                this.lblWorkingDays.AutoSize = true;
                this.lblWorkingDays.Location = new System.Drawing.Point(30, 80);
                this.lblWorkingDays.Name = "lblWorkingDays";
                this.lblWorkingDays.Size = new System.Drawing.Size(88, 15);
                this.lblWorkingDays.Text = "Working Days:";

                // 
                // lstAttendanceHistory
                // 
                this.lstAttendanceHistory.FormattingEnabled = true;
                this.lstAttendanceHistory.ItemHeight = 15;
                this.lstAttendanceHistory.Location = new System.Drawing.Point(30, 110);
                this.lstAttendanceHistory.Name = "lstAttendanceHistory";
                this.lstAttendanceHistory.Size = new System.Drawing.Size(300, 200);

                // 
                // btnCheckIn
                // 
                this.btnCheckIn.Location = new System.Drawing.Point(30, 330);
                this.btnCheckIn.Name = "btnCheckIn";
                this.btnCheckIn.Size = new System.Drawing.Size(75, 25);
                this.btnCheckIn.Text = "Check In";
                this.btnCheckIn.Click += new System.EventHandler(this.btnCheckIn_Click);

                // 
                // btnCheckOut
                // 
                this.btnCheckOut.Location = new System.Drawing.Point(120, 330);
                this.btnCheckOut.Name = "btnCheckOut";
                this.btnCheckOut.Size = new System.Drawing.Size(75, 25);
                this.btnCheckOut.Text = "Check Out";
                this.btnCheckOut.Click += new System.EventHandler(this.btnCheckOut_Click);

                // 
                // AttendanceForm
                // 
                this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
                this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
                this.ClientSize = new System.Drawing.Size(400, 400);
                this.Controls.Add(this.lblEmployeeID);
                this.Controls.Add(this.txtEmployeeID);
                this.Controls.Add(this.lblStatus);
                this.Controls.Add(this.lblWorkingDays);
                this.Controls.Add(this.lstAttendanceHistory);
                this.Controls.Add(this.btnCheckIn);
                this.Controls.Add(this.btnCheckOut);
                this.Text = "Attendance Form";
            }

            private Attendance attendanceManager;
            private List<Employee> employees;

            public AttendanceForm()
            {
                InitializeComponent();
                attendanceManager = new Attendance(DateTime.Now, TimeSpan.Zero, false, "", TimeSpan.Zero, false, TimeSpan.Zero);
                employees = new List<Employee>(); // Tạo danh sách nhân viên
            }

            public void AttendanceForm_Load(string filepath)
            {

            }

            private void btnCheckIn_Click(object sender, EventArgs e)
            {
                string employeeID = txtEmployeeID.Text;
                DateTime now = DateTime.Now;

                if (!string.IsNullOrEmpty(employeeID))
                {
                    attendanceManager.UpdateRecord(employeeID);
                    lblStatus.Text = "Checked In!";
                    UpdateAttendanceHistory(employeeID);
                }
                else
                {
                    MessageBox.Show("Vui lòng nhập mã nhân viên.");
                }
            }

            private void btnCheckOut_Click(object sender, EventArgs e)
            {
                string employeeID = txtEmployeeID.Text;
                DateTime now = DateTime.Now;

                if (!string.IsNullOrEmpty(employeeID))
                {
                    attendanceManager.UpdateRecord(employeeID);
                    lblStatus.Text = "Checked Out!";
                    UpdateAttendanceHistory(employeeID);
                }
                else
                {
                    MessageBox.Show("Vui lòng nhập mã nhân viên.");
                }
            }

            private void UpdateAttendanceHistory(string employeeID)
            {
                lstAttendanceHistory.Items.Clear();
                Employee employee = employees.Find(emp => emp.EmployeeID1 == employeeID);
                if (employee != null)
                {
                    foreach (var attendance in employee.attendances)
                    {
                        lstAttendanceHistory.Items.Add($"Date: {attendance.Date}, Status: {attendance.Status}, OT: {attendance.OtTime}");
                    }

                    int workingDays = attendanceManager.CountDay(employeeID);
                    lblWorkingDays.Text = $"Total Working Days: {workingDays}";
                }
                else
                {
                    MessageBox.Show("Không tìm thấy nhân viên.");
                }
            }
    }
}
