using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Restaurant
{
    public class Receptionist : Person, ISalary, ICreateReport
    {
        private int salary;

        public Receptionist()
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

        public void CreateReport()
        {
            throw new System.NotImplementedException();
        }

        public void SearchReservation()
        {
            throw new System.NotImplementedException();
        }

        public void ViewReservation()
        {
            throw new System.NotImplementedException();
        }

        public void ViewReservationInfo()
        {
            throw new System.NotImplementedException();
        }

        public void ViewPayment()
        {
            throw new System.NotImplementedException();
        }

        public void ConfirmPayment()
        {
            throw new System.NotImplementedException();
        }

        public void ConfirmReservation()
        {
            throw new System.NotImplementedException();
        }
    }
}