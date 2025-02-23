using Guna.UI2.WinForms;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Restaurant_Management_System.Model
{
    public partial class frmCheckout : SampleAdd
    {
        public frmCheckout()
        {
            InitializeComponent();
        }

        private void frmCheckout_Load(object sender, EventArgs e)
        {

        }
        public double amt;

        private void txtReceive_TextChanged(object sender, EventArgs e)
        {
            double amt = 0;
            double receipt = 0;
            double change = 0;
            double.TryParse(txtBillAmount.Text, out amt);
            double.TryParse(txtReceive.Text, out amt);

            change = amt - receipt;

            txtChange.Text = change.ToString();
        }
        public override void btnSave_Click(object sender, EventArgs e)
        {
            //string qry = @"Update tblMain set total = @total, receive @rec, change = @change,
            //            status = 'Paid' where MainID = @id";
            //Hashtable ht = new Hashtable();
            //ht.Add("@total", txtBillAmount.Text);
            //ht.Add("@rec", txtReceive);
            //ht.Add("@change", txtChange);
            //if(MainClass.SQl(qry, ht) > 0)
            //{
            //    guna22MessageDialog1.Buttons = Guna.UI2.WinForms.MessageDialogButtons.OK;
            //    guna22MessageDialog1.Show("Save successfully");
            //    this.Close();
            //}
        }
    }
}
