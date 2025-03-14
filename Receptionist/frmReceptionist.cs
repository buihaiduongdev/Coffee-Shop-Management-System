using Restaurant_Management_System.Model;
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
        public frmReceptionist()
        {
            InitializeComponent();
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
            frmTableView frm = new frmTableView();
            frm.btnAdd.Visible = false;
            AddControls(frm);
        }


        private void btnBillList_Click(object sender, EventArgs e)
        {
            frmBillList frm = new frmBillList();    
            frm.btnAdd.Visible = false;
            AddControls(frm);
        }
    }
}
