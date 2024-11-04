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


        private void InitializeComponent4()
        {
            this.Text = "Add Employee";
            this.Size = new System.Drawing.Size(400, 450);
            this.ClientSize = new System.Drawing.Size(400, 450);
            this.AutoScaleMode = AutoScaleMode.Font;

            Label lblName = new Label() { Text = "Name:", Left = 20, Top = 20 };
            txtName = new TextBox() { Left = 150, Top = 20, Width = 200 };

            Label lblAddress = new Label() { Text = "Address:", Left = 20, Top = 60 };
            txtAddress = new TextBox() { Left = 150, Top = 60, Width = 200 };

            Label lblEmail = new Label() { Text = "Email:", Left = 20, Top = 100 };
            txtEmail = new TextBox() { Left = 150, Top = 100, Width = 200 };

            Label lblDOB = new Label() { Text = "Date of Birth:", Left = 20, Top = 140 };
            dtpDOB = new DateTimePicker() { Left = 150, Top = 140, Width = 200 };

            Label lblPhone = new Label() { Text = "Phone Number:", Left = 20, Top = 180 };
            txtPhone = new TextBox() { Left = 150, Top = 180, Width = 200 };

            Label lblEmployeeID = new Label() { Text = "Employee ID:", Left = 20, Top = 220 };
            txtEmployeeID = new TextBox() { Left = 150, Top = 220, Width = 200 };

            Label lblRoleID = new Label() { Text = "Role ID:", Left = 20, Top = 260 };
            txtRoleID = new TextBox() { Left = 150, Top = 260, Width = 200 };

            Label lblDepartmentID = new Label() { Text = "Department ID:", Left = 20, Top = 300 };
            txtDepartmentID = new TextBox() { Left = 150, Top = 300, Width = 200 };

            Button btnSubmit = new Button() { Text = "Add Employee", Left = 150, Top = 350 };
            btnSubmit.Click += (sender, e) =>
            {
                Payroll payroll = new Payroll(txtEmployeeID.Text,            // PayrollID
                                              txtDepartmentID.Text,
                                              txtEmployeeID.Text,
                                              txtName.Text,
                                              1.0,                  // SalaryCoefficient
                                              1.0,                  // SalaryCoefficientDepartment
                                              1.0,                  // SalaryCoefficientPosition
                                              10000,                // BaseSalary (Giá trị mặc định, có thể thay đổi)
                                              0);                     // AttendanceDay (Giá trị mặc định)

                AddEmployee(txtName.Text,
                            txtAddress.Text,
                            txtEmail.Text,
                            dtpDOB.Value,
                            txtPhone.Text,
                            txtEmployeeID.Text,
                            txtRoleID.Text,
                            txtDepartmentID.Text,
                            payroll);
            };

            // Add all controls to the form
            this.Controls.Add(lblName);
            this.Controls.Add(txtName);
            this.Controls.Add(lblAddress);
            this.Controls.Add(txtAddress);
            this.Controls.Add(lblEmail);
            this.Controls.Add(txtEmail);
            this.Controls.Add(lblDOB);
            this.Controls.Add(dtpDOB);
            this.Controls.Add(lblPhone);
            this.Controls.Add(txtPhone);
            this.Controls.Add(lblEmployeeID);
            this.Controls.Add(txtEmployeeID);
            this.Controls.Add(lblRoleID);
            this.Controls.Add(txtRoleID);
            this.Controls.Add(lblDepartmentID);
            this.Controls.Add(txtDepartmentID);
            this.Controls.Add(btnSubmit);

           

        }



        public EmployeeForm(EmployeeList employees)
        {
            
            InitializeComponent4();
            
            employeeList = employees;

        }

        private void AddEmployee(string name, string address, string email, DateTime dob, string phone, string employeeID, string roleID, string departmentID, Payroll payroll)
        {
            // Create a new Employee and add it to the list
            Employee newEmployee = new Employee(name, email, dob, phone, address, employeeID, roleID, departmentID);
            employeeList.AddEmployee(newEmployee, payroll);
            

            MessageBox.Show("Employee added successfully!");

            // Optionally clear the form inputs
            ClearForm();
        }

        private void UpdateEmployee(string employeeID, string name, string address, string email, DateTime dateofbirth, string phone, string roleID, string departmentID)
        {
            foreach ((Employee, Payroll) e in EmployeeList.emp)
                if (e.Item1.EmployeeID1 == employeeID)
                {

                    e.Item1.UpdateEmployee(name, email,dateofbirth,phone,address,roleID,departmentID);

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
            bool removed = employeeList.removeEmployee(employeeID); // Adjust this method in EmployeeList class
            
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
    }
}
