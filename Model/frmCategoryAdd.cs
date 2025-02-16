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
    public partial class frmCategoryAdd :SampleAdd
    {
        public frmCategoryAdd()
        {
            InitializeComponent();
        
            //btnSave.Enabled = true;
            //btnClose.Enabled = true;

        }

        private void frmCategoryAdd_Load(object sender, EventArgs e)
        {
            btnSave.Click += btnSave_Click;
            btnClose.Click += btnClose_Click;
        }
        public int id = 0;

        public override void btnSave_Click(object sender, EventArgs e)
        {
            //string qry = "";
            //if (id == 0)//Insert
            //{
            //    qry = "Insert into category Values(@Name)";
            //}
            //else 
            //{
            //    qry = "Update category Set catName = @Name where catID = @id";
            //}
            //Hashtable ht = new Hashtable();
            //ht.Add("@id", id);
            //ht.Add("@Name", txtName.Text);

            //if(MainClass.SQl(qry, ht) > 0)
            //{
            //    MessageBox.Show("Saved successlly...");
            //    id = 0;
            //  txtName.Text = "";
            //    txtName.Focus();
            //}
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
