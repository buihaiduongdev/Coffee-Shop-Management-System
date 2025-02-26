using Restaurant_Management_System.Backend;
using Restaurant_Management_System.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
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

        private void frmCategoryView_Load(object sender, EventArgs e)
        {

            DataGridViewImageColumn imageColumn = (DataGridViewImageColumn)dgvCategory.Columns[3];
            imageColumn.ImageLayout = DataGridViewImageCellLayout.Zoom;

            dgvCategory.Rows[0].Cells[3].Value = Properties.Resources.store;
            LoadCategoryData();
        }
        public override void btnAdd_Click(object sender, EventArgs e)
        {
            frmCategoryAdd frm  = new frmCategoryAdd(-1);
            frm.ShowDialog();
            LoadCategoryData();
        }

        private void LoadCategoryData()

        {
            string query = "SELECT CategoryID, CategoryName FROM Categories";

            try
            {
                DataTable dt = DatabaseHelper.ExecuteQuery(query); 

                dgvCategory.Rows.Clear();

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    dgvCategory.Rows.Add();
                    dgvCategory.Rows[i].Cells["dgvSno"].Value = i + 1; // STT
                    dgvCategory.Rows[i].Cells["dgvCategoryID"].Value = dt.Rows[i]["CategoryID"];
                    dgvCategory.Rows[i].Cells["dgvCategoryName"].Value = dt.Rows[i]["CategoryName"];
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public override void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string searchValue = txtSearch.Text.Trim().ToLower();

            foreach (DataGridViewRow row in dgvCategory.Rows)
            {
                if (row.Cells["dgvCategoryID"].Value != null && row.Cells["dgvCategoryName"].Value != null)
                {
                    string id = row.Cells["dgvCategoryID"].Value.ToString().ToLower();
                    string name = row.Cells["dgvCategoryName"].Value.ToString().ToLower();

                    // Nếu ID hoặc Name chứa chuỗi tìm kiếm thì hiển thị, ngược lại ẩn
                    row.Visible = id.Contains(searchValue) || name.Contains(searchValue);
                }
            }
        }

        private void dgvCategory_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) 
            {
                if (e.ColumnIndex == dgvCategory.Columns["dgvedit"].Index)
                {
                    string categoryID = dgvCategory.Rows[e.RowIndex].Cells["dgvCategoryID"].Value.ToString();
                    int id = Convert.ToInt32(categoryID);
                    frmCategoryAdd frm = new frmCategoryAdd(id);
     
                    frm.txtCategoryName.Text = Convert.ToString(dgvCategory.CurrentRow.Cells["dgvCategoryName"].Value);
                    frm.ShowDialog();
                    LoadCategoryData(); 
                }


                if (e.ColumnIndex == dgvCategory.Columns["dgvdel"].Index)
                {
                    string categoryID = dgvCategory.Rows[e.RowIndex].Cells["dgvCategoryID"].Value.ToString();
                    DialogResult result = MessageBox.Show($"Bạn có chắc muốn xóa danh mục {categoryID}?",
                                                          "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                    if (result == DialogResult.Yes)
                    {
                        string deleteQuery = "DELETE FROM Categories WHERE CategoryID = @CategoryID";
                        SqlParameter[] param = { new SqlParameter("@CategoryID", categoryID) };

                        int rowsAffected = DatabaseHelper.ExecuteNonQuery(deleteQuery, param);
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show($"Đã xóa danh mục {categoryID} thành công!");
                            LoadCategoryData();
                        }
                        else
                        {
                            MessageBox.Show("Lỗi khi xóa danh mục!");
                        }
                    }
                }
            }
        }

    }
}
