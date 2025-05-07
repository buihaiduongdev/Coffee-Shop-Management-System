using Restaurant_Management_System.Backend;
using Restaurant_Management_System.Customer;
using Restaurant_Management_System.CustomerModel;
using Restaurant_Management_System.Model;
using Restaurant_Management_System.Setting;
using Restaurant_Management_System.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Restaurant_Management_System
{
    public partial class frmMainEmployee : Form
    {
        int EmployeeID;
        Employee emp;

        public frmMainEmployee(Employee emp)
        {
            InitializeComponent();
            EmployeeID = emp.ID;
            this.emp = emp;
        }
        
        public void AddControls(Form form)
        {
            centerPanel.Controls.Clear();
            form.TopLevel = false;
            centerPanel.Controls.Add(form);
            form.Dock = DockStyle.Fill;
            form.Show();
        }

        private void btnMenu_Click(object sender, EventArgs e)
        {
            AddControls(new frmMenu(emp));
        }

        private void btnSetting_Click(object sender, EventArgs e)
        {
            AddControls(new frmSettingView(EmployeeID));
        }

        private void btnBillList_Click(object sender, EventArgs e)
        {
            AddControls(new frmBillList(EmployeeID));
        }

        private void btnTable_Click(object sender, EventArgs e)
        {
            AddControls(new frmReserveTable());
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.Hide();

            frmLoginRegister loginForm = new frmLoginRegister();
            loginForm.Show();

            this.Close();
        }
    }
}
