using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant_Management_System.Backend
{
    public class Employee : Person
    {
        private byte[] image;
        private decimal salary;
        private string role;

        public Employee(int id, string username, string password, string lastName, string firstName, string phone,
                        byte[] image, decimal salary, string role)
            : base(id, username, password, lastName, firstName, phone)
        {
            this.image = image;
            this.salary = salary;
            this.role = role;
        }

        public byte[] Image { get => image; set => image = value; }
        public decimal Salary { get => salary; set => salary = value; }
        public string Role { get => role; set => role = value; }
    }

}
