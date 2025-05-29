using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_KTMH
{
    public class EmployeeList
    {
        public static List<(Employee,Payroll)> emp = new List<(Employee, Payroll)>(); 
        public List<(Employee, Payroll)>GetEmployees()
        {

            return emp;
        }
        public bool Find(string id)
        {

           foreach((Employee, Payroll) emp in emp)
            {
                if (emp.Item1.EmployeeID1 == id)
                {
                    return true;
                }
            }
           return false;
            
        }
        public static string getEmployeeID(string employeeID)
        {
            foreach((Employee,Payroll) e in emp)
            {
                if (e.Item1.EmployeeID1 == employeeID)
                {
                    return e.Item1.EmployeeID1;
                }
            }
            return null;
        }
       

        public static string getDepartmentID(string employeeID)
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

     
    }
}
