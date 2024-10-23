using System;
using System.Collections.Generic;
using System.Text;

namespace _Project__Atendence_Program
{
    public class Department
    {
        public string DepartmentID { get; }
        public string DepartmentName { get; set; }
        public string Description { get; set; }

        public Department(string departmentID, string departmentName, string description)
        {
            DepartmentID = departmentID;
            DepartmentName = departmentName;
            Description = description;
        }

        public static List<Department> Departments = new List<Department>();

        public Department FindDepartment(string departmentName)
        {
            foreach (Department department in Departments)
            {
                if (string.Equals(department.DepartmentName, departmentName, StringComparison.OrdinalIgnoreCase))
                {
                    return department;
                }
            }
            return null;
        }
        public void DisplayEmployeeInDepartment(List<Employee> employees, string departmentName)
        {
            Department department = FindDepartment(departmentName);
            if (department == null)
            {
                Console.WriteLine("Khong tim thay phong ban voi ten nay.");
                return;
            }

            Console.WriteLine($"Nhan vien trong phong ban: {department.DepartmentName}");

            List<Employee> employeesInDepartment = new List<Employee>();

            foreach (Employee emp in employees)
            {
                if (emp.DepartmentID() == department.DepartmentID)
                {
                    employeesInDepartment.Add(emp);
                }
            }

            if (employeesInDepartment.Count == 0)
            {
                Console.WriteLine("Khong co nhan vien nao trong phong ban nay.");
            }
            else
            {
                foreach (Employee emp in employeesInDepartment)
                {
                    Console.WriteLine($"- {emp.EmployeeID()}: {emp.Name}");
                }
            }
        }
    }
}
