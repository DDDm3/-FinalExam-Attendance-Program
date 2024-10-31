using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
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

        public List<Attendance> attendances = new List<Attendance>();
        public string EmployeeID1 { get => employeeID; set => employeeID = value; }
        public string RoleID1 { get => roleID; set => roleID = value; }
        public string DepartmentID1 { get => departmentID; set => departmentID = value; }

        //public string EmployeeID() { return EmployeeID1; }
        //public string RoleID() { return RoleID1; }
        //public string DepartmentID() { return DepartmentID1; }
      


        public Employee(string name, string email, DateTime dateofbirth, string phone_num, string address, string employeeID, string roleID, string departmentID)
            : base(name, email, dateofbirth, phone_num, address)
        {
            this.EmployeeID1 = employeeID;
            this.RoleID1 = roleID;
            this.DepartmentID1 = departmentID;
            this.attendances = new List<Attendance>();
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

        public void Add(List<Employee> employee)
        {
            Console.Write("nhap ten: ");
            string name= Console.ReadLine();
            Console.Write("nhap dia chi: ");
            string address = Console.ReadLine();
            Console.Write("nhap email: ");
            string email = Console.ReadLine();
            Console.Write("nhap ngay sinh nhat: ");
            DateTime dateofbirth = DateTime.Parse(Console.ReadLine());
            Console.Write("nhap so dien thoai: ");
            string phone_num = Console.ReadLine();
            Console.Write("nhap ma cong nhan: ");
            string employeeID = Console.ReadLine();
            Console.Write("nhap ma chuc vu: ");
            string roleID = Console.ReadLine();
            Console.Write("nhap ma phong ban: ");
            string departmentID = Console.ReadLine();
            

            employee.Add(new Employee(name, email, dateofbirth, phone_num, address, employeeID, roleID, departmentID));
        }

        public void Remove(List<Employee> employee)
        {
            Console.Write("Nhap ma nhan vien ban muon xoa: ");
            string employeeIDtodelete = Console.ReadLine();
            foreach (Employee emp in employee)
            {
                if (emp.EmployeeID1 == employeeIDtodelete)
                {
                    employee.Remove(emp);
                }
            }
        }

        public void Update(List<Employee> employee)
        {
            Console.Write("Nhap ma nhan vien ban muon chinh sua: ");
            string employeeIDtoupdate = Console.ReadLine();
            foreach (Employee emp in employee)
            {
                if (emp.EmployeeID1 == employeeIDtoupdate)
                {
                    Console.Write("Nhap vi tri ban muon sua: ");
                    int vitri = int.Parse(Console.ReadLine());
                    switch (vitri)
                    {
                        case 1:
                            {
                                Console.Write("nhap ten moi: ");
                                string tenmoi = Console.ReadLine();
                                string employeeID = tenmoi;
                            }
                            break;
                        case 2:
                            {
                                Console.Write("nhap ma nhan vien moi: ");
                                string newemployeeid = Console.ReadLine();
                                emp.EmployeeID1 = newemployeeid;
                            }
                            break;
                        case 3:
                            {
                                Console.Write("nhap ma chuc vu moi: ");
                                string newroleid = Console.ReadLine();
                                emp.RoleID1 = newroleid;
                            }
                            break;
                        case 4:
                            {
                                Console.Write("nhap ma phong ban moi: ");
                                string newdepartmentid = Console.ReadLine();
                                emp.DepartmentID1 = newdepartmentid;
                            }
                            break;                   
                    }
                }
            }
        }
    }
}