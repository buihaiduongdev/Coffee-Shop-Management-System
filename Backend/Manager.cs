using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Restaurant
{
    public class Manager : Person, ISalary, ICreateReport, ISearchFood, ISearchReservation
    {
        private int salary;

        public Manager()
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

        public void SearchEmployee()
        {
            throw new System.NotImplementedException();
        }

        public void SearchFood()
        {
            throw new System.NotImplementedException();
        }

        public void SearchFeedBack()
        {
            throw new System.NotImplementedException();
        }

        public void SearchReservation()
        {
            throw new NotImplementedException();
        }
    }
}