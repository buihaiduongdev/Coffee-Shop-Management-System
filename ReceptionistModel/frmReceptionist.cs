using Restaurant_Management_System.Backend;
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

namespace Restaurant_Management_System.Receptionist
{
    public partial class frmReceptionist : Form
    {
        private Employee receptionist;
        private int receptionistID;
        public frmReceptionist(Employee emp)
        {
            InitializeComponent();
            receptionist = emp;
            receptionistID = receptionist.ID;
        }
        public void AddControls(Form form)
        {
            centerPanel.Controls.Clear();
            form.TopLevel = false;
            centerPanel.Controls.Add(form);
            form.Dock = DockStyle.Fill;
            form.Show();
        }

        private void btnTable_Click(object sender, EventArgs e)
        {
            AddControls(new frmTableViews());
        }


        private void btnBillList_Click(object sender, EventArgs e)
        {
            frmBillList frm = new frmBillList(receptionistID);    
            frm.btnAdd.Visible = false;
            AddControls(frm);
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnLogout_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSetting_Click(object sender, EventArgs e)
        {
            AddControls(new frmSettingView(receptionistID));
        }
    }
}
