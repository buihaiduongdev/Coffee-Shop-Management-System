using Guna.UI2.WinForms;
using Restaurant_Management_System.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Restaurant_Management_System.Model
{
    public partial class frmPOS : Form
    {
        public frmPOS()
        {
            InitializeComponent();
        }

        public int MainID = 0;
        public string orderType;

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmPOS_Load(object sender, EventArgs e)
        {
            dgvPOS.BorderStyle = BorderStyle.FixedSingle;
        }

        //SYS6 23:00
        private void addCategory() { 
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            lblTable.Text = "";
            lblWaiter.Text = "";
            lblTable.Visible = false;
            lblWaiter.Visible = false;
            dgvPOS.Rows.Clear();
            MainID = 0;
            lblCost.Text = "0.00";
        }

        private void btnDelivery_Click(object sender, EventArgs e)
        {
            lblTable.Text = "";
            lblWaiter.Text = "";
            lblTable.Visible = false;
            lblWaiter.Visible = false;
            orderType = "Delivery";
        }

        private void btnTakeAway_Click(object sender, EventArgs e)
        {
            lblTable.Text = "";
            lblWaiter.Text = "";
            lblTable.Visible = false;
            lblWaiter.Visible = false;
            orderType = "Take Away";

        }

        //thieu BE de add data vao 
        private void btnDinIn_Click(object sender, EventArgs e)
        {
            //need to crate form for table selection and waier selection
            frmTableSelect frmTableSelect = new frmTableSelect();
            //MainClass.BlurBackground(frm);       
            if(frmTableSelect.tableName != "")
            {
                lblTable.Text = frmTableSelect.tableName;
                lblTable.Visible = true;
            }
            else
            {
                lblTable.Text = "";
                lblTable.Visible = false;
            }

            frmWaiterSelect frmWaiterSelect = new frmWaiterSelect();
            //MainClass.BlurBackground(frm);       
            if (frmWaiterSelect.waiterName != "")
            {
                lblTable.Text = frmWaiterSelect.waiterName;
                lblWaiter.Visible=true;
            }
            else
            {
                lblWaiter.Text = "";
                lblWaiter.Visible=false;    
            }

        }
        //cac ham BE load tu 23p den het video
        //O duoi tinh tu 1:07 cua video sys 9
        private void btnBill_Click(object sender, EventArgs e)
        {
            
        }

        private void dgvPOS_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {

        }

        private void dgvPOS_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //int count = 0;
            //foreach (DataGridViewRow row in Guna2DataGridView1.Rows)
            //{
            //    count++;
            //    row.Cells[0].Value = count;
            //}
        }

        private void btnBillList_Click(object sender, EventArgs e)
        {
            //phut 10:55 sys9
        }

        private void btnCheckout_Click(object sender, EventArgs e)
        {
            //frmCheckout frm = new frmCheckout();
            //frm.MainID = id;
            //MainID = 0;
            //dgvPOS.Rows.Clear();
            //lblTable.Text = "";
            //lblWaiter.Text = "";
            //lblTable.Visible = false;
            //lblWaiter.Visible = false;
            //lblTotal.Text = "00";
        }
        
    }
}
