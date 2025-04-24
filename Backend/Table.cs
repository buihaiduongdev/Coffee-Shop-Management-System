using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Restaurant_Management_System.CustomerModel
{
    public class Table
    {
        private int tableID;
        private int capacity;
        private string status;

        public Table(int tableID, int capacity, string status)
        {
            this.tableID = tableID;
            this.capacity = capacity;
            this.status = status;
        }

        public int TableID { get => tableID; set => tableID = value; }
        public int Capacity { get => capacity; set => capacity = value; }
        public string Status { get => status; set => status = value; }



        //public Color GetStatusColor()
        //{
        //    return Status == "Available" ? Color.LightGreen : Color.IndianRed;
        //}

        //public void ToggleStatus()
        //{
        //    Status = Status == "Available" ? "Reserved" : "Available";
        //}
    }
}
