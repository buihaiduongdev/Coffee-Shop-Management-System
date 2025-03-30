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
        public int TableID { get; set; }
        public int Capacity { get; set; }
        public string Status { get; set; }

        public Color GetStatusColor()
        {
            return Status == "Available" ? Color.LightGreen : Color.IndianRed;
        }

        public void ToggleStatus()
        {
            Status = Status == "Available" ? "Reserved" : "Available";
        }
    }
}
