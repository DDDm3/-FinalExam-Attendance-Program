using System;
using System.IO;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Text.Json;

namespace Project_KTMH
{
    public partial class PayrollForm : Form
    {
        private List<(Employee, Payroll)> employees = EmployeeList.emp;
        private List<Payroll> payrolls;
        private string payrollFilePath = "payrolls.json"; // Đổi tên file lưu trữ thành JSON
        private DataGridView dgvPayrolls;
        private ComboBox cmbEmployees;

        private TextBox txtBaseSalary;
        private TextBox txtAttendanceDay;
        private Button btnUpdatePayroll;
        private Button btnDeletePayroll;
        private Button btnAddPayroll;

        public PayrollForm()
        {
            InitializeComponent();
            LoadData();
            LoadEmployees();
            LoadPayrolls();
        }

        // Phương thức tải dữ liệu từ file
        public void LoadData()
        {
            List<Employee> employeesList = LoadEmployeesFromFile("employees.json"); // Sử dụng JSON cho employees
            payrolls = LoadPayrollsFromFile(payrollFilePath);

            employees = new List<(Employee, Payroll)>();

            foreach (Employee employee in employeesList)
            {
                Payroll current_p = null;
                foreach (Payroll payroll in payrolls)
                {
                    if (payroll.PayrollID == employee.EmployeeID1)
                    {
                        current_p = payroll;
                        break;
                    }
                }
                employees.Add((employee, current_p));
            }
        }

        // Phương thức tải danh sách nhân viên từ file JSON
        public List<Employee> LoadEmployeesFromFile(string filePath)
        {
            if (!File.Exists(filePath))
                return new List<Employee>();

            string json = File.ReadAllText(filePath);
            return JsonSerializer.Deserialize<List<Employee>>(json);
        }

        // Phương thức tải danh sách lương từ file JSON
        public List<Payroll> LoadPayrollsFromFile(string filePath)
        {
            if (!File.Exists(filePath))
                return new List<Payroll>();

            string json = File.ReadAllText(filePath);
            return JsonSerializer.Deserialize<List<Payroll>>(json);
        }

        // Phương thức lưu danh sách lương vào file JSON
        public void SavePayrollsToFile()
        {
            var options = new JsonSerializerOptions { WriteIndented = true };
            string json = JsonSerializer.Serialize(payrolls, options);
            File.WriteAllText(payrollFilePath, json);
        }

        // Phương thức tải danh sách nhân viên vào ComboBox
        public void LoadEmployees()
        {
            List<Employee> employeesList = new List<Employee>();
            foreach ((Employee, Payroll) employee in employees)
            {
                employeesList.Add(employee.Item1);
            }

            cmbEmployees.DataSource = employeesList;
            cmbEmployees.DisplayMember = "Name";
            cmbEmployees.ValueMember = "EmployeeID";
            cmbEmployees.SelectedIndex = -1;
        }

        // Phương thức tải danh sách bảng lương vào DataGridView
        public void LoadPayrolls()
        {
            dgvPayrolls.DataSource = null;
            List<object> payrollsdisplay = new List<object>();
            foreach (Payroll payroll in payrolls)
            {
                payrollsdisplay.Add(new
                {
                    payroll.PayrollID,
                    payroll.EmployeeID,
                    payroll.EmployeeName,
                    payroll.DepartmentID,
                    payroll.SalaryCoefficient,
                    payroll.SalaryCoefficientDepartment,
                    payroll.SalaryCoefficientPosition,
                    payroll.BaseSalary,
                    payroll.OvertimeSalary,
                    payroll.TotalSalary,
                    payroll.AttendanceDay,
                    payroll.BHXH,
                    payroll.BHYT,
                    payroll.Bonus,
                    payroll.Tax,
                    payroll.TotalDeductions,
                    payroll.CalculationDate
                });
            }
            dgvPayrolls.DataSource = payrollsdisplay;
        }

        // Sự kiện thêm bảng lương
        private void btnAddPayroll_Click(object sender, EventArgs e)
        {
            // Lấy thông tin từ giao diện người dùng
            string employeeID = (string)cmbEmployees.SelectedValue;
            string payrollID = employeeID;
            decimal baseSalary = decimal.Parse(txtBaseSalary.Text);
            int attendanceDay = int.Parse(txtAttendanceDay.Text);

            (Employee, Payroll) employee_tuple = (null, null);

            for (int i = 0; i < employees.Count; i++)
            {
                if (employees[i].Item1.EmployeeID1 == employeeID)
                {
                    employee_tuple = employees[i];
                    break;
                }
            }

            if (employee_tuple.Item1 != null)
            {
                string departmentID = employee_tuple.Item1.DepartmentID1;
                string employeeName = employee_tuple.Item1.Name;
                double salaryCoefficient = (employee_tuple.Item2 != null) ? employee_tuple.Item2.SalaryCoefficient : 1;
                double salaryCoefficientDepartment = (employee_tuple.Item2 != null) ? employee_tuple.Item2.SalaryCoefficientDepartment : 1;
                double salaryCoefficientPosition = (employee_tuple.Item2 != null) ? employee_tuple.Item2.SalaryCoefficientPosition : 1;

                Payroll newPayroll = new Payroll(payrollID, departmentID, employeeID, employeeName,
                                                 salaryCoefficient, salaryCoefficientDepartment, salaryCoefficientPosition,
                                                 baseSalary, attendanceDay);

                payrolls.Add(newPayroll);
                SavePayrollsToFile();
                LoadPayrolls(); // Tải lại dữ liệu bảng lương
            }
            ClearInputs();
        }


        // Sự kiện cập nhật bảng lương
        private void btnUpdatePayroll_Click(object sender, EventArgs e)
        {
            // Cập nhật bảng lương đã chọn
            if (dgvPayrolls.CurrentRow != null)
            {
                var selectedPayroll = (Payroll)dgvPayrolls.CurrentRow.DataBoundItem;
                selectedPayroll.BaseSalary = decimal.Parse(txtBaseSalary.Text);
                selectedPayroll.AttendanceDay = int.Parse(txtAttendanceDay.Text);
                selectedPayroll.CalculateTotalSalary();
                SavePayrollsToFile();
                LoadPayrolls(); // Tải lại dữ liệu bảng lương
            }
            ClearInputs();
        }

        // Sự kiện xóa bảng lương
        private void btnDeletePayroll_Click(object sender, EventArgs e)
        {
            if (dgvPayrolls.CurrentRow != null)
            {
                var selectedPayroll = (Payroll)dgvPayrolls.CurrentRow.DataBoundItem;
                payrolls.Remove(selectedPayroll);
                SavePayrollsToFile();
                LoadPayrolls(); // Tải lại dữ liệu bảng lương
            }
            ClearInputs();
        }

        // Sự kiện khi thay đổi lựa chọn trong DataGridView
        private void dgvPayrolls_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvPayrolls.CurrentRow != null)
            {
                var selectedPayroll = (Payroll)dgvPayrolls.CurrentRow.DataBoundItem;
                txtBaseSalary.Text = selectedPayroll.BaseSalary.ToString();
                txtAttendanceDay.Text = selectedPayroll.AttendanceDay.ToString();
            }
        }

        private void InitializeComponent()
        {
            this.dgvPayrolls = new System.Windows.Forms.DataGridView();
            this.cmbEmployees = new System.Windows.Forms.ComboBox();
            this.txtBaseSalary = new System.Windows.Forms.TextBox();
            this.txtAttendanceDay = new System.Windows.Forms.TextBox();
            this.btnAddPayroll = new System.Windows.Forms.Button();
            this.btnUpdatePayroll = new System.Windows.Forms.Button();
            this.btnDeletePayroll = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPayrolls)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvPayrolls
            // 
            this.dgvPayrolls.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPayrolls.Location = new System.Drawing.Point(12, 12);
            this.dgvPayrolls.Name = "dgvPayrolls";
            this.dgvPayrolls.RowHeadersWidth = 51;
            this.dgvPayrolls.Size = new System.Drawing.Size(800, 300);
            this.dgvPayrolls.TabIndex = 0;
            this.dgvPayrolls.SelectionChanged += new System.EventHandler(this.dgvPayrolls_SelectionChanged);
            // 
            // cmbEmployees
            // 
            this.cmbEmployees.Location = new System.Drawing.Point(12, 320);
            this.cmbEmployees.Name = "cmbEmployees";
            this.cmbEmployees.Size = new System.Drawing.Size(200, 24);
            this.cmbEmployees.TabIndex = 1;
            // 
            // txtBaseSalary
            // 
            this.txtBaseSalary.Location = new System.Drawing.Point(12, 350);
            this.txtBaseSalary.Name = "txtBaseSalary";
            this.txtBaseSalary.Size = new System.Drawing.Size(100, 22);
            this.txtBaseSalary.TabIndex = 2;
            // 
            // txtAttendanceDay
            // 
            this.txtAttendanceDay.Location = new System.Drawing.Point(12, 380);
            this.txtAttendanceDay.Name = "txtAttendanceDay";
            this.txtAttendanceDay.Size = new System.Drawing.Size(100, 22);
            this.txtAttendanceDay.TabIndex = 3;
            // 
            // btnAddPayroll
            // 
            this.btnAddPayroll.Location = new System.Drawing.Point(12, 410);
            this.btnAddPayroll.Name = "btnAddPayroll";
            this.btnAddPayroll.Size = new System.Drawing.Size(153, 59);
            this.btnAddPayroll.TabIndex = 4;
            this.btnAddPayroll.Text = "Add Payroll";
            this.btnAddPayroll.Click += new System.EventHandler(this.btnAddPayroll_Click);
            // 
            // btnUpdatePayroll
            // 
            this.btnUpdatePayroll.Location = new System.Drawing.Point(181, 410);
            this.btnUpdatePayroll.Name = "btnUpdatePayroll";
            this.btnUpdatePayroll.Size = new System.Drawing.Size(153, 59);
            this.btnUpdatePayroll.TabIndex = 5;
            this.btnUpdatePayroll.Text = "Update Payroll";
            this.btnUpdatePayroll.Click += new System.EventHandler(this.btnUpdatePayroll_Click);
            // 
            // btnDeletePayroll
            // 
            this.btnDeletePayroll.Location = new System.Drawing.Point(349, 410);
            this.btnDeletePayroll.Name = "btnDeletePayroll";
            this.btnDeletePayroll.Size = new System.Drawing.Size(153, 59);
            this.btnDeletePayroll.TabIndex = 6;
            this.btnDeletePayroll.Text = "Delete Payroll";
            this.btnDeletePayroll.Click += new System.EventHandler(this.btnDeletePayroll_Click);
            // 
            // PayrollForm
            // 
            this.ClientSize = new System.Drawing.Size(826, 477);
            this.Controls.Add(this.dgvPayrolls);
            this.Controls.Add(this.cmbEmployees);
            this.Controls.Add(this.txtBaseSalary);
            this.Controls.Add(this.txtAttendanceDay);
            this.Controls.Add(this.btnAddPayroll);
            this.Controls.Add(this.btnUpdatePayroll);
            this.Controls.Add(this.btnDeletePayroll);
            this.Name = "PayrollForm";
            ((System.ComponentModel.ISupportInitialize)(this.dgvPayrolls)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        // Phương thức để làm sạch các input
        private void ClearInputs()
        {
            txtBaseSalary.Clear();
            txtAttendanceDay.Clear();
        }
    }
}