using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
        //private void btnLogOut_Click(object sender, EventArgs e)
        //{
        //    Logout();
        //}

        //public void Logout()
        //{
            
        //        foreach (sForm form in Application.OpenForms)
        //        {
        //            if (form != this) // Giữ lại LoginForm hoặc MainForm
        //                form.Close();
        //        }
        //        this.Hide(); // Ẩn form hiện tại
        //        UserForm loginForm = new UserForm();
        //        loginForm.Show();
        //    Console.WriteLine("Đăng xuất thành công!");
        //}
    }
}
