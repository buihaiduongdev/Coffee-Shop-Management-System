using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Restaurant_Management_System
{
    public class Person
    {
        private int id;
        private string username;
        private string password;
        private string lastName;
        private string firstName;
        private string phone;

        public Person(int id, string username, string password, string lastName, string firstName, string phone)
        {
            this.id = id;
            this.username = username;
            this.password = password; 
            this.lastName = lastName;
            this.firstName = firstName;
            this.phone = phone;
        }

        public int ID  { get => id; set => id = value; }
        public string Username { get => username; set => username = value; }
        public string Password { get => password; set => password = value; }
        public string LastName { get => lastName; set => lastName = value; }
        public string FirstName { get => firstName; set => firstName = value; }
        public string Phone { get => phone; set => phone = value; }
    }
}