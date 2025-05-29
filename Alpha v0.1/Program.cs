using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project_KTMH
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Attendance attendance = new Attendance(DateTime.Now, TimeSpan.Zero, false,"", TimeSpan.Zero, false, TimeSpan.Zero);
            
            Employee nv1 = new Employee("Nam", "namcty@ueh.edu", new DateTime(), "097373737", "12/9 NVL", "nv001", "it001i", "it", "nhan vien");
            Payroll payroll = new Payroll("PRnv1", "it", "nv001", "Nam", 1, 1, 1, 1, 1);
            EmployeeList employeeList = new EmployeeList();
            nv1.CreateUser();

            employeeList.AddEmployee(nv1, payroll);
            attendance.CreateDailyRecord(employeeList.GetEmployeeList());
            
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new UserForm());

            
            //namnv001
        }
    }
}
