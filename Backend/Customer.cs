using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Restaurant
{
    public class Customer : Person, ISearchFood, ISearchReservation
    {
        private int rank;

        public Customer()
        {
            throw new System.NotImplementedException();
        }

        public int Rank
        {
            get => default;
            set
            {
            }
        }

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
    }
}