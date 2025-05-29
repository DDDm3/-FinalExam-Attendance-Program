using System;
using System.Collections.Generic;
using System.Text;

namespace Project_KTMH
{
    public class Role
    {
        private string roleID;
        private string roleName;
        private string permission;
        public bool checkExist = false;

        public Role(string roleID, string roleName, string permission)
        {
            this.roleID = roleID;
            this.roleName = roleName;
            this.permission = permission;
        }

        public string CheckRoleID(List<Employee> employee, List<Role> role)
        {
            Console.Write("Nhap ma chuc vu ");
            string x = Console.ReadLine();
            foreach (Employee emp in employee)
            {
                foreach (Role role1 in role)
                {
                    if (emp.EmployeeID() == role1.roleID)
                    {
                        return role1.roleName;
                    }
                }
            }
            return "Mã chức vụ không tồn tại";
        }

        public void AddPermission()
        {

        }

        public void RemovePermission()
        {

        }

        public void UpdatePermission()
        {

        }

    }
}
