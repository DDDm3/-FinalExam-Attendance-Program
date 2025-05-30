﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Project_KTMH
{
    partial class AttendanceForm : Form
    {
        private Attendance attendanceManager;

        public AttendanceForm(Employee employee)
        {
            InitializeComponent();
            attendanceManager = new Attendance(DateTime.Now, TimeSpan.Zero, false, "", TimeSpan.Zero, false, TimeSpan.Zero);
            this.txtEmployeeID.Text = employee.EmployeeID1;
        }

        private void InitializeComponent()
        {
            this.lblEmployeeID = new System.Windows.Forms.Label();
            this.txtEmployeeID = new System.Windows.Forms.TextBox();
            this.lblStatus = new System.Windows.Forms.Label();
            this.lblWorkingDays = new System.Windows.Forms.Label();
            this.lstAttendanceHistory = new System.Windows.Forms.ListBox();
            this.btnCheckIn = new System.Windows.Forms.Button();
            this.btnCheckOut = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.txtStatus = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lblEmployeeID
            // 
            this.lblEmployeeID.AutoSize = true;
            this.lblEmployeeID.Location = new System.Drawing.Point(35, 22);
            this.lblEmployeeID.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblEmployeeID.Name = "lblEmployeeID";
            this.lblEmployeeID.Size = new System.Drawing.Size(107, 16);
            this.lblEmployeeID.TabIndex = 0;
            this.lblEmployeeID.Text = "Mã số nhân viên:";
            // 
            // txtEmployeeID
            // 
            this.txtEmployeeID.Location = new System.Drawing.Point(225, 16);
            this.txtEmployeeID.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtEmployeeID.Name = "txtEmployeeID";
            this.txtEmployeeID.Size = new System.Drawing.Size(166, 22);
            this.txtEmployeeID.TabIndex = 1;
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(35, 54);
            this.lblStatus.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(70, 16);
            this.lblStatus.TabIndex = 2;
            this.lblStatus.Text = "Trạng thái:";
            // 
            // lblWorkingDays
            // 
            this.lblWorkingDays.AutoSize = true;
            this.lblWorkingDays.Location = new System.Drawing.Point(35, 86);
            this.lblWorkingDays.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblWorkingDays.Name = "lblWorkingDays";
            this.lblWorkingDays.Size = new System.Drawing.Size(141, 16);
            this.lblWorkingDays.TabIndex = 3;
            this.lblWorkingDays.Text = "Working Days / Month:";
            // 
            // lstAttendanceHistory
            // 
            this.lstAttendanceHistory.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.lstAttendanceHistory.FormattingEnabled = true;
            this.lstAttendanceHistory.ItemHeight = 20;
            this.lstAttendanceHistory.Location = new System.Drawing.Point(35, 118);
            this.lstAttendanceHistory.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.lstAttendanceHistory.Name = "lstAttendanceHistory";
            this.lstAttendanceHistory.Size = new System.Drawing.Size(392, 204);
            this.lstAttendanceHistory.TabIndex = 4;
            this.lstAttendanceHistory.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.lstAttendanceHistory_DrawItem);
            // 
            // btnCheckIn
            // 
            this.btnCheckIn.Location = new System.Drawing.Point(35, 352);
            this.btnCheckIn.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnCheckIn.Name = "btnCheckIn";
            this.btnCheckIn.Size = new System.Drawing.Size(95, 37);
            this.btnCheckIn.TabIndex = 5;
            this.btnCheckIn.Text = "Check In";
            this.btnCheckIn.Click += new System.EventHandler(this.btnCheckIn_Click);
            // 
            // btnCheckOut
            // 
            this.btnCheckOut.Location = new System.Drawing.Point(150, 352);
            this.btnCheckOut.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnCheckOut.Name = "btnCheckOut";
            this.btnCheckOut.Size = new System.Drawing.Size(104, 37);
            this.btnCheckOut.TabIndex = 6;
            this.btnCheckOut.Text = "Check Out";
            this.btnCheckOut.Click += new System.EventHandler(this.btnCheckOut_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(318, 352);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(109, 57);
            this.button1.TabIndex = 7;
            this.button1.Text = "Đăng xuất";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.LogOut_Click);
            // 
            // txtStatus
            // 
            this.txtStatus.Location = new System.Drawing.Point(225, 54);
            this.txtStatus.Name = "txtStatus";
            this.txtStatus.Size = new System.Drawing.Size(166, 22);
            this.txtStatus.TabIndex = 8;
            // 
            // AttendanceForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(457, 426);
            this.Controls.Add(this.txtStatus);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.lblEmployeeID);
            this.Controls.Add(this.txtEmployeeID);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.lblWorkingDays);
            this.Controls.Add(this.lstAttendanceHistory);
            this.Controls.Add(this.btnCheckIn);
            this.Controls.Add(this.btnCheckOut);
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "AttendanceForm";
            this.Text = "Attendance Form";
            this.ResumeLayout(false);
            this.PerformLayout();

        }   

        public void AttendanceForm_Load(string filepath)
        {

        }

        private void btnCheckIn_Click(object sender, EventArgs e)
        {
            string employeeID = txtEmployeeID.Text;
            Attendance todayAttendance = null;
            foreach ((Employee, Payroll) employee in EmployeeList.emp)
            {
                if (employee.Item1.EmployeeID1 == employeeID)
                {
                    foreach (Attendance attendance in employee.Item1.attendances)
                    {
                        if (attendance.Date.Date == DateTime.Today.Date)
                        {
                            attendance.UpdateRecord(employeeID, "CheckIn");
                        }
                        if (attendance.Date.Date == DateTime.Today.Date)
                        {
                            todayAttendance = attendance;
                            break;
                        }
                    }
                    break;
                }
                break;
            }
            if (todayAttendance != null)
            {
                txtStatus.Text = todayAttendance.Status;
            }
            else
            {
                txtStatus.Text = "No Attendance Record Found for Today.";
            }
            UpdateAttendanceHistory(employeeID);
        }

        private void btnCheckOut_Click(object sender, EventArgs e)
        {
            string employeeID = txtEmployeeID.Text;
            Attendance todayAttendance = null;
            foreach ((Employee, Payroll) employee in EmployeeList.emp)
            {
                if (employee.Item1.EmployeeID1 == employeeID)
                {
                    foreach (Attendance attendance in employee.Item1.attendances)
                    {
                        if (attendance.Date.Date == DateTime.Today.Date)
                        {
                            attendance.UpdateRecord(employeeID, "CheckOut");
                        }
                        if (attendance.Date.Date == DateTime.Today.Date)
                        {
                            todayAttendance = attendance;
                            break;
                        }
                    }
                    break;
                }
                break;
            }
            if (todayAttendance != null)
            {
                txtStatus.Text = todayAttendance.Status;
            }
            else
            {
                txtStatus.Text = "No Attendance Record Found for Today.";
            }
            UpdateAttendanceHistory(employeeID);
        }

        private void lstAttendanceHistory_DrawItem(object sender, DrawItemEventArgs e)
        {
            // Ensure we have a valid index
            if (e.Index < 0) return;

            // Get the current item text
            string itemText = lstAttendanceHistory.Items[e.Index].ToString();

            // Set color based on content
            Color itemColor = itemText.Contains("CheckIn") ? Color.Green : Color.Red;

            // Draw the background
            e.DrawBackground();

            // Draw the item text with chosen color
            using (Brush brush = new SolidBrush(itemColor))
            {
                e.Graphics.DrawString(itemText, e.Font, brush, e.Bounds);
            }

            // Draw focus rectangle if the item has focus
            e.DrawFocusRectangle();
        }

        private void UpdateAttendanceHistory(string employeeID)
        {
            lstAttendanceHistory.Items.Clear();

            foreach ((Employee, Payroll) e in EmployeeList.emp)
            {
                if (e.Item1.EmployeeID1 == employeeID)
                {
                    foreach (Attendance attendance in e.Item1.attendances)
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

        private void LogOut_Click(object sender, EventArgs e)
        {
            UserForm user = new UserForm();
            user.Show();

            this.Close();
        }

        private void AttendanceForm_Load(object sender, EventArgs e)
        {

        }
    }
}