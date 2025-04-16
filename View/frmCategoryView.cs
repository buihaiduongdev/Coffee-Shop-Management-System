using Restaurant_Management_System.Backend;
using Restaurant_Management_System.Model;
using System;
using System.Collections;
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
    public partial class frmCategoryView : Form
    {
        public frmCategoryView()
        {
            InitializeComponent();
        }

        private void frmCategoryView_Load(object sender, EventArgs e)
        {

            //DataGridViewImageColumn imageColumn = (DataGridViewImageColumn)dgvCategory.Columns[3];
            //imageColumn.ImageLayout = DataGridViewImageCellLayout.Stretch;

            //dgvCategory.Rows[0].Cells[3].Value = Properties.Resources.store;
            LoadCategoryData();
            if (dgvCategory.RowCount <= 1) labelNumberResultFound.Text = $"{dgvCategory.RowCount.ToString()} result found";
            else labelNumberResultFound.Text = $"{dgvCategory.RowCount.ToString()} results found";
            dgvCategory.AllowUserToAddRows = false;
        }
        private void LoadCategoryData()

        {
            string query = "SELECT CategoryID, CategoryName FROM Categories WHERE IsDeleted = 0";

            try
            {
                DataTable dt = DatabaseHelper.ExecuteQuery(query); 

                dgvCategory.Rows.Clear();
                dgvCategory.DefaultCellStyle.Font = new Font("Segoe UI", 12);
                dgvCategory.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 12, FontStyle.Bold);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    dgvCategory.Rows.Add();
                    dgvCategory.Rows[i].Cells["dgvSno"].Value = i + 1; // STT
                    dgvCategory.Rows[i].Cells["dgvCategoryID"].Value = dt.Rows[i]["CategoryID"];
                    dgvCategory.Rows[i].Cells["dgvCategoryName"].Value = dt.Rows[i]["CategoryName"];
                }
                lbl_TotalNumberCategories.Text = dgvCategory.RowCount.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                        string deleteQuery = "UPDATE Categories SET IsDeleted = 1 WHERE CategoryID = @CategoryID";
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

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string searchValue = txtSearch.Text.Trim().ToLower();
            int count = 0;

            foreach (DataGridViewRow row in dgvCategory.Rows)
            {
                if (row.Cells["dgvCategoryID"].Value != null && row.Cells["dgvCategoryName"].Value != null)
                {
                    string id = row.Cells["dgvCategoryID"].Value.ToString().ToLower();
                    string name = row.Cells["dgvCategoryName"].Value.ToString().ToLower();
                    bool IsContain = id.Contains(searchValue) || name.Contains(searchValue);
                    row.Visible = IsContain;
                    if (IsContain) count++;
                }
            }
            if (count == 0) labelNumberResultFound.Text = $"Result not found";
            if (count == 1) labelNumberResultFound.Text = $"{count} result found";
            else labelNumberResultFound.Text = $"{count} results found";
        }

        private void btnAddCatagory_Click(object sender, EventArgs e)
        {
            frmCategoryAdd frm = new frmCategoryAdd(-1);
            frm.ShowDialog();
        }
    }
}
