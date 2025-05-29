using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace Project_KTMH
{
    public class Employee : Person
    {
        private string employeeID;
        private string roleID;
        private string departmentID;
        private int paidleave;
        private string roleName;

        public List<Attendance> attendances = new List<Attendance>();
        public string EmployeeID1 { get => employeeID; private set => employeeID = value; }
        public string RoleID1 { get => roleID; private set => roleID = value; }
        public string DepartmentID1 { get => departmentID; private set => departmentID = value; }

        public string RoleName { get; }

        //public string EmployeeID() { return EmployeeID1; }
        //public string RoleID() { return RoleID1; }
        //public string DepartmentID() { return DepartmentID1; }

        public Employee(string name, string email, DateTime dateofbirth, string phone_num, string address, string employeeID, string roleID, string departmentID, string roleName)
            : base(name, email, dateofbirth, phone_num, address)
        {
            this.EmployeeID1 = employeeID;
            this.RoleID1 = roleID;
            this.RoleName = roleName;
            this.DepartmentID1 = departmentID;
            this.attendances = new List<Attendance>();
        }

        public void CreateUser()
        {
            string username = Trans(Name, employeeID);
            string password = employeeID;
            User user = new User(username, password);
            UserManager.Instance.AddUser(user);
        }
        private string Trans(string name, string employeeid)
        {
            string login = name.ToLower();
            login = Regex.Replace(login.Normalize(NormalizationForm.FormD), @"\p{Mn}", "");
            login = login.Replace(" ", "");
            return login + employeeid;
        }

        public void Absent(List<Employee> employees)
        {
            Console.WriteLine("Nhap ma nhan vien: ");
            string absentemployeeID = Console.ReadLine();
            foreach (Employee employee in employees)
            {
                if (employee.EmployeeID1 == absentemployeeID)
                {
                    employee.paidleave++;
                }
            }
        }

        public int numAbsent(List<Employee> employees, string employeeID)
        {
            foreach (Employee employee in employees)
            {
                if (employee.EmployeeID1 == employeeID)
                    return employee.paidleave;
            }
            return 0;
        }

        public void UpdateEmployee(string name, string email, DateTime dateOfBirth, string phoneNum, string address, string roleID, string departmentID, string roleName)
        {
            UpdatePersonalDetails(name, email, dateOfBirth);
            this.Phone_num = phoneNum;
            this.Address = address;
            this.RoleID1 = roleID;
            this.roleName = roleName;
            this.DepartmentID1 = departmentID;
        }
    }
}