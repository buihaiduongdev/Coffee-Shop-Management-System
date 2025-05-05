using Restaurant_Management_System.Backend;
using Restaurant_Management_System.Barista;
using Restaurant_Management_System.Customer;
using Restaurant_Management_System.CustomerModel;
using Restaurant_Management_System.Receptionist;
using Restaurant_Management_System.View;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Restaurant_Management_System
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmLoginRegister());
        }
    }
}
