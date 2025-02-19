using Guna.UI2.WinForms;
using Restaurant_Management_System.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Restaurant_Management_System.View
{
    public partial class frmStaffView : SampleView
    {
        public frmStaffView()
        {
            InitializeComponent();
        }

        private void frmStaffView_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'restaurantDBDataSet.Employees' table. You can move, or remove it, as needed.
            this.employeesTableAdapter.Fill(this.restaurantDBDataSet.Employees);
            //GetData();
        }

        private void guna2DataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        //public void GetData()
        //{
        //    string qry = "Select * From staff where sName like '%" + txtSearch.Text + "%'";
        //    ListBox lb = new ListBox();
        //    lb.Items.Add(dgvid);
        //    lb.Items.Add(dgvName);
        //    lb.Items.Add(dgvPhone);
        //    lb.Items.Add(dgvRole);

        //    MainClass.LoadData(qry, guna2DataGridView1, lb);
        //}
        public override void btnAdd_Click(object sender, EventArgs e)
        {
            frmStaffAdd frm = new frmStaffAdd();
            frm.ShowDialog();
            //GetData();
        }

        public override void txtSearch_TextChanged(object sender, EventArgs e)
        {
            //GetData();
        }


        //private void guna2DataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        //{

        //}

        private void guna2DataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //if (guna2DataGridView1.CurrentCell.OwningColumn.Name == "dvgedit")
            //{
            //    frmStaffAdd frm = new frmStaffAdd();
            //    frm.id = Convert.ToInt32(guna2DataGridView1.CurrentRow.Cells["dvgid"].Value);
            //    frm.txtName.Text = Convert.ToString(guna2DataGridView1.CurrentRow.Cells["dvgName"].Value);
            //    frm.txtPhone.Text = Convert.ToString(guna2DataGridView1.CurrentRow.Cells["dvgPhone"].Value);
            //    frm.cbRole.Text = Convert.ToString(guna2DataGridView1.CurrentRow.Cells["dvgRole"].Value);
            //    frm.ShowDialog();
            //    GetData();
            //}
            //if (guna2DataGridView1.CurrentCell.OwningColumn.Name == "dvgdel")
            //{
            //    //đưa ra thông báo có Xóa hay không
            //    guna2MessageDialog1.Icon = Guna.UI2.WinForms.MessageDialogIcon.Question;
            //    guna2MessageDialog1.Buttons = Guna.UI2.WinForms.MessageDialogButtons.YesNo;
            //    if (Guna2MessageDialog1.Show("Bạn có muốn xóa không?") == DialogResult.Yes)
            //    {
            //        int id = Convert.ToInt32(guna2DataGridView1.CurrentRow.Cells["dvgid"].Value);
            //        string qry = "Delete from staff where staffID= " + id + "";
            //        Hashtable ht = new Hashtable();
            //        MainClass.SQl(qry, ht);

            //        guna2MessageDialog1.Icon = Guna.UI2.WinForms.MessageDialogIcon.Information;
            //        guna2MessageDialog1.Buttons = Guna.UI2.WinForms.MessageDialogButtons.OK;
            //        guna2MessageDialog1.Show("Deleted successfully...");
            //        GetData();
            //    }
            //}
            //Chưa có file BE MainClass
        }
    }
}
