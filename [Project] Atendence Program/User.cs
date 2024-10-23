using System;
using System.Collections.Generic;
using System.Text;

namespace _Project__Atendence_Program
{
    public class User
    {
        private string login_name;
        private string password;
        private string employee_ID;

        public string Login_name { get => login_name; set => login_name = value; }
        public string Password { get => password; set => password = value; }
        public string Employee_ID { get => employee_ID; set => employee_ID = value; }
        public User(string login_name, string password, string employee_ID)
        {
            this.login_name = login_name;
            this.password = password;
            this.employee_ID = employee_ID;
        }

        public bool Login(string username, string password)
        {
            if (username == Login_name && password == Password)
            {
                Console.WriteLine("Đăng nhập thành công!");
                return true;
            }
            else
            {
                Console.WriteLine("Tên đăng nhập hoặc mật khẩu không đúng.");
                return false;
            }
        }

        public void Logout()
        {



            Console.WriteLine("Đăng xuất thành công!");
        }
    }
}
