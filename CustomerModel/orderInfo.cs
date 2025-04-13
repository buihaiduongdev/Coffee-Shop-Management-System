using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant_Management_System.CustomerModel
{
    public class orderInfo
    {
        private int orderID;
        private string status;
        private DateTime orderdate;

        public orderInfo(int orderID, string status, DateTime orderdate)
        {
            this.orderID = orderID;
            this.status = status;
            this.orderdate = orderdate;

        }
        public orderInfo() { }
        public int OrderID { get => orderID; set => orderID = value; }
        public string Status { get => status; set => status = value; }
        public DateTime Orderdate { get => orderdate; set => orderdate = value; }
    }
}
