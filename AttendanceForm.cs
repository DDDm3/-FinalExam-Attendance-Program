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
        private System.Windows.Forms.Button button1;

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
            this.SuspendLayout();
            // 
            // lblEmployeeID
            // 
            this.lblEmployeeID.AutoSize = true;
            this.lblEmployeeID.Location = new System.Drawing.Point(39, 27);
            this.lblEmployeeID.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblEmployeeID.Name = "lblEmployeeID";
            this.lblEmployeeID.Size = new System.Drawing.Size(104, 20);
            this.lblEmployeeID.TabIndex = 0;
            this.lblEmployeeID.Text = "Employee ID:";
            // 
            // txtEmployeeID
            // 
            this.txtEmployeeID.Location = new System.Drawing.Point(154, 23);
            this.txtEmployeeID.Margin = new System.Windows.Forms.Padding(4);
            this.txtEmployeeID.Name = "txtEmployeeID";
            this.txtEmployeeID.Size = new System.Drawing.Size(192, 26);
            this.txtEmployeeID.TabIndex = 1;
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(39, 67);
            this.lblStatus.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(60, 20);
            this.lblStatus.TabIndex = 2;
            this.lblStatus.Text = "Status:";
            // 
            // lblWorkingDays
            // 
            this.lblWorkingDays.AutoSize = true;
            this.lblWorkingDays.Location = new System.Drawing.Point(39, 107);
            this.lblWorkingDays.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblWorkingDays.Name = "lblWorkingDays";
            this.lblWorkingDays.Size = new System.Drawing.Size(111, 20);
            this.lblWorkingDays.TabIndex = 3;
            this.lblWorkingDays.Text = "Working Days:";
            // 
            // lstAttendanceHistory
            // 
            this.lstAttendanceHistory.FormattingEnabled = true;
            this.lstAttendanceHistory.ItemHeight = 20;
            this.lstAttendanceHistory.Location = new System.Drawing.Point(39, 147);
            this.lstAttendanceHistory.Margin = new System.Windows.Forms.Padding(4);
            this.lstAttendanceHistory.Name = "lstAttendanceHistory";
            this.lstAttendanceHistory.Size = new System.Drawing.Size(385, 264);
            this.lstAttendanceHistory.TabIndex = 4;
            this.lstAttendanceHistory.DrawMode = DrawMode.OwnerDrawFixed;
            this.lstAttendanceHistory.DrawItem += new DrawItemEventHandler(lstAttendanceHistory_DrawItem);

            // 
            // btnCheckIn
            // 
            this.btnCheckIn.Location = new System.Drawing.Point(39, 440);
            this.btnCheckIn.Margin = new System.Windows.Forms.Padding(4);
            this.btnCheckIn.Name = "btnCheckIn";
            this.btnCheckIn.Size = new System.Drawing.Size(96, 33);
            this.btnCheckIn.TabIndex = 5;
            this.btnCheckIn.Text = "Check In";
            this.btnCheckIn.Click += new System.EventHandler(this.btnCheckIn_Click);
            // 
            // btnCheckOut
            // 
            this.btnCheckOut.Location = new System.Drawing.Point(154, 440);
            this.btnCheckOut.Margin = new System.Windows.Forms.Padding(4);
            this.btnCheckOut.Name = "btnCheckOut";
            this.btnCheckOut.Size = new System.Drawing.Size(96, 33);
            this.btnCheckOut.TabIndex = 6;
            this.btnCheckOut.Text = "Check Out";
            this.btnCheckOut.Click += new System.EventHandler(this.btnCheckOut_Click);
            // 
            // LogOut
            // 
            this.button1.Location = new System.Drawing.Point(384, 466);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(97, 45);
            this.button1.TabIndex = 7;
            this.button1.Text = "Log Out";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.LogOut_Click);
            // 
            // AttendanceForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(514, 533);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.lblEmployeeID);
            this.Controls.Add(this.txtEmployeeID);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.lblWorkingDays);
            this.Controls.Add(this.lstAttendanceHistory);
            this.Controls.Add(this.btnCheckIn);
            this.Controls.Add(this.btnCheckOut);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "AttendanceForm";
            this.Text = "Attendance Form";
            this.ResumeLayout(false);
            this.PerformLayout();

            this.lstAttendanceHistory.DrawItem += new DrawItemEventHandler(lstAttendanceHistory_DrawItem);
            this.btnCheckIn.Click += new EventHandler(btnCheckIn_Click);
            this.btnCheckOut.Click += new EventHandler(btnCheckOut_Click);
            this.button1.Click += new EventHandler(LogOut_Click);

        }

        private Attendance attendanceManager;
        private List<Employee> employees;

        public AttendanceForm()
        {
            InitializeComponent();
            attendanceManager = new Attendance(DateTime.Now, TimeSpan.Zero, false, "", TimeSpan.Zero, false, TimeSpan.Zero);
            
        }

        public void AttendanceForm_Load(string filepath)
        {

        }

        private void btnCheckIn_Click(object sender, EventArgs e)
        {
            string employeeID = txtEmployeeID.Text;

            if (!string.IsNullOrEmpty(employeeID))
            {
                // Update the record with check-in action
                attendanceManager.UpdateRecord(employeeID, "CheckIn");

                // Retrieve the current attendance status
                Attendance todayAttendance = null;
                foreach (Employee emp in employees)
                {
                    if (emp.EmployeeID1 == employeeID)
                    {
                        foreach (Attendance attendance in emp.attendances)
                        {
                            if (attendance.Date.Date == DateTime.Today)
                            {
                                todayAttendance = attendance;
                                break;
                            }
                        }
                        break;
                    }
                }

                // Set lblStatus text to today's attendance status
                if (todayAttendance != null)
                {
                    lblStatus.Text = todayAttendance.Status;
                }
                else
                {
                    lblStatus.Text = "No Attendance Record Found for Today.";
                }

                // Refresh attendance history for the specified employee
                UpdateAttendanceHistory(employeeID);
            }
            else
            {
                MessageBox.Show("Please enter a valid Employee ID.");
            }
        }

        private void btnCheckOut_Click(object sender, EventArgs e)
        {
            string employeeID = txtEmployeeID.Text;

            if (!string.IsNullOrEmpty(employeeID))
            {
                // Update the record with check-out action
                attendanceManager.UpdateRecord(employeeID, "CheckOut");

                // Retrieve the current attendance status
                Attendance todayAttendance = null;
                foreach (Employee emp in employees)
                {
                    if (emp.EmployeeID1 == employeeID)
                    {
                        foreach (Attendance attendance in emp.attendances)
                        {
                            if (attendance.Date.Date == DateTime.Today)
                            {
                                todayAttendance = attendance;
                                break;
                            }
                        }
                        break;
                    }
                }

                // Set lblStatus text to today's attendance status
                if (todayAttendance != null)
                {
                    lblStatus.Text = todayAttendance.Status;
                }
                else
                {
                    lblStatus.Text = "No Attendance Record Found for Today.";
                }

                // Refresh attendance history for the specified employee
                UpdateAttendanceHistory(employeeID);
            }
            else
            {
                MessageBox.Show("Please enter a valid Employee ID.");
            }
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
    }
}