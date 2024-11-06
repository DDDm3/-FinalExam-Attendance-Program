using System;
using System.Collections.Generic;
using System.Text;

namespace Project_KTMH
{
    public abstract class Person
    {
        private string name;
        private string email;
        private DateTime dateOfBirth;
        private string phone_num;
        private string address;

        public string Name { get; private set; }
        public string Email { get; private set; }
        public DateTime DateOfBirth { get; private set; }
        public string Phone_num { get; set; }
        public string Address { get; set; }

        public int Age
        {
            get
            {
                return DateTime.Now.Year - DateOfBirth.Year;
            }
        }

        protected Person(string name, string email, DateTime dateofbirth, string phone_num, string address)
        {
            this.Name = name;
            this.Email = email;
            this.DateOfBirth = dateofbirth;
            this.Phone_num = phone_num;
            this.Address = address;
        }
        public void UpdateContactInfo(string phone_num, string address)
        {
            Phone_num = phone_num;
            Address = address;
        }

        public void UpdatePersonalDetails(string name, string email, DateTime dateOfBirth)
        {
            this.Name = name;
            this.Email = email;
            this.DateOfBirth = dateOfBirth;
        }
    }
}