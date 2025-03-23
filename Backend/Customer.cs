using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Restaurant_Management_System.Backend
{
    public class CustomerInfo : Person
    {
        private byte[] image;
        private string rank ;

        public CustomerInfo(int id, string username, string password, string lastName, string firstName, string phone,
                        byte[] image, string rank)
            : base(id, username, password, lastName, firstName, phone)
        {
            this.image = image;
            this.rank = rank;
        }

        public byte[] Image { get => image; set => image = value; }
        public string Rank { get => rank; set => rank = value; }

        public void ViewMenu()
        {
            throw new System.NotImplementedException();
        }

        public void ViewOrderHistory()
        {
            throw new System.NotImplementedException();
        }

        public void SearchReservation()
        {
            throw new System.NotImplementedException();
        }

        public void SeachFood()
        {
            throw new System.NotImplementedException();
        }

        public void ReserveTable()
        {
            throw new System.NotImplementedException();
        }

        public void CancelTable()
        {
            throw new System.NotImplementedException();
        }

        public void SearchFood()
        {
            throw new NotImplementedException();
        }
    }
}