using System;
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
    public partial class frmTableAdd : SampleAdd
    {
        public frmTableAdd()
        {
            InitializeComponent();
        }
        public int id = 0;
        private void frmTableAdd_Load(object sender, EventArgs e)
        {

        }
        public override void btnSave_Click(object sender, EventArgs e)
        {
            //string qry = "";
            //if (id == 0)//Insert
            //{
            //    qry = "Insert into Table Values(@Name)";
            //}
            //else
            //{
            //    qry = "Update table Set tName = @Name where tID = @id";
            //}
            //Hashtable ht = new Hashtable();
            //ht.Add("@id", id);
            //ht.Add("@Name", txtName.Text);

            //if (MainClass.SQl(qry, ht) > 0)
            //{
            //    Guna2MessageDialog2.Show("Saved successlly...");
            //    id = 0;
            //    txtName.Text = "";
            //    txtName.Focus();
            //}
        }
        //private void label1_Click(object sender, EventArgs e)
        //{

        //}
    }
}
