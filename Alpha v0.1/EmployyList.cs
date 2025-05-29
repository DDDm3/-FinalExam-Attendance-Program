using System.Collections.Generic;

namespace Project_KTMH
{
    public class EmployeeList
    {
        public static List<(Employee, Payroll)> emp = new List<(Employee, Payroll)>();
        
        public List<(Employee, Payroll)> GetEmployees()
        {

            return emp;
        }

        public void AddEmployee(Employee employee, Payroll payroll)
        {
            emp.Add((employee, payroll));
        }

        public bool RemoveEmployee(string employeeID)
        {
            for (int i = 0; i < emp.Count; i++)
            {
                if (emp[i].Item1.EmployeeID1 == employeeID)
                {
                    emp.RemoveAt(i);
                    return true;
                }
            }
            return false;
        }

        public bool Find(string id)
        {

            foreach ((Employee, Payroll) emp in emp)
            {
                if (emp.Item1.EmployeeID1 == id)
                {
                    return true;
                }
            }
            return false;

        }
        public static string GetEmployeeID(string employeeID)
        {
            foreach ((Employee, Payroll) e in emp)
            {
                if (e.Item1.EmployeeID1 == employeeID)
                {
                    return e.Item1.EmployeeID1;
                }
            }
            return null;
        }

        public static string GetDepartmentID(string employeeID)
        {
            foreach ((Employee, Payroll) emp in emp)
            {
                if (emp.Item1.EmployeeID1 == employeeID)
                {
                    return emp.Item1.DepartmentID1;
                }
            }
            return null;

        }

        public List<Employee> GetEmployeeList()
        {
            List<Employee> employeeList = new List<Employee>();

            foreach ((Employee, Payroll) e in emp)
            {
                // Lấy đối tượng Employee từ Item1 của tuple và thêm vào danh sách
                employeeList.Add(e.Item1);
            }

            return employeeList;

        }
    }
}