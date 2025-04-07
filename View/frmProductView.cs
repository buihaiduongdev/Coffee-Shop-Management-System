using Restaurant_Management_System.Backend;
using Restaurant_Management_System.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Restaurant_Management_System.View
{
    public partial class frmProductView : Form
    {
        public frmProductView()
        {
            InitializeComponent();
        }
        private DataTable dt;

        private void frmProductView_Load(object sender, EventArgs e)
        {
            LoadProductData();
        }
        private void LoadProductData()
        {
            string query = "SELECT ProductID, ProductName, Price, CategoryName, Image FROM Products WHERE IsDeleted = 0";
            List<string> Categories = new List<string> { "Category" };
            try
            {
                dt = DatabaseHelper.ExecuteQuery(query);
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
                    if (!Categories.Contains(dt.Rows[i]["CategoryName"]))
                    {
                        Categories.Add(dt.Rows[i]["CategoryName"].ToString());
                    }
                }
                int count = dgvProduct.RowCount;
                if (count == 0) labelNumberResultFound.Text = $"Result not found";
                if (count == 1) labelNumberResultFound.Text = $"{count} result found";
                else labelNumberResultFound.Text = $"{count} results found";
                dgvProduct.AllowUserToAddRows = false;
                cbbCategories.DataSource = Categories;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu sản phẩm: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
                    frm.txtName.Text = Convert.ToString(dgvProduct.CurrentRow.Cells["dgvProductName"].Value);
                    frm.txtPrice.Text = Convert.ToString(dgvProduct.CurrentRow.Cells["dgvPrice"].Value);
                    frm.picImage.Image = ConvertByteArrayToImage((byte[])dt.Rows[e.RowIndex]["Image"]);
                    frm.ShowDialog();
                    LoadProductData();
                }

                if (e.ColumnIndex == dgvProduct.Columns["dgvdel"].Index)
                {
                    string productID = dgvProduct.Rows[e.RowIndex].Cells["dgvProductID"].Value.ToString();
                    DialogResult result = MessageBox.Show($"Bạn có chắc muốn xóa sản phẩm {productID}?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                    if (result == DialogResult.Yes)
                    {
                        string deleteQuery = "UPDATE Products SET IsDeleted = 1 WHERE ProductID = @ProductID";
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

        private Image ConvertByteArrayToImage(byte[] ByteArray)
        {
            using (MemoryStream ms = new MemoryStream(ByteArray))
            {
                return Image.FromStream(ms);
            }
        }

        private void btnAddProduct_Click(object sender, EventArgs e)
        {
            frmProductAdd frm = new frmProductAdd(-1);
            frm.ShowDialog();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            int count = 0;
            string searchValue = txtSearch.Text.Trim().ToLower();
            foreach (DataGridViewRow row in dgvProduct.Rows)
            {
                if (row.Cells["dgvProductID"].Value != null && row.Cells["dgvProductName"].Value != null && row.Cells["dgvCategory"].Value != null)
                {
                    string productId = row.Cells["dgvProductID"].Value.ToString().ToLower();
                    string productName = row.Cells["dgvProductName"].Value.ToString().ToLower();
                    string productCatagory = row.Cells["dgvCategory"].Value.ToString().ToLower();
                    bool isContain = productId.Contains(searchValue) || productName.Contains(searchValue) || productCatagory.Contains(searchValue);
                    row.Visible = isContain;
                    if (isContain) count++;
                }
            }
            if (count == 0) labelNumberResultFound.Text = $"Result not found";
            if (count == 1) labelNumberResultFound.Text = $"{count} result found";
            else labelNumberResultFound.Text = $"{count} results found";
        }

        private void cbbCategories_SelectedIndexChanged(object sender, EventArgs e)
        {
            string filterValue = cbbCategories.Text;
            if (filterValue == "Category")
            {
                cbbCategories.SelectedText = "Category";
                cbbCategories.ForeColor = Color.Gray;
                LoadProductData();
            }
            else
            {
                cbbCategories.ForeColor = Color.Black;
                string query = $"SELECT * FROM Products WHERE CategoryName = N'{filterValue}'";
                try
                {
                    dt = DatabaseHelper.ExecuteQuery(query);
                    dgvProduct.Rows.Clear();
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        dgvProduct.Rows.Add();
                        dgvProduct.Rows[i].Cells["dgvSno"].Value = i + 1;
                        dgvProduct.Rows[i].Cells["dgvProductID"].Value = dt.Rows[i]["ProductID"];
                        dgvProduct.Rows[i].Cells["dgvProductName"].Value = dt.Rows[i]["ProductName"];
                        dgvProduct.Rows[i].Cells["dgvPrice"].Value = dt.Rows[i]["Price"];
                        dgvProduct.Rows[i].Cells["dgvCategory"].Value = dt.Rows[i]["CategoryName"];
                    }
                    int count = dgvProduct.RowCount;
                    if (count == 0) labelNumberResultFound.Text = $"Result not found";
                    if (count == 1) labelNumberResultFound.Text = $"{count} result found";
                    else labelNumberResultFound.Text = $"{count} results found";
                    dgvProduct.AllowUserToAddRows = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi tải dữ liệu sản phẩm: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
