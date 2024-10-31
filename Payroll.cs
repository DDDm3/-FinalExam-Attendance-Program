using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_KTMH
{
    public class Payroll
    {
        public string PayrollID { get; private set; }
        public string DepartmentID { get; private set; }
        public string EmployeeID { get; private set; }
        public string EmployeeName { get; private set; }
        public double SalaryCoefficient { get; private set; }
        public double SalaryCoefficientDepartment { get; private set; }
        public double SalaryCoefficientPosition { get; private set; }
        public decimal BaseSalary { get;  set; }
        public decimal OvertimeSalary { get; private set; }
        public decimal TotalSalary { get; private set; }
        public int AttendanceDay { get; set; }
        public List<Attendance> AttendanceList { get; set; }
        public decimal BHXH { get; private set; }
        public decimal BHYT { get; private set; }

        public decimal Bonus { get; private set; }
        public decimal Tax { get; private set; }
        public decimal TotalDeductions { get; private set; }

        public DateTime CalculationDate { get; private set; }

        public Payroll(string payrollID,string departmentID, string employeeID, string employeeName,
                      double salaryCoefficient, double salaryCoefficientDepartment, double salaryCoefficientPosition,
                      decimal baseSalary, int attendanceDay)
        {
            PayrollID = payrollID;
            DepartmentID = departmentID;
            EmployeeID = employeeID;
            EmployeeName = employeeName;
            SalaryCoefficient = salaryCoefficient;
            SalaryCoefficientDepartment = salaryCoefficientDepartment;
            SalaryCoefficientPosition = salaryCoefficientPosition;
            BaseSalary = baseSalary;
            AttendanceDay = attendanceDay;
            OvertimeSalary = 0;
            Bonus = 0;
            Tax = 0;
            TotalDeductions = 0;
            TotalSalary = 0;
            AttendanceList = new List<Attendance>();
            CalculationDate = DateTime.Now;
        }

        public void CalculateOvertimePay(decimal overtimeHours, decimal overtimeRate)
        {
            OvertimeSalary = overtimeHours * overtimeRate;
        }


        public void CalculateTotalSalary()
        {
            decimal baseSalaryCalculated = BaseSalary * (decimal)SalaryCoefficient * (decimal)SalaryCoefficientDepartment * (decimal)SalaryCoefficientPosition;
            decimal totalBeforeDeductions = baseSalaryCalculated + OvertimeSalary + Bonus;
            TotalDeductions = BHXH + BHYT + (totalBeforeDeductions * Tax / 100);
            TotalSalary = totalBeforeDeductions - TotalDeductions;
        }


        public void AddAttendance(Attendance attendance)
        {
            AttendanceList.Add(attendance);
        }

        public decimal CalculateTotalOvertimeHours()
        {
            decimal totalOvertime = 0;
            foreach (var attendance in AttendanceList)
            {
                //totalOvertime += attendance.OvertimeHours;
            }
            return totalOvertime;
        }

        public void AddDeductions(decimal bhxh, decimal bhyt, decimal tax)
        {
            BHXH = bhxh;
            BHYT = bhyt;
            Tax = tax;
        }
        public void AddBonus(decimal bonus)
        {
            Bonus = bonus;
        }
    }
}
