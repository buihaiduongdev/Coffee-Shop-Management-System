using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Restaurant
{
    public class Chef : Person, ISalary
    {
        private int salary;

        public Chef()
        {
            throw new System.NotImplementedException();
        }

        public int Salary
        {
            get => default;
            set
            {
            }
        }

        public void ViewOrder()
        {
            throw new System.NotImplementedException();
        }

        public void SearchOrder()
        {
            throw new System.NotImplementedException();
        }

        public void TrackOrderStatus()
        {
            throw new System.NotImplementedException();
        }
    }
}