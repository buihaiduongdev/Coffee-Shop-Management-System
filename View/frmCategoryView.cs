using Restaurant_Management_System.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Restaurant_Management_System.View
{
    public partial class frmCategoryView : SampleView
    {
        public frmCategoryView()
        {
            InitializeComponent();
        }
        //public void GetData()
        //{
        //    string qry = "Select * From category where catName like '%" + txtSearch.Text + "%'";
        //    ListBox lb = new ListBox();
        //    lb.Items.Add(dgvid);
        //    lb.Items.Add(dgvName);

        //    MainClass.LoadData(qry, guna2DataGridView1, lb);
        //}
        //Phần này thiếu MainClass nên t command hết
        private void frmCategoryView_Load(object sender, EventArgs e)
        {
            //GetData();
            // Đảm bảo cột 3 là kiểu DataGridViewImageColumn
            DataGridViewImageColumn imageColumn = (DataGridViewImageColumn)dgvCategory.Columns[3];
            imageColumn.ImageLayout = DataGridViewImageCellLayout.Zoom;

            // Gán ảnh vào ô
            dgvCategory.Rows[0].Cells[3].Value = Image.FromFile(@"C:\Users\DuongLapTop\source\repos\Coffee-Shop-Management-System\Resources\store.png");
        }
        public override void btnAdd_Click(object sender, EventArgs e)
        {
            frmCategoryAdd frm  = new frmCategoryAdd();
            frm.ShowDialog();
            //GetData();
        }

        public override void txtSearch_TextChanged(object sender, EventArgs e)
        {

        }
        

        private void guna2DataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void guna2DataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //if(guna2DataGridView1.CurrentCell.OwningColumn.Name == "dvgedit")
            //{
            //    frmCategoryAdd frm = new frmCategoryAdd();
            //    frm.id = Convert.ToInt32(guna2DataGridView1.CurrentRow.Cells["dvgid"].Value);
            //    frm.txtName.Text = Convert.ToString(guna2DataGridView1.CurrentRow.Cells["dvgName"].Value);
            //    frm.ShowDialog();
            //    GetData();
            //}
            //if (guna2DataGridView1.CurrentCell.OwningColumn.Name == "dvgdel")
            //{
                
            //    int id = Convert.ToInt32(guna2DataGridView1.CurrentRow.Cells["dvgid"].Value);
            //    string qry = "Delete from category where catID= " + id + "";
            //    Hashtable ht = new Hashtable();
            //    MainClass.SQl(qry, ht);

            //    MessageBox.Show("Deleted successfully...");
            //    GetData();
            //}
            //Chưa có file BE MainClass

        }
       
    }
}
