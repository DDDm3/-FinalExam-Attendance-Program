using System;

namespace Project_KTMH
{
    public class User
    {
        private string login_name;
        private string password;

        public string Login_name { get => login_name; set => login_name = value; }
        public string Password { get => password; set => password = value; }

        public User(string loginname, string password)
        {
            this.login_name = loginname;
            this.password = password;
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
    }
}