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
        private string language = ucLogin.languages;
        public frmCategoryView()
        {
            InitializeComponent();
        }

        private void frmCategoryView_Load(object sender, EventArgs e)
        {
            ApplyCustomTheme();
            LoadCategoryData();
            load_language(language);
            if (dgvCategory.RowCount <= 1)
            {
                if (language == "en") labelNumberResultFound.Text = $"{dgvCategory.RowCount.ToString()} result found";
                else labelNumberResultFound.Text = $"{dgvCategory.RowCount.ToString()} tìm thấy kết quả";
            }
            else
            {
                if (language == "en") labelNumberResultFound.Text = $"{dgvCategory.RowCount.ToString()} results found";
                else labelNumberResultFound.Text = $"{dgvCategory.RowCount.ToString()} kết quả tìm thấy";
            }
            dgvCategory.AllowUserToAddRows = false;
        }
        private void ApplyCustomTheme()
        {
            // Xóa theme mặc định
            dgvCategory.Theme = Guna.UI2.WinForms.Enums.DataGridViewPresetThemes.Default;
            dgvCategory.EnableHeadersVisualStyles = false;

            // Header
            dgvCategory.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(102, 99, 76);
            dgvCategory.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvCategory.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            dgvCategory.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvCategory.Columns["dgvCategoryID"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgvCategory.Columns["dgvSno"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgvCategory.ColumnHeadersHeight = 40;

            // Dòng thường
            dgvCategory.DefaultCellStyle.BackColor = Color.FromArgb(165, 140, 100); // Be sáng
            dgvCategory.DefaultCellStyle.ForeColor = Color.Black;
            dgvCategory.DefaultCellStyle.Font = new Font("Segoe UI", 10);
            dgvCategory.DefaultCellStyle.SelectionBackColor = Color.FromArgb(224, 224, 224); // Nâu vừa
            dgvCategory.DefaultCellStyle.SelectionForeColor = Color.Black;
            dgvCategory.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            // Dòng xen kẽ
            dgvCategory.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(204, 177, 142); // Xám nhạt  

            // Bảng
            //dgvCategory.BackgroundColor = Color.AntiqueWhite;
            dgvCategory.BorderStyle = BorderStyle.None;
            dgvCategory.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvCategory.RowTemplate.Height = 35;

            // Khác
            dgvCategory.ReadOnly = false;
            dgvCategory.AllowUserToAddRows = false;
            dgvCategory.AllowUserToResizeRows = false;
            dgvCategory.EditMode = DataGridViewEditMode.EditOnKeystrokeOrF2;
            dgvCategory.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
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
                if (language == "en") MessageBox.Show("Error loading data: " + ex.Message, "Erorr", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else MessageBox.Show("Lỗi khi tải dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    DialogResult result = language == "en" ? MessageBox.Show($"Are you wish to delete the category {categoryID}?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) : MessageBox.Show($"Bạn có chắc muốn xóa danh mục {categoryID}?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (result == DialogResult.Yes)
                    {
                        string deleteQuery = "UPDATE Categories SET IsDeleted = 1 WHERE CategoryID = @CategoryID";
                        SqlParameter[] param = { new SqlParameter("@CategoryID", categoryID) };

                        int rowsAffected = DatabaseHelper.ExecuteNonQuery(deleteQuery, param);
                        if (rowsAffected > 0)
                        {
                            if (language == "en") MessageBox.Show($"Category {categoryID} has been deleted successfully!");
                            else MessageBox.Show($"Đã xóa danh mục {categoryID} thành công!");
                            LoadCategoryData();
                        }
                        else
                        {
                            if (language == "en") MessageBox.Show("Error deleting category!");
                            else MessageBox.Show("Lỗi khi xóa danh mục!");
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
            if (count == 0) labelNumberResultFound.Text = language == "en" ? $"Result not found" : "Không tìm thấy kết quả";
            if (count == 1) labelNumberResultFound.Text = language == "en" ? $"{count} result found" : $"{count} kết quả tìm thấy";
            else labelNumberResultFound.Text = language == "en" ? $"{count} results found" : $"{count} kết quả tìm thấy";
            dgvCategory.AllowUserToAddRows = false;
        }

        private void btnAddCatagory_Click(object sender, EventArgs e)
        {
            frmCategoryAdd frm = new frmCategoryAdd(-1);
            frm.ShowDialog();
        }
        private void load_language(string languages)
        {
            LocalizationHelper.SetLanguage(languages);
            btnAddCategory.Text = LocalizationHelper.GetString("btnAddCategory");
            lblCategory.Text = LocalizationHelper.GetString("lblCategory"); 
            lblTotalCategories.Text = LocalizationHelper.GetString("lblTotalCategories");
            txtSearch.PlaceholderText = LocalizationHelper.GetString("txtSearch");
            dgvCategory.Columns["dgvCategoryName"].HeaderText = LocalizationHelper.GetString("dgvCategoryName");
            dgvCategory.Columns["dgvedit"].HeaderText = LocalizationHelper.GetString("dgvedit");
            dgvCategory.Columns["dgvdel"].HeaderText = LocalizationHelper.GetString("dgvdel");
        }
    }
}
