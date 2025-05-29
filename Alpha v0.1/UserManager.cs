using System;
using System.Collections.Generic;

namespace Project_KTMH
{
    public class UserManager
    {
        private static UserManager instance;
        private List<User> users;

        private UserManager()
        {
            users = new List<User>();
        }
        public static UserManager Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new UserManager();
                }
                return instance;
            }
        }
        public void AddUser(User user)
        {
            users.Add(user);
        }
        public List<User> GetUsers()
        {
            return users;
        }
        public bool Login(string username, string password)
        {
            foreach (User user in users)
            {
                if (user.Login(username, password))
                {
                    return true;
                }
            }
            Console.WriteLine("Tên đăng nhập hoặc mật khẩu không đúng.");
            return false;
        }
    }
}
