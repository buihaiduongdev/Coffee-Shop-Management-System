using Restaurant_Management_System.Backend;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Restaurant_Management_System.Model
{
    public partial class frmCategoryAdd :Form
    {
        public frmCategoryAdd(int categoryID)
        {
            InitializeComponent();
            CategoryID = categoryID;
            pbHeaderIcon.Image = Properties.Resources.Categories;
        }
        int CategoryID;
        private void InsertCategory()
        {
            string query = "SELECT MAX(CategoryID) FROM Categories";
            object result = DatabaseHelper.ExecuteScalar(query);
            int categoryID = (result == DBNull.Value || result == null) ? 1 : Convert.ToInt32(result) + 1; // Bắt đầu từ 1 nếu bảng trống
            string categoryName = txtCategoryName.Text.Trim();

            string query2 = "INSERT INTO Categories (CategoryID, CategoryName) VALUES (@CategoryID, @CategoryName)";

            if (string.IsNullOrEmpty(categoryName))
            {
                throw new ArgumentNullException("Lỗi nhập liệu! Vui lòng điền đầy đủ thông tin");
            }

            SqlParameter[] parameters = {
                new SqlParameter("@CategoryID", categoryID),
                new SqlParameter("@CategoryName", categoryName)
            };


            int rowsAffected = DatabaseHelper.ExecuteNonQuery(query2, parameters);

            if (rowsAffected > 0)
            {
                MessageBox.Show("Thêm danh mục thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtCategoryName.Clear();
            }
            else
            {
                MessageBox.Show("Thêm danh mục thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdateCategory(int CategoryID)
        {
                string categoryName = txtCategoryName.Text.Trim();

                if (string.IsNullOrEmpty(categoryName))
                {
                    throw new ArgumentNullException("Lỗi nhập liệu! Vui lòng điền đầy đủ thông tin");

                }

            string queryUpdate = "UPDATE Categories SET CategoryName = @CategoryName WHERE CategoryID = @CategoryID";

                SqlParameter[] parameters = {
            new SqlParameter("@CategoryID", CategoryID),
            new SqlParameter("@CategoryName", categoryName)
        };

                int rowsAffected = DatabaseHelper.ExecuteNonQuery(queryUpdate, parameters);

                if (rowsAffected > 0)
                {
                    MessageBox.Show("Danh mục đã được cập nhật thành công!", "Notification");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Không có thay đổi nào được thực hiện.", "Notification");
                }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            bool AddCategory = false;
            try
            {
                if (CategoryID == -1)
                {
                    AddCategory = true;
                    InsertCategory();
                    this.Close();
                }
                else
                {
                    UpdateCategory(CategoryID);
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                if (AddCategory) MessageBox.Show("Lỗi thêm danh mục: " + ex.Message, "Notification");
                else MessageBox.Show("Lỗi cập nhật danh mục: " + ex.Message, "Notification");
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
