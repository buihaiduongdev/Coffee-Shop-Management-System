using Restaurant_Management_System.Backend;
using Restaurant_Management_System.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Restaurant_Management_System.View
{
    public partial class frmProductView : SampleView
    {
        public frmProductView()
        {
            InitializeComponent();
        }

        private void frmProductView_Load(object sender, EventArgs e)
        {
            LoadProductData();
        }
        private void LoadProductData()
        {
            string query = "SELECT ProductID, ProductName, Price, CategoryName FROM Products"; 
            try
            {
                DataTable dt = DatabaseHelper.ExecuteQuery(query);

                
                dgvProduct.Rows.Clear();

                // Duyệt từng dòng dữ liệu từ DataTable và thêm vào DataGridView
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    dgvProduct.Rows.Add();
                    dgvProduct.Rows[i].Cells["dgvSno"].Value = i + 1; // STT
                    dgvProduct.Rows[i].Cells["dgvProductID"].Value = dt.Rows[i]["ProductID"];
                    dgvProduct.Rows[i].Cells["dgvProductName"].Value = dt.Rows[i]["ProductName"];
                    dgvProduct.Rows[i].Cells["dgvPrice"].Value = dt.Rows[i]["Price"];
                    dgvProduct.Rows[i].Cells["dgvCategory"].Value = dt.Rows[i]["CategoryName"];
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu sản phẩm: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAdd_Click_1(object sender, EventArgs e)
        {
            frmProductAdd frm = new frmProductAdd(-1);
            frm.ShowDialog();
            //GetData();

        }

        public override void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string searchValue = txtSearch.Text.Trim().ToLower();

            foreach (DataGridViewRow row in dgvProduct.Rows)
            {
                if (row.Cells["dgvProductID"].Value != null &&
                    row.Cells["dgvProductName"].Value != null &&
                    row.Cells["dgvCategory"].Value != null)
                {
                    string productId = row.Cells["dgvProductID"].Value.ToString().ToLower();
                    string productName = row.Cells["dgvProductName"].Value.ToString().ToLower();
                    string category = row.Cells["dgvCategory"].Value.ToString().ToLower();

                    // Kiểm tra tìm kiếm theo ID, tên sản phẩm hoặc danh mục
                    row.Visible = productId.Contains(searchValue) ||
                                  productName.Contains(searchValue) ||
                                  category.Contains(searchValue);
                }
            }
        }

        private void guna2DataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
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
            //        string qry = "Delete from products where pID= " + id + "";
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

        private void dgvProduct_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // Đảm bảo không click vào Header
            {

                if (e.ColumnIndex == dgvProduct.Columns["dgvedit"].Index)
                {
                    string productID = dgvProduct.Rows[e.RowIndex].Cells["dgvProductID"].Value.ToString();
                    int id = Convert.ToInt32(productID);

                    frmProductAdd frm = new frmProductAdd(id);
                    frm.txtProductID.Text = productID;
                    frm.txtProductID.Enabled = false;
                    frm.txtName.Text = Convert.ToString(dgvProduct.CurrentRow.Cells["dgvProductName"].Value);
                    frm.txtPrice.Text = Convert.ToString(dgvProduct.CurrentRow.Cells["dgvPrice"].Value);
                    frm.ShowDialog();
                    LoadProductData();
                }

                if (e.ColumnIndex == dgvProduct.Columns["dgvdel"].Index)
                {
                    string productID = dgvProduct.Rows[e.RowIndex].Cells["dgvProductID"].Value.ToString();
                    DialogResult result = MessageBox.Show($"Bạn có chắc muốn xóa sản phẩm {productID}?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                    if (result == DialogResult.Yes)
                    {
                        string deleteQuery = "DELETE FROM Products WHERE ProductID = @ProductID";
                        SqlParameter[] param = { new SqlParameter("@ProductID", productID) };

                        int rowsAffected = DatabaseHelper.ExecuteNonQuery(deleteQuery, param);
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show($"Đã xóa sản phẩm {productID} thành công!");
                            LoadProductData(); // Cập nhật lại danh sách sản phẩm
                        }
                        else
                        {
                            MessageBox.Show("Lỗi khi xóa sản phẩm!");
                        }
                    }
                }
            }
        }

    }
}
