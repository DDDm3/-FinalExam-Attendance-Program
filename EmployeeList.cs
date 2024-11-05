﻿
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_KTMH
{
    public class EmployeeList
    {


        public static List<(Employee, Payroll)> emp = new List<(Employee, Payroll)>();
        public List<(Employee, Payroll)> GetEmployees()
        {
            return emp;
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

        public void AddEmployee(Employee employee, Payroll payroll) 
        {
            emp.Add((employee, payroll));
        }

        public bool removeEmployee(string employeeID)
        {
            for (int i = 0; i< emp.Count; i++)
            {
                if (emp[i].Item1.EmployeeID1 == employeeID)
                {
                    emp.RemoveAt(i);
                    return true;
                }    
            }
            return false;
        }


    }
}